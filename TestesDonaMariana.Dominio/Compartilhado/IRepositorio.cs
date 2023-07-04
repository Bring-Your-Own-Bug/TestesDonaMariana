namespace TestesDonaMariana.Dominio.Compartilhado
{
    public interface IRepositorio<T> where T : Entidade<T>
    {
        int Id { get; set; }
        void Adicionar(T entidade);
        void Adicionar<TEntidade>(TEntidade? entidade) where TEntidade : Entidade<TEntidade>, new();
        void Editar(T entidade);
        void Editar(int id, T entidade);
        void Editar<TEntidade>(TEntidade entidade) where TEntidade : Entidade<TEntidade>, new();
        void Excluir(T entidade);
        void Excluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade<TEntidade>, new();
        T SelecionarPorId(int id);
        List<T> SelecionarTodos();
        List<T> ObterListaRegistros();
    }
}
