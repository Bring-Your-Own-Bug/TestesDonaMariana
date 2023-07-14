using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Dominio.ModuloQuestao
{
    public class Questao : Entidade<Questao>
    {
        public Disciplina? Disciplina => Materia.Disciplina;
        public Materia Materia { get; set; }
        public string Enunciado { get; set; }
        public List<string> Alternativas { get; set; }
        public string AlternativaCorreta { get; set; }

        public Questao(Materia materia, string enunciado, List<string> alternativas, string alternativaCorreta)
        {
            Materia = materia;
            Enunciado = enunciado;
            Alternativas = alternativas;
            AlternativaCorreta = alternativaCorreta;
        }

        public Questao()
        {
            
        }

        public override string ToString()
        {
            return Enunciado;
        }
    }
}
