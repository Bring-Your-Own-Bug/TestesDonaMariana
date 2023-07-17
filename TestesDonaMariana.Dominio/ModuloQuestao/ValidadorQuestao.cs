using FluentValidation;

namespace TestesDonaMariana.Dominio.ModuloQuestao
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(q => q.Enunciado)
                .MinimumLength(6).WithMessage(@"'Enunciado' deve ser maior ou igual a 6 caracteres.")
                .NotEmpty();

            RuleFor(q => q.Disciplina)
                .NotEmpty();

            RuleFor(q => q.Materia)
                .NotEmpty();

            RuleFor(q => q.AlternativaCorreta)
                .NotEmpty().WithMessage("Precisa ter 1 Resposta Correta").OverridePropertyName("Alternativas");

            RuleFor(q => q.Alternativas.Count)
                .GreaterThanOrEqualTo(3).WithMessage("Deve ter no mínimo 3 alternativas").OverridePropertyName("Alternativas")
                .LessThanOrEqualTo(4).WithMessage("Deve ter no máximo 4 alternativas").OverridePropertyName("Alternativas");

            RuleFor(q => q.Alternativas)
                .Must(ValidarAlternativasRepetidas).WithMessage("Não deve haver alternativas repetidas");
        }

        private bool ValidarAlternativasRepetidas(List<string> alternativas)
        {
            return alternativas.Select(a => a.Substring(3)).Distinct().Count() == alternativas.Count;
        }

        public static bool ValidarQuestaoExistente(Questao questao, List<Questao> listaQuestao)
        {
            return (listaQuestao.Any(q => string.Equals(q.Enunciado.RemoverAcento(), questao.Enunciado.RemoverAcento(), StringComparison.OrdinalIgnoreCase)
            && questao.Materia.Nome == q.Materia.Nome
            && questao.Materia.Serie == q.Materia.Serie
            && questao.Disciplina.Nome == q.Disciplina.Nome));
        }
    }
}
