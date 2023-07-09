using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Dominio.ModuloDisciplina
{
    public class Disciplina : Entidade<Disciplina>
    {
        public string Nome { get; set; }
        public List<Materia> ListaMaterias { get; set; }

        public Disciplina(string nome)
        {
            Nome = nome;
        }

        public Disciplina()
        {
            
        }
    }
}
