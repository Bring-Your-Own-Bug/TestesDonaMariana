using FluentResults;
using FluentValidation.Results;
using Microsoft.Data.SqlClient;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.Aplicacao.ModuloDisciplina
{
    public class ServicoDisciplina : ServicoBase<Disciplina, RepositorioDisciplina>
    {
        private RepositorioDisciplina _repositorioDisciplina;

        public ServicoDisciplina(RepositorioDisciplina _repositorio) : base(_repositorio)
        {
            _repositorioDisciplina = _repositorio;
        }

        public override Result ValidarRegistro(Disciplina disciplina)
        {
            List<IError> erros = new();

            ValidationResult validacao = new ValidadorDisciplina().Validate(disciplina);

            erros.AddRange(ConverterParaListaErros(validacao));

            if (ValidadorDisciplina.ValidarDisciplinaExistente(disciplina, _repositorioDisciplina.ObterListaRegistros()))
                erros.Add(new CustomError("Essa Disciplina já existe", "Nome"));

            return Result.Fail(erros);
        }

        public override Result Excluir(Disciplina disciplina)
        {
            try
            {
                _repositorioDisciplina.Excluir(disciplina);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_TBTESTE_TBDISCIPLINA"))
                    return Result.Fail(new Error("*Essa Disciplina está relacionada à um Teste." +
                        " Primeiro exclua o Teste relacionado"));

                if (ex.Message.Contains("FK_TBMATERIA_TBDISCIPLINA"))
                    return Result.Fail(new Error("*Essa Disciplina está relacionada à uma Matéria." +
                        " Primeiro exclua a Matéria relacionada"));
            }

            return Result.Ok();
        }
    }
}