using FluentValidation;
using System.Runtime.ConstrainedExecution;

namespace TestesDonaMariana.Dominio.ModuloDisciplina
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina()
        {
            RuleFor(d => d.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .NotEmpty();
        }

        public static bool ValidarDisciplinaExistente(Disciplina disciplina, List<Disciplina> listaDisciplinas)
        {
            return listaDisciplinas.Any(m => string.Equals(m.Nome.RemoverAcento(), disciplina.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && m.Id != disciplina.Id);
        }
    }
}
