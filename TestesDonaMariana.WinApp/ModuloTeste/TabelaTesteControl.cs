using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.WinApp.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl, ITabelaBase<Teste>
    {
        public TabelaTesteControl()
        {
            InitializeComponent();
            gridTeste.ConfigurarTabelaGrid("Número", "Título", "Disciplina", "Matéria", "N° Questões", "Série", "Recuperação");
        }

        public DataGridView DataGridView => gridTeste;

        public void AtualizarLista(List<Teste> testes)
        {
            gridTeste.Rows.Clear();

            foreach (Teste item in testes)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridTeste, item.Id, item.Titulo, item.Disciplina.Nome, item.Materia == null ? "Geral" : item.Materia.Nome, item.ListaQuestoes.Count, item.Serie.ObterDescricao(), item.Recuperacao.ObterDescricao());
                row.Cells[0].Tag = item;
                gridTeste.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {testes.Count} Testes");
        }

        public Teste? ObterRegistroSelecionado()
        {
            return (Teste)gridTeste.SelectedRows[0].Cells[0].Tag;
        }
    }
}
