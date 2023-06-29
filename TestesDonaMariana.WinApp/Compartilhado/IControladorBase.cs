namespace PartyPlanner.WinApp.Compartilhado
{
    public interface IControladorBase
    {
        public abstract string ToolTipAdicionar { get; }

        public abstract string ToolTipEditar { get; }

        public abstract string ToolTipExcluir { get; }

        public abstract void Adicionar();

        public abstract void Editar();

        public abstract void Excluir();

        public abstract void Filtrar();

        public abstract void AdicionarItens();

        public abstract void AtualizarStatus();

        public abstract void CarregarRegistros();

        public abstract string ObterTipoCadastro();

        public UserControl ObterListagem();
    }
}
