using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.WinApp.Compartilhado
{
    public interface ITabelaBase<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        public DataGridView DataGridView { get; }

        public void AtualizarLista(List<TEntidade> registros);

        public TEntidade ObterRegistroSelecionado();
    }
}
