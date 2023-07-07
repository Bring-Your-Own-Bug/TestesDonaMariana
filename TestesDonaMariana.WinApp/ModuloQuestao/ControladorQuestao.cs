using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase<Questao, RepositorioQuestao, TabelaQuestaoControl, TelaQuestaoForm, RepositorioMateria, RepositorioDisciplina>
    {
        private RepositorioQuestao _repositorioQuestao;
        private TabelaQuestaoControl _tabelaQuestao;

        private RepositorioMateria _repositorioMateria;
        private RepositorioDisciplina _repositorioDisciplina;

        public ControladorQuestao(RepositorioQuestao _repositorio, TabelaQuestaoControl _tabela, RepositorioMateria _repositorio2, RepositorioDisciplina _repositorio3) : base(_repositorio, _tabela, _repositorio2, _repositorio3)
        {
            _repositorioQuestao = _repositorio;
            _tabelaQuestao = _tabela;
            _repositorioMateria = _repositorio2;
            _repositorioDisciplina = _repositorio3;

            onComandosAdicionaisAddAndEdit += CarregarComboBox;
            onComandosAdicionaisAddAndEdit += CarregarAlternativas;
            onValidarRelacaoExistente += VerificarRelacoesExistentes;
        }

        public bool VerificarRelacoesExistentes(Questao questao)
        {
            if (questao.ValidarDependencia(questao, new RepositorioTeste().ObterListaRegistros()))
            {
                MessageBox.Show($"Existem Testes cadastrados com a questão selecionada, Exclua-os para excluir essa Questão",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        public void CarregarComboBox(TelaQuestaoForm telaQuestao, Questao questao)
        {
            telaQuestao.txtMateria.DisplayMember = "Nome";
            telaQuestao.txtMateria.ValueMember = "Nome";
            telaQuestao.txtMateria.DataSource = _repositorioMateria.ObterListaRegistros();

            telaQuestao.txtDisciplina.DisplayMember = "Nome";
            telaQuestao.txtDisciplina.ValueMember = "Nome";
            telaQuestao.txtDisciplina.DataSource = _repositorioDisciplina.ObterListaRegistros();
        }

        public void CarregarAlternativas(TelaQuestaoForm telaQuestao, Questao questao)
        {
            if (questao != null)
                questao.Alternativas = _repositorioQuestao.ObterAlternativas(questao);
        }

        public override TabelaQuestaoControl ObterListagem()
        {
            return _tabelaQuestao;
        }
    }
}
