USE [Blackjack]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 05/09/2011 21:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[id] [uniqueidentifier] NOT NULL,
	[dollars_in_pot] [decimal](18, 2) NOT NULL,
	[version] [numeric](18, 0) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembershipEvents]    Script Date: 05/09/2011 21:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipEvents](
	[date_of_action] [datetime] NOT NULL,
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[action] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MembershipEvents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlackJackTables]    Script Date: 05/09/2011 21:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlackJackTables](
	[id] [uniqueidentifier] NOT NULL,
	[player_token] [uniqueidentifier] NOT NULL,
	[finished] [bit] NOT NULL,
	[version] [numeric](18, 0) NOT NULL,
	[state_id] [int] NOT NULL,
	[can_accept_bet] [bit] NOT NULL,
	[can_deal] [bit] NOT NULL,
	[state_name] [nvarchar](50) NOT NULL,
	[cards_dealt] [bit] NOT NULL,
 CONSTRAINT [PK__BlackJac__3213E83F7F60ED59] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hands]    Script Date: 05/09/2011 21:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hands](
	[id] [uniqueidentifier] NOT NULL,
	[blackjack_table_id] [uniqueidentifier] NOT NULL,
	[discriminator] [nvarchar](50) NOT NULL,
	[bet] [money] NULL,
	[version] [numeric](18, 0) NOT NULL,
	[state_id] [int] NOT NULL,
	[turn_ended] [bit] NOT NULL,
	[state_name] [nvarchar](50) NOT NULL,
	[can_double_down] [bit] NULL,
	[can_split] [bit] NULL,
	[is_active] [bit] NULL,
	[hand_letter] [nvarchar](50) NULL,
	[can_take_insurance] [bit] NULL,
	[has_taken_insurance] [bit] NULL,
 CONSTRAINT [PK__Hands__3213E83F03317E3D] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Decks]    Script Date: 05/09/2011 21:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Decks](
	[blackjack_table_id] [uniqueidentifier] NOT NULL,
	[suit] [int] NOT NULL,
	[card_value] [int] NOT NULL,
	[position_in_pack] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Table_and_Player]    Script Date: 05/09/2011 21:50:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Table_and_Player]
AS
SELECT        dbo.Players.dollars_in_pot, dbo.BlackJackTables.finished, dbo.BlackJackTables.id, dbo.BlackJackTables.can_accept_bet, dbo.BlackJackTables.can_deal, 
                         dbo.BlackJackTables.player_token
FROM            dbo.BlackJackTables INNER JOIN
                         dbo.Players ON dbo.BlackJackTables.player_token = dbo.Players.id
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
         Begin Table = "BlackJackTables"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Players"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
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
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Table_and_Player'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Table_and_Player'
GO
/****** Object:  View [dbo].[Players_Bets]    Script Date: 05/09/2011 21:50:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Players_Bets]
AS
SELECT        bet, blackjack_table_id, id
FROM            dbo.Hands
WHERE        (discriminator = N'Player')
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
         Begin Table = "Hands"
            Begin Extent = 
               Top = 16
               Left = 171
               Bottom = 169
               Right = 356
            End
            DisplayFlags = 280
            TopColumn = 1
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
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Players_Bets'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Players_Bets'
GO
/****** Object:  Table [dbo].[CardsInHand]    Script Date: 05/09/2011 21:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardsInHand](
	[hand_id] [uniqueidentifier] NOT NULL,
	[suit] [nvarchar](50) NOT NULL,
	[card_value] [nvarchar](50) NOT NULL,
	[is_hidden] [bit] NOT NULL,
	[name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[clear]    Script Date: 05/09/2011 21:50:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[clear]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	
	delete Decks; 
	delete CardsInHand;
	delete Hands;
	delete BlackJackTables;
	delete Players;

	RETURN
GO
/****** Object:  Default [DF_Players_dollars_in_pot]    Script Date: 05/09/2011 21:50:42 ******/
ALTER TABLE [dbo].[Players] ADD  CONSTRAINT [DF_Players_dollars_in_pot]  DEFAULT ((0)) FOR [dollars_in_pot]
GO
/****** Object:  ForeignKey [FK_BlackJackTables_Players]    Script Date: 05/09/2011 21:50:42 ******/
ALTER TABLE [dbo].[BlackJackTables]  WITH CHECK ADD  CONSTRAINT [FK_BlackJackTables_Players] FOREIGN KEY([player_token])
REFERENCES [dbo].[Players] ([id])
GO
ALTER TABLE [dbo].[BlackJackTables] CHECK CONSTRAINT [FK_BlackJackTables_Players]
GO
/****** Object:  ForeignKey [FK_CardsInHand_Hands]    Script Date: 05/09/2011 21:50:42 ******/
ALTER TABLE [dbo].[CardsInHand]  WITH CHECK ADD  CONSTRAINT [FK_CardsInHand_Hands] FOREIGN KEY([hand_id])
REFERENCES [dbo].[Hands] ([id])
GO
ALTER TABLE [dbo].[CardsInHand] CHECK CONSTRAINT [FK_CardsInHand_Hands]
GO
/****** Object:  ForeignKey [FK_Decks_BlackJackTables]    Script Date: 05/09/2011 21:50:42 ******/
ALTER TABLE [dbo].[Decks]  WITH CHECK ADD  CONSTRAINT [FK_Decks_BlackJackTables] FOREIGN KEY([blackjack_table_id])
REFERENCES [dbo].[BlackJackTables] ([id])
GO
ALTER TABLE [dbo].[Decks] CHECK CONSTRAINT [FK_Decks_BlackJackTables]
GO
/****** Object:  ForeignKey [FKEAA04F03EBAA6582]    Script Date: 05/09/2011 21:50:42 ******/
ALTER TABLE [dbo].[Hands]  WITH CHECK ADD  CONSTRAINT [FKEAA04F03EBAA6582] FOREIGN KEY([blackjack_table_id])
REFERENCES [dbo].[BlackJackTables] ([id])
GO
ALTER TABLE [dbo].[Hands] CHECK CONSTRAINT [FKEAA04F03EBAA6582]
GO
