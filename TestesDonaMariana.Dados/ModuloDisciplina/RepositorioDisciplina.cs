using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.Dados.ModuloDisciplina
{
    public class RepositorioDisciplina : RepositorioBaseSql<Disciplina>, IRepositorio<Disciplina>
    {
        protected override string AddCommand => throw new NotImplementedException();

        protected override string EditCommand => throw new NotImplementedException();

        protected override string DeleteCommand => throw new NotImplementedException();

        protected override string SelectCommand => throw new NotImplementedException();

        protected override string SelectAllCommand => throw new NotImplementedException();

        protected override MapeadorBase<Disciplina> Mapear => new MapeadorDisciplina();

        int IRepositorio<Disciplina>.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Adicionar<TEntidade>(TEntidade? entidade) where TEntidade : Entidade<TEntidade>, new()
        {
            throw new NotImplementedException();
        }

        public void Editar(int id, Disciplina entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar<TEntidade>(TEntidade entidade) where TEntidade : Entidade<TEntidade>, new()
        {
            throw new NotImplementedException();
        }

        public void Excluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade<TEntidade>, new()
        {
            throw new NotImplementedException();
        }

        public List<Disciplina> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
