using FluentValidation;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dominio.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Disciplina)
                .NotEmpty()
                .NotNull();
        }

        public static bool ValidarMateriaExistente(Materia materia, List<Materia> listaMateria)
        {
            return (listaMateria.Any(m => string.Equals(m.Nome.RemoverAcento(), materia.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && m.Serie == materia.Serie && m.Disciplina.Nome == materia.Disciplina.Nome && m.Id != materia.Id));
        }
    }
}
