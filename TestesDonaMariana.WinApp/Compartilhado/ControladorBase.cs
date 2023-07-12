using FluentResults;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.Compartilhado;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.Compartilhado
{
    public abstract class ControladorBase<TEntidade, TRepositorio, TServico, TTabela, TTela, TRepositorio2, TRepositorio3> : IControladorBase
        where TEntidade : Entidade<TEntidade>, new()
        where TServico : ServicoBase<TEntidade, TRepositorio>
        where TRepositorio : RepositorioBaseSql<TEntidade>
        where TTabela : ITabelaBase<TEntidade>, new()
        where TTela : ITelaBase<TEntidade>, new()
    {
        protected TServico _servico;
        protected TRepositorio _repositorio;
        protected TRepositorio2 _repositorio2;
        protected TRepositorio3 _repositorio3;
        protected TTabela _tabela;

        protected event Action<TTela, TEntidade> onComandosAdicionaisAddAndEdit;

        protected event Predicate<TEntidade> onValidarRelacaoExistente;

        public ControladorBase()
        {

        }

        public ControladorBase(TRepositorio _repositorio, TServico _servico, TTabela _tabela)
        {
            this._repositorio = _repositorio;
            this._servico = _servico;
            this._tabela = _tabela;
        }

        public ControladorBase(TRepositorio _repositorio, TServico _servico, TTabela _tabela, TRepositorio2 _repositorio2)
        {
            this._repositorio = _repositorio;
            this._servico = _servico;
            this._tabela = _tabela;
            this._repositorio2 = _repositorio2;
        }

        public ControladorBase(TRepositorio _repositorio, TServico _servico, TTabela _tabela, TRepositorio2 _repositorio2, TRepositorio3 _repositorio3)
        {
            this._repositorio = _repositorio;
            this._servico = _servico;
            this._tabela = _tabela;
            this._repositorio2 = _repositorio2;
            this._repositorio3 = _repositorio3;
        }

        public virtual string ToolTipAdicionar => $"Adicionar {typeof(TEntidade).Name}";
        public virtual string ToolTipEditar => $"Editar {typeof(TEntidade).Name} existente";
        public virtual string ToolTipExcluir => $"Excluir {typeof(TEntidade).Name} existente";

        public virtual void Adicionar()
        {
            TTela tela = new();

            onComandosAdicionaisAddAndEdit?.Invoke(tela, tela.Entidade);

            tela.onGravarRegistro += _servico.Adicionar;

            TelaPrincipalForm.AtualizarStatus($"Cadastrando {typeof(TEntidade).Name}");

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarRegistros();
        }

        public virtual void Editar()
        {
            TEntidade? entidade = _tabela.ObterRegistroSelecionado();

            TTela tela = new();

            onComandosAdicionaisAddAndEdit?.Invoke(tela, entidade);

            tela.Entidade = entidade;

            tela.onGravarRegistro += _servico.Editar;

            TelaPrincipalForm.AtualizarStatus($"Editando {typeof(TEntidade).Name}");

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarRegistros();
        }

        public virtual void Excluir()
        {
            TEntidade? entidade = _tabela.ObterRegistroSelecionado();

            TelaPrincipalForm.AtualizarStatus($"Excluindo {typeof(TEntidade).Name}");

            if (MessageBox.Show($"Deseja mesmo excluir?", $"Exclusão de {typeof(TEntidade).Name}",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Result resultado = _servico.Excluir(entidade);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message,
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                else
                    CarregarRegistros();
            }
        }

        public virtual void Filtrar() { }

        public virtual void MostrarDetalhesTeste() { }

        public virtual void DuplicarTeste() { }

        public virtual void GerarPdf() { }

        public virtual void CarregarRegistros()
        {
            _tabela.AtualizarLista(_repositorio.ObterListaRegistros());
        }

        public virtual string ObterTipoCadastro()
        {
            string nomeEntidade = typeof(TEntidade).Name;

            if (nomeEntidade.EndsWith("ao"))
            {
                nomeEntidade = nomeEntidade.Remove(nomeEntidade.Length - 2);
                return $"Cadastro de {nomeEntidade}ões";
            }
            else
            {
                return $"Cadastro de {nomeEntidade}s";
            }
        }

        public abstract UserControl ObterListagem();

        public virtual void CarregarDetalhesTeste() { }
    }
}
