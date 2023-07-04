using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.WinApp.ModuloMateria
{
    public partial class TabelaMateriaControl : UserControl, ITabelaBase<Materia>
    {
        public TabelaMateriaControl()
        {
            InitializeComponent();
            gridMateria.ConfigurarTabelaGrid("Número", "Nome", "Disciplina", "Série");
        }

        public DataGridView DataGridView { get { return gridMateria; } }

        public void AtualizarLista(List<Materia> materias)
        {
            gridMateria.Rows.Clear();

            foreach (Materia item in materias)
            {
                DataGridViewRow row = new();

                row.CreateCells(gridMateria, item.Id, item.Nome, item.Disciplina.Nome, item.Serie);

                row.Cells[0].Tag = item;

                gridMateria.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {materias.Count} Matérias");
        }

        public void AtualizarLista<TEntidade>(List<TEntidade> materias) where TEntidade : Entidade<TEntidade>, new()
        {
            gridMateria.Rows.Clear();

            System.Collections.IList list = materias;
            for (int i = 0; i < list.Count; i++)
            {
                Materia item = (Materia)list[i];
                DataGridViewRow row = new();

                row.CreateCells(gridMateria, item.Id, item.Nome, item.Disciplina.Nome, item.Serie);

                row.Cells[0].Tag = item;

                gridMateria.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {materias.Count} Matérias");
        }

        public Materia? ObterRegistroSelecionado()
        {
            return (Materia)gridMateria.SelectedRows[0].Cells[0].Tag;
        }
    }
}
