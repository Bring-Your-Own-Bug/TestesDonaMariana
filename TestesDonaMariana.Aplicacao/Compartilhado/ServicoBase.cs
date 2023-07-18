using FluentResults;
using FluentValidation.Results;
using Serilog;
using System.Collections.Generic;
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
            string nome = Convert.ToString(entidade.GetType().GetProperties()[0].GetValue(entidade))!;

            if (adicionar)
                Log.Debug("Tentando adicionar um(a) '{entidadeTipo} {entidadeNome}'", typeof(TEntidade).Name, nome);

            Result resultado = ValidarRegistro(entidade);

            if (resultado.IsFailed)
            {
                if (adicionar)
                    Log.Warning("Falha ao tentar adicionar um(a) '{entidadeTipo} {entidadeNome}'", typeof(TEntidade).Name, nome);
                return resultado;
            }

            if (adicionar)
                _repositorio.Adicionar(entidade);

            if (adicionar)
                Log.Debug("Adicionado um(a) '{entidadeTipo} {entidadeNome} {entidadeId}' com sucesso!", typeof(TEntidade).Name, nome, entidade.Id);

            return Result.Ok();
        }

        public virtual Result Editar(TEntidade entidade, bool editar = false)
        {
            string nome = Convert.ToString(entidade.GetType().GetProperties()[0].GetValue(entidade))!;

            if (editar)
                Log.Debug("Tentando editar '{entidadeTipo} {entidadeNome} {entidadeId}'", typeof(TEntidade).Name, nome, entidade.Id);

            Result resultado = ValidarRegistro(entidade);

            if (resultado.IsFailed)
            {
                if (editar)
                    Log.Warning("Falha ao tentar editar '{entidadeTipo} {entidadeNome} {entidadeId}'", typeof(TEntidade).Name, nome, entidade.Id);
                return resultado;
            }

            if (editar)
                _repositorio.Editar(entidade);

            if (editar)
                Log.Debug("Editado '{entidadeTipo} {entidadeNome} {entidadeId}' com sucesso!", typeof(TEntidade).Name, nome, entidade.Id);

            return Result.Ok();
        }

        public virtual Result Excluir(TEntidade entidade) { return Result.Ok(); }

        public virtual List<IError> ConverterParaListaErros(ValidationResult validacao)
        {
            return new List<IError>(validacao.Errors.Select(item => new CustomError(item.ErrorMessage, item.PropertyName)));
        }

        public abstract Result ValidarRegistro(TEntidade entidade);
    }
}
