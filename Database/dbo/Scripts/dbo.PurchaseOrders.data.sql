SET IDENTITY_INSERT [dbo].[PurchaseOrders] ON
INSERT INTO [dbo].[PurchaseOrders] ([PurchaseOrders_Id], [Order_Date], [Created_By], [Created_Date], [Shipping_Fee], [Tax], [Payment_Date], [Payment_Amount], [Order_Subtotal], [Order_Total], [Status], [Date_Received]) VALUES (2, N'2017-04-29', N'Bob', N'2017-04-29', 10, 2.52, N'2017-04-29', 40.52, 28, 40.52, N'New', N'2017-04-29')
SET IDENTITY_INSERT [dbo].[PurchaseOrders] OFF
