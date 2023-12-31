﻿using Microsoft.Data.SqlClient;
using System.Data;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dados.ModuloTeste
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("TITULO", registro.Titulo);
            comando.Parameters.AddWithValue("NUMERODEQUESTOES", registro.NumeroDeQuestoes);
            comando.Parameters.AddWithValue("DISCIPLINA_ID", registro.Disciplina.Id);
            comando.Parameters.AddWithValue("MATERIA_ID", registro.Materia == null ? DBNull.Value : registro.Materia.Id);
            comando.Parameters.AddWithValue("DATAGERACAO", registro.DataGeracao);
            comando.Parameters.AddWithValue("RECUPERACAO", SqlDbType.Bit).Value = registro.Recuperacao;
            comando.Parameters.AddWithValue("SERIE", SqlDbType.Bit).Value = registro.Serie;
        }

        public override Teste ConverterRegistro(SqlDataReader leitorRegistros)
        {
            Teste teste = new();

            int id = Convert.ToInt32(leitorRegistros["TESTE_ID"]);
            string titulo = Convert.ToString(leitorRegistros["TESTE_TITULO"]);
            int numeroDeQuestoes = Convert.ToInt32(leitorRegistros["TESTE_NUMEROQUESTOES"]);
            Disciplina disciplina = new MapeadorDisciplina().ConverterRegistro(leitorRegistros);

            Materia materia = null;

            if (leitorRegistros["MATERIA_ID"] != DBNull.Value)
                materia = new MapeadorMateria().ConverterRegistro(leitorRegistros);

            Serie serie = (Serie)Convert.ToInt32(leitorRegistros["TESTE_SERIE"]);

            DateTime dataGeracao = Convert.ToDateTime(leitorRegistros["TESTE_DATAGERACAO"]);

            Recuperacao recuperacao = (Recuperacao)leitorRegistros["TESTE_RECUPERACAO"];

            teste.Id = id;
            teste.Titulo = titulo;
            teste.NumeroDeQuestoes = numeroDeQuestoes;
            teste.Disciplina = disciplina;
            teste.Materia = materia;
            teste.Serie = serie;
            teste.DataGeracao = dataGeracao;
            teste.Recuperacao = recuperacao;

            return teste;
        }
    }
}
