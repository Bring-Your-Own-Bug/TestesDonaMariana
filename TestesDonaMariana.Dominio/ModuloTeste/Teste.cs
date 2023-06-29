using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public class Teste
    {
        public int NumeroDeQuestoes { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public List<Questao> ListaQuestoes { get; set; }
        public DateTime DataGeracao { get; set; }
    }
}
