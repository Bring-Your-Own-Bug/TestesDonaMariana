namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public static class ValidadorTeste
    {
        public static bool ValidarNomeExistente(string titulo, List<Teste> listaTeste)
        {
            return (listaTeste.Any(t => string.Equals(t.Titulo, titulo, StringComparison.OrdinalIgnoreCase)));
        }

        public static bool ValidarDisciplinaExistente(int index)
        {
            return index == -1;
        }

        public static bool ValidarMateriaExistente(int selectedIndex, bool @checked)
        {
            return (@checked && selectedIndex != -1) || (!@checked && selectedIndex == -1);
        }

        public static bool ValidarListaQuestoes(int qtdQuestoesLista)
        {
            return qtdQuestoesLista == 0;
        }

        public static bool ValidarDiretorioExistente(string text)
        {
            return !Directory.Exists(text);
        }
    }
}
