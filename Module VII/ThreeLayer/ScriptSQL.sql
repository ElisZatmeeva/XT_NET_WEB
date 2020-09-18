USE [master]
GO

/****** Object:  Database [Users_and_Awardsa]    Script Date: 18.09.2020 23:19:01 ******/
CREATE DATABASE [Users_and_Awardsa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Users_and_Awardsa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Users_and_Awardsa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Users_and_Awardsa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Users_and_Awardsa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Users_and_Awardsa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Users_and_Awardsa] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET ARITHABORT OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Users_and_Awardsa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Users_and_Awardsa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Users_and_Awardsa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Users_and_Awardsa] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Users_and_Awardsa] SET  MULTI_USER 
GO

ALTER DATABASE [Users_and_Awardsa] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Users_and_Awardsa] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Users_and_Awardsa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Users_and_Awardsa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Users_and_Awardsa] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Users_and_Awardsa] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Users_and_Awardsa] SET  READ_WRITE 
GO


