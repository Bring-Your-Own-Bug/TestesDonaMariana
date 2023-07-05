using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.WinApp.ModuloMateria;

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
        }

        public void CarregarComboBox(TelaQuestaoForm telaQuestao)
        {
            telaQuestao.txtMateria.DisplayMember = "Nome";
            telaQuestao.txtMateria.ValueMember = "Nome";
            telaQuestao.txtMateria.DataSource = _repositorioMateria.ObterListaRegistros();

            telaQuestao.txtDisciplina.DisplayMember = "Nome";
            telaQuestao.txtDisciplina.ValueMember = "Nome";
            telaQuestao.txtDisciplina.DataSource = _repositorioDisciplina.ObterListaRegistros();
        }

        public override TabelaQuestaoControl ObterListagem()
        {
            return _tabelaQuestao;
        }
    }
}
