using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.WinApp.Compartilhado
{
    public interface ITabelaBase<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        DataGridView DataGridView { get; }
        void AtualizarLista(List<TEntidade> entidades);
        void AtualizarLista<TEntidade>(List<TEntidade> entidades) where TEntidade : Entidade<TEntidade>, new();
        TEntidade ObterRegistroSelecionado();
    }
}
