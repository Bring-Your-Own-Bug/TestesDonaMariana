using TestesDonaMariana.Dominio.Compartilhado;
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

        public void AtualizarLista<TEntidade>(List<TEntidade> disciplinas) where TEntidade : Entidade<TEntidade>, new()
        {
            gridDisciplina.Rows.Clear();

            System.Collections.IList list = disciplinas;
            for (int i = 0; i < list.Count; i++)
            {
                Disciplina item = (Disciplina)list[i];
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
