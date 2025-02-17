
CREATE TABLE [dbo].[tblStateCodes] (
  [State_Id] INT NOT NULL IDENTITY(0,1),
  [Code] VARCHAR(2) NULL ,
  [Description] VARCHAR(32) NULL ,
 CONSTRAINT [PK_tblState] PRIMARY KEY CLUSTERED 
(
	[State_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
