using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.WinApp.Compartilhado
{
    public interface ITelaBase<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        TextBox TxtId { get; }
        TEntidade? Entidade { get; set; }
        DialogResult ShowDialog();
    }
}
