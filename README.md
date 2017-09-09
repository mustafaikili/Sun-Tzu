# Sun-Tzu
Sun Tzu Game Project
Databese
DatabaseName: SunTzu

Create database SunTzu
go
Use SunTzu
go
CREATE TABLE [dbo].[Table] (
    [id] INT NOT NULL IDENTITY, 
    [seviye] INT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([id])
);
go
insert into  [Table] (seviye) values (5)
