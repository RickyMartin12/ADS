
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/28/2015 12:10:41
-- Generated from EDMX file: c:\users\rpsr\documents\visual studio 2013\Projects\Algarve Destino Seguro - BackOffice\Algarve Destino Seguro\Models\Database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ADS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TopicTheme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Topic] DROP CONSTRAINT [FK_TopicTheme];
GO
IF OBJECT_ID(N'[dbo].[FK_SubTopicTopic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubTopic] DROP CONSTRAINT [FK_SubTopicTopic];
GO
IF OBJECT_ID(N'[dbo].[FK_ThemeContentTheme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ThemeContent] DROP CONSTRAINT [FK_ThemeContentTheme];
GO
IF OBJECT_ID(N'[dbo].[FK_ThemeContentLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ThemeContent] DROP CONSTRAINT [FK_ThemeContentLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_TopicContentTopic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicContent] DROP CONSTRAINT [FK_TopicContentTopic];
GO
IF OBJECT_ID(N'[dbo].[FK_TopicContentLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicContent] DROP CONSTRAINT [FK_TopicContentLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_SubTopicContentSubTopic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubTopicContent] DROP CONSTRAINT [FK_SubTopicContentSubTopic];
GO
IF OBJECT_ID(N'[dbo].[FK_SubTopicContentLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubTopicContent] DROP CONSTRAINT [FK_SubTopicContentLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_PhraseLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Phrase] DROP CONSTRAINT [FK_PhraseLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_PhrasePhrase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Phrase] DROP CONSTRAINT [FK_PhrasePhrase];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityTypeLanguageLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityTypeLanguage] DROP CONSTRAINT [FK_EntityTypeLanguageLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityTypeLanguageEntityType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityTypeLanguage] DROP CONSTRAINT [FK_EntityTypeLanguageEntityType];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryLanguageLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CountryLanguage] DROP CONSTRAINT [FK_CountryLanguageLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryLanguageCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CountryLanguage] DROP CONSTRAINT [FK_CountryLanguageCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entity] DROP CONSTRAINT [FK_EntityCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityEntityType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entity] DROP CONSTRAINT [FK_EntityEntityType];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityVertex]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entity] DROP CONSTRAINT [FK_EntityVertex];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityLanguageLanguage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityLanguage] DROP CONSTRAINT [FK_EntityLanguageLanguage];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityLanguageEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityLanguage] DROP CONSTRAINT [FK_EntityLanguageEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_IdentifiedZoneVertex]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IdentifiedZone] DROP CONSTRAINT [FK_IdentifiedZoneVertex];
GO
IF OBJECT_ID(N'[dbo].[FK_IdentifiedZoneScheduleIdentifiedZoneType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IdentifiedZoneSchedule] DROP CONSTRAINT [FK_IdentifiedZoneScheduleIdentifiedZoneType];
GO
IF OBJECT_ID(N'[dbo].[FK_IdentifiedZoneScheduleIdentifiedZone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IdentifiedZoneSchedule] DROP CONSTRAINT [FK_IdentifiedZoneScheduleIdentifiedZone];
GO
IF OBJECT_ID(N'[dbo].[FK_CommunicationCommunicationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Communication] DROP CONSTRAINT [FK_CommunicationCommunicationType];
GO
IF OBJECT_ID(N'[dbo].[FK_CommunicationCommunicationState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Communication] DROP CONSTRAINT [FK_CommunicationCommunicationState];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Theme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Theme];
GO
IF OBJECT_ID(N'[dbo].[Topic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Topic];
GO
IF OBJECT_ID(N'[dbo].[SubTopic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubTopic];
GO
IF OBJECT_ID(N'[dbo].[Language]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Language];
GO
IF OBJECT_ID(N'[dbo].[ThemeContent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ThemeContent];
GO
IF OBJECT_ID(N'[dbo].[TopicContent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TopicContent];
GO
IF OBJECT_ID(N'[dbo].[SubTopicContent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubTopicContent];
GO
IF OBJECT_ID(N'[dbo].[Phrase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phrase];
GO
IF OBJECT_ID(N'[dbo].[EntityType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntityType];
GO
IF OBJECT_ID(N'[dbo].[EntityTypeLanguage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntityTypeLanguage];
GO
IF OBJECT_ID(N'[dbo].[Vertex]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vertex];
GO
IF OBJECT_ID(N'[dbo].[Entity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Entity];
GO
IF OBJECT_ID(N'[dbo].[Country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Country];
GO
IF OBJECT_ID(N'[dbo].[CountryLanguage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CountryLanguage];
GO
IF OBJECT_ID(N'[dbo].[EntityLanguage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntityLanguage];
GO
IF OBJECT_ID(N'[dbo].[IdentifiedZone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IdentifiedZone];
GO
IF OBJECT_ID(N'[dbo].[IdentifiedZoneType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IdentifiedZoneType];
GO
IF OBJECT_ID(N'[dbo].[IdentifiedZoneSchedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IdentifiedZoneSchedule];
GO
IF OBJECT_ID(N'[dbo].[CommunicationType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommunicationType];
GO
IF OBJECT_ID(N'[dbo].[CommunicationState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommunicationState];
GO
IF OBJECT_ID(N'[dbo].[Communication]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Communication];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Theme'
CREATE TABLE [dbo].[Theme] (
    [Title] nvarchar(64)  NOT NULL,
    [Description] nvarchar(128)  NULL,
    [Visibility] bit  NOT NULL,
    [Icon] nvarchar(512)  NULL
);
GO

-- Creating table 'Topic'
CREATE TABLE [dbo].[Topic] (
    [ThemeTitle] nvarchar(64)  NOT NULL,
    [Title] nvarchar(64)  NOT NULL,
    [Description] nvarchar(128)  NULL,
    [Visibility] bit  NOT NULL,
    [Icon] nvarchar(512)  NULL
);
GO

-- Creating table 'SubTopic'
CREATE TABLE [dbo].[SubTopic] (
    [TopicThemeTitle] nvarchar(64)  NOT NULL,
    [TopicTitle] nvarchar(64)  NOT NULL,
    [Title] nvarchar(64)  NOT NULL,
    [Description] nvarchar(128)  NULL,
    [Visibility] bit  NOT NULL,
    [Icon] nvarchar(512)  NULL
);
GO

-- Creating table 'Language'
CREATE TABLE [dbo].[Language] (
    [Code] nvarchar(8)  NOT NULL,
    [Name] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'ThemeContent'
CREATE TABLE [dbo].[ThemeContent] (
    [ThemeTitle] nvarchar(64)  NOT NULL,
    [LanguageCode] nvarchar(8)  NOT NULL,
    [TranslatedTitle] nvarchar(64)  NOT NULL,
    [Visibility] bit  NOT NULL,
    [Document] nvarchar(512)  NULL
);
GO

-- Creating table 'TopicContent'
CREATE TABLE [dbo].[TopicContent] (
    [TopicTitle] nvarchar(64)  NOT NULL,
    [TopicThemeTitle] nvarchar(64)  NOT NULL,
    [LanguageCode] nvarchar(8)  NOT NULL,
    [TranslatedTitle] nvarchar(64)  NOT NULL,
    [Visibility] bit  NOT NULL,
    [Document] nvarchar(512)  NULL
);
GO

-- Creating table 'SubTopicContent'
CREATE TABLE [dbo].[SubTopicContent] (
    [SubTopicTitle] nvarchar(64)  NOT NULL,
    [SubTopicTopicTitle] nvarchar(64)  NOT NULL,
    [SubTopicTopicThemeTitle] nvarchar(64)  NOT NULL,
    [LanguageCode] nvarchar(8)  NOT NULL,
    [TranslatedTitle] nvarchar(64)  NOT NULL,
    [Visibility] bit  NOT NULL,
    [Document] nvarchar(512)  NULL
);
GO

-- Creating table 'Phrase'
CREATE TABLE [dbo].[Phrase] (
    [Code] nvarchar(64)  NOT NULL,
    [LanguageCode] nvarchar(8)  NOT NULL,
    [PhraseCode] nvarchar(64)  NULL,
    [Content] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'EntityType'
CREATE TABLE [dbo].[EntityType] (
    [Name] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'EntityTypeLanguage'
CREATE TABLE [dbo].[EntityTypeLanguage] (
    [LanguageCode] nvarchar(8)  NOT NULL,
    [EntityTypeName] nvarchar(64)  NOT NULL,
    [TranslateName] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'Vertex'
CREATE TABLE [dbo].[Vertex] (
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL
);
GO

-- Creating table 'Entity'
CREATE TABLE [dbo].[Entity] (
    [Name] nvarchar(128)  NOT NULL,
    [ZipCode] nvarchar(8)  NOT NULL,
    [CountryCode] int  NOT NULL,
    [EntityTypeName] nvarchar(64)  NOT NULL,
    [VertexLatitude] float  NOT NULL,
    [VertexLongitude] float  NOT NULL,
    [Phone] bigint  NOT NULL,
    [Address] nvarchar(128)  NOT NULL,
    [Attachment] nvarchar(512)  NULL
);
GO

-- Creating table 'Country'
CREATE TABLE [dbo].[Country] (
    [Code] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'CountryLanguage'
CREATE TABLE [dbo].[CountryLanguage] (
    [LanguageCode] nvarchar(8)  NOT NULL,
    [CountryCode] int  NOT NULL
);
GO

-- Creating table 'EntityLanguage'
CREATE TABLE [dbo].[EntityLanguage] (
    [LanguageCode] nvarchar(8)  NOT NULL,
    [EntityName] nvarchar(128)  NOT NULL,
    [EntityZipCode] nvarchar(8)  NOT NULL,
    [TranslatedName] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'IdentifiedZone'
CREATE TABLE [dbo].[IdentifiedZone] (
    [Name] nvarchar(64)  NOT NULL,
    [Radius] float  NOT NULL,
    [Vertex_Latitude] float  NOT NULL,
    [Vertex_Longitude] float  NOT NULL
);
GO

-- Creating table 'IdentifiedZoneType'
CREATE TABLE [dbo].[IdentifiedZoneType] (
    [Name] nvarchar(64)  NOT NULL,
    [Notification] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'IdentifiedZoneSchedule'
CREATE TABLE [dbo].[IdentifiedZoneSchedule] (
    [IdentifiedZoneTypeName] nvarchar(64)  NOT NULL,
    [IdentifiedZoneName] nvarchar(64)  NOT NULL,
    [Start] time  NOT NULL,
    [End] time  NOT NULL
);
GO

-- Creating table 'CommunicationType'
CREATE TABLE [dbo].[CommunicationType] (
    [Name] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'CommunicationState'
CREATE TABLE [dbo].[CommunicationState] (
    [Name] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'Communication'
CREATE TABLE [dbo].[Communication] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [CommunicationTypeName] nvarchar(64)  NOT NULL,
    [CommunicationStateName] nvarchar(64)  NOT NULL,
    [Subject] nvarchar(64)  NOT NULL,
    [Content] nvarchar(256)  NOT NULL,
    [Attachment] nvarchar(512)  NULL,
    [SenderName] nvarchar(64)  NULL,
    [SenderEmail] nvarchar(128)  NULL,
    [SentOn] datetime  NOT NULL,
    [ReceivedOn] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Title] in table 'Theme'
ALTER TABLE [dbo].[Theme]
ADD CONSTRAINT [PK_Theme]
    PRIMARY KEY CLUSTERED ([Title] ASC);
GO

-- Creating primary key on [Title], [ThemeTitle] in table 'Topic'
ALTER TABLE [dbo].[Topic]
ADD CONSTRAINT [PK_Topic]
    PRIMARY KEY CLUSTERED ([Title], [ThemeTitle] ASC);
GO

-- Creating primary key on [Title], [TopicTitle], [TopicThemeTitle] in table 'SubTopic'
ALTER TABLE [dbo].[SubTopic]
ADD CONSTRAINT [PK_SubTopic]
    PRIMARY KEY CLUSTERED ([Title], [TopicTitle], [TopicThemeTitle] ASC);
GO

-- Creating primary key on [Code] in table 'Language'
ALTER TABLE [dbo].[Language]
ADD CONSTRAINT [PK_Language]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [ThemeTitle], [LanguageCode] in table 'ThemeContent'
ALTER TABLE [dbo].[ThemeContent]
ADD CONSTRAINT [PK_ThemeContent]
    PRIMARY KEY CLUSTERED ([ThemeTitle], [LanguageCode] ASC);
GO

-- Creating primary key on [TopicTitle], [TopicThemeTitle], [LanguageCode] in table 'TopicContent'
ALTER TABLE [dbo].[TopicContent]
ADD CONSTRAINT [PK_TopicContent]
    PRIMARY KEY CLUSTERED ([TopicTitle], [TopicThemeTitle], [LanguageCode] ASC);
GO

-- Creating primary key on [SubTopicTitle], [SubTopicTopicTitle], [SubTopicTopicThemeTitle], [LanguageCode] in table 'SubTopicContent'
ALTER TABLE [dbo].[SubTopicContent]
ADD CONSTRAINT [PK_SubTopicContent]
    PRIMARY KEY CLUSTERED ([SubTopicTitle], [SubTopicTopicTitle], [SubTopicTopicThemeTitle], [LanguageCode] ASC);
GO

-- Creating primary key on [Code] in table 'Phrase'
ALTER TABLE [dbo].[Phrase]
ADD CONSTRAINT [PK_Phrase]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [Name] in table 'EntityType'
ALTER TABLE [dbo].[EntityType]
ADD CONSTRAINT [PK_EntityType]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [LanguageCode], [EntityTypeName] in table 'EntityTypeLanguage'
ALTER TABLE [dbo].[EntityTypeLanguage]
ADD CONSTRAINT [PK_EntityTypeLanguage]
    PRIMARY KEY CLUSTERED ([LanguageCode], [EntityTypeName] ASC);
GO

-- Creating primary key on [Latitude], [Longitude] in table 'Vertex'
ALTER TABLE [dbo].[Vertex]
ADD CONSTRAINT [PK_Vertex]
    PRIMARY KEY CLUSTERED ([Latitude], [Longitude] ASC);
GO

-- Creating primary key on [Name], [ZipCode] in table 'Entity'
ALTER TABLE [dbo].[Entity]
ADD CONSTRAINT [PK_Entity]
    PRIMARY KEY CLUSTERED ([Name], [ZipCode] ASC);
GO

-- Creating primary key on [Code] in table 'Country'
ALTER TABLE [dbo].[Country]
ADD CONSTRAINT [PK_Country]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [LanguageCode], [CountryCode] in table 'CountryLanguage'
ALTER TABLE [dbo].[CountryLanguage]
ADD CONSTRAINT [PK_CountryLanguage]
    PRIMARY KEY CLUSTERED ([LanguageCode], [CountryCode] ASC);
GO

-- Creating primary key on [LanguageCode], [EntityName], [EntityZipCode] in table 'EntityLanguage'
ALTER TABLE [dbo].[EntityLanguage]
ADD CONSTRAINT [PK_EntityLanguage]
    PRIMARY KEY CLUSTERED ([LanguageCode], [EntityName], [EntityZipCode] ASC);
GO

-- Creating primary key on [Name] in table 'IdentifiedZone'
ALTER TABLE [dbo].[IdentifiedZone]
ADD CONSTRAINT [PK_IdentifiedZone]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [Name] in table 'IdentifiedZoneType'
ALTER TABLE [dbo].[IdentifiedZoneType]
ADD CONSTRAINT [PK_IdentifiedZoneType]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [IdentifiedZoneTypeName], [IdentifiedZoneName] in table 'IdentifiedZoneSchedule'
ALTER TABLE [dbo].[IdentifiedZoneSchedule]
ADD CONSTRAINT [PK_IdentifiedZoneSchedule]
    PRIMARY KEY CLUSTERED ([IdentifiedZoneTypeName], [IdentifiedZoneName] ASC);
GO

-- Creating primary key on [Name] in table 'CommunicationType'
ALTER TABLE [dbo].[CommunicationType]
ADD CONSTRAINT [PK_CommunicationType]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [Name] in table 'CommunicationState'
ALTER TABLE [dbo].[CommunicationState]
ADD CONSTRAINT [PK_CommunicationState]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [ID] in table 'Communication'
ALTER TABLE [dbo].[Communication]
ADD CONSTRAINT [PK_Communication]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ThemeTitle] in table 'Topic'
ALTER TABLE [dbo].[Topic]
ADD CONSTRAINT [FK_TopicTheme]
    FOREIGN KEY ([ThemeTitle])
    REFERENCES [dbo].[Theme]
        ([Title])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicTheme'
CREATE INDEX [IX_FK_TopicTheme]
ON [dbo].[Topic]
    ([ThemeTitle]);
GO

-- Creating foreign key on [TopicTitle], [TopicThemeTitle] in table 'SubTopic'
ALTER TABLE [dbo].[SubTopic]
ADD CONSTRAINT [FK_SubTopicTopic]
    FOREIGN KEY ([TopicTitle], [TopicThemeTitle])
    REFERENCES [dbo].[Topic]
        ([Title], [ThemeTitle])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubTopicTopic'
CREATE INDEX [IX_FK_SubTopicTopic]
ON [dbo].[SubTopic]
    ([TopicTitle], [TopicThemeTitle]);
GO

-- Creating foreign key on [ThemeTitle] in table 'ThemeContent'
ALTER TABLE [dbo].[ThemeContent]
ADD CONSTRAINT [FK_ThemeContentTheme]
    FOREIGN KEY ([ThemeTitle])
    REFERENCES [dbo].[Theme]
        ([Title])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LanguageCode] in table 'ThemeContent'
ALTER TABLE [dbo].[ThemeContent]
ADD CONSTRAINT [FK_ThemeContentLanguage]
    FOREIGN KEY ([LanguageCode])
    REFERENCES [dbo].[Language]
        ([Code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ThemeContentLanguage'
CREATE INDEX [IX_FK_ThemeContentLanguage]
ON [dbo].[ThemeContent]
    ([LanguageCode]);
GO

-- Creating foreign key on [TopicTitle], [TopicThemeTitle] in table 'TopicContent'
ALTER TABLE [dbo].[TopicContent]
ADD CONSTRAINT [FK_TopicContentTopic]
    FOREIGN KEY ([TopicTitle], [TopicThemeTitle])
    REFERENCES [dbo].[Topic]
        ([Title], [ThemeTitle])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LanguageCode] in table 'TopicContent'
ALTER TABLE [dbo].[TopicContent]
ADD CONSTRAINT [FK_TopicContentLanguage]
    FOREIGN KEY ([LanguageCode])
    REFERENCES [dbo].[Language]
        ([Code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicContentLanguage'
CREATE INDEX [IX_FK_TopicContentLanguage]
ON [dbo].[TopicContent]
    ([LanguageCode]);
GO

-- Creating foreign key on [SubTopicTitle], [SubTopicTopicTitle], [SubTopicTopicThemeTitle] in table 'SubTopicContent'
ALTER TABLE [dbo].[SubTopicContent]
ADD CONSTRAINT [FK_SubTopicContentSubTopic]
    FOREIGN KEY ([SubTopicTitle], [SubTopicTopicTitle], [SubTopicTopicThemeTitle])
    REFERENCES [dbo].[SubTopic]
        ([Title], [TopicTitle], [TopicThemeTitle])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LanguageCode] in table 'SubTopicContent'
ALTER TABLE [dbo].[SubTopicContent]
ADD CONSTRAINT [FK_SubTopicContentLanguage]
    FOREIGN KEY ([LanguageCode])
    REFERENCES [dbo].[Language]
        ([Code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubTopicContentLanguage'
CREATE INDEX [IX_FK_SubTopicContentLanguage]
ON [dbo].[SubTopicContent]
    ([LanguageCode]);
GO

-- Creating foreign key on [LanguageCode] in table 'Phrase'
ALTER TABLE [dbo].[Phrase]
ADD CONSTRAINT [FK_PhraseLanguage]
    FOREIGN KEY ([LanguageCode])
    REFERENCES [dbo].[Language]
        ([Code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhraseLanguage'
CREATE INDEX [IX_FK_PhraseLanguage]
ON [dbo].[Phrase]
    ([LanguageCode]);
GO

-- Creating foreign key on [PhraseCode] in table 'Phrase'
ALTER TABLE [dbo].[Phrase]
ADD CONSTRAINT [FK_PhrasePhrase]
    FOREIGN KEY ([PhraseCode])
    REFERENCES [dbo].[Phrase]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhrasePhrase'
CREATE INDEX [IX_FK_PhrasePhrase]
ON [dbo].[Phrase]
    ([PhraseCode]);
GO

-- Creating foreign key on [LanguageCode] in table 'EntityTypeLanguage'
ALTER TABLE [dbo].[EntityTypeLanguage]
ADD CONSTRAINT [FK_EntityTypeLanguageLanguage]
    FOREIGN KEY ([LanguageCode])
    REFERENCES [dbo].[Language]
        ([Code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EntityTypeName] in table 'EntityTypeLanguage'
ALTER TABLE [dbo].[EntityTypeLanguage]
ADD CONSTRAINT [FK_EntityTypeLanguageEntityType]
    FOREIGN KEY ([EntityTypeName])
    REFERENCES [dbo].[EntityType]
        ([Name])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntityTypeLanguageEntityType'
CREATE INDEX [IX_FK_EntityTypeLanguageEntityType]
ON [dbo].[EntityTypeLanguage]
    ([EntityTypeName]);
GO

-- Creating foreign key on [LanguageCode] in table 'CountryLanguage'
ALTER TABLE [dbo].[CountryLanguage]
ADD CONSTRAINT [FK_CountryLanguageLanguage]
    FOREIGN KEY ([LanguageCode])
    REFERENCES [dbo].[Language]
        ([Code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CountryCode] in table 'CountryLanguage'
ALTER TABLE [dbo].[CountryLanguage]
ADD CONSTRAINT [FK_CountryLanguageCountry]
    FOREIGN KEY ([CountryCode])
    REFERENCES [dbo].[Country]
        ([Code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryLanguageCountry'
CREATE INDEX [IX_FK_CountryLanguageCountry]
ON [dbo].[CountryLanguage]
    ([CountryCode]);
GO

-- Creating foreign key on [CountryCode] in table 'Entity'
ALTER TABLE [dbo].[Entity]
ADD CONSTRAINT [FK_EntityCountry]
    FOREIGN KEY ([CountryCode])
    REFERENCES [dbo].[Country]
        ([Code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntityCountry'
CREATE INDEX [IX_FK_EntityCountry]
ON [dbo].[Entity]
    ([CountryCode]);
GO

-- Creating foreign key on [EntityTypeName] in table 'Entity'
ALTER TABLE [dbo].[Entity]
ADD CONSTRAINT [FK_EntityEntityType]
    FOREIGN KEY ([EntityTypeName])
    REFERENCES [dbo].[EntityType]
        ([Name])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntityEntityType'
CREATE INDEX [IX_FK_EntityEntityType]
ON [dbo].[Entity]
    ([EntityTypeName]);
GO

-- Creating foreign key on [VertexLatitude], [VertexLongitude] in table 'Entity'
ALTER TABLE [dbo].[Entity]
ADD CONSTRAINT [FK_EntityVertex]
    FOREIGN KEY ([VertexLatitude], [VertexLongitude])
    REFERENCES [dbo].[Vertex]
        ([Latitude], [Longitude])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntityVertex'
CREATE INDEX [IX_FK_EntityVertex]
ON [dbo].[Entity]
    ([VertexLatitude], [VertexLongitude]);
GO

-- Creating foreign key on [LanguageCode] in table 'EntityLanguage'
ALTER TABLE [dbo].[EntityLanguage]
ADD CONSTRAINT [FK_EntityLanguageLanguage]
    FOREIGN KEY ([LanguageCode])
    REFERENCES [dbo].[Language]
        ([Code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EntityName], [EntityZipCode] in table 'EntityLanguage'
ALTER TABLE [dbo].[EntityLanguage]
ADD CONSTRAINT [FK_EntityLanguageEntity]
    FOREIGN KEY ([EntityName], [EntityZipCode])
    REFERENCES [dbo].[Entity]
        ([Name], [ZipCode])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntityLanguageEntity'
CREATE INDEX [IX_FK_EntityLanguageEntity]
ON [dbo].[EntityLanguage]
    ([EntityName], [EntityZipCode]);
GO

-- Creating foreign key on [Vertex_Latitude], [Vertex_Longitude] in table 'IdentifiedZone'
ALTER TABLE [dbo].[IdentifiedZone]
ADD CONSTRAINT [FK_IdentifiedZoneVertex]
    FOREIGN KEY ([Vertex_Latitude], [Vertex_Longitude])
    REFERENCES [dbo].[Vertex]
        ([Latitude], [Longitude])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IdentifiedZoneVertex'
CREATE INDEX [IX_FK_IdentifiedZoneVertex]
ON [dbo].[IdentifiedZone]
    ([Vertex_Latitude], [Vertex_Longitude]);
GO

-- Creating foreign key on [IdentifiedZoneTypeName] in table 'IdentifiedZoneSchedule'
ALTER TABLE [dbo].[IdentifiedZoneSchedule]
ADD CONSTRAINT [FK_IdentifiedZoneScheduleIdentifiedZoneType]
    FOREIGN KEY ([IdentifiedZoneTypeName])
    REFERENCES [dbo].[IdentifiedZoneType]
        ([Name])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdentifiedZoneName] in table 'IdentifiedZoneSchedule'
ALTER TABLE [dbo].[IdentifiedZoneSchedule]
ADD CONSTRAINT [FK_IdentifiedZoneScheduleIdentifiedZone]
    FOREIGN KEY ([IdentifiedZoneName])
    REFERENCES [dbo].[IdentifiedZone]
        ([Name])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IdentifiedZoneScheduleIdentifiedZone'
CREATE INDEX [IX_FK_IdentifiedZoneScheduleIdentifiedZone]
ON [dbo].[IdentifiedZoneSchedule]
    ([IdentifiedZoneName]);
GO

-- Creating foreign key on [CommunicationTypeName] in table 'Communication'
ALTER TABLE [dbo].[Communication]
ADD CONSTRAINT [FK_CommunicationCommunicationType]
    FOREIGN KEY ([CommunicationTypeName])
    REFERENCES [dbo].[CommunicationType]
        ([Name])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommunicationCommunicationType'
CREATE INDEX [IX_FK_CommunicationCommunicationType]
ON [dbo].[Communication]
    ([CommunicationTypeName]);
GO

-- Creating foreign key on [CommunicationStateName] in table 'Communication'
ALTER TABLE [dbo].[Communication]
ADD CONSTRAINT [FK_CommunicationCommunicationState]
    FOREIGN KEY ([CommunicationStateName])
    REFERENCES [dbo].[CommunicationState]
        ([Name])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommunicationCommunicationState'
CREATE INDEX [IX_FK_CommunicationCommunicationState]
ON [dbo].[Communication]
    ([CommunicationStateName]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------