using FluentResults;
using FluentValidation.Results;
using Microsoft.Data.SqlClient;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.Aplicacao.ModuloQuestao
{
    public class ServicoQuestao : ServicoBase<Questao, RepositorioQuestao>
    {
        private RepositorioQuestao _resitorioQuestao;

        public ServicoQuestao(RepositorioQuestao _repositorio) : base(_repositorio)
        {
            _resitorioQuestao = _repositorio;
        }

        public override Result Excluir(Questao entidade)
        {
            try
            {
                _resitorioQuestao.Excluir(entidade);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_TBTESTE_TBQUESTAO"))
                    return Result.Fail(new Error("*Essa Questão está relacionada à um Teste." +
                        " Primeiro exclua o Teste relacionado"));

                if (ex.Message.Contains("FK_TBQUESTAO_TBMATERIA"))
                    return Result.Fail(new Error("*Essa Questão está relacionada à uma Matéria." +
                        " Primeiro exclua a Matéria relacionada"));
            }

            return Result.Ok();
        }

        public override Result ValidarRegistro(Questao entidade)
        {
            List<IError> erros = new();

            ValidationResult validacao = new ValidadorQuestao().Validate(entidade);

            erros.AddRange(ConverterParaListaErros(validacao));

            if (ValidadorQuestao.ValidarQuestaoExistente(entidade, _resitorioQuestao.ObterListaRegistros()))
                erros.Add(new CustomError("Essa Questão já existe", "Enunciado"));

            return Result.Fail(erros);
        }
    }
}
