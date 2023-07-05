using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase<Materia, RepositorioMateria, TabelaMateriaControl, TelaMateriaForm, RepositorioDisciplina, RepositorioQuestao>
    {
        private readonly TabelaMateriaControl _tabelaMateria;

        private readonly RepositorioDisciplina _repositorioDisciplina;

        public ControladorMateria(RepositorioMateria _repositorio, TabelaMateriaControl _tabela, RepositorioDisciplina _repositorio2, RepositorioQuestao _repositorio3) : base(_repositorio, _tabela, _repositorio2, _repositorio3)
        {
            _tabelaMateria = _tabela;
            _repositorioDisciplina = _repositorio2;

            onComandosAdicionaisAddAndEdit += CarregarComboBox;
        }

        public ControladorMateria()
        {
            
        }

        public List<Materia> ObterListaMateria()
        {
            return new RepositorioMateria().ObterListaRegistros();
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
