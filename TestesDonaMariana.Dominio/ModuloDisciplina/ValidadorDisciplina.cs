namespace TestesDonaMariana.Dominio.ModuloDisciplina
{
    public static class ValidadorDisciplina
    {
        public static bool ValidarCampoVazio(string campo)
        {
            return string.IsNullOrWhiteSpace(campo);
        }

        public static bool ValidarNomeExistente(Disciplina disciplina, List<Disciplina> listaDisciplinas)
        {
            return listaDisciplinas.Any(m => string.Equals(m.Nome.RemoverAcento(), disciplina.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && m.Id != disciplina.Id);
        }
    }
}
