using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.WinApp.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase<Materia, RepositorioMateria, TabelaMateriaControl, TelaMateriaForm, RepositorioDisciplina, RepositorioQuestao>
    {
        private RepositorioMateria _repositorioMateria;
        private TabelaMateriaControl _tabelaMateria;

        private RepositorioDisciplina _repositorioDisciplina;
        private RepositorioQuestao _repositorioQuestao;

        public ControladorMateria(RepositorioMateria _repositorio, TabelaMateriaControl _tabela, RepositorioDisciplina _repositorio2, RepositorioQuestao _repositorio3) : base(_repositorio, _tabela, _repositorio2, _repositorio3)
        {
            _repositorioMateria = _repositorio;
            _tabelaMateria = _tabela;
            _repositorioDisciplina = _repositorio2;
            _repositorioQuestao = _repositorio3;

            onComandosAdicionaisAddAndEdit += CarregarComboBox;
        }

        public ControladorMateria()
        {
            
        }

        public List<Materia> ObterListaMateria()
        {
            RepositorioMateria _repositorioMateria = new();

            return _repositorioMateria.ObterListaRegistros();
        }

        public void CarregarComboBox(TelaMateriaForm telaMateria)
        {
            telaMateria.txtDisciplina.DisplayMember = "Nome";
            telaMateria.txtDisciplina.ValueMember = "Nome";
            telaMateria.txtDisciplina.DataSource = _repositorioDisciplina.ObterListaRegistros();
        }

        public override TabelaMateriaControl ObterListagem()
        {
            return _tabelaMateria;
        }
    }
}
