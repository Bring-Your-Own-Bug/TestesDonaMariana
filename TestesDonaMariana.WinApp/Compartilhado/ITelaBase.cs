﻿using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.WinApp.Compartilhado
{
    public interface ITelaBase<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        TEntidade? Entidade { get; set; }

        event GravarRegistroDelegate<TEntidade> onGravarRegistro;

        DialogResult ShowDialog();
    }
}
