
CREATE TABLE [dbo].[tblCustomer] (
  [Customer_Id] INT NOT NULL IDENTITY(0, 1),
  [AccountNumber] VARCHAR(64) NOT NULL UNIQUE,
  [FirstName] VARCHAR(32) NULL,
  [LastName] VARCHAR(32) NULL,
  [Address] VARCHAR(48) NULL,
  [City] VARCHAR(24) NULL,
  [State] VARCHAR(2) NULL,
  [Zip] VARCHAR(9) NULL,
  [Phone] VARCHAR(10) NULL,
  [Email] VARCHAR(64) NULL,
  [DateOfBirth] DATE NULL,
  [CustomerStatus_Id] INT NOT NULL,
  CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
  (
	[Customer_Id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO