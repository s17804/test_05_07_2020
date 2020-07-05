IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Actions] (
    [IdAction] int NOT NULL IDENTITY,
    [StartTime] datetime2 NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [NeedSpecialEquipment] tinyint NOT NULL,
    CONSTRAINT [PK_Actions] PRIMARY KEY ([IdAction])
);

GO

CREATE TABLE [Firefighters] (
    [IdFirefighter] int NOT NULL IDENTITY,
    [FirstName] nvarchar(30) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Firefighters] PRIMARY KEY ([IdFirefighter])
);

GO

CREATE TABLE [FireTrucks] (
    [IdFireTruck] int NOT NULL IDENTITY,
    [TruckNumber] nvarchar(10) NOT NULL,
    [SpecialEquipment] tinyint NOT NULL,
    CONSTRAINT [PK_FireTrucks] PRIMARY KEY ([IdFireTruck])
);

GO

CREATE TABLE [FirefighterActions] (
    [IdFirefighter] int NOT NULL,
    [IdAction] int NOT NULL,
    CONSTRAINT [PK_FirefighterActions] PRIMARY KEY ([IdFirefighter], [IdAction]),
    CONSTRAINT [FK_FirefighterActions_Actions_IdAction] FOREIGN KEY ([IdAction]) REFERENCES [Actions] ([IdAction]) ON DELETE CASCADE,
    CONSTRAINT [FK_FirefighterActions_Firefighters_IdFirefighter] FOREIGN KEY ([IdFirefighter]) REFERENCES [Firefighters] ([IdFirefighter]) ON DELETE CASCADE
);

GO

CREATE TABLE [FireTruckActions] (
    [IdFireTruckAction] int NOT NULL IDENTITY,
    [AssignmentDate] datetime2 NOT NULL,
    [IdAction] int NULL,
    [IdFireTruck] int NULL,
    CONSTRAINT [PK_FireTruckActions] PRIMARY KEY ([IdFireTruckAction]),
    CONSTRAINT [FK_FireTruckActions_Actions_IdAction] FOREIGN KEY ([IdAction]) REFERENCES [Actions] ([IdAction]) ON DELETE NO ACTION,
    CONSTRAINT [FK_FireTruckActions_FireTrucks_IdFireTruck] FOREIGN KEY ([IdFireTruck]) REFERENCES [FireTrucks] ([IdFireTruck]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_FirefighterActions_IdAction] ON [FirefighterActions] ([IdAction]);

GO

CREATE INDEX [IX_FireTruckActions_IdAction] ON [FireTruckActions] ([IdAction]);

GO

CREATE INDEX [IX_FireTruckActions_IdFireTruck] ON [FireTruckActions] ([IdFireTruck]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200705104800_InitialCreate', N'5.0.0-preview.6.20312.4');

GO

