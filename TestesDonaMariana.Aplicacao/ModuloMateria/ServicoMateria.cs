using FluentResults;
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

        public override Result Adicionar(Materia entidade, bool adicionar = false)
        {
            throw new NotImplementedException();
        }

        public override Result Editar(Materia entidade, bool adicionar = false)
        {
            throw new NotImplementedException();
        }

        public override Result Excluir(Materia entidade)
        {
            throw new NotImplementedException();
        }

        public override Result ValidarRegistro(Materia entidade)
        {
            throw new NotImplementedException();
        }
    }
}
