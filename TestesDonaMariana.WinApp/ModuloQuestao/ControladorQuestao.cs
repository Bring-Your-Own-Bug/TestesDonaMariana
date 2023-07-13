﻿using TestesDonaMariana.Aplicacao.ModuloMateria;
using TestesDonaMariana.Aplicacao.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase<Questao, RepositorioQuestao, ServicoQuestao, TabelaQuestaoControl, TelaQuestaoForm, RepositorioMateria, RepositorioDisciplina>
    {
        private readonly TabelaQuestaoControl _tabelaQuestao;

        private readonly RepositorioMateria _repositorioMateria;
        private readonly RepositorioDisciplina _repositorioDisciplina;
        private readonly ServicoQuestao _servicoQuestao;

        public ControladorQuestao(RepositorioQuestao _repositorio, ServicoQuestao _servico, TabelaQuestaoControl _tabela, RepositorioMateria _repositorio2, RepositorioDisciplina _repositorio3) : base(_repositorio, _servico, _tabela, _repositorio2, _repositorio3)
        {
            _tabelaQuestao = _tabela;
            _servicoQuestao = _servico;
            _repositorioMateria = _repositorio2;
            _repositorioDisciplina = _repositorio3;

            onComandosAdicionaisAddAndEdit += CarregarComboBox;
        }

        public override TabelaQuestaoControl ObterListagem()
        {
            return _tabelaQuestao;
        }

        private void CarregarComboBox(TelaQuestaoForm telaQuestao, Questao questao)
        {
            telaQuestao.txtMateria.DisplayMember = "NomeSerie";
            telaQuestao.txtMateria.ValueMember = "NomeSerie";
            telaQuestao.txtMateria.DataSource = _repositorioMateria.ObterListaRegistros();

            telaQuestao.txtDisciplina.DisplayMember = "Nome";
            telaQuestao.txtDisciplina.ValueMember = "Nome";
            telaQuestao.txtDisciplina.DataSource = _repositorioDisciplina.ObterListaRegistros();
        }
    }
}
