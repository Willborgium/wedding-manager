IF (SELECT COUNT(1) FROM [dbo].[PaymentMethod]) = 0
	BEGIN
		INSERT INTO [dbo].[PaymentMethod] ([Description]) VALUES
		('Cash'),
		('Check')
	END

IF (SELECT COUNT(1) FROM [dbo].[Company]) = 0
	BEGIN
		INSERT INTO [dbo].[Company] ([Name]) VALUES
		('Test Company')
	END

IF (SELECT COUNT(1) FROM [dbo].[Customer]) = 0
	BEGIN
		INSERT INTO [dbo].[Customer] ([CompanyId], [FirstName], [LastName], [PhoneNumber], [Notes]) VALUES
		(1, 'John', 'Stevenson', '4015551234', 'John lives in a black house\r\nHis wife doesn''t like him.')
	END

IF (SELECT COUNT(1) FROM [dbo].[Service]) = 0
	BEGIN
		INSERT INTO [dbo].[Service] ([CustomerId], [Description]) VALUES
		(1, 'Event Photography')
	END

IF (SELECT COUNT(1) FROM [dbo].[ServiceDetail]) = 0
	BEGIN
		INSERT INTO [dbo].[ServiceDetail] ([ServiceId], [Details], [Location], [StartTime], [EndTime] ) VALUES
		(1, 'Reception', '1 Main Street', DATEADD(DAY, 30, GETDATE()), DATEADD(DAY, 31, GETDATE()))
	END

IF (SELECT COUNT(1) FROM [dbo].[Invoice]) = 0
	BEGIN
		INSERT INTO [dbo].[Invoice] ([ServiceId], [Amount], [CreatedDate], [Description], [DueDate]) VALUES
		(1, 500.25, GETDATE(), 'Event photography bill', DATEADD(DAY, 30, GETDATE()))
	END

IF (SELECT COUNT(1) FROM [dbo].[Payment]) = 0
	BEGIN
		INSERT INTO [dbo].[Payment] ([ServiceId], [Amount], [DateReceived], [Notes], [PaymentMethodId]) VALUES
		(1, 100.12, GETDATE(), 'Event photography deposit', 1)
	END

IF (SELECT COUNT(1) FROM [dbo].[Expense]) = 0
	BEGIN
		INSERT INTO [dbo].[Expense] ([CompanyId], [Amount], [CreatedDate], [Description]) VALUES
		(1, 225.50, GETDATE(), 'Business cards')
	END

IF (SELECT COUNT(1) FROM [dbo].[CustomerInteractionType]) = 0
	BEGIN
		INSERT INTO [dbo].[CustomerInteractionType] ([Description]) VALUES
		('Email'),
		('Phone'),
		('Facebook'),
		('Text message'),
		('In-person'),
		('Mail'),
		('Event')
	END

IF (SELECT COUNT(1) FROM [dbo].[CustomerInteraction]) = 0
	BEGIN
		INSERT INTO [dbo].[CustomerInteraction] ([CustomerId], [InteractionType], [Date], [Notes]) VALUES
		(1, 1, DATEADD(DAY, -1, GETDATE()), 'The customer had a change in plans'),
		(1, 2, DATEADD(DAY, -5, GETDATE()), 'First contact!')
	END