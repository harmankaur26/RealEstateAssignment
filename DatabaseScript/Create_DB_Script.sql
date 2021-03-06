Use Master
Go
Create database [Realtor]
Go
USE [Realtor]
GO
/****** Object:  StoredProcedure [dbo].[spAddProperty]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAddProperty] 
	 @PropertyID INT = NULL
	,@PropertyName VARCHAR(100)
	,@Address VARCHAR(250)
	,@City VARCHAR(100)
	,@State VARCHAR(100)
	,@Zip VARCHAR(25)
	,@OwnerName VARCHAR(100)
	,@UserID INT

AS
BEGIN
	SET NOCOUNT ON;
	IF(ISNULL(@PropertyID, 0) = 0)
	BEGIN

			INSERT INTO [dbo].[tbl_Property]
           ([PropertyName]
           ,[Address]
           ,[City]
           ,[State]
           ,[Zip]
           ,[OwnerName]
           ,[UserID])
     VALUES
           (@PropertyName 
	,@Address 
	,@City 
	,@State 
	,@Zip 
	,@OwnerName 
	,@UserID)


	END
	ELSE
	BEGIN

UPDATE [dbo].[tbl_Property]
   SET [PropertyName] = @PropertyName
      ,[Address] = @Address
      ,[City] = @City
      ,[State] = @State
      ,[Zip] = @Zip
      ,[OwnerName] = @OwnerName
      ,[UserID] = @UserID
 WHERE PropertyID = @PropertyID

	END
END


GO
/****** Object:  StoredProcedure [dbo].[spAddTenant]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAddTenant] 
	 @TenantID INT = NULL
	,@Firstname VARCHAR(50)
	,@Lastname VARCHAR(50)
	,@StartDate DATE
	,@EndDate DATE
	,@Amount DECIMAL(11,2)
	,@PropertyID INT
	,@FileName VARCHAR(100)

AS
BEGIN
	SET NOCOUNT ON;
	IF(ISNULL(@TenantID, 0) = 0)
	BEGIN

			INSERT INTO [dbo].[tbl_Tenant]
           ([Firstname]
           ,[Lastname]
           ,[StartDate]
           ,[EndDate]
           ,[Amount]
           ,[PropertyID]
           ,[FileName])
     VALUES
           (@Firstname 
	,@Lastname
	,@StartDate
	,@EndDate
	,@Amount
	,@PropertyID
	,@FileName)


	END
	ELSE
	BEGIN

UPDATE [dbo].[tbl_Tenant]
   SET [Firstname] = @Firstname
      ,[Lastname] = @Lastname
      ,[StartDate] = @StartDate
      ,[EndDate] = @EndDate
      ,[Amount] = @Amount
      ,[PropertyID] = @PropertyID
      ,[FileName] = @FileName
 WHERE TenantID = @TenantID

	END
END


GO
/****** Object:  StoredProcedure [dbo].[spGetAllProperties]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllProperties] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

SELECT [PropertyID]
      ,[PropertyName]
      ,[Address]
      ,[City]
      ,[State]
      ,[Zip]
      ,[OwnerName]
      ,[UserID]
  FROM [dbo].[tbl_Property]


END


GO
/****** Object:  StoredProcedure [dbo].[spGetAllTenants]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllTenants] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

SELECT [TenantID]
      ,[Firstname]
      ,[Lastname]
      ,[StartDate]
      ,[EndDate]
      ,[Amount]
      ,[PropertyID]
      ,[FileName]
  FROM [dbo].[tbl_Tenant]


END



GO
/****** Object:  StoredProcedure [dbo].[spGetPropertyByID]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetPropertyByID] 
	(@PropertyID int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	

SELECT prop.[PropertyID]
      ,prop.[PropertyName]
      ,prop.[Address]
      ,prop.[City]
      ,prop.[State]
      ,prop.[Zip]
      ,prop.[OwnerName]
      ,prop.[UserID]
	  ,ten.[TenantID]
      ,ten.[Firstname]
      ,ten.[Lastname]
      ,ten.[StartDate]
      ,ten.[EndDate]
      ,ten.[Amount]
      ,ten.[FileName]
  FROM [dbo].[tbl_Property] prop
  LEFT JOIN tbl_Tenant ten on prop.[PropertyID] = ten.PropertyID
  where prop.[PropertyID]=@PropertyID


END



GO
/****** Object:  StoredProcedure [dbo].[spGetTenantByID]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetTenantByID] 
	(@TenantID int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	

SELECT [TenantID]
      ,[Firstname]
      ,[Lastname]
      ,[StartDate]
      ,[EndDate]
      ,[Amount]
      ,[PropertyID]
      ,[FileName]
  FROM [dbo].[tbl_Tenant]
  where [TenantID]=@TenantID


END




GO
/****** Object:  StoredProcedure [dbo].[spLoginUser]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spLoginUser](
 @UserName Varchar(50)
 ,@Password varchar(25)
)
AS
BEGIN	

SELECT [UserID]
      ,[Username]
      ,[Password]
      ,[FirstName]
      ,[LastName]
      ,[Role]
  FROM [dbo].[tbl_User]
  WHERE USERNAME = @UserName
  AND   PASSWORD =@Password


END
GO
/****** Object:  Table [dbo].[tbl_Property]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Property](
	[PropertyID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyName] [varchar](100) NOT NULL,
	[Address] [varchar](250) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[Zip] [varchar](25) NOT NULL,
	[OwnerName] [varchar](100) NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_dbo_Property] PRIMARY KEY CLUSTERED 
(
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Tenant]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Tenant](
	[TenantID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Amount] [decimal](11, 2) NOT NULL,
	[PropertyID] [int] NOT NULL,
	[FileName] [varchar](100) NULL,
 CONSTRAINT [PK_dbo_Tenant] PRIMARY KEY CLUSTERED 
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 5/2/2019 6:17:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](25) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[Role] [tinyint] NOT NULL,
 CONSTRAINT [PK_dbo] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT INTO [dbo].[tbl_User]
           ([Username]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[Role])
     VALUES
	 (
           'Admin'
           ,'password'
           ,'Hello'
           ,'World'
           ,1)
GO
go
