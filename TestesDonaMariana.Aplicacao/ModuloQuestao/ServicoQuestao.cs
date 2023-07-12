using FluentResults;
using TestesDonaMariana.Aplicacao.Compartilhado;
using TestesDonaMariana.Dados.ModuloQuestao;
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

        public override Result Adicionar(Questao entidade)
        {
            throw new NotImplementedException();
        }

        public override Result Editar(Questao entidade)
        {
            throw new NotImplementedException();
        }

        public override Result Excluir(Questao entidade)
        {
            throw new NotImplementedException();
        }
    }
}
