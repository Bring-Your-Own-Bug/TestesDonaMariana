﻿using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase<Teste, RepositorioTeste, TabelaTesteControl, TelaTesteForm, RepositorioDisciplina, RepositorioQuestao>
    {
        private readonly RepositorioTeste _repositorioTeste;
        private readonly RepositorioDisciplina _repositorioDisciplina;
        private readonly RepositorioQuestao _repositorioQuestao;
        private readonly RepositorioMateria _repositorioMateria;

        private TabelaTesteControl _tabelaTeste;

        public ControladorTeste()
        {

        }
        public ControladorTeste(RepositorioTeste _repositorio, TabelaTesteControl _tabela, RepositorioDisciplina _repositorio2, RepositorioQuestao _repositorio3, RepositorioMateria repositorio4) : base(_repositorio, _tabela, _repositorio2, _repositorio3)
        {
            _repositorioTeste = _repositorio;
            _tabelaTeste = _tabela;
            _repositorioDisciplina = _repositorio2;
            _repositorioQuestao = _repositorio3;
            _repositorioMateria = repositorio4;

            onComandosAdicionaisAddAndEdit += CarregarComboBox;
        }

        public void CarregarComboBox(TelaTesteForm telaTeste)
        {
            telaTeste.cmbMateria.DisplayMember = "Nome";
            telaTeste.cmbMateria.ValueMember = "Nome";
            telaTeste.cmbMateria.DataSource = _repositorioMateria.ObterListaRegistros();

            telaTeste.cmbDisciplina.DisplayMember = "Nome";
            telaTeste.cmbDisciplina.ValueMember = "Nome";
            telaTeste.cmbDisciplina.DataSource = _repositorioDisciplina.ObterListaRegistros();
        }

        public override TabelaTesteControl ObterListagem()
        {
            return _tabelaTeste;
        }

        public List<Teste>? ObterListaTeste()
        {
            return new RepositorioTeste().ObterListaRegistros();
        }
        public List<Materia>? ObterListaMateria()
        {
            return new RepositorioMateria().ObterListaRegistros();
        }
    }
}
