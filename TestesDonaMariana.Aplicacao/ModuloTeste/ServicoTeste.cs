using FluentResults;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.ModuloTeste;
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

        public override Result Adicionar(Teste entidade, bool adicionar = false)
        {
            throw new NotImplementedException();
        }

        public override Result Editar(Teste entidade, bool adicionar = false)
        {
            throw new NotImplementedException();
        }

        public override Result Excluir(Teste entidade)
        {
            throw new NotImplementedException();
        }

        public override Result ValidarRegistro(Teste entidade)
        {
            throw new NotImplementedException();
        }
    }
}
