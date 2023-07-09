using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloSerie;

namespace TestesDonaMariana.Dominio.ModuloMateria
{
    public class Materia : Entidade<Materia>
    {
        public string NomeSerie => $"{Nome}, {Serie.ObterDescricao()}";
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Questao> ListaQuestoes { get; set; } = new();
        public Serie Serie { get; set; }

        public Materia(string nome, Disciplina disciplina, Serie serie)
        {
            Nome = nome;
            Disciplina = disciplina;
            Serie = serie;
        }

        public Materia()
        {

        }
    }
}
