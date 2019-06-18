
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/17/2019 23:25:35
-- Generated from EDMX file: C:\Users\Artur\Desktop\Studia\Semestr 6\Budowa aplikacji użytkowych w technologii WPF\Projekt\WalletWPF\WalletModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Wallet];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Subcategory_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subcategory] DROP CONSTRAINT [FK_Subcategory_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_ConstOrder_Subcategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConstOrder] DROP CONSTRAINT [FK_ConstOrder_Subcategory];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaction_PaymentMethod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaction] DROP CONSTRAINT [FK_Transaction_PaymentMethod];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaction_Subcategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaction] DROP CONSTRAINT [FK_Transaction_Subcategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Commitment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Commitment];
GO
IF OBJECT_ID(N'[dbo].[ConstOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConstOrder];
GO
IF OBJECT_ID(N'[dbo].[Language]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Language];
GO
IF OBJECT_ID(N'[dbo].[PaymentMethod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentMethod];
GO
IF OBJECT_ID(N'[dbo].[Subcategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subcategory];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Transaction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transaction];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [id_category] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NULL
);
GO

-- Creating table 'Commitment'
CREATE TABLE [dbo].[Commitment] (
    [id_commitment] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NULL,
    [amount] float  NULL,
    [number_of_installments] int  NULL,
    [date] datetime  NULL
);
GO

-- Creating table 'ConstOrder'
CREATE TABLE [dbo].[ConstOrder] (
    [id_const_order] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NULL,
    [amount] float  NULL,
    [date_const_order] datetime  NULL,
    [id_subcategory] int  NULL
);
GO

-- Creating table 'Language'
CREATE TABLE [dbo].[Language] (
    [id_language] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NULL
);
GO

-- Creating table 'PaymentMethod'
CREATE TABLE [dbo].[PaymentMethod] (
    [id_payment_method] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NULL,
    [balance] float  NULL
);
GO

-- Creating table 'Subcategory'
CREATE TABLE [dbo].[Subcategory] (
    [id_subcategory] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NULL,
    [id_category] int  NULL
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

-- Creating table 'Transaction'
CREATE TABLE [dbo].[Transaction] (
    [Id_transaction] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NULL,
    [amount] float  NULL,
    [date_transaction] datetime  NULL,
    [id_payment_method] int  NULL,
    [id_subcategory] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_category] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([id_category] ASC);
GO

-- Creating primary key on [id_commitment] in table 'Commitment'
ALTER TABLE [dbo].[Commitment]
ADD CONSTRAINT [PK_Commitment]
    PRIMARY KEY CLUSTERED ([id_commitment] ASC);
GO

-- Creating primary key on [id_const_order] in table 'ConstOrder'
ALTER TABLE [dbo].[ConstOrder]
ADD CONSTRAINT [PK_ConstOrder]
    PRIMARY KEY CLUSTERED ([id_const_order] ASC);
GO

-- Creating primary key on [id_language] in table 'Language'
ALTER TABLE [dbo].[Language]
ADD CONSTRAINT [PK_Language]
    PRIMARY KEY CLUSTERED ([id_language] ASC);
GO

-- Creating primary key on [id_payment_method] in table 'PaymentMethod'
ALTER TABLE [dbo].[PaymentMethod]
ADD CONSTRAINT [PK_PaymentMethod]
    PRIMARY KEY CLUSTERED ([id_payment_method] ASC);
GO

-- Creating primary key on [id_subcategory] in table 'Subcategory'
ALTER TABLE [dbo].[Subcategory]
ADD CONSTRAINT [PK_Subcategory]
    PRIMARY KEY CLUSTERED ([id_subcategory] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id_transaction] in table 'Transaction'
ALTER TABLE [dbo].[Transaction]
ADD CONSTRAINT [PK_Transaction]
    PRIMARY KEY CLUSTERED ([Id_transaction] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_category] in table 'Subcategory'
ALTER TABLE [dbo].[Subcategory]
ADD CONSTRAINT [FK_Subcategory_Category]
    FOREIGN KEY ([id_category])
    REFERENCES [dbo].[Category]
        ([id_category])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Subcategory_Category'
CREATE INDEX [IX_FK_Subcategory_Category]
ON [dbo].[Subcategory]
    ([id_category]);
GO

-- Creating foreign key on [id_subcategory] in table 'ConstOrder'
ALTER TABLE [dbo].[ConstOrder]
ADD CONSTRAINT [FK_ConstOrder_Subcategory]
    FOREIGN KEY ([id_subcategory])
    REFERENCES [dbo].[Subcategory]
        ([id_subcategory])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConstOrder_Subcategory'
CREATE INDEX [IX_FK_ConstOrder_Subcategory]
ON [dbo].[ConstOrder]
    ([id_subcategory]);
GO

-- Creating foreign key on [id_payment_method] in table 'Transaction'
ALTER TABLE [dbo].[Transaction]
ADD CONSTRAINT [FK_Transaction_PaymentMethod]
    FOREIGN KEY ([id_payment_method])
    REFERENCES [dbo].[PaymentMethod]
        ([id_payment_method])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaction_PaymentMethod'
CREATE INDEX [IX_FK_Transaction_PaymentMethod]
ON [dbo].[Transaction]
    ([id_payment_method]);
GO

-- Creating foreign key on [id_subcategory] in table 'Transaction'
ALTER TABLE [dbo].[Transaction]
ADD CONSTRAINT [FK_Transaction_Subcategory]
    FOREIGN KEY ([id_subcategory])
    REFERENCES [dbo].[Subcategory]
        ([id_subcategory])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaction_Subcategory'
CREATE INDEX [IX_FK_Transaction_Subcategory]
ON [dbo].[Transaction]
    ([id_subcategory]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------