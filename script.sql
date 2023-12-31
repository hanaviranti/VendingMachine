USE [master]
GO
/****** Object:  Database [dbtest]    Script Date: 6/27/2023 4:17:14 PM ******/
CREATE DATABASE [dbtest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbtest', FILENAME = N'/var/opt/mssql/data/dbtest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbtest_log', FILENAME = N'/var/opt/mssql/data/dbtest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbtest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbtest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbtest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbtest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbtest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbtest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbtest] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbtest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbtest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbtest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbtest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbtest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbtest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbtest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbtest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbtest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbtest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbtest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbtest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbtest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbtest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbtest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbtest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbtest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbtest] SET RECOVERY FULL 
GO
ALTER DATABASE [dbtest] SET  MULTI_USER 
GO
ALTER DATABASE [dbtest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbtest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbtest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbtest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbtest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbtest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbtest', N'ON'
GO
ALTER DATABASE [dbtest] SET QUERY_STORE = OFF
GO
USE [dbtest]
GO
/****** Object:  Table [dbo].[tabel_barang]    Script Date: 6/27/2023 4:17:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tabel_barang](
	[kode_barang] [nvarchar](30) NOT NULL,
	[nama_barang] [nvarchar](50) NULL,
	[harga] [numeric](10, 0) NULL,
	[stock] [numeric](10, 0) NULL,
	[image] [varchar](1000) NULL,
 CONSTRAINT [PK_tabel_barang] PRIMARY KEY CLUSTERED 
(
	[kode_barang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tabel_barang] ([kode_barang], [nama_barang], [harga], [stock], [image]) VALUES (N'1', N'Biskuit', CAST(6000 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), N'D:\\_FAHMI\\DATA\\HANA\\VendingMachine\\VendingMachine\\image\\biskuit.jpg')
INSERT [dbo].[tabel_barang] ([kode_barang], [nama_barang], [harga], [stock], [image]) VALUES (N'2', N'Chips', CAST(8000 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), N'D:\\_FAHMI\\DATA\\HANA\\VendingMachine\\VendingMachine\\image\\chips.jpg')
INSERT [dbo].[tabel_barang] ([kode_barang], [nama_barang], [harga], [stock], [image]) VALUES (N'3', N'Oreo', CAST(10000 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), N'D:\\_FAHMI\\DATA\\HANA\\VendingMachine\\VendingMachine\\image\\oreo.jpg')
INSERT [dbo].[tabel_barang] ([kode_barang], [nama_barang], [harga], [stock], [image]) VALUES (N'4', N'Tango', CAST(12000 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), N'D:\\_FAHMI\\DATA\\HANA\\VendingMachine\\VendingMachine\\image\\tango.jpg')
INSERT [dbo].[tabel_barang] ([kode_barang], [nama_barang], [harga], [stock], [image]) VALUES (N'5', N'Cokelat', CAST(15000 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), N'D:\\_FAHMI\\DATA\\HANA\\VendingMachine\\VendingMachine\\image\\cokelat.jpg')
GO
USE [master]
GO
ALTER DATABASE [dbtest] SET  READ_WRITE 
GO
