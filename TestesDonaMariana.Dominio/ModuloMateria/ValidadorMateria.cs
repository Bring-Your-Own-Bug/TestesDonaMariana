using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dominio.ModuloMateria
{
    public static class ValidadorMateria
    {
        public static bool ValidarMateriaExistente(Materia materia, List<Materia> listaMateria)
        {
            return (listaMateria.Any(m => string.Equals(m.Nome.RemoverAcento(), materia.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && m.Serie == materia.Serie && m.Disciplina.Nome == materia.Disciplina.Nome && m.Id != materia.Id));
        }

        public static bool ValidarDependencia(Materia materia, List<Questao> questoes, List<Teste> testes)
        {
            return questoes.Any(q => q.Materia != null && q.Materia.Id == materia.Id) || testes.Any(t => t.Materia != null && t.Materia.Id == materia.Id);
        }
    }
}
