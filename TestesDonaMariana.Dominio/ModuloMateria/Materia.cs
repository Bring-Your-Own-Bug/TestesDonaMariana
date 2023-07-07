using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloSerie;
using TestesDonaMariana.Dominio.ModuloTeste;

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

        public bool ValidarNomeExistente(string nome, Serie serie, List<Materia> listaMateria)
        {
            return (listaMateria.Any(m => string.Equals(m.Nome, nome, StringComparison.OrdinalIgnoreCase) && m.Serie == serie));
        }

        public bool ValidarDependencia(Materia materia, List<Questao> questoes, List<Teste> testes)
        {
            return questoes.Exists(q => q.Materia.Id == materia.Id) || testes.Exists(t => t.Materia.Id == materia.Id);
        }
    }
}
