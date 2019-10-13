
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/13/2019 11:34:14
-- Generated from EDMX file: C:\Users\14790\source\repos\FIT5032AssVer2\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-FIT5032AssVer2-20191013113026];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Dob] nvarchar(max)  NOT NULL,
    [UserId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Discription] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EventRegisters'
CREATE TABLE [dbo].[EventRegisters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RegisterDate] nvarchar(max)  NOT NULL,
    [CustomerId] int  NOT NULL,
    [EventId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EventRegisters'
ALTER TABLE [dbo].[EventRegisters]
ADD CONSTRAINT [PK_EventRegisters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'EventRegisters'
ALTER TABLE [dbo].[EventRegisters]
ADD CONSTRAINT [FK_CustomerEventRegister]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerEventRegister'
CREATE INDEX [IX_FK_CustomerEventRegister]
ON [dbo].[EventRegisters]
    ([CustomerId]);
GO

-- Creating foreign key on [EventId] in table 'EventRegisters'
ALTER TABLE [dbo].[EventRegisters]
ADD CONSTRAINT [FK_EventEventRegister]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventEventRegister'
CREATE INDEX [IX_FK_EventEventRegister]
ON [dbo].[EventRegisters]
    ([EventId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------