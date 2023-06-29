using PartyPlanner.Dominio.Compartilhado;

namespace PartyPlanner.WinApp.Compartilhado
{
    public interface ITabelaBase<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        public DataGridView DataGridView { get; }

        public void AtualizarLista(List<TEntidade> contatos);

        public TEntidade ObterRegistroSelecionado();
    }
}
