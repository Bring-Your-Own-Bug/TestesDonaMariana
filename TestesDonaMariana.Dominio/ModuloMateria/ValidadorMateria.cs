using FluentValidation;
using System.Data;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dominio.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {

        public ValidadorMateria()
        {
            RuleFor(m => m.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .NotEmpty();

            RuleFor(m => m.Disciplina.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .NotEmpty();
        }

        public static bool ValidarNomeExistente(string nome, Serie serie, ModuloDisciplina.Disciplina? disciplina, List<Materia> listaMateria)
        {
            return (listaMateria.Any(m => string.Equals(m.Nome.RemoverAcento(), nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && m.Serie == serie && m.Disciplina.Nome == disciplina.Nome));
        }

        public static bool ValidarDependencia(Materia materia, List<Questao> questoes, List<Teste> testes)
        {
            return questoes.Any(q => q.Materia != null && q.Materia.Id == materia.Id) || testes.Any(t => t.Materia != null && t.Materia.Id == materia.Id);
        }

        public static bool ValidarMateriaExistente(Materia materia, List<Materia> listaMaterias)
        {
            return listaMaterias.Any(m => string.Equals(m.Nome.RemoverAcento(), materia.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && m.Id != materia.Id);
        }
    }
}
