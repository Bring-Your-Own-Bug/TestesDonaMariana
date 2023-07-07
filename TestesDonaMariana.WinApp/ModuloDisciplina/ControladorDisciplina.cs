using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase<Disciplina, RepositorioDisciplina, TabelaDisciplinaControl, TelaDisciplinaForm, RepositorioMateria, NenhumRepositorio>
    {
        private readonly TabelaDisciplinaControl _tabelaDisciplina;
        private readonly RepositorioDisciplina _repositorioDisciplina;
        private readonly RepositorioMateria _repositorioMateria;

        public ControladorDisciplina(RepositorioDisciplina _repositorio, TabelaDisciplinaControl _tabela, RepositorioMateria _repositorio2) : base(_repositorio, _tabela, _repositorio2)
        {
            _tabelaDisciplina = _tabela;
            _repositorioDisciplina = _repositorio;
            _repositorioMateria = _repositorio2;

            onValidarRelacaoExistente += VerificarRelacoesExistentes;
        }

        public ControladorDisciplina()
        {
            
        }

        public List<Disciplina> ObterListaDisciplina()
        {
            return new RepositorioDisciplina().ObterListaRegistros();
        }

        public override TabelaDisciplinaControl ObterListagem()
        {
            return _tabelaDisciplina;
        }

        private bool VerificarRelacoesExistentes(Disciplina disciplina)
        {
            if (disciplina.ValidarDependencia(disciplina, _repositorioMateria.ObterListaRegistros(), new RepositorioTeste().ObterListaRegistros()))
            {
                MessageBox.Show($"Existem Matérias ou Testes cadastrados na Disciplina \"{disciplina.Nome}\", Exclua-os para excluir essa Disciplina",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
    }
}
