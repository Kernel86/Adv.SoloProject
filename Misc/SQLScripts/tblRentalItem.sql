
CREATE TABLE [dbo].[tblRentalItem] (
  [RentalItem_Id] INT NOT NULL IDENTITY(0, 1),
  [Rental_Id] INT NOT NULL ,
  [MediaItem_Id] INT NOT NULL ,
  [DueDate] DATE NULL ,
  [DateIn] DATE NULL
 CONSTRAINT [PK_tblRentalItem] PRIMARY KEY CLUSTERED 
(
	[RentalItem_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO