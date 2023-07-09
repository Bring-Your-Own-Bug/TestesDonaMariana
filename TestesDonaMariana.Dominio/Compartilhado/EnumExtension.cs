using System.ComponentModel;
using System.Reflection;

namespace TestesDonaMariana.Dominio.Compartilhado
{
    public static class EnumExtension
    {
        public static string ObterDescricao(this Enum valor)
        {
            Type tipo = valor.GetType();
            string nome = Enum.GetName(tipo, valor);
            FieldInfo campo = tipo.GetField(nome);
            DescriptionAttribute atributo = campo?.GetCustomAttribute<DescriptionAttribute>();
            return atributo?.Description ?? nome;
        }
    }
}
