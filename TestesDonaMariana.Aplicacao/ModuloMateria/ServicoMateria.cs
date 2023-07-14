using FluentResults;
using FluentValidation.Results;
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

        public override Result Excluir(Materia entidade)
        {
            try
            {
                _repositorioMateria.Excluir(entidade);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_TBTESTE_TBMATERIA"))
                    return Result.Fail(new Error("*Essa Matéria está relacionada à um Teste." +
                        " Primeiro exclua o Teste relacionado"));

                if (ex.Message.Contains("FK_TBDISCIPLINA_TBMATERIA"))
                    return Result.Fail(new Error("*Essa Matéria está relacionada à uma Disciplina." +
                        " Primeiro exclua a Disciplina relacionada"));
            }

            return Result.Ok();
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
    }
}
