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
                .MinimumLength(3).WithMessage(@"'Enunciado' deve ser maior ou igual a 3 caracteres.")
                .NotEmpty();

            RuleFor(q => q.Materia.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .NotEmpty();

            RuleFor(q => q.Disciplina.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .NotEmpty();

            RuleFor(q => q.Alternativas)
                .NotEmpty()
                .NotEqual(q => q.Alternativas);
        }

        public static bool ValidarQuestaoExistente(Questao questao, List<Questao> listaQuestoes)
        {
            return listaQuestoes.Any(m => string.Equals(questao.Enunciado.RemoverAcento(), questao.Enunciado.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && m.Id != questao.Id);
        }

        public static bool ValidarAlternativaExistente(string alternativaAdd, List<string> lista)
        {
            return (lista.Any(alternativa => string.Equals(alternativa.Substring(3), alternativaAdd, StringComparison.OrdinalIgnoreCase)));
        }

        public static bool ValidarQuestaoExistente(string enunciado, Disciplina disciplina, Materia materia, List<Questao> listaQuestao)
        {
            return (listaQuestao.Any(q => string.Equals(q.Enunciado.RemoverAcento(), enunciado.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && materia.Nome == q.Materia.Nome && materia.Serie == q.Materia.Serie && disciplina.Nome == q.Disciplina.Nome));
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
