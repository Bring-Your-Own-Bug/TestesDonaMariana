using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloSerie;

namespace TestesDonaMariana.Dominio.ModuloMateria
{
    public class Materia : Entidade<Materia>
    {
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Questao> ListaQuestoes { get; set; }
        public Serie Serie { get; set; }
    }
}
