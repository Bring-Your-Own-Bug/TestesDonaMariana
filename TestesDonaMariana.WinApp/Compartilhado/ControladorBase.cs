using System.Diagnostics;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloGabarito;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;


namespace TestesDonaMariana.WinApp.Compartilhado
{
    public abstract class ControladorBase<TEntidade, TTabela, TTela> : IControladorBase
        where TEntidade : Entidade<TEntidade>, new()
        where TTabela : ITabelaBase<TEntidade>, new()
        where TTela : ITelaBase<TEntidade>, new()
    {
        protected IRepositorio<Disciplina> _repositorioDisciplina;
        protected IRepositorio<Materia> _repositorioMateria;
        protected IRepositorio<Questao> _repositorioQuestao;
        protected IRepositorio<Teste> _repositorioTeste;
        protected IRepositorio<Gabarito> _repositorioGabarito;
        protected TTabela _tabela;

        protected event Action<TTela> onCarregarArquivosEComandos;

        protected event Action<TEntidade> onAtualizarItensReferentes;

        protected ControladorBase(IRepositorio<Disciplina> repositorioDisciplina, TTabela tabela)
        {
            this._repositorioDisciplina = repositorioDisciplina;
            this._tabela = tabela;
        }

        protected ControladorBase(IRepositorio<Gabarito> repositorioGabarito, TTabela tabela)
        {
            this._repositorioGabarito = repositorioGabarito;
            this._tabela = tabela;
        }

        protected ControladorBase(IRepositorio<Questao> repositorioQuestao, IRepositorio<Materia> repositorioMateria, TTabela tabela)
        {
            this._repositorioQuestao = repositorioQuestao;
            this._repositorioMateria = repositorioMateria;
            this._tabela = tabela;
        }

        protected ControladorBase(IRepositorio<Questao> repositorioQuestao, IRepositorio<Materia> repositorioMateria, IRepositorio<Disciplina> repositorioDisciplina, TTabela tabela)
        {
            this._repositorioDisciplina = repositorioDisciplina;
            this._repositorioMateria = repositorioMateria;
            this._repositorioQuestao = repositorioQuestao;
            this._tabela = tabela;
        }

        protected ControladorBase(IRepositorio<Teste> repositorioTeste, IRepositorio<Disciplina> repositorioDisciplina, IRepositorio<Questao> repositorioQuestao, TTabela tabela)
        {
            this._repositorioTeste = repositorioTeste;
            this._repositorioDisciplina = repositorioDisciplina;
            this._repositorioQuestao = repositorioQuestao;
            this._tabela = tabela;
        }

        public virtual string ToolTipAdicionar => $"Adicionar {typeof(TEntidade).Name}";

        public virtual string ToolTipEditar => $"Editar {typeof(TEntidade).Name} existente";

        public virtual string ToolTipExcluir => $"Excluir {typeof(TEntidade).Name} existente";

        public virtual void Adicionar()
        {
            TTela tela = new();

            if (onCarregarArquivosEComandos != null)
                onCarregarArquivosEComandos(tela);

            tela.TxtId.Text = _repositorioDisciplina.Id.ToString();

            TelaPrincipalForm.AtualizarStatus($"Cadastrando {typeof(TEntidade).Name}");

            DialogResult opcaoEscolhida = tela.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                TEntidade? entidade = tela.Entidade;

                _repositorioDisciplina.Adicionar(entidade);

            }
            CarregarRegistros();
        }

        public virtual void Editar()
        {
            TEntidade? entidade = _tabela.ObterRegistroSelecionado();

            TTela tela = new();

            if (onCarregarArquivosEComandos != null)
                onCarregarArquivosEComandos(tela);

            tela.Entidade = entidade;

            TelaPrincipalForm.AtualizarStatus($"Editando {typeof(TEntidade).Name}");

            DialogResult opcaoEscolhida = tela.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                _repositorioDisciplina.Editar(tela.Entidade);

            }
            CarregarRegistros();
        }

        public virtual void Excluir()
        {
            TEntidade? entidade = _tabela.ObterRegistroSelecionado();

            TelaPrincipalForm.AtualizarStatus($"Excluindo {typeof(TEntidade).Name}");

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja mesmo excluir?", $"Exclusão de {typeof(TEntidade).Name}",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.Yes)
            {
                _repositorioDisciplina.Excluir(entidade);

                if (onAtualizarItensReferentes != null)
                    onAtualizarItensReferentes(entidade);
            }
            CarregarRegistros();
        }

        public virtual void Filtrar() { }

        public virtual void AdicionarItens() { }

        public virtual void AtualizarStatus() { }

        public virtual void CarregarRegistros()
        {
            Stopwatch contador = Stopwatch.StartNew();
            _tabela.AtualizarLista(_repositorioDisciplina.ObterListaRegistros());
            contador.Stop();
            MessageBox.Show((contador.ElapsedMilliseconds/1000).ToString());
        }

        public virtual string ObterTipoCadastro()
        {
            if ((typeof(TEntidade).Name).EndsWith("el"))
                return $"Cadastro de {typeof(TEntidade).Name.TrimEnd('l').Replace('e', 'é')}is";
            else
                return $"Cadastro de {typeof(TEntidade).Name}s";
        }

        public abstract UserControl ObterListagem();
    }
}
