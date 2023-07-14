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

        public virtual Result Adicionar(TEntidade entidade, bool adicionar = false)
        {
            Result resultado = ValidarRegistro(entidade);

            if (resultado.IsFailed)
                return resultado;

            if (adicionar)
                _repositorio.Adicionar(entidade);

            return Result.Ok();
        }

        public virtual Result Editar(TEntidade entidade, bool editar = false)
        {
            Result resultado = ValidarRegistro(entidade);

            if (resultado.IsFailed)
                return resultado;

            if (editar)
                _repositorio.Editar(entidade);

            return Result.Ok();
        }

        public virtual Result Excluir(TEntidade entidade) { return Result.Ok(); }

        public abstract Result ValidarRegistro(TEntidade entidade);
    }
}
