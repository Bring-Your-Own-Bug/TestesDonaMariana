using TestesDonaMariana.Dominio.Compartilhado;
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

        public bool ValidarNomeExistente(string nome, List<Disciplina> listaDisciplinas)
        {
            return listaDisciplinas.Any(m => string.Equals(m.Nome, nome, StringComparison.OrdinalIgnoreCase));
        }

        public bool ValidarDependencia(Disciplina disciplina, List<Materia> materias)
        {
            return materias.Exists(m => m.Disciplina.Id == disciplina.Id);
        }
    }
}
