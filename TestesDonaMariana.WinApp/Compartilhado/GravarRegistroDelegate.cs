using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Dominio.Compartilhado;

namespace TestesDonaMariana.WinApp.Compartilhado
{
    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade entidade) where TEntidade : Entidade<TEntidade>;
}
