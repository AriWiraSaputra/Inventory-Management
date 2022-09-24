CREATE TABLE [dbo].[tbProduct] (
    [pid]    INT          NOT NULL,
    [pname]  VARCHAR (50) NOT NULL,
    [pshift] INT          NOT NULL,
    [pprice] INT          NOT NULL,
    [pcode]  VARCHAR (50) NULL,
    [pdate]  DATETIME NOT NULL
);

