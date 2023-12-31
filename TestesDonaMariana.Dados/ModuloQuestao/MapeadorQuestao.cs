﻿using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;

namespace TestesDonaMariana.Dados.ModuloQuestao
{
    public class MapeadorQuestao : MapeadorBase<Questao>
    {
        public override void ConfigurarParametros(SqlCommand comando, Questao registro)
        {
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("MATERIA_ID", registro.Materia.Id);
            comando.Parameters.AddWithValue("ENUNCIADO", registro.Enunciado);
            comando.Parameters.AddWithValue("ALTERNATIVACORRETA", registro.AlternativaCorreta);
        }

        public override Questao ConverterRegistro(SqlDataReader leitorRegistros)
        {
            Questao questao = new();

            int id = Convert.ToInt32(leitorRegistros["QUESTAO_ID"]);
            Materia materia = new MapeadorMateria().ConverterRegistro(leitorRegistros);
            string enunciado = Convert.ToString(leitorRegistros["QUESTAO_ENUNCIADO"])!;
            string alternativaCorreta = Convert.ToString(leitorRegistros["QUESTAO_ALTERNATIVACORRETA"])!;

            questao.Id = id;
            questao.Materia = materia;
            questao.Enunciado = enunciado;
            questao.AlternativaCorreta = alternativaCorreta;

            return questao;
        }
    }
}
