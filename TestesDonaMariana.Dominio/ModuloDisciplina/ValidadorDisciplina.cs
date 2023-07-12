using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dominio.ModuloDisciplina
{
    public static class ValidadorDisciplina
    {
        public static bool ValidarCampoVazio(string campo)
        {
            return string.IsNullOrWhiteSpace(campo);
        }

        public static bool ValidarNomeExistente(string nome, List<Disciplina> listaDisciplinas)
        {
            return listaDisciplinas.Any(m => string.Equals(m.Nome.RemoverAcento(), nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase));
        }

        public static bool ValidarDependencia(Disciplina disciplina, List<Materia> materias, List<Teste> testes)
        {
            return materias.Exists(m => m.Disciplina.Id == disciplina.Id) || testes.Exists(t => t.Disciplina.Id == disciplina.Id);
        }
    }
}
