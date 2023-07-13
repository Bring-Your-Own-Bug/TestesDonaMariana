using FluentResults;
using Microsoft.Data.SqlClient;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloDisciplina;
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

        public override Result ValidarRegistro(Questao questao)
        {
            List<IError> erros = new();

            if (ValidadorQuestao.ValidarCampoVazio(questao.Enunciado))
                erros.Add(new Error("*Campo Obrigatório", new Error("Enunciado")));

            else if (ValidadorQuestao.ValidarQuestaoExistente(questao, _resitorioQuestao.ObterListaRegistros()))
                erros.Add(new Error("*Essa Questão já existe", new Error("Enunciado")));

            if (ValidadorQuestao.ValidarCampoVazio(questao.Disciplina == null ? "" : questao.Disciplina.Nome))
                erros.Add(new Error("*Campo Obrigatório", new Error("Disciplina")));

            if (ValidadorQuestao.ValidarCampoVazio(questao.Materia == null ? "" : questao.Materia.Nome))
                erros.Add(new Error("*Campo Obrigatório", new Error("Materia")));

            if (ValidadorQuestao.ValidarQtdMinimaAlternativas(questao.Alternativas.Count))
                erros.Add(new Error("*Deve ter no mínimo 3 alternativas", new Error("Alternativas")));

            if (ValidadorQuestao.ValidarCampoVazio(questao.AlternativaCorreta))
                erros.Add(new Error("*Precisa ter 1 Resposta Correta", new Error("Alternativas")));

            Result resultado = Result.Fail(erros);

            return resultado;
        }

        public override Result Excluir(Questao questao)
        {
            try
            {
                _resitorioQuestao.Excluir(questao);
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
