using FluentResults;
using TestesDonaMariana.Dados.Compartilhado;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.Aplicacao.Compartilhado
{
    public abstract class ServicoBase<TEntidade, TRepositorio> 
        where TEntidade : Entidade<TEntidade>, new()
        where TRepositorio : RepositorioBaseSql<TEntidade>
    {
        protected TRepositorio _repositorio;

        public ServicoBase(TRepositorio _repositorio)
        {
            this._repositorio = _repositorio;
        }

        public abstract Result Adicionar(TEntidade entidade);

        public abstract Result Editar(TEntidade entidade);

        public abstract Result Excluir(TEntidade entidade);
    }
}
