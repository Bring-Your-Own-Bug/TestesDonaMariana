using FluentValidation;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloTeste;

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
                .NotNull()
                .NotEmpty();

            RuleFor(q => q.Materia)
                .NotEmpty();

            RuleFor(q => q.AlternativaCorreta)
                .NotEmpty().WithMessage("Precisa ter 1 Resposta Correta").OverridePropertyName("Alternativas");

            RuleFor(q => q.Alternativas.Count)
                .LessThanOrEqualTo(0).WithMessage("Deve ter no mínimo 3 alternativas").OverridePropertyName("Alternativas");
        }

        public static bool ValidarCampoVazio(string campo)
        {
            return string.IsNullOrWhiteSpace(campo);
        }

        public static bool ValidarQuestaoExistente(Questao questao, List<Questao> listaQuestao)
        {
            return (listaQuestao.Any(q => string.Equals(q.Enunciado.RemoverAcento(), questao.Enunciado.RemoverAcento(), StringComparison.OrdinalIgnoreCase)
            && questao.Materia.Nome == q.Materia.Nome
            && questao.Materia.Serie == q.Materia.Serie
            && questao.Disciplina.Nome == q.Disciplina.Nome));
        }

        public static bool ValidarAlternativaExistente(string alternativaAdd, List<string> lista)
        {
            return (lista.Any(alternativa => string.Equals(alternativa.Substring(3), alternativaAdd, StringComparison.OrdinalIgnoreCase)));
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
