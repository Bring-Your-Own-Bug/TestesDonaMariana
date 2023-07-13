using FluentResults;
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

            if (ValidadorDisciplina.ValidarCampoVazio(disciplina.Nome))
                erros.Add(new Error("*Campo Obrigatório", new Error("Nome")));

            if (ValidadorDisciplina.ValidarDisciplinaExistente(disciplina, _repositorioDisciplina.ObterListaRegistros()))
                erros.Add(new Error("*Essa Disciplina já existe", new Error("Nome")));

            Result resultado = Result.Fail(erros);

            return resultado;
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
