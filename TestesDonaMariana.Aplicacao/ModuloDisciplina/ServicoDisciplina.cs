using FluentResults;
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

        public override Result Adicionar(Disciplina disciplina)
        {
            Result resultado = new();

            resultado = ValidarRegistro(disciplina);

            if (resultado.IsFailed)
                return resultado;

            _repositorioDisciplina.Adicionar(disciplina);

            return Result.Ok();
        }

        private Result ValidarRegistro(Disciplina disciplina)
        {
            return Result.FailIf(ValidadorDisciplina.ValidarCampoVazio(disciplina.Nome), new Error("*Campo Obrigatório", new Error("Nome")));
        }

        public override Result Editar(Disciplina entidade)
        {
            throw new NotImplementedException();
        }

        public override Result Excluir(Disciplina entidade)
        {
            throw new NotImplementedException();
        }
    }
}
