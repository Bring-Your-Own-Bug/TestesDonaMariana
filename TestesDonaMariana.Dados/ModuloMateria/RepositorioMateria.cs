using TestesDonaMariana.Dominio.ModuloMateria;

namespace TestesDonaMariana.Dados.ModuloMateria
{
    public class RepositorioMateria : RepositorioBaseSql<Materia>
    {
        protected override string AddCommand => throw new NotImplementedException();

        protected override string EditCommand => throw new NotImplementedException();

        protected override string DeleteCommand => throw new NotImplementedException();

        protected override string SelectCommand => throw new NotImplementedException();

        protected override string SelectAllCommand => throw new NotImplementedException();

        protected override MapeadorBase<Materia> Mapear => new MapeadorMateria();
    }
}
