USE [SuperSecureBank]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 10/20/2011 16:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[errorID] [bigint] IDENTITY(1,9431114) NOT NULL,
	[time] [datetime] NOT NULL,
	[errorText] [text] NOT NULL,
	[exception] [text] NOT NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[errorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 10/20/2011 16:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[commentID] [bigint] IDENTITY(1,1) NOT NULL,
	[userID] [bigint] NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[body] [text] NOT NULL,
	[postTime] [datetime] NOT NULL,
	[Validated] [bit] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[commentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 10/20/2011 16:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypes](
	[type] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [text] NOT NULL,
	[IsLoan] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountStatus]    Script Date: 10/20/2011 16:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountStatus](
	[status] [bigint] NOT NULL,
	[Description] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 10/20/2011 16:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[accountID] [bigint] IDENTITY(3512143,1) NOT NULL,
	[userID] [bigint] NOT NULL,
	[type] [bigint] NOT NULL,
	[balance] [bigint] NOT NULL,
	[level] [bigint] NOT NULL,
	[status] [bigint] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[accountID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountLevels]    Script Date: 10/20/2011 16:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountLevels](
	[level] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/20/2011 16:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [bigint] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sessions]    Script Date: 10/20/2011 16:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sessions](
	[userID] [bigint] NOT NULL,
	[sessionID] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[FriendlyAccounts]    Script Date: 10/20/2011 16:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[FriendlyAccounts]
AS
SELECT        dbo.Users.userID, dbo.Accounts.accountID, dbo.Accounts.balance, dbo.AccountLevels.Name AS LevelName, dbo.AccountLevels.Description AS LevelDescription, 
                         dbo.AccountTypes.Name AS TypeName, dbo.AccountTypes.Description AS TypeDescription, dbo.AccountStatus.Description AS Status
FROM            dbo.Users INNER JOIN
                         dbo.Accounts ON dbo.Users.userID = dbo.Accounts.userID INNER JOIN
                         dbo.AccountLevels ON dbo.Accounts.level = dbo.AccountLevels.level INNER JOIN
                         dbo.AccountTypes ON dbo.Accounts.type = dbo.AccountTypes.type INNER JOIN
                         dbo.AccountStatus ON dbo.Accounts.status = dbo.AccountStatus.status
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Users"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Accounts"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountLevels"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 118
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountTypes"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 118
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountStatus"
            Begin Extent = 
               Top = 6
               Left = 870
               Bottom = 101
               Right = 1040
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 3480
         Width = 1755
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 9' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FriendlyAccounts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'00
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FriendlyAccounts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FriendlyAccounts'
GO
/****** Object:  Default [DF_Accounts_status]    Script Date: 10/20/2011 16:41:32 ******/
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_status]  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF_AccountTypes_Description]    Script Date: 10/20/2011 16:41:32 ******/
ALTER TABLE [dbo].[AccountTypes] ADD  CONSTRAINT [DF_AccountTypes_Description]  DEFAULT ('No description') FOR [Description]
GO
/****** Object:  Default [DF_AccountTypes_IsLoan]    Script Date: 10/20/2011 16:41:32 ******/
ALTER TABLE [dbo].[AccountTypes] ADD  CONSTRAINT [DF_AccountTypes_IsLoan]  DEFAULT ((0)) FOR [IsLoan]
GO
/****** Object:  Default [DF_Comments_Validated]    Script Date: 10/20/2011 16:41:32 ******/
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_Validated]  DEFAULT ((0)) FOR [Validated]
GO
/****** Object:  Default [DF_ErrorLog_time]    Script Date: 10/20/2011 16:41:32 ******/
ALTER TABLE [dbo].[ErrorLog] ADD  CONSTRAINT [DF_ErrorLog_time]  DEFAULT (getdate()) FOR [time]
GO
