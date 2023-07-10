using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.Dominio.ModuloTeste
{
    public class Teste : Entidade<Teste>
    {
        public string Titulo { get; set; }
        public int NumeroDeQuestoes { get; set; }
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public List<Questao> ListaQuestoes { get; set; }
        public DateTime DataGeracao { get; set; }
        public Recuperacao Recuperacao { get; set; }
        public Serie Serie { get; set; }

        public Teste()
        {

        }

        public Teste(string titulo, int numeroDeQuestoes, Disciplina disciplina, Materia materia, Serie serie, List<Questao> listaQuestoes, DateTime dataGeracao, Recuperacao recuperacao)
        {
            Titulo = titulo;
            NumeroDeQuestoes = numeroDeQuestoes;
            Disciplina = disciplina;
            Materia = materia;
            Serie = serie;
            ListaQuestoes = listaQuestoes;
            DataGeracao = dataGeracao;
            Recuperacao = recuperacao;
        }
    }
}
