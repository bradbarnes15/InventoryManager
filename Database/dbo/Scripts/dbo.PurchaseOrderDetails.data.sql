SET IDENTITY_INSERT [dbo].[PurchaseOrderDetails] ON
INSERT INTO [dbo].[PurchaseOrderDetails] ([PurchaseOrderDetails_Id], [Purchase_Order_Number], [Product], [Quantity], [Unit_Price], [Extended_Price]) VALUES (4, 2, N'Millk 2%', 20, 0.15, 3)
INSERT INTO [dbo].[PurchaseOrderDetails] ([PurchaseOrderDetails_Id], [Purchase_Order_Number], [Product], [Quantity], [Unit_Price], [Extended_Price]) VALUES (5, 2, N'Milk Skim', 20, 0.15, 3)
INSERT INTO [dbo].[PurchaseOrderDetails] ([PurchaseOrderDetails_Id], [Purchase_Order_Number], [Product], [Quantity], [Unit_Price], [Extended_Price]) VALUES (7, 2, N'Eggs', 40, 0.55, 22)
SET IDENTITY_INSERT [dbo].[PurchaseOrderDetails] OFF
