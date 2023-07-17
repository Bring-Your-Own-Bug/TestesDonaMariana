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
                .NotEmpty().When(t => t.Recuperacao == Recuperacao.Nao);

            RuleFor(t => t.ListaQuestoes.Count)
                .GreaterThan(0).WithMessage("Deve ter no mínimo 1 questão").OverridePropertyName("Questoes");

            RuleFor(t => t)
                .Must(ValidarLimiteDeQuestoes).WithMessage("Foi excedido o limite de Questões da(s) Matéria(s)").OverridePropertyName("Questoes");
        }

        private bool ValidarLimiteDeQuestoes(Teste teste)
        {
            return teste.ListaQuestoes.Count >= teste.NumeroDeQuestoes;
        }

        public static bool ValidarTesteExistente(string titulo, List<Teste> listaTeste)
        {
            return (listaTeste.Any(t => string.Equals(t.Titulo, titulo, StringComparison.OrdinalIgnoreCase)));
        }

        public static bool ValidarDiretorioExistente(string text)
        {
            return !Directory.Exists(text);
        }
    }
}
