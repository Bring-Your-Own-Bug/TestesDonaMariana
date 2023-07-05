using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloSerie;

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

        public Teste()
        {
            
        }

        public Teste(string titulo, int numeroDeQuestoes, Disciplina disciplina, Materia materia, List<Questao> listaQuestoes, DateTime dataGeracao, Recuperacao recuperacao)
        {
            Titulo = titulo;
            NumeroDeQuestoes = numeroDeQuestoes;
            Disciplina = disciplina;
            Materia = materia;
            ListaQuestoes = listaQuestoes;
            DataGeracao = dataGeracao;
            Recuperacao = recuperacao;
        }

        public bool ValidarNomeExistente(string titulo, List<Teste> listaTeste)
        {
            return (listaTeste.Any(t => string.Equals(t.Titulo, titulo, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
