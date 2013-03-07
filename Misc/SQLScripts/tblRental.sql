
CREATE TABLE [dbo].[tblRental] (
  [Rental_Id] INT NOT NULL IDENTITY(0, 1),
  [Customer_Id] INT NOT NULL ,
  [PaymentType_Id] INT NOT NULL ,
  [CreditCard_Id] INT NULL ,
  [TransactionDate] DATE NOT NULL ,
  [TransactionAmount] DECIMAL(8,2) NOT NULL ,
 CONSTRAINT [PK_tblRental] PRIMARY KEY CLUSTERED 
(
	[Rental_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO