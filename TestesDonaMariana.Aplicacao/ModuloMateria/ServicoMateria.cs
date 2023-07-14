using FluentResults;
using FluentValidation;
using Microsoft.Data.SqlClient;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Aplicacao.ModuloMateria
{
    public class ServicoMateria : ServicoBase<Materia, RepositorioMateria>
    {
        private RepositorioMateria _repositorioMateria;

        public ServicoMateria(RepositorioMateria _repositorio) : base(_repositorio)
        {
            _repositorioMateria = _repositorio;
        }

        public override Result ValidarRegistro(Materia materia)
        {
            ValidadorMateria validador = new();

            var resultadoValidacao = validador.Validate(materia);

            List<IError> erros = new();

            erros.AddRange(resultadoValidacao.Errors.Select(item => new CustomError(item.ErrorMessage, item.PropertyName)));

            if (ValidadorMateria.ValidarMateriaExistente(materia, _repositorioMateria.ObterListaRegistros()))
                erros.Add(new CustomError("*Essa materia já existe", "Nome"));

            Result resultado = Result.Fail(erros);

            return resultado;
        }

        public override Result Excluir(Materia materia)
        {
            try
            {
                _repositorioMateria.Excluir(materia);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_TBQUESTAO_TBMATERIA"))
                    return Result.Fail(new Error("*Essa Matéria está relacionada à uma Questão." +
                        " Primeiro exclua a Questão relacionada"));

                if (ex.Message.Contains("FK_TBTESTE_TBMATERIA"))
                    return Result.Fail(new Error("*Essa Matéria está relacionada à um Teste." +
                        " Primeiro exclua o Teste relacionado"));
            }

            return Result.Ok();
        }
    }
}
