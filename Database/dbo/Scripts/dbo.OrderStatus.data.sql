SET IDENTITY_INSERT [dbo].[OrderStatus] ON
INSERT INTO [dbo].[OrderStatus] ([OrderStatus_Id], [Status_Text]) VALUES (1, N'New')
INSERT INTO [dbo].[OrderStatus] ([OrderStatus_Id], [Status_Text]) VALUES (2, N'Invoiced')
INSERT INTO [dbo].[OrderStatus] ([OrderStatus_Id], [Status_Text]) VALUES (3, N'Shipped')
INSERT INTO [dbo].[OrderStatus] ([OrderStatus_Id], [Status_Text]) VALUES (4, N'Completed')
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
