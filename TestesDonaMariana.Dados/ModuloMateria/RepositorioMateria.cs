using Microsoft.Data.SqlClient;
using System.Data;
using TestesDonaMariana.Dados.ModuloDisciplina;
using TestesDonaMariana.Dados.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloQuestao;
using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dados.ModuloMateria
{
    public class RepositorioMateria : RepositorioBaseSql<Materia>
    {
        public RepositorioMateria()
        {
            onComandoDeRelacaoAdd += AdicionarDisciplina;
            onComandoDeRelacaoEdit += EditarDisciplina;
            onComandoDeRelacaoSelect += ObterDisciplina;
        }

        protected override string AddCommand => @"INSERT INTO [dbo].[TBMATERIA]
                                                           (
                                                                [NOME]
                                                               ,[DISCIPLINA_ID]
                                                               ,[SERIE]
                                                           )
                                                     VALUES
                                                           (
                                                                @NOME
                                                               ,@DISCIPLINA_ID
                                                               ,@SERIE
                                                           )
                                                           SELECT SCOPE_IDENTITY();";

        protected override string EditCommand => @"UPDATE [dbo].[TBMATERIA]
                                                       SET [NOME] =                 @NOME
                                                          ,[DISCIPLINA_ID] =        @DISCIPLINA_ID
                                                          ,[SERIE] =                @SERIE

                                                     WHERE [ID] =                   @ID";

        protected override string DeleteCommand => @"DELETE FROM [dbo].[TBDISCIPLINA_TBMATERIA] 
                                                   WHERE [MATERIA_ID] =          @ID

                                                    DELETE FROM [dbo].[TBMATERIA]
													WHERE [ID] =                    @ID";

        protected override string SelectCommand => @"SELECT    M.[ID]                   MATERIA_ID
                                                              ,M.[NOME]                 MATERIA_NOME
                                                              ,M.[DISCIPLINA_ID]        MATERIA_DISCIPLINA_ID
                                                              ,M.[SERIE]                MATERIA_SERIE

                                                              ,D.[ID]                   DISCIPLINA_ID
                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBMATERIA] AS M

                                                          INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                          ON M.DISCIPLINA_ID =          D.ID

                                                          WHERE [ID] =                   @ID";

        protected override string SelectAllCommand => @"SELECT     M.[ID]                   MATERIA_ID
                                                                  ,M.[NOME]                 MATERIA_NOME
                                                                  ,M.[DISCIPLINA_ID]        MATERIA_DISCIPLINA_ID
                                                                  ,M.[SERIE]                MATERIA_SERIE

                                                                  ,D.[ID]                   DISCIPLINA_ID
                                                                  ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBMATERIA] AS M

                                                          INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                          ON M.DISCIPLINA_ID =          D.ID";

        protected string AddDisciplina => @"INSERT INTO [dbo].[TBDISCIPLINA_TBMATERIA]
                                                        (
                                                             [DISCIPLINA_ID]
                                                            ,[MATERIA_ID]
                                                        )
                                                    VALUES
                                                        (
                                                              @DISCIPLINA_ID
                                                             ,@MATERIA_ID
                                                        )";

        protected string EditAlternativas => @"UPDATE [dbo].[TBDISCIPLINA_TBMATERIA]

                                                   SET
                                                        [DISCIPLINA_ID] =      @DISCIPLINA_ID

                                                 WHERE
                                                        MATERIA_ID =         @MATERIA_ID";

        protected string DeleteDisciplina => @"DELETE FROM [dbo].[TBDISCIPLINA_TBMATERIA] 
                                                   INNER JOIN [dbo].[TBDISCIPLINA]
                                                   ON TBDISCIPLINA_TBMATERIA.DISCIPLINA_ID =          TBDISCIPLINA.ID";

        protected string SelectDisciplina => @"SELECT   DM.  [DISCIPLINA_ID]
		                                               ,DM.  [MATERIA_ID]

		                                               ,D.[ID]       DISCIPLINA_ID              
                                                       ,D.[NOME]     DISCIPLINA_NOME            
		 
                                                     FROM [dbo].[TBDISCIPLINA_TBMATERIA] AS DM
                                                     INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                     ON DM.[DISCIPLINA_ID] =     D.[ID]
                                                     WHERE [MATERIA_ID] =      @ID";

        private void AdicionarDisciplina(Materia materia)
        {
                comandoBd.CommandText = AddDisciplina;

                comandoBd.Parameters.Clear();
                comandoBd.Parameters.AddWithValue("DISCIPLINA_ID", materia.Disciplina.Id);
                comandoBd.Parameters.AddWithValue("MATERIA_ID", materia.Id);

                comandoBd.ExecuteNonQuery();
        }

        private void EditarDisciplina(Materia materia)
        {
            comandoBd.CommandText = DeleteDisciplina;

            comandoBd.Parameters.Clear();
            comandoBd.Parameters.AddWithValue("ID", materia.Disciplina.Id);
            comandoBd.ExecuteNonQuery();

            comandoBd.CommandText = AddDisciplina;

            comandoBd.Parameters.Clear();
            comandoBd.Parameters.AddWithValue("DISCIPLINA_ID", materia.Disciplina.Id);
            comandoBd.Parameters.AddWithValue("MATERIA_ID", materia.Id);

            comandoBd.ExecuteNonQuery();
        }

        private void ObterDisciplina(List<Materia> materias, SqlDataReader reader)
        {
            comandoBd.CommandText = SelectDisciplina;

            foreach (Materia materia in materias)
            {
                comandoBd.Parameters.Clear();
                comandoBd.Parameters.AddWithValue("ID", materia.Id);

                reader = comandoBd.ExecuteReader();

                if (reader.Read() == true)
                {
                    MapeadorDisciplina mapeadorDisciplina = new();

                    materia.Disciplina = mapeadorDisciplina.ConverterRegistro(reader);
                }
                

                reader.Close();
            }
        }

        protected override MapeadorBase<Materia> Mapear => new MapeadorMateria();
    }
}
