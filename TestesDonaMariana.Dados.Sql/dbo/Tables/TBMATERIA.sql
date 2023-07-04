CREATE TABLE [dbo].[TBMATERIA] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [NOME]          VARCHAR (200) NOT NULL,
    [DISCIPLINA_ID] INT           NOT NULL,
    [SERIE]         INT           NOT NULL,
    CONSTRAINT [PK_TBMATERIA] PRIMARY KEY CLUSTERED ([ID] ASC)
);



