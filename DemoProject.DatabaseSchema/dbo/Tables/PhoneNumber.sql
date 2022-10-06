CREATE TABLE [dbo].[PhoneNumber] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [PersonId]  INT           NULL,
    [Number]    NVARCHAR (50) NULL,
    [IsActive]  BIT           DEFAULT ((1)) NULL,
    [DateAdded] DATETIME      DEFAULT (getutcdate()) NULL,
    FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

