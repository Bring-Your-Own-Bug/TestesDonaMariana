﻿CREATE TABLE [dbo].[TBTESTE] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [TITULO]           VARCHAR (200) NOT NULL,
    [NUMERODEQUESTOES] INT           NOT NULL,
    [DISCIPLINA_ID]    INT           NOT NULL,
    [MATERIA_ID]       INT           NULL,
    [DATAGERACAO]      DATETIME      NOT NULL,
    CONSTRAINT [PK_TBTESTE] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TBTESTE_TBDISCIPLINA] FOREIGN KEY ([DISCIPLINA_ID]) REFERENCES [dbo].[TBDISCIPLINA] ([ID]),
    CONSTRAINT [FK_TBTESTE_TBMATERIA] FOREIGN KEY ([MATERIA_ID]) REFERENCES [dbo].[TBMATERIA] ([ID])
);



