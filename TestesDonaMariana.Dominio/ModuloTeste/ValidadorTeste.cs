using FluentValidation;

namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(t => t.Titulo)
                .MinimumLength(4).WithMessage(@"'Titulo' deve ser maior ou igual a 4 caracteres.")
                .NotEmpty();

            RuleFor(t => t.Disciplina)
                .NotEmpty();

            RuleFor(t => t.Materia)
                .NotEmpty().When(t => t.Materia != null);

            RuleFor(q => q.ListaQuestoes.Count)
                .LessThanOrEqualTo(0).WithMessage("Deve ter no mínimo 1 questão").OverridePropertyName("Questoes");
        }

        public static bool ValidarTesteExistente(string titulo, List<Teste> listaTeste)
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
