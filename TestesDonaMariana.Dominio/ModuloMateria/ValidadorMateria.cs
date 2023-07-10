using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dominio.ModuloMateria
{
    public static class ValidadorMateria
    {
        public static bool ValidarNomeExistente(string nome, Serie serie, ModuloDisciplina.Disciplina? disciplina, List<Materia> listaMateria)
        {
            return (listaMateria.Any(m => string.Equals(m.Nome.RemoverAcento(), nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && m.Serie == serie && m.Disciplina.Nome == disciplina.Nome));
        }

        public static bool ValidarDependencia(Materia materia, List<Questao> questoes, List<Teste> testes)
        {
            return questoes.Any(q => q.Materia != null && q.Materia.Id == materia.Id) || testes.Any(t => t.Materia != null && t.Materia.Id == materia.Id);
        }
    }
}
