USE [SuperSecureBank]
GO
/****** Object:  View [dbo].[FriendlyAccounts]    Script Date: 10/20/2011 16:41:56 ******/
DROP VIEW [dbo].[FriendlyAccounts]
GO
/****** Object:  Table [dbo].[sessions]    Script Date: 10/20/2011 16:41:56 ******/
DROP TABLE [dbo].[sessions]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/20/2011 16:41:56 ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[AccountLevels]    Script Date: 10/20/2011 16:41:56 ******/
DROP TABLE [dbo].[AccountLevels]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 10/20/2011 16:41:56 ******/
ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [DF_Accounts_status]
GO
DROP TABLE [dbo].[Accounts]
GO
/****** Object:  Table [dbo].[AccountStatus]    Script Date: 10/20/2011 16:41:56 ******/
DROP TABLE [dbo].[AccountStatus]
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 10/20/2011 16:41:56 ******/
ALTER TABLE [dbo].[AccountTypes] DROP CONSTRAINT [DF_AccountTypes_Description]
GO
ALTER TABLE [dbo].[AccountTypes] DROP CONSTRAINT [DF_AccountTypes_IsLoan]
GO
DROP TABLE [dbo].[AccountTypes]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 10/20/2011 16:41:56 ******/
ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [DF_Comments_Validated]
GO
DROP TABLE [dbo].[Comments]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 10/20/2011 16:41:56 ******/
ALTER TABLE [dbo].[ErrorLog] DROP CONSTRAINT [DF_ErrorLog_time]
GO
DROP TABLE [dbo].[ErrorLog]
GO
