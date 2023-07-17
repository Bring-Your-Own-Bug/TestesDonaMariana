using FluentResults;
using FluentValidation.Results;
using Microsoft.Data.SqlClient;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.Aplicacao.ModuloQuestao
{
    public class ServicoQuestao : ServicoBase<Questao, RepositorioQuestao>
    {
        private RepositorioQuestao _repositorioQuestao;

        public ServicoQuestao(RepositorioQuestao _repositorio) : base(_repositorio)
        {
            _repositorioQuestao = _repositorio;
        }

        public override Result ValidarRegistro(Questao questao)
        {
            List<IError> erros = new();

            ValidationResult validacao = new ValidadorQuestao().Validate(questao);

            erros.AddRange(ConverterParaListaErros(validacao));

            if (ValidadorQuestao.ValidarQuestaoExistente(questao, _repositorioQuestao.ObterListaRegistros()))
                erros.Add(new CustomError("Essa Questão já existe", "Enunciado"));

            return Result.Fail(erros);
        }

        public override Result Excluir(Questao questao)
        {
            try
            {
                _repositorioQuestao.Excluir(questao);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_TBTESTE_TBQUESTAO"))
                    return Result.Fail(new Error("*Essa Questão está relacionada à um Teste." +
                        " Primeiro exclua o Teste relacionado"));
            }

            return Result.Ok();
        }
    }
}
