using System.Globalization;
using System.Text;

namespace TestesDonaMariana.Dominio.Compartilhado
{
    public static class StringExtension
    {
        public static string RemoverAcento(this string texto)
        {
            return new string(texto
                    .Normalize(NormalizationForm.FormD)
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    .ToArray())
                    .Normalize(NormalizationForm.FormC);
        }

        public static bool ValidarCampoVazio(this string campo)
        {
            return string.IsNullOrWhiteSpace(campo);
        }
    }
}
