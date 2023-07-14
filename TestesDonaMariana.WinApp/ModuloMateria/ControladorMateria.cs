using TestesDonaMariana.Aplicacao.ModuloMateria;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase<Materia, RepositorioMateria, ServicoMateria, TabelaMateriaControl, TelaMateriaForm, RepositorioDisciplina, RepositorioQuestao>
    {
        private readonly TabelaMateriaControl _tabelaMateria;
        private readonly RepositorioDisciplina _repositorioDisciplina;
        private readonly RepositorioQuestao _repositorioQuestao;
        private readonly ServicoMateria _servicoMateria;

        public ControladorMateria(RepositorioMateria _repositorio, ServicoMateria _servico, TabelaMateriaControl _tabela, RepositorioDisciplina _repositorio2, RepositorioQuestao _repositorio3) : base(_repositorio, _servico, _tabela, _repositorio2, _repositorio3)
        {
            _tabelaMateria = _tabela;
            _servicoMateria = _servico;
            _repositorioDisciplina = _repositorio2;
            _repositorioQuestao = _repositorio3;

            onComandosAdicionaisAddAndEdit += CarregarComboBox;
        }

        public ControladorMateria()
        {
            
        }

        public static List<Materia> ObterListaMateria()
        {
            return new RepositorioMateria().ObterListaRegistros();
        }

        public override TabelaMateriaControl ObterListagem()
        {
            return _tabelaMateria;
        }

        private void CarregarComboBox(TelaMateriaForm telaMateria, Materia materia)
        {
            telaMateria.txtDisciplina.DisplayMember = "Nome";
            telaMateria.txtDisciplina.ValueMember = "Nome";
            telaMateria.txtDisciplina.DataSource = _repositorioDisciplina.ObterListaRegistros();
        }
    }
}
