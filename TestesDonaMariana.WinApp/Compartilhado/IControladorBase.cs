namespace TestesDonaMariana.WinApp.Compartilhado
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

        public abstract void MostrarDetalhes();

        public abstract void MostrarDuplicacao();

        public abstract void CarregarRegistros();

        public abstract string ObterTipoCadastro();

        public abstract void CarregarDetalhesTeste();

        public UserControl ObterListagem();
    }
}
