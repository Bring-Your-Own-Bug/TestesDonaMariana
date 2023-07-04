using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.ModuloDisciplina
{
    public partial class TabelaDisciplinaControl : UserControl, ITabelaBase<Disciplina>
    {
        public TabelaDisciplinaControl()
        {
            InitializeComponent();
            gridDisciplina.ConfigurarTabelaGrid("Número", "Nome");
        }

        public DataGridView DataGridView { get { return gridDisciplina; } }

        public void AtualizarLista(List<Disciplina> disciplinas)
        {
            gridDisciplina.Rows.Clear();

            foreach (Disciplina item in disciplinas)
            {
                DataGridViewRow row = new();

                row.CreateCells(gridDisciplina, item.Id, item.Nome);

                row.Cells[0].Tag = item;

                gridDisciplina.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {disciplinas.Count} Disciplinas");
        }

        public Disciplina? ObterRegistroSelecionado()
        {
            return (Disciplina)gridDisciplina.SelectedRows[0].Cells[0].Tag;
        }
    }
}
