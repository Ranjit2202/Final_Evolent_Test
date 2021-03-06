USE [TEST_DB]
GO
/****** Object:  Table [dbo].[Tbl_Contact]    Script Date: 05/03/2021 18:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [nvarchar](max) NULL,
	[Last_Name] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [nchar](10) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Tbl_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[CRUD_SP]    Script Date: 05/03/2021 18:38:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CRUD_SP]
 @Id int = null,
 @First_Name NVARCHAR(MAX) = NULL  
,@Last_Name NVARCHAR(MAX) = NULL  
,@Email NVARCHAR(MAX) = NULL  
,@PhoneNumber NVARCHAR(MAX) = NULL   
,@Status bit  
,@Query INT
AS  
BEGIN  

IF (@Query = 1)  
BEGIN  
INSERT INTO [dbo].[Tbl_Contact]
(  
[First_Name], 
[Last_Name], 
[Email],
[PhoneNumber],
[Status]
)  
VALUES (  
		 @First_Name  
		,@Last_Name 
		,@Email
		,@PhoneNumber
		,@Status
)
END

IF (@Query = 2)   
BEGIN  
SELECT *  FROM [dbo].[Tbl_Contact]  
END

IF (@Query = 3)   
BEGIN  
Delete FROM [dbo].[Tbl_Contact] where Id=@Id  
END

IF (@Query = 4)   
BEGIN  
Update [dbo].[Tbl_Contact] set First_Name=@First_Name,Last_Name=@Last_Name,PhoneNumber=@PhoneNumber,Email=@Email,Status=@Status
where Id=@Id  
END

END
  
GO
