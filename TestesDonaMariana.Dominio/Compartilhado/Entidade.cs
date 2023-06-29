namespace PartyPlanner.Dominio.Compartilhado
{
    public abstract class Entidade<TEntidade>
    {
        public int Id { get; set; }

        public bool ValidarCampoVazio(string campo)
        {
            return string.IsNullOrEmpty(campo);
        }
    }
}