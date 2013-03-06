
CREATE TABLE [dbo].[tblMediaItem] (
  [MediaItem_Id] INT NOT NULL IDENTITY(0,1),
  [InvetoryDate] DATE NULL ,
  [Media_Id] INT NOT NULL ,
  [MediaItemState_Id] INT NOT NULL ,
  [MediaItemPricing_Id] INT NOT NULL,
  [Format_Id] INT NOT NULL ,
 CONSTRAINT [PK_tblMediaItem] PRIMARY KEY CLUSTERED 
(
	[MediaItem_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO