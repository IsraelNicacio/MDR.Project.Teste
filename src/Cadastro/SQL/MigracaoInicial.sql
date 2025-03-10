IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Departamento] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(120) NOT NULL,
    CONSTRAINT [PK_Departamento] PRIMARY KEY ([Id])
);

CREATE TABLE [Pessoas] (
    [Id] uniqueidentifier NOT NULL,
    [DepartamentoId] uniqueidentifier NOT NULL,
    [Nome] varchar(60) NOT NULL,
    [Sobrenome] varchar(60) NOT NULL,
    [Idade] integer NOT NULL,
    CONSTRAINT [PK_Pessoas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pessoas_Departamento_DepartamentoId] FOREIGN KEY ([DepartamentoId]) REFERENCES [Departamento] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Pessoas_DepartamentoId] ON [Pessoas] ([DepartamentoId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250310173236_migracao_inicial', N'9.0.2');

COMMIT;
GO

