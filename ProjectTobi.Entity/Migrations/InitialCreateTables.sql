IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'tobs') IS NULL EXEC(N'CREATE SCHEMA [tobs];');

GO

CREATE TABLE [tobs].[Categories] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] varchar(200) NULL,
    [CreatedDate] datetimeoffset NOT NULL DEFAULT (getutcdate()),
    [ModifiedBy] varchar(200) NULL,
    [ModifiedDate] datetimeoffset NULL,
    [CategoryName] varchar(200) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [tobs].[Permissions] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] varchar(200) NULL,
    [CreatedDate] datetimeoffset NOT NULL DEFAULT (getutcdate()),
    [ModifiedBy] varchar(200) NULL,
    [ModifiedDate] datetimeoffset NULL,
    [PermissionName] varchar(300) NULL,
    CONSTRAINT [PK_Permissions] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [tobs].[Users] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] varchar(200) NULL,
    [CreatedDate] datetimeoffset NOT NULL DEFAULT (getutcdate()),
    [ModifiedBy] varchar(200) NULL,
    [ModifiedDate] datetimeoffset NULL,
    [FirstName] varchar(200) NULL,
    [LastName] varchar(200) NULL,
    [DisplayName] AS [FirstName] + ' ' + [LastName],
    [Email] nvarchar(200) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [tobs].[Blogs] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] varchar(200) NULL,
    [CreatedDate] datetimeoffset NOT NULL DEFAULT (getutcdate()),
    [ModifiedBy] varchar(200) NULL,
    [ModifiedDate] datetimeoffset NULL,
    [Title] varchar(200) NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [CategoryId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Blogs_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [tobs].[Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Blogs_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [tobs].[Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [tobs].[Images] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] varchar(200) NULL,
    [CreatedDate] datetimeoffset NOT NULL DEFAULT (getutcdate()),
    [ModifiedBy] varchar(200) NULL,
    [ModifiedDate] datetimeoffset NULL,
    [Name] nvarchar(max) NULL,
    [IsPrimary] bit NOT NULL,
    [Picture] varbinary(max) NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Images_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [tobs].[Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [tobs].[UserPermissions] (
    [UserId] int NOT NULL,
    [PermissionId] int NOT NULL,
    [Id] int NOT NULL,
    [CreatedBy] varchar(200) NULL,
    [CreatedDate] datetimeoffset NOT NULL DEFAULT (getutcdate()),
    [ModifiedBy] varchar(200) NULL,
    [ModifiedDate] datetimeoffset NULL,
    CONSTRAINT [PK_UserPermissions] PRIMARY KEY ([UserId], [PermissionId]),
    CONSTRAINT [FK_UserPermissions_Permissions_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [tobs].[Permissions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserPermissions_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [tobs].[Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [tobs].[Comments] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] varchar(200) NULL,
    [CreatedDate] datetimeoffset NOT NULL DEFAULT (getutcdate()),
    [ModifiedBy] varchar(200) NULL,
    [ModifiedDate] datetimeoffset NULL,
    [UserName] varchar(200) NULL,
    [Content] nvarchar(max) NULL,
    [BlogId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comments_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [tobs].[Blogs] ([Id]),
    CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [tobs].[Users] ([Id])
);

GO

CREATE INDEX [IX_Blogs_CategoryId] ON [tobs].[Blogs] ([CategoryId]);

GO

CREATE INDEX [IX_tobs_Blog_Title] ON [tobs].[Blogs] ([Title]);

GO

CREATE INDEX [IX_Blogs_UserId] ON [tobs].[Blogs] ([UserId]);

GO

CREATE INDEX [IX_Comments_BlogId] ON [tobs].[Comments] ([BlogId]);

GO

CREATE INDEX [IX_Comments_UserId] ON [tobs].[Comments] ([UserId]);

GO

CREATE INDEX [IX_Images_UserId] ON [tobs].[Images] ([UserId]);

GO

CREATE UNIQUE INDEX [IX_tobs_Permission_PermissionName] ON [tobs].[Permissions] ([PermissionName]) WHERE [PermissionName] IS NOT NULL;

GO

CREATE INDEX [IX_UserPermissions_PermissionId] ON [tobs].[UserPermissions] ([PermissionId]);

GO

CREATE UNIQUE INDEX [IX_tobs_User_FirstName] ON [tobs].[Users] ([FirstName]) WHERE [FirstName] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200521064503_InitialCreate', N'3.1.3');

GO

