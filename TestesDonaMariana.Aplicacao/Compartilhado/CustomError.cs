using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMariana.Aplicacao.Compartilhado
{
    public class CustomError : Error
    {
        public string ErrorMessage { get; set; }

        public string PropertyName { get; set; }

        public CustomError(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}
