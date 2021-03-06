USE [master]
GO
/****** Object:  Database [POCecommercesite]    Script Date: 28-03-2021 04:37:26 PM ******/
CREATE DATABASE [POCecommercesite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POCecommercesite', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\POCecommercesite.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'POCecommercesite_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\POCecommercesite_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [POCecommercesite] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [POCecommercesite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [POCecommercesite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [POCecommercesite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [POCecommercesite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [POCecommercesite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [POCecommercesite] SET ARITHABORT OFF 
GO
ALTER DATABASE [POCecommercesite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [POCecommercesite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [POCecommercesite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [POCecommercesite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [POCecommercesite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [POCecommercesite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [POCecommercesite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [POCecommercesite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [POCecommercesite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [POCecommercesite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [POCecommercesite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [POCecommercesite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [POCecommercesite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [POCecommercesite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [POCecommercesite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [POCecommercesite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [POCecommercesite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [POCecommercesite] SET RECOVERY FULL 
GO
ALTER DATABASE [POCecommercesite] SET  MULTI_USER 
GO
ALTER DATABASE [POCecommercesite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [POCecommercesite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [POCecommercesite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [POCecommercesite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [POCecommercesite] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [POCecommercesite] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'POCecommercesite', N'ON'
GO
ALTER DATABASE [POCecommercesite] SET QUERY_STORE = OFF
GO
USE [POCecommercesite]
GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 28-03-2021 04:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[TokenID] [int] NOT NULL,
	[UserID] [varchar](10) NOT NULL,
	[Token] [varchar](200) NOT NULL,
	[ExpireDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TokenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCart]    Script Date: 28-03-2021 04:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCart](
	[Quantity_wished] [decimal](5, 0) NOT NULL,
	[Date_Added] [datetime] NOT NULL,
	[CartID] [varchar](10) NOT NULL,
	[UserID] [varchar](10) NOT NULL,
	[ProductID] [varchar](10) NOT NULL,
	[Purchased] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[CartID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 28-03-2021 04:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CategoryID] [varchar](10) NOT NULL,
	[CatergoryName] [varchar](20) NULL,
	[SellerID] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 28-03-2021 04:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[ProductID] [varchar](10) NOT NULL,
	[CategoryID] [varchar](10) NULL,
	[ProductColor] [varchar](15) NOT NULL,
	[ProductSize] [varchar](10) NOT NULL,
	[Cost] [decimal](5, 0) NOT NULL,
	[Quantity] [decimal](5, 0) NOT NULL,
	[SellerID] [varchar](10) NOT NULL,
	[ProductDescription] [text] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ProductImage] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSeller]    Script Date: 28-03-2021 04:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSeller](
	[SellerID] [varchar](10) NOT NULL,
	[SellerPassword] [varchar](10) NOT NULL,
	[SellerName] [varchar](20) NOT NULL,
	[SellerEmail] [varchar](255) NOT NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SellerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblShippingDetails]    Script Date: 28-03-2021 04:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblShippingDetails](
	[ShippingDetailID] [varchar](10) NOT NULL,
	[UserID] [varchar](10) NOT NULL,
	[UAddress] [varchar](500) NULL,
	[UCity] [varchar](500) NULL,
	[UState] [varchar](500) NULL,
	[UCountry] [varchar](50) NULL,
	[UZipCode] [varchar](50) NULL,
	[ProductID] [varchar](10) NULL,
	[AmountPaid] [decimal](18, 0) NULL,
	[PaymentType] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ShippingDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 28-03-2021 04:37:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [varchar](10) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[UserPassword] [varchar](20) NOT NULL,
	[Firstname] [varchar](20) NOT NULL,
	[Lastname] [varchar](20) NOT NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblCart] ADD  DEFAULT (getdate()) FOR [Date_Added]
GO
ALTER TABLE [dbo].[tblCart] ADD  DEFAULT ('NO') FOR [Purchased]
GO
ALTER TABLE [dbo].[tblProduct] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblProduct] ADD  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[tblSeller] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[tblUser] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[RefreshToken]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUser] ([UserID])
GO
ALTER TABLE [dbo].[tblCart]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[tblProduct] ([ProductID])
GO
ALTER TABLE [dbo].[tblCart]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUser] ([UserID])
GO
ALTER TABLE [dbo].[tblCategory]  WITH CHECK ADD FOREIGN KEY([SellerID])
REFERENCES [dbo].[tblSeller] ([SellerID])
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tblCategory] ([CategoryID])
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD FOREIGN KEY([SellerID])
REFERENCES [dbo].[tblSeller] ([SellerID])
GO
ALTER TABLE [dbo].[tblShippingDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[tblProduct] ([ProductID])
GO
ALTER TABLE [dbo].[tblShippingDetails]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUser] ([UserID])
GO
USE [master]
GO
ALTER DATABASE [POCecommercesite] SET  READ_WRITE 
GO
