using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloGabarito;

namespace TestesDonaMariana.WinApp.ModuloGabarito
{
    public partial class TabelaGabaritoControl : UserControl, ITabelaBase<Gabarito>
    {
        public TabelaGabaritoControl()
        {
            InitializeComponent();
            gridGabarito.ConfigurarTabelaGrid("Número");
        }

        public DataGridView DataGridView { get { return gridGabarito; } }

        public void AtualizarLista(List<Gabarito> gabaritos)
        {
            gridGabarito.Rows.Clear();

            foreach (Gabarito item in gabaritos)
            {
                DataGridViewRow row = new();

                row.CreateCells(gridGabarito, item.Id);

                row.Cells[0].Tag = item;

                gridGabarito.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {gabaritos.Count} gabaritos");
        }

        public void AtualizarLista<TEntidade>(List<TEntidade> gabaritos) where TEntidade : Entidade<TEntidade>, new()
        {
            gridGabarito.Rows.Clear();

            System.Collections.IList list = gabaritos;
            for (int i = 0; i < list.Count; i++)
            {
                Gabarito item = (Gabarito)list[i];
                DataGridViewRow row = new();

                row.CreateCells(gridGabarito, item.Id);

                row.Cells[0].Tag = item;

                gridGabarito.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {gabaritos.Count} gabaritos");
        }

        public Gabarito? ObterRegistroSelecionado()
        {
            return (Gabarito)gridGabarito.SelectedRows[0].Cells[0].Tag;
        }
    }
}
