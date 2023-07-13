using FluentResults;
using FluentValidation.Results;
using Microsoft.Data.SqlClient;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.ModuloMateria;
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

            ValidationResult validacao = new ValidadorMateria().Validate(materia);

            erros.AddRange(ConverterParaListaErros(validacao));

            if (ValidadorMateria.ValidarMateriaExistente(materia, _repositorioMateria.ObterListaRegistros()))
                erros.Add(new CustomError("Essa Matéria já existe", "Nome"));

            return Result.Fail(erros);
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
