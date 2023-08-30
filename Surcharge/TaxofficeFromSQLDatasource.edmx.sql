
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/27/2023 17:10:36
-- Generated from EDMX file: C:\Users\3060\source\repos\Surcharge\Surcharge\TaxofficeFromSQLDatasource.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InteractiveTaxOffice];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Ministries_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ministries] DROP CONSTRAINT [FK_Ministries_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentDetail_Citizen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentDetail] DROP CONSTRAINT [FK_PaymentDetail_Citizen];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentDetail_Taxes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentDetail] DROP CONSTRAINT [FK_PaymentDetail_Taxes];
GO
IF OBJECT_ID(N'[dbo].[FK_Taxes_Ministries]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Taxes] DROP CONSTRAINT [FK_Taxes_Ministries];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Citizen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Citizen];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Ministries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ministries];
GO
IF OBJECT_ID(N'[dbo].[PaymentDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentDetail];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Taxes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Taxes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Citizens'
CREATE TABLE [dbo].[Citizens] (
    [CitizenID] int IDENTITY(1,1) NOT NULL,
    [CitizenshipNo] nchar(11)  NOT NULL,
    [CitizenOccupation] nvarchar(50)  NULL,
    [CitizenAdress] nvarchar(150)  NULL,
    [CitizenPhoneNo] nchar(14)  NULL,
    [CitizenMail] nvarchar(50)  NULL,
    [CitizenPassword] nvarchar(15)  NULL,
    [CitizenBalance] decimal(19,4)  NULL,
    [NameSurname] nvarchar(50)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [EmployeeName] nvarchar(50)  NULL,
    [EmployeePassword] nvarchar(20)  NULL,
    [EmployeeTitle] nvarchar(50)  NULL
);
GO

-- Creating table 'Ministries'
CREATE TABLE [dbo].[Ministries] (
    [MinistryID] int IDENTITY(1,1) NOT NULL,
    [MinistryName] nvarchar(50)  NULL,
    [HeadOfDepartments] nvarchar(50)  NULL,
    [TotalEarnings] decimal(19,4)  NULL,
    [EmployeeID] int  NULL,
    [TaxID] int  NULL
);
GO

-- Creating table 'PaymentDetails'
CREATE TABLE [dbo].[PaymentDetails] (
    [PaymentDetailID] int IDENTITY(1,1) NOT NULL,
    [TaxAmount] decimal(19,4)  NULL,
    [Interest] decimal(19,4)  NULL,
    [TotalPayment] decimal(19,4)  NULL,
    [CitizenID] int  NULL,
    [TaxID] int  NULL,
    [PaymentDate] datetime  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Taxes'
CREATE TABLE [dbo].[Taxes] (
    [TaxID] int IDENTITY(1,1) NOT NULL,
    [TaxName] nvarchar(50)  NULL,
    [MinistryID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CitizenID] in table 'Citizens'
ALTER TABLE [dbo].[Citizens]
ADD CONSTRAINT [PK_Citizens]
    PRIMARY KEY CLUSTERED ([CitizenID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [MinistryID] in table 'Ministries'
ALTER TABLE [dbo].[Ministries]
ADD CONSTRAINT [PK_Ministries]
    PRIMARY KEY CLUSTERED ([MinistryID] ASC);
GO

-- Creating primary key on [PaymentDetailID] in table 'PaymentDetails'
ALTER TABLE [dbo].[PaymentDetails]
ADD CONSTRAINT [PK_PaymentDetails]
    PRIMARY KEY CLUSTERED ([PaymentDetailID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TaxID] in table 'Taxes'
ALTER TABLE [dbo].[Taxes]
ADD CONSTRAINT [PK_Taxes]
    PRIMARY KEY CLUSTERED ([TaxID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CitizenID] in table 'PaymentDetails'
ALTER TABLE [dbo].[PaymentDetails]
ADD CONSTRAINT [FK_PaymentDetail_Citizen]
    FOREIGN KEY ([CitizenID])
    REFERENCES [dbo].[Citizens]
        ([CitizenID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentDetail_Citizen'
CREATE INDEX [IX_FK_PaymentDetail_Citizen]
ON [dbo].[PaymentDetails]
    ([CitizenID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Ministries'
ALTER TABLE [dbo].[Ministries]
ADD CONSTRAINT [FK_Ministries_Employees]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ministries_Employees'
CREATE INDEX [IX_FK_Ministries_Employees]
ON [dbo].[Ministries]
    ([EmployeeID]);
GO

-- Creating foreign key on [TaxID] in table 'Ministries'
ALTER TABLE [dbo].[Ministries]
ADD CONSTRAINT [FK_Ministries_Taxes]
    FOREIGN KEY ([TaxID])
    REFERENCES [dbo].[Taxes]
        ([TaxID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ministries_Taxes'
CREATE INDEX [IX_FK_Ministries_Taxes]
ON [dbo].[Ministries]
    ([TaxID]);
GO

-- Creating foreign key on [TaxID] in table 'PaymentDetails'
ALTER TABLE [dbo].[PaymentDetails]
ADD CONSTRAINT [FK_PaymentDetail_Taxes]
    FOREIGN KEY ([TaxID])
    REFERENCES [dbo].[Taxes]
        ([TaxID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentDetail_Taxes'
CREATE INDEX [IX_FK_PaymentDetail_Taxes]
ON [dbo].[PaymentDetails]
    ([TaxID]);
GO

-- Creating foreign key on [MinistryID] in table 'Taxes'
ALTER TABLE [dbo].[Taxes]
ADD CONSTRAINT [FK_Taxes_Ministries]
    FOREIGN KEY ([MinistryID])
    REFERENCES [dbo].[Ministries]
        ([MinistryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Taxes_Ministries'
CREATE INDEX [IX_FK_Taxes_Ministries]
ON [dbo].[Taxes]
    ([MinistryID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------