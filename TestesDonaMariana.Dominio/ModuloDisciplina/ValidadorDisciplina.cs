using FluentValidation;
using System.Text.RegularExpressions;

namespace TestesDonaMariana.Dominio.ModuloDisciplina
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .Custom(ValidarCaractereInvalido);
        }

        private void ValidarCaractereInvalido(string nome, ValidationContext<Disciplina> contexto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return;

            if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}'\s-\d]+$"))
                contexto.AddFailure("Caractere Inválido");
        }

        public static bool ValidarDisciplinaExistente(Disciplina disciplina, List<Disciplina> disciplinas)
        {
            return disciplinas.Any(d => string.Equals(d.Nome.RemoverAcento(), disciplina.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && d.Id != disciplina.Id);
        }
    }
}
