using Microsoft.Data.SqlClient;
using TestesDonaMariana.Dados.ModuloMateria;
using TestesDonaMariana.Dominio.ModuloDisciplina;
using TestesDonaMariana.Dominio.ModuloMateria;

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

        protected override string SelectCommand => @"SELECT    D.[ID]                   DISCIPLINA_ID
                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBDISCIPLINA] AS D

													      WHERE [ID] =                  @ID";

        protected override string SelectAllCommand => @"SELECT D.[ID]                   DISCIPLINA_ID
                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBDISCIPLINA] AS D";

        protected string SelectMaterias => @"SELECT            M.[ID]                   MATERIA_ID
                                                              ,M.[NOME]                 MATERIA_NOME
                                                              ,M.[DISCIPLINA_ID]        MATERIA_DISCIPLINA_ID
                                                              ,M.[SERIE]                MATERIA_SERIE

                                                              ,D.[ID]                   DISCIPLINA_ID
                                                              ,D.[NOME]                 DISCIPLINA_NOME

                                                          FROM [dbo].[TBMATERIA] AS M

                                                          INNER JOIN [dbo].[TBDISCIPLINA] AS D
                                                          ON M.DISCIPLINA_ID =          D.ID

                                                          WHERE [DISCIPLINA_ID] =                   @ID";

        public List<Materia> ObterMaterias(Disciplina disciplina)
        {
            conectarBd.Open();

            comandoBd.CommandText = SelectMaterias;

            comandoBd.Parameters.AddWithValue("ID", disciplina.Id);

            SqlDataReader reader = comandoBd.ExecuteReader();

            List<Materia> materias = new();

            while (reader.Read())
            {
                Materia materia = new MapeadorMateria().ConverterRegistro(reader);
                materias.Add(materia);
            }

            conectarBd.Close();

            return materias;
        }

        protected override MapeadorBase<Disciplina> Mapear => new MapeadorDisciplina();
    }
}
