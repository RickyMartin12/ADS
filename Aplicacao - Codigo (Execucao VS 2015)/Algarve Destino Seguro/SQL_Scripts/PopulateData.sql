SET QUOTED_IDENTIFIER OFF;
GO
USE [ADS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

INSERT INTO [dbo].[Theme] ([Title], [Visibility]) VALUES (N'Conselhos de Segurança', 0)
INSERT INTO [dbo].[Theme] ([Title], [Visibility]) VALUES (N'Fui Vítima de Crime', 0)
INSERT INTO [dbo].[Theme] ([Title], [Visibility]) VALUES (N'Tenho um Problema', 0)
