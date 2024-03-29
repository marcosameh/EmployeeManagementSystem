USE [master]
GO
/****** Object:  Database [EmployeeManagementSystem]    Script Date: 1/18/2024 10:37:36 PM ******/
CREATE DATABASE [EmployeeManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZoobookEmployeeManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ZoobookEmployeeManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ZoobookEmployeeManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ZoobookEmployeeManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [EmployeeManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmployeeManagementSystem', N'ON'
GO
USE [EmployeeManagementSystem]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 1/18/2024 10:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[MiddleName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName]) VALUES (1, N'Mark', N'Kenneth', N'Mardo')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName]) VALUES (2, N'Ktine', N'Kristine', N'Marie')
INSERT [dbo].[Employee] ([Id], [FirstName], [MiddleName], [LastName]) VALUES (3, N'Marco', N'Sameh', N'Boktor')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
USE [master]
GO
ALTER DATABASE [EmployeeManagementSystem] SET  READ_WRITE 
GO
