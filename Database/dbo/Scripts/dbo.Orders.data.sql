SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([Order_Id], [Order_Date], [Employee], [Shipping_Address], [Ship_City], [Ship_State], [Zip], [Order_Total], [Tax], [Status], [Closed_Date]) VALUES (2, N'2017-04-29', N'Sam', N'132 AP drive', N'Clarksville', N'TN', 37043, 105.78, 8.73, N'New', N'2017-04-29')
SET IDENTITY_INSERT [dbo].[Orders] OFF
