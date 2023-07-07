using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase<Materia, RepositorioMateria, TabelaMateriaControl, TelaMateriaForm, RepositorioDisciplina, RepositorioQuestao>
    {
        private readonly TabelaMateriaControl _tabelaMateria;
        private readonly RepositorioDisciplina _repositorioDisciplina;
        private readonly RepositorioMateria _repositorioMateria;
        private readonly RepositorioQuestao _repositorioQuestao;

        public ControladorMateria(RepositorioMateria _repositorio, TabelaMateriaControl _tabela, RepositorioDisciplina _repositorio2, RepositorioQuestao _repositorio3) : base(_repositorio, _tabela, _repositorio2, _repositorio3)
        {
            _tabelaMateria = _tabela;
            _repositorioMateria = _repositorio;
            _repositorioDisciplina = _repositorio2;
            _repositorioQuestao = _repositorio3;

            onComandosAdicionaisAddAndEdit += CarregarComboBox;
            onValidarRelacaoExistente += VerificarRelacoesExistentes;
        }

        public ControladorMateria()
        {
            
        }

        public List<Materia> ObterListaMateria()
        {
            return new RepositorioMateria().ObterListaRegistros();
        }

        public override TabelaMateriaControl ObterListagem()
        {
            return _tabelaMateria;
        }

        private bool VerificarRelacoesExistentes(Materia materia)
        {
            if (materia.ValidarDependencia(materia, _repositorioQuestao.ObterListaRegistros(), new RepositorioTeste().ObterListaRegistros()))
            {
                MessageBox.Show($"Existem Questões ou Testes cadastrados na Matéria \"{materia.Nome}\", Exclua-os para excluir essa Matéria",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        private void CarregarComboBox(TelaMateriaForm telaMateria, Materia materia)
        {
            telaMateria.txtDisciplina.DisplayMember = "Nome";
            telaMateria.txtDisciplina.ValueMember = "Nome";
            telaMateria.txtDisciplina.DataSource = _repositorioDisciplina.ObterListaRegistros();
        }
    }
}
