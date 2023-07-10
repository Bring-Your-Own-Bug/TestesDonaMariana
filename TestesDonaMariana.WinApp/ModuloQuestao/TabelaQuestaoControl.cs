using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.WinApp.ModuloQuestao
{
    public partial class TabelaQuestaoControl : UserControl, ITabelaBase<Questao>
    {
        public TabelaQuestaoControl()
        {
            InitializeComponent();
            gridQuestao.ConfigurarTabelaGrid("Número", "Enunciado", "Resposta", "Matéria", "Disciplina");
        }

        public DataGridView DataGridView => gridQuestao;
        public void AtualizarLista(List<Questao> questoes)
        {
            gridQuestao.Rows.Clear();

            foreach (Questao item in questoes)
            {
                DataGridViewRow row = new();
                row.CreateCells(gridQuestao, item.Id, item.Enunciado, item.AlternativaCorreta, item.Materia.NomeSerie, item.Materia.Disciplina.Nome);
                row.Cells[0].Tag = item;
                gridQuestao.Rows.Add(row);
            }

            TelaPrincipalForm.AtualizarStatus($"Visualizando {questoes.Count} Questões");
        }

        public Questao? ObterRegistroSelecionado()
        {
            return (Questao)gridQuestao.SelectedRows[0].Cells[0].Tag;
        }
    }
}
