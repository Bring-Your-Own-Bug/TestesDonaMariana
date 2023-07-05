using TestesDonaMariana.Dominio.ModuloTeste;

namespace TestesDonaMariana.Dados.ModuloTeste
{
    public class RepositorioTeste : RepositorioBaseSql<Teste>
    {
        protected override string AddCommand => @"INSERT INTO [dbo].[TBTESTE]
                                                           (
                                                                [TITULO]
                                                               ,[NUMERODEQUESTOES]
                                                               ,[DISCIPLINA_ID]
                                                               ,[MATERIA_ID]
                                                               ,[LISTA_QUESTAO_ID]
                                                               ,[DATAGERACAO_ID]
                                                           )
                                                     VALUES
                                                           (
                                                                 @TITULO
                                                                ,@NUMERODEQUESTOES
                                                                ,@DISCIPLINA_ID
                                                                ,@MATERIA_ID
                                                                ,@LISTA_QUESTAO_ID
                                                                ,@DATAGERACAO_ID
                                                           )
                                                           SELECT SCOPE_IDENTITY();";

        protected override string EditCommand => throw new NotImplementedException();

        protected override string DeleteCommand => throw new NotImplementedException();

        protected override string SelectCommand => throw new NotImplementedException();

        protected override string SelectAllCommand => throw new NotImplementedException();

        protected override MapeadorBase<Teste> Mapear => new MapeadorTeste();
    }
}
