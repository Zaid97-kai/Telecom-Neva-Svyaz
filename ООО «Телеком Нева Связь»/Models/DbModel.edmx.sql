
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/07/2022 20:59:43
-- Generated from EDMX file: C:\Users\zzmin\source\repos\-\Сессия 2\ООО «Телеком Нева Связь»\Models\DbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DbUsers];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CrmRequests_Subscribers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CrmRequests] DROP CONSTRAINT [FK_CrmRequests_Subscribers];
GO
IF OBJECT_ID(N'[dbo].[FK_SubscriberAdress_Subscribers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubscriberAdress] DROP CONSTRAINT [FK_SubscriberAdress_Subscribers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CrmRequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CrmRequests];
GO
IF OBJECT_ID(N'[dbo].[EmploeeEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmploeeEvents];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[SpbDistricts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpbDistricts];
GO
IF OBJECT_ID(N'[dbo].[SubscriberAdress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubscriberAdress];
GO
IF OBJECT_ID(N'[dbo].[Subscribers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subscribers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CrmRequests'
CREATE TABLE [dbo].[CrmRequests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RequestNumber] nvarchar(50)  NULL,
    [Date] datetime  NULL,
    [SubscriberId] int  NOT NULL,
    [Service] nvarchar(50)  NULL,
    [ServiceKindOf] nvarchar(100)  NULL,
    [ServiceType] nvarchar(100)  NULL,
    [Status] nvarchar(50)  NULL,
    [Type] nvarchar(50)  NULL,
    [ProblemDescription] nvarchar(50)  NULL,
    [CloseDate] datetime  NULL,
    [ProblemType] nvarchar(50)  NULL
);
GO

-- Creating table 'EmploeeEvents'
CREATE TABLE [dbo].[EmploeeEvents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmploeeType] nvarchar(50)  NULL,
    [Decription] nvarchar(100)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FIO] nvarchar(50)  NULL,
    [Type] nvarchar(50)  NULL,
    [Number] nvarchar(50)  NULL
);
GO

-- Creating table 'SpbDistricts'
CREATE TABLE [dbo].[SpbDistricts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'SubscriberAdress'
CREATE TABLE [dbo].[SubscriberAdress] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubscriberId] int  NULL,
    [Prefix_code] nvarchar(50)  NULL,
    [Raion] nvarchar(50)  NULL,
    [Prefix] nvarchar(100)  NULL,
    [House] nvarchar(50)  NULL
);
GO

-- Creating table 'Subscribers'
CREATE TABLE [dbo].[Subscribers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubscriberNumber] nvarchar(50)  NULL,
    [FIO] nvarchar(100)  NULL,
    [Gender] nvarchar(50)  NULL,
    [Birthday] datetime  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(100)  NULL,
    [PlaceOfResidence] nvarchar(100)  NULL,
    [ResidentialAddress] nvarchar(50)  NULL,
    [SeriesAndPassportNumber] nvarchar(50)  NULL,
    [DepartmentCode] nvarchar(50)  NULL,
    [IssuedBy] nvarchar(100)  NULL,
    [PassportIssueDate] datetime  NULL,
    [NumberOfContract] nvarchar(50)  NULL,
    [DateOfConclusionContract] datetime  NULL,
    [ContractType] nvarchar(50)  NULL,
    [ReasonForTermination] nvarchar(50)  NULL,
    [PersonalAccount] nvarchar(50)  NULL,
    [Services] nvarchar(50)  NULL,
    [ContractTerminationDate] datetime  NULL,
    [EquipmentRent] nvarchar(50)  NULL,
    [SerialNumberOfEquipment] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CrmRequests'
ALTER TABLE [dbo].[CrmRequests]
ADD CONSTRAINT [PK_CrmRequests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmploeeEvents'
ALTER TABLE [dbo].[EmploeeEvents]
ADD CONSTRAINT [PK_EmploeeEvents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpbDistricts'
ALTER TABLE [dbo].[SpbDistricts]
ADD CONSTRAINT [PK_SpbDistricts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubscriberAdress'
ALTER TABLE [dbo].[SubscriberAdress]
ADD CONSTRAINT [PK_SubscriberAdress]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Subscribers'
ALTER TABLE [dbo].[Subscribers]
ADD CONSTRAINT [PK_Subscribers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SubscriberId] in table 'CrmRequests'
ALTER TABLE [dbo].[CrmRequests]
ADD CONSTRAINT [FK_CrmRequests_Subscribers]
    FOREIGN KEY ([SubscriberId])
    REFERENCES [dbo].[Subscribers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CrmRequests_Subscribers'
CREATE INDEX [IX_FK_CrmRequests_Subscribers]
ON [dbo].[CrmRequests]
    ([SubscriberId]);
GO

-- Creating foreign key on [SubscriberId] in table 'SubscriberAdress'
ALTER TABLE [dbo].[SubscriberAdress]
ADD CONSTRAINT [FK_SubscriberAdress_Subscribers]
    FOREIGN KEY ([SubscriberId])
    REFERENCES [dbo].[Subscribers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubscriberAdress_Subscribers'
CREATE INDEX [IX_FK_SubscriberAdress_Subscribers]
ON [dbo].[SubscriberAdress]
    ([SubscriberId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------