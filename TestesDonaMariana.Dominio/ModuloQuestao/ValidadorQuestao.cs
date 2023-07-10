using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dominio.ModuloQuestao
{
    public static class ValidadorQuestao
    {
        public static bool ValidarAlternativaExistente(string alternativaAdd, List<string> lista)
        {
            return (lista.Any(alternativa => string.Equals(alternativa.Substring(3), alternativaAdd, StringComparison.OrdinalIgnoreCase)));
        }

        public static bool ValidarQuestaoExistente(string enunciado, List<Questao> listaQuestao)
        {
            return (listaQuestao.Any(m => string.Equals(m.Enunciado.RemoverAcento(), enunciado.RemoverAcento(), StringComparison.OrdinalIgnoreCase)));
        }

        public static bool ValidarAlternativaCorreta(int checkCount)
        {
            return checkCount == 0;
        }

        public static bool ValidarQtdMinimaAlternativas(int qtdAlternativas)
        {
            return qtdAlternativas < 3;
        }

        public static bool ValidarQtdMaximaAlternativas(int qtdAlternativas)
        {
            return qtdAlternativas >= 4;
        }

        public static bool ValidarDependencia(Questao questao, List<Teste> testes)
        {
            foreach (Teste teste in testes)
            {
                if (teste.ListaQuestoes.Exists(q => q.Id == questao.Id))
                    return true;
            }
            return false;
        }
    }
}
