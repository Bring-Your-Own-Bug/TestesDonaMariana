using FluentResults;
using FluentValidation.Results;
using Microsoft.Data.SqlClient;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dados.ModuloTeste;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Aplicacao.ModuloTeste
{
    public class ServicoTeste : ServicoBase<Teste, RepositorioTeste>
    {
        private RepositorioTeste _repositorioTeste;

        public ServicoTeste(RepositorioTeste _repositorio) : base(_repositorio)
        {
            _repositorioTeste = _repositorio;
        }

        public override Result ValidarRegistro(Teste teste)
        {
            List<IError> erros = new();

            ValidationResult validacao = new ValidadorTeste().Validate(teste);

            erros.AddRange(ConverterParaListaErros(validacao));

            if (ValidadorTeste.ValidarTesteExistente(teste.Titulo, _repositorioTeste.ObterListaRegistros()))
                erros.Add(new CustomError("Esse Teste já existe", "Titulo"));

            //public static bool ValidarDiretorioExistente(string text)
            //{
            //    return !Directory.Exists(text);
            //}

            return Result.Fail(erros);
        }
    }
}
