using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dominio.ModuloDisciplina;

namespace TestesDonaMariana.Dados.ModuloDisciplina
{
    public class RepositorioDisciplina : RepositorioBaseSql<Disciplina>
    {
        protected override string AddCommand => @"INSERT INTO [dbo].[TBDISCIPLINA]
                                                        (
                                                             [NOME]
                                                        )
                                                   VALUES
                                                        (
                                                             @NOME
                                                        )
                                                        SELECT SCOPE_IDENTITY();";

        protected override string EditCommand => @"UPDATE [dbo].[TBDISCIPLINA]
                                                       SET [NOME] =                     @NOME
                                                     WHERE
                                                            [ID] =                      @ID";

        protected override string DeleteCommand => @"DELETE FROM [dbo].[TBDISCIPLINA]
													WHERE [ID] =                        @ID";

        protected override string SelectCommand => @"SELECT    D.[ID]                   ID
                                                              ,D.[NOME]                 NOME

                                                          FROM [dbo].[TBDISCIPLINA] AS D

													      WHERE [ID] =                  @ID";

        protected override string SelectAllCommand => @"SELECT D.[ID]                   ID
                                                              ,D.[NOME]                 NOME

                                                          FROM [dbo].[TBDISCIPLINA] AS D";

        protected override void ConfigurarParametros(Disciplina registro)
        {
            comandoBd.Parameters.Clear();
            comandoBd.Parameters.AddWithValue("NOME", registro.Nome);
        }

        protected override void ObterPropriedadesEntidade(Disciplina entidade, SqlDataReader reader)
        {
            int idDisciplina = (int)reader["ID"];
            string nomeDisciplina = Convert.ToString(reader["NOME"])!;

            entidade.Id = idDisciplina;
            entidade.Nome = nomeDisciplina;
        }
    }
}
