

exec sp_dboption N'FoundStone_Bank', N'autoclose', N'true'
GO

exec sp_dboption N'FoundStone_Bank', N'bulkcopy', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'trunc. log', N'true'
GO

exec sp_dboption N'FoundStone_Bank', N'torn page detection', N'true'
GO

exec sp_dboption N'FoundStone_Bank', N'read only', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'dbo use', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'single', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'autoshrink', N'true'
GO

exec sp_dboption N'FoundStone_Bank', N'ANSI null default', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'recursive triggers', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'ANSI nulls', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'concat null yields null', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'cursor close on commit', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'default to local cursor', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'quoted identifier', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'ANSI warnings', N'false'
GO

exec sp_dboption N'FoundStone_Bank', N'auto create statistics', N'true'
GO

exec sp_dboption N'FoundStone_Bank', N'auto update statistics', N'true'
GO

if( ( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) ) or ( (@@microsoftversion / power(2, 24) = 7) and (@@microsoftversion & 0xffff >= 1082) ) )
	exec sp_dboption N'FoundStone_Bank', N'db chaining', N'false'
GO

use [FoundStone_Bank]
GO

/****** Object:  Table [dbo].[fsb_accounts]    Script Date: 7/26/2005 9:55:01 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[fsb_accounts]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [fsb_accounts]
GO


/****** Object:  Table [dbo].[fsb_fund_transfers]    Script Date: 7/26/2005 9:55:01 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[fsb_fund_transfers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [fsb_fund_transfers]
GO


/****** Object:  Table [dbo].[fsb_loan_rates]    Script Date: 7/26/2005 9:55:01 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[fsb_loan_rates]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [fsb_loan_rates]
GO


/****** Object:  Table [dbo].[fsb_messages]    Script Date: 7/26/2005 9:55:01 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[fsb_messages]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [fsb_messages]
GO


/****** Object:  Table [dbo].[fsb_transactions]    Script Date: 7/26/2005 9:55:01 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[fsb_transactions]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [fsb_transactions]
GO


/****** Object:  Table [dbo].[fsb_users]    Script Date: 7/26/2005 9:55:01 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[fsb_users]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [fsb_users]
GO


/****** Object:  Table [dbo].[fsb_users1]    Script Date: 7/26/2005 9:55:01 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[fsb_users1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [fsb_users1]
GO


/****** Object:  Table [dbo].[fsb_accounts]    Script Date: 7/26/2005 9:55:01 PM ******/
CREATE TABLE [fsb_accounts] (
	[account_no] [numeric](16, 0) NOT NULL ,
	[user_id] [numeric](18, 0) NOT NULL ,
	[currency] [varchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[branch] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[balance_amount] [numeric](20, 2) NULL ,
	[creation_date] [datetime] NULL ,
	[account_type] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[fsb_fund_transfers]    Script Date: 7/26/2005 9:55:02 PM ******/
CREATE TABLE [fsb_fund_transfers] (
	[transfer_id] [numeric](18, 0) IDENTITY (1, 1) NOT NULL ,
	[transfer_date] [datetime] NULL ,
	[source_account_no] [numeric](16, 0) NULL ,
	[destination_account_no] [numeric](16, 0) NULL ,
	[transfer_amount] [numeric](20, 2) NULL ,
	[remark] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[fsb_loan_rates]    Script Date: 7/26/2005 9:55:02 PM ******/
CREATE TABLE [fsb_loan_rates] (
	[loan_period] [numeric](10, 0) NOT NULL ,
	[rate_of_interest] [numeric](10, 2) NOT NULL 
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[fsb_messages]    Script Date: 7/26/2005 9:55:02 PM ******/
CREATE TABLE [fsb_messages] (
	[message_id] [numeric](10, 0) IDENTITY (1, 1) NOT NULL ,
	[user_id] [numeric](18, 0) NOT NULL ,
	[message_date] [datetime] NULL ,
	[subject] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[text] [varchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[fsb_transactions]    Script Date: 7/26/2005 9:55:02 PM ******/
CREATE TABLE [fsb_transactions] (
	[transaction_id] [numeric](18, 0) IDENTITY (1, 1) NOT NULL ,
	[account_no] [numeric](16, 0) NOT NULL ,
	[transaction_date] [datetime] NULL ,
	[transaction_mode] [varchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[transaction_amount] [numeric](20, 2) NOT NULL ,
	[description] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[fsb_users]    Script Date: 7/26/2005 9:55:02 PM ******/
CREATE TABLE [fsb_users] (
	[user_id] [numeric](18, 0) IDENTITY (1, 1) NOT NULL ,
	[user_name] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[login_id] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[password] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[creation_date] [datetime] NULL 
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[fsb_users1]    Script Date: 7/26/2005 9:55:02 PM ******/
CREATE TABLE [fsb_users1] (
	[user_id] [numeric](18, 0) NOT NULL ,
	[user_name] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[login_id] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[password] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[creation_date] [datetime] NULL 
) ON [PRIMARY]
GO


/* Data for table fsb_accounts */
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (1111111, 5, 'GBP', 'London', 1000.00, '6/19/2005 7:31:26 PM', 'Gold')
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (4534523452345, 7, 'GBP', 'London', 700.00, '6/21/2005 11:29:58 AM', 'Platinum')
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (5204320422040001, 1, 'USD', 'Texas-Remington Circle', 4877.00, '6/14/2005 1:29:36 AM', 'Platinum')
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (5204320422040002, 1, 'USD', 'Texas-Remington Circle', 5123.00, '6/14/2005 1:29:36 AM', 'Silver')
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (5204320422040003, 2, 'USD', 'L A-Hoston Road', 5000.00, '6/14/2005 1:29:36 AM', 'Platinum')
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (5204320422040004, 2, 'USD', 'L A-Hoston Road', 5000.00, '6/14/2005 1:29:36 AM', 'Silver')
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (5204320422040005, 3, 'USD', 'L A-Hoston Road', 5000.00, '6/14/2005 1:29:36 AM', 'Platinum')
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (5204320422040006, 3, 'USD', 'L A-Hoston Road', 5000.00, '6/14/2005 1:29:37 AM', 'Silver')
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (5204320422040007, 3, 'USD', 'Buston-Richadson Avenue', 5000.00, '6/14/2005 1:29:37 AM', 'Platinum')
INSERT [fsb_accounts] ([account_no], [user_id], [currency], [branch], [balance_amount], [creation_date], [account_type]) VALUES (5204320422040008, 3, 'USD', 'Buston-Richadson Avenue', 5000.00, '6/14/2005 1:29:37 AM', 'Silver')
/* Data for table fsb_fund_transfers */
SET identity_insert [fsb_fund_transfers] on

INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (1, '6/17/2005 7:24:42 PM', 5204320422040001, 5204320422040002, 123, 'asd')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (2, '6/17/2005 7:50:57 PM', 111111111111, 222222222222, 999, '<b>xss</b>')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (3, '6/17/2005 7:52:39 PM', 12312313, 456456456, -10, '<b>xssd</b>')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (4, '6/17/2005 8:10:42 PM', 1234123412341234, 111111111111111, 1234, '<b>xss</b>')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (5, '6/17/2005 8:11:54 PM', 1234123412341234, 111111111111111, 1234, '<b>xss</b>')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (6, '6/17/2005 8:16:26 PM', 1234123412341234, 777777777777, 66, '[loan for 5 at 4%] 3333333')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (7, '6/17/2005 9:01:50 PM', 1234123412341234, 1231231231231231, 556, '[CC Payment from 123123123123123:12/12] <b>')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (8, '6/17/2005 9:02:23 PM', 1234123412341234, 22222222222, 556, '[CC Payment from 4444444444444444:12/12] <b>')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (9, '6/17/2005 9:09:20 PM', 1234123412341234, 22222222222, 556, '[CC Payment from 4444444444444444:12/12] <b>')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (10, '6/22/2005 7:12:58 PM', 5204320422040001, 5204320422040002, 999, 'kjljklj')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (11, '6/22/2005 7:13:44 PM', 5204320422040002, 5204320422040001, 100, '<b>XSS</b>')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (12, '6/22/2005 7:17:58 PM', 4534523452345, 5204320422040001, 100, '<b> XSS from a </b>')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (13, '6/22/2005 8:28:15 PM', 1234123412341234, 5204320422040001, 12345, '[loan for 2 yrs at 3.50%] Loan <b>xss</b> test')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (14, '6/22/2005 9:32:20 PM', 1234123412341234, 5204320422040002, 123, '[loan for 1 yrs at 4.00%] s')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (15, '6/22/2005 9:32:54 PM', 1234123412341234, 5204320422040001, 456, '[loan for 1 yrs at 4.00%] ')
INSERT [fsb_fund_transfers] ([transfer_id], [transfer_date], [source_account_no], [destination_account_no], [transfer_amount], [remark]) VALUES (16, '6/22/2005 9:33:56 PM', 5204320422040001, 4534523452345, 100, 'From Joe')
SET identity_insert [fsb_fund_transfers] off
GO
/* Data for table fsb_loan_rates */
INSERT [fsb_loan_rates] ([loan_period], [rate_of_interest]) VALUES (1, 4.00)
INSERT [fsb_loan_rates] ([loan_period], [rate_of_interest]) VALUES (2, 3.50)
INSERT [fsb_loan_rates] ([loan_period], [rate_of_interest]) VALUES (3, 3.00)
INSERT [fsb_loan_rates] ([loan_period], [rate_of_interest]) VALUES (4, 2.50)
INSERT [fsb_loan_rates] ([loan_period], [rate_of_interest]) VALUES (5, 2.00)
INSERT [fsb_loan_rates] ([loan_period], [rate_of_interest]) VALUES (6, 1.50)
INSERT [fsb_loan_rates] ([loan_period], [rate_of_interest]) VALUES (7, 1.00)
/* Data for table fsb_messages */
SET identity_insert [fsb_messages] on

INSERT [fsb_messages] ([message_id], [user_id], [message_date], [subject], [text]) VALUES (1, 1, '6/17/2005 8:03:19 PM', 'asd', 'asd')
INSERT [fsb_messages] ([message_id], [user_id], [message_date], [subject], [text]) VALUES (2, 1, '6/17/2005 8:03:36 PM', '111asd<i>asd</i>', 'a111sd<i>asd</i>')
INSERT [fsb_messages] ([message_id], [user_id], [message_date], [subject], [text]) VALUES (3, 2, '6/17/2005 8:33:16 PM', 'subject', 'text')
INSERT [fsb_messages] ([message_id], [user_id], [message_date], [subject], [text]) VALUES (4, 1, '6/22/2005 9:27:33 PM', 'yuiyiuiui', 'tuitiyui')
INSERT [fsb_messages] ([message_id], [user_id], [message_date], [subject], [text]) VALUES (5, 1, '6/22/2005 9:29:18 PM', 'New message', 'With Automatic Refesh')
SET identity_insert [fsb_messages] off
GO
/* Data for table fsb_transactions */
SET identity_insert [fsb_transactions] on

INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (1, 5204320422040001, '6/14/2005 1:29:37 AM', 'CR', 10000.00, 'Salary Credited')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (2, 5204320422040001, '6/14/2005 1:29:37 AM', 'DB', 2000.00, 'ATM Cash-Churchill Road')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (3, 5204320422040001, '6/14/2005 1:29:37 AM', 'DB', 3000.00, 'Credit Payment')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (4, 5204320422040002, '6/14/2005 1:29:37 AM', 'CR', 7000.00, 'Salary Credited')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (5, 5204320422040002, '6/14/2005 1:29:37 AM', 'DR', 2000.00, 'Debit Purchase-WallMart')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (6, 5204320422040003, '6/14/2005 1:29:37 AM', 'CR', 6000.00, 'Consulting fee')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (7, 5204320422040003, '6/14/2005 1:29:38 AM', 'DB', 1000.00, 'Credit Payment')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (8, 5204320422040004, '6/14/2005 1:29:38 AM', 'CR', 6500.00, 'Salary Credited')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (9, 5204320422040004, '6/14/2005 1:29:38 AM', 'DB', 1500.00, 'Medical Claims')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (10, 5204320422040005, '6/14/2005 1:29:38 AM', 'CR', 5500.00, 'Consulting fee')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (11, 5204320422040005, '6/14/2005 1:29:38 AM', 'DB', 500.00, 'ATM Cash-Houston Road')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (12, 5204320422040006, '6/14/2005 1:29:38 AM', 'CR', 9000.00, 'Jackpot earned')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (13, 5204320422040006, '6/14/2005 1:29:38 AM', 'DB', 4000.00, 'Credit Payment')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (14, 5204320422040007, '6/14/2005 1:29:38 AM', 'CR', 7500.00, 'Salary Credited')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (15, 5204320422040007, '6/14/2005 1:29:39 AM', 'DB', 2500.00, 'Debit Payment-Air India')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (16, 5204320422040008, '6/14/2005 1:29:39 AM', 'CR', 6000.00, 'Salary Credited')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (17, 5204320422040008, '6/14/2005 1:29:39 AM', 'DB', 1000.00, 'ATM Cash-Richarson Street')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (18, 5204320422040001, '6/17/2005 7:24:42 PM', 'DB', 123.00, 'Account Transfer')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (19, 5204320422040002, '6/17/2005 7:24:42 PM', 'CR', 123.00, 'Account Transfer')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (20, 1, '6/17/2005 7:41:36 PM', 'DB', 3.00, ' Transfer $3 to 2 (4)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (21, 1, '6/17/2005 7:44:56 PM', 'DB', 3.00, ' Transfer $3 to 2 (4)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (22, 2, '6/17/2005 7:44:56 PM', 'CR', 3.00, ' Received $3 from 2 (4)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (23, 111111111111, '6/17/2005 7:45:40 PM', 'DB', 999.00, ' Transfer $999 to 222222222222 (<b>xss</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (24, 222222222222, '6/17/2005 7:45:40 PM', 'CR', 999.00, ' Received $999 from 222222222222 (<b>xss</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (25, 111111111111, '6/17/2005 7:50:57 PM', 'DB', 999.00, ' Transfered $999 to 222222222222 (<b>xss</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (26, 222222222222, '6/17/2005 7:50:57 PM', 'CR', 999.00, ' Received $999 from 222222222222 (<b>xss</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (27, 12312313, '6/17/2005 7:52:39 PM', 'DB', -10.00, ' Transfered $-10 to 456456456 (<b>xssd</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (28, 456456456, '6/17/2005 7:52:39 PM', 'CR', -10.00, ' Received $-10 from 456456456 (<b>xssd</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (29, 1234123412341234, '6/17/2005 8:10:42 PM', 'DB', 1234.00, ' Transfered $1234 to 111111111111111 (<b>xss</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (30, 111111111111111, '6/17/2005 8:10:42 PM', 'CR', 1234.00, ' Received $1234 from 111111111111111 (<b>xss</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (31, 1234123412341234, '6/17/2005 8:11:54 PM', 'DB', 1234.00, ' Transfered $1234 to 111111111111111 (<b>xss</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (32, 111111111111111, '6/17/2005 8:11:54 PM', 'CR', 1234.00, ' Received $1234 from 1234123412341234 (<b>xss</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (33, 1234123412341234, '6/17/2005 8:16:26 PM', 'DB', 66.00, ' Transfered $66 to 777777777777 ([loan for 5 at 4%] 3333333)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (34, 777777777777, '6/17/2005 8:16:26 PM', 'CR', 66.00, ' Received $66 from 1234123412341234 ([loan for 5 at 4%] 3333333)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (35, 1234123412341234, '6/17/2005 9:01:50 PM', 'DB', 556.00, ' Transfered $556 to 1231231231231231 ([CC Payment from 123123123123123:12/12] <b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (36, 1231231231231231, '6/17/2005 9:01:50 PM', 'CR', 556.00, ' Received $556 from 1234123412341234 ([CC Payment from 123123123123123:12/12] <b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (37, 1234123412341234, '6/17/2005 9:02:23 PM', 'DB', 556.00, ' Transfered $556 to 22222222222 ([CC Payment from 4444444444444444:12/12] <b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (38, 22222222222, '6/17/2005 9:02:23 PM', 'CR', 556.00, ' Received $556 from 1234123412341234 ([CC Payment from 4444444444444444:12/12] <b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (39, 1234123412341234, '6/17/2005 9:09:20 PM', 'CR', 556.00, ' Received $556 from CC 4444444444444444:12/12 (CC Payment)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (40, 1234123412341234, '6/17/2005 9:09:20 PM', 'DB', 556.00, ' Transfered $556 to 22222222222 ([CC Payment from 4444444444444444:12/12] <b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (41, 22222222222, '6/17/2005 9:09:20 PM', 'CR', 556.00, ' Received $556 from 1234123412341234 ([CC Payment from 4444444444444444:12/12] <b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (42, 5204320422040001, '6/22/2005 7:12:58 PM', 'DB', 999.00, ' Transfered $999 to 5204320422040002 (kjljklj)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (43, 5204320422040002, '6/22/2005 7:12:58 PM', 'CR', 999.00, ' Received $999 from 5204320422040001 (kjljklj)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (44, 5204320422040002, '6/22/2005 7:13:44 PM', 'DB', 100.00, ' Transfered $100 to 5204320422040001 (<b>XSS</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (45, 5204320422040001, '6/22/2005 7:13:44 PM', 'CR', 100.00, ' Received $100 from 5204320422040002 (<b>XSS</b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (46, 4534523452345, '6/22/2005 7:17:58 PM', 'DB', 100.00, ' Transfered $100 to 5204320422040001 (<b> XSS from a </b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (47, 5204320422040001, '6/22/2005 7:17:58 PM', 'CR', 100.00, ' Received $100 from 4534523452345 (<b> XSS from a </b>)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (48, 1234123412341234, '6/22/2005 8:28:15 PM', 'DB', 12345.00, ' Transfered $12345 to 5204320422040001 ([loan for 2 yrs at 3.50%] Loan <b>xss</b> test)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (49, 5204320422040001, '6/22/2005 8:28:15 PM', 'CR', 12345.00, ' Received $12345 from 1234123412341234 ([loan for 2 yrs at 3.50%] Loan <b>xss</b> test)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (50, 1234123412341234, '6/22/2005 9:32:20 PM', 'DB', 123.00, ' Transfered $123 to 5204320422040002 ([loan for 1 yrs at 4.00%] s)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (51, 5204320422040002, '6/22/2005 9:32:20 PM', 'CR', 123.00, ' Received $123 from 1234123412341234 ([loan for 1 yrs at 4.00%] s)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (52, 1234123412341234, '6/22/2005 9:32:54 PM', 'DB', 456.00, ' Transfered $456 to 5204320422040001 ([loan for 1 yrs at 4.00%] )')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (53, 5204320422040001, '6/22/2005 9:32:54 PM', 'CR', 456.00, ' Received $456 from 1234123412341234 ([loan for 1 yrs at 4.00%] )')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (54, 5204320422040001, '6/22/2005 9:33:56 PM', 'DB', 100.00, ' Transfered $100 to 4534523452345 (From Joe)')
INSERT [fsb_transactions] ([transaction_id], [account_no], [transaction_date], [transaction_mode], [transaction_amount], [description]) VALUES (55, 4534523452345, '6/22/2005 9:33:56 PM', 'CR', 100.00, ' Received $100 from 5204320422040001 (From Joe)')
SET identity_insert [fsb_transactions] off
GO
/* Data for table fsb_users */
SET identity_insert [fsb_users] on

INSERT [fsb_users] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (1, 'Joe Vilella', 'JV', '', '6/14/2005 1:29:36 AM')
INSERT [fsb_users] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (2, 'John Mathew', 'JM', 'jm789', '6/14/2005 1:29:36 AM')
INSERT [fsb_users] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (3, 'Jane Chris', 'JC', 'jc789', '6/14/2005 1:29:36 AM')
INSERT [fsb_users] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (5, 'aaa', 'aaa', '-', '6/17/2005 10:39:12 AM')
INSERT [fsb_users] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (6, 'qqq', 'aaa', 'bbb', '6/17/2005 6:57:47 PM')
INSERT [fsb_users] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (7, 'a', 'a', 'a', '6/18/2005 6:40:09 PM')
SET identity_insert [fsb_users] off
GO
/* Data for table fsb_users1 */
INSERT [fsb_users1] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (1, 'Joe Vilella', 'JV', 'jv789', '6/14/2005 1:29:36 AM')
INSERT [fsb_users1] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (2, 'John Mathew', 'JM', 'jm789', '6/14/2005 1:29:36 AM')
INSERT [fsb_users1] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (3, 'Jane Chris', 'JC', 'jc789', '6/14/2005 1:29:36 AM')
INSERT [fsb_users1] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (5, 'aaa', 'aaa', '-', '6/17/2005 10:39:12 AM')
INSERT [fsb_users1] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (6, 'qqq', 'aaa', 'bbb', '6/17/2005 6:57:47 PM')
INSERT [fsb_users1] ([user_id], [user_name], [login_id], [password], [creation_date]) VALUES (7, 'a', 'a', 'a', '6/18/2005 6:40:09 PM')
/****** Object:  Table [dbo].[fsb_accounts]    Script Date: 7/26/2005 9:55:03 PM ******/
ALTER TABLE [fsb_accounts] WITH NOCHECK ADD 
	CONSTRAINT [PK_fsb_accounts] PRIMARY KEY  CLUSTERED 
	(
		[account_no]
	)  ON [PRIMARY] 
GO


/****** Object:  Table [dbo].[fsb_fund_transfers]    Script Date: 7/26/2005 9:55:03 PM ******/
ALTER TABLE [fsb_fund_transfers] WITH NOCHECK ADD 
	CONSTRAINT [PK_fsb_fund_transfers] PRIMARY KEY  CLUSTERED 
	(
		[transfer_id]
	)  ON [PRIMARY] 
GO


/****** Object:  Table [dbo].[fsb_loan_rates]    Script Date: 7/26/2005 9:55:03 PM ******/
ALTER TABLE [fsb_loan_rates] WITH NOCHECK ADD 
	CONSTRAINT [PK_fsb_loan_rates] PRIMARY KEY  CLUSTERED 
	(
		[loan_period]
	)  ON [PRIMARY] 
GO


/****** Object:  Table [dbo].[fsb_messages]    Script Date: 7/26/2005 9:55:03 PM ******/
ALTER TABLE [fsb_messages] WITH NOCHECK ADD 
	CONSTRAINT [PK_fsb_messages] PRIMARY KEY  CLUSTERED 
	(
		[message_id]
	)  ON [PRIMARY] 
GO


/****** Object:  Table [dbo].[fsb_transactions]    Script Date: 7/26/2005 9:55:03 PM ******/
ALTER TABLE [fsb_transactions] WITH NOCHECK ADD 
	CONSTRAINT [PK_fsb_transactions] PRIMARY KEY  CLUSTERED 
	(
		[transaction_id]
	)  ON [PRIMARY] 
GO


/****** Object:  Table [dbo].[fsb_users]    Script Date: 7/26/2005 9:55:03 PM ******/
ALTER TABLE [fsb_users] WITH NOCHECK ADD 
	CONSTRAINT [PK_fsb_users] PRIMARY KEY  CLUSTERED 
	(
		[user_id]
	)  ON [PRIMARY] 
GO
























