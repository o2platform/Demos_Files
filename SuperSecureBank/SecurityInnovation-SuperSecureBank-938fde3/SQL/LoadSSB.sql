/*
	SQL Server Dumper

	User Interface: SQL Server Dumper  3.0.8
	Script Engine:  SQLDumper.Engine  1.0.8

	Copyright � 2009 Ruizata Project. All Rights Reserved.

	Creation Date:2011-10-20 04:40:32
	Database:`DATABASE1` 
*/
USE [SuperSecureBank]
GO

-- `dbo.AccountLevels`
INSERT dbo.AccountLevels VALUES (0, N'Basic', 'Zero Interest Rate')
INSERT dbo.AccountLevels VALUES (1, N'Standard', 'Zero Interest Rate, Check Card')
INSERT dbo.AccountLevels VALUES (2, N'Advanced', 'Zero Interest Rate, Check Card, Free Credit Card')
INSERT dbo.AccountLevels VALUES (3, N'Silver', 'Customers who want basic banking options, maintain smaller balances and don''t want to manage too many details.<ul><li>No monthly fees</li><li>Preferred loan rates</li><li>No-fee credit card</li></ul>')
INSERT dbo.AccountLevels VALUES (4, N'Gold', 'Customers with growing financial needs who are looking for a simple, comprehensive and superior value solution.	<ul><li>25% rewards bonus for SuperSecure Bank Check Card and Credit Card use</li><li>Preferred loan rates</li><li>No fees on the first overdraft occasion</li><li>Two free non-SuperSecure Bank ATM transactions for SuperSecure Bank Gold Checking</li></ul>')
INSERT dbo.AccountLevels VALUES (5, N'Platinum', 'Customers with higher account balances who want to maintain their financial strength.<ul><li>Preferred interest and loan rates</li><li>50% monthly bonus on all rewards earned for net purchases</li><li>Unlimited free non-SuperSecure Bank ATM transactions</li></ul>')

-- `dbo.Accounts`
SET IDENTITY_INSERT dbo.Accounts ON

INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512144, 1, 0, 2812, 0, 0)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512145, 1, 3, 12000, 1, 0)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512146, 1, 2, 0, 0, 3)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512147, 5, 5, -500000, 5, 1)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512148, 5, 8, -5000, 0, 1)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512149, 5, 7, -400, 1, 1)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512150, 5, 0, 1100, 2, 0)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512151, 6, 8, -45500, 5, 0)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512152, 5, 1, 0, 1, 0)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512153, 7, 0, 0, 0, 1)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512154, 7, 0, 0, 0, 1)
INSERT dbo.Accounts (accountID, userID, type, balance, [level], status) VALUES (3512155, 7, 3, 11110000, 5, 1)
SET IDENTITY_INSERT dbo.Accounts OFF


-- `dbo.AccountStatus`
INSERT dbo.AccountStatus VALUES (0, N'Active')
INSERT dbo.AccountStatus VALUES (1, N'Pending')
INSERT dbo.AccountStatus VALUES (2, N'Denied')
INSERT dbo.AccountStatus VALUES (3, N'Under Review')
INSERT dbo.AccountStatus VALUES (4, N'Issues Found')
INSERT dbo.AccountStatus VALUES (5, N'Waiting for Resolution')
INSERT dbo.AccountStatus VALUES (6, N'Issue: 57192785')
INSERT dbo.AccountStatus VALUES (7, N'Not my fault')
INSERT dbo.AccountStatus VALUES (8, N'This should never happen')

-- `dbo.AccountTypes`
INSERT dbo.AccountTypes VALUES (0, N'Student Checking', 'Checking especially for college students', 0)
INSERT dbo.AccountTypes VALUES (1, N'Advantage Checking', 'Premium rates with the best benefits and discounts we offer', 0)
INSERT dbo.AccountTypes VALUES (2, N'Online Savings', 'A great way to start saving automatically with an opportunity to receive a premium interest rate on your Online Savings Account', 0)
INSERT dbo.AccountTypes VALUES (3, N'Money Market Savings', 'Competitive rates and easy access to your money with the option to write checks', 0)
INSERT dbo.AccountTypes VALUES (4, N'CD', 'A guaranteed return with fixed rates and a choice of terms', 0)
INSERT dbo.AccountTypes VALUES (5, N'Home Loan', 'Whether you are buying or refinancing, our ', 1)
INSERT dbo.AccountTypes VALUES (6, N'Home Equity', 'Put the equity in your home to work for', 1)
INSERT dbo.AccountTypes VALUES (7, N'Student Loans', 'Finance your or your children''s education.', 1)
INSERT dbo.AccountTypes VALUES (8, N'Credit Card', 'Enjoy low introductory rates, optional rewards and great SuperSecureBank Service!', 1)

-- `dbo.Comments`
SET IDENTITY_INSERT dbo.Comments ON

INSERT dbo.Comments (commentID, userID, title, body, postTime, Validated) VALUES (15, 5, N'super secure bank is great!', 'I love this bank!', '20110525 11:46:52:000', 0)
INSERT dbo.Comments (commentID, userID, title, body, postTime, Validated) VALUES (16, 5, N'New Comment', 'This one will show up!', '20110525 11:51:29:000', 1)
INSERT dbo.Comments (commentID, userID, title, body, postTime, Validated) VALUES (17, 5, N'test', 'test', '20110525 11:53:03:000', 0)
SET IDENTITY_INSERT dbo.Comments OFF


-- `dbo.Users`
SET IDENTITY_INSERT dbo.Users ON

INSERT dbo.Users (userID, userName, email, password) VALUES (1, N'admin', N'admin', N'admin')
INSERT dbo.Users (userID, userName, email, password) VALUES (5, N'joe', N'joe@whoisjoe.net', N'letmein')
INSERT dbo.Users (userID, userName, email, password) VALUES (7, N'test', N'test', N'test')
INSERT dbo.Users (userID, userName, email, password) VALUES (8, N'username', N'test@test.com', N'password')
INSERT dbo.Users (userID, userName, email, password) VALUES (9, N'jim', N'pass', N'')
INSERT dbo.Users (userID, userName, email, password) VALUES (10, N'asdf', N'asdf', N'asdf')
INSERT dbo.Users (userID, userName, email, password) VALUES (11, N'newJoe', N'newJoe@example.com', N'pass')
INSERT dbo.Users (userID, userName, email, password) VALUES (12, N'newJoe', N'newJoe@example.com', N'pass')
INSERT dbo.Users (userID, userName, email, password) VALUES (13, N'newJoe', N'newJoe@example.com', N'pass')
INSERT dbo.Users (userID, userName, email, password) VALUES (14, N'test2', N'test@test.com', N'ASDF')
INSERT dbo.Users (userID, userName, email, password) VALUES (15, N'asdffefe', N'joe@joe.com', N'asdf')
SET IDENTITY_INSERT dbo.Users OFF

