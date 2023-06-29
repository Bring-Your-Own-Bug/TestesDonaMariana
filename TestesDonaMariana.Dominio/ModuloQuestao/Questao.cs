using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Dominio.ModuloQuestao
{
    public class Questao
    {
        public Materia Materia { get; set; }
        public string Enunciado { get; set; }
        public List<string> Alternativas { get; set; }
        public string AlternativaCorreta { get; set; }
    }
}
