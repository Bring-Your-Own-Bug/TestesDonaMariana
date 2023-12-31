﻿using TestesDonaMariana.Dados.Compartilhado;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.WinApp.Compartilhado
{
    public abstract class ControladorBase<TEntidade, TRepositorio, TTabela, TTela, TRepositorio2, TRepositorio3> : IControladorBase
        where TEntidade : Entidade<TEntidade>, new()
        where TRepositorio : RepositorioBaseSql<TEntidade>
        where TTabela : ITabelaBase<TEntidade>, new()
        where TTela : ITelaBase<TEntidade>, new()
    {
        protected TRepositorio _repositorio;
        protected TRepositorio2 _repositorio2;
        protected TRepositorio3 _repositorio3;
        protected TTabela _tabela;

        protected event Action<TTela, TEntidade> onComandosAdicionaisAddAndEdit;

        protected event Predicate<TEntidade> onValidarRelacaoExistente;

        public ControladorBase()
        {

        }

        public ControladorBase(TRepositorio _repositorio, TTabela _tabela)
        {
            this._repositorio = _repositorio;
            this._tabela = _tabela;
        }

        public ControladorBase(TRepositorio _repositorio, TTabela _tabela, TRepositorio2 _repositorio2)
        {
            this._repositorio = _repositorio;
            this._tabela = _tabela;
            this._repositorio2 = _repositorio2;
        }

        public ControladorBase(TRepositorio _repositorio, TTabela _tabela, TRepositorio2 _repositorio2, TRepositorio3 _repositorio3)
        {
            this._repositorio = _repositorio;
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

            TelaPrincipalForm.AtualizarStatus($"Cadastrando {typeof(TEntidade).Name}");

            if (tela.ShowDialog() == DialogResult.OK)
                _repositorio.Adicionar(tela.Entidade);

            CarregarRegistros();
        }

        public virtual void Editar()
        {
            TEntidade? entidade = _tabela.ObterRegistroSelecionado();

            TTela tela = new();

            onComandosAdicionaisAddAndEdit?.Invoke(tela, entidade);

            tela.Entidade = entidade;

            TelaPrincipalForm.AtualizarStatus($"Editando {typeof(TEntidade).Name}");

            if (tela.ShowDialog() == DialogResult.OK)
                _repositorio.Editar(tela.Entidade);

            CarregarRegistros();
        }

        public virtual void Excluir()
        {
            TEntidade? entidade = _tabela.ObterRegistroSelecionado();
            TelaPrincipalForm.AtualizarStatus($"Excluindo {typeof(TEntidade).Name}");

            if (onValidarRelacaoExistente?.Invoke(entidade) ?? false)
                return;

            if (MessageBox.Show($"Deseja mesmo excluir?", $"Exclusão de {typeof(TEntidade).Name}",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                _repositorio.Excluir(entidade);

            CarregarRegistros();
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
