using FluentResults;
using TestesDonaMariana.Dominio.Compartilhado;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.WinApp.Compartilhado
{
    public interface ITelaBase<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        TEntidade? Entidade { get; set; }

        event Func<TEntidade, bool, Result> OnGravarRegistro;

        DialogResult ShowDialog();
    }
}
