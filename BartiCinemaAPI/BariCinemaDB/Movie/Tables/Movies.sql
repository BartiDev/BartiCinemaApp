CREATE TABLE [Movie].[Movies] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (512)  NOT NULL,
    [Directors]   NVARCHAR (512)  NOT NULL,
    [Genres]      NVARCHAR (256)  NOT NULL,
    [ReleaseDate] DATETIME2 (7)   NOT NULL,
    [Description] NVARCHAR (2048) NULL,
    [Certificate] NVARCHAR (128)  NULL,
    [ImdbRating]  DECIMAL (3, 1)  NULL,
    [Runtime]     INT             NULL,
    [PosterLink]  NVARCHAR (512)  NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

