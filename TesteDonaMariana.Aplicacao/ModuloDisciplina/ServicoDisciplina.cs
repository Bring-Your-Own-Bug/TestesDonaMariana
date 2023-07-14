using FluentResults;
using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TesteDonaMariana.Aplicacao.ModuloDisciplina
{
    public class ServicoDisciplina
    {

        private RepositorioDisciplina repositorioDisciplina;

        public ServicoDisciplina(RepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }
        
        public Result Inserir(Disciplina disciplina)
        {
            List<string> erros = ValidadorDisciplina.ValidarDisciplina(disciplina);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioDisciplina.Adicionar(disciplina);

            return Result.Ok();
        }

        public Result Editar(Disciplina disciplina)
        {
            List<string> erros = ValidadorDisciplina.ValidarDisciplina(disciplina);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            repositorioDisciplina.Editar(disciplina);

            return Result.Ok();
        }

        public Result Excluir(Disciplina disciplinaSelecionada)
        {
            List<string> erros = new List<string>();

            try
            {
                repositorioDisciplina.Excluir(disciplinaSelecionada);

                return Result.Ok();
            }
            catch(SqlException ex)
            {
                if (ex.Message.Contains("TBDISCIPLINA_TBMATERIA"))
                    erros.Add("Esta disciplina está relacionada com uma matéria e não pode ser excluída");

                return Result.Fail(erros);
            }

        }
    }
}
