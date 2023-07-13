using FluentResults;
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
            List<IError> erros = new();

            if (ValidadorMateria.ValidarCampoVazio(materia.Nome))
                erros.Add(new Error("*Campo Obrigatório", new Error("Nome")));

            if (ValidadorMateria.ValidarMateriaExistente(materia, _repositorioMateria.ObterListaRegistros()))
                erros.Add(new Error("*Essa Materia já existe", new Error("Nome")));

            if (ValidadorMateria.ValidarCampoVazio(materia.Disciplina == null ? "" : materia.Disciplina.Nome))
                erros.Add(new Error("*Campo Obrigatório", new Error("Disciplina")));

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
            }

            return Result.Ok();
        }
    }
}
