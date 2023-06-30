using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dominio.ModuloGabarito
{
    public class Gabarito : Entidade<Gabarito>
    {
        public Teste Teste { get; set; }
        public List<Questao> ListaQuestoes => Teste.ListaQuestoes;
    }
}
