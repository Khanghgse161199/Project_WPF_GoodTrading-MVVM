   M S B A M L   `   `   `  ����F  BGoodTrading, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GoodTrading.ViewsGoodTrading.Views  5   	   '    !GoodTrading.Views.WorkSpaceWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GoodTrading.Views     5   	     � Title$  WorkSpaceWindow��5   	   $	��450��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $��20 �6   6*   �� 5      $
��0.2* �6   6,   �� 5      $
��0.7* �6   6,   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   .+�5      � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� ��6   �� *UpLoadButtonClicked+ �� UpdateSourceTrigger$ PropertyChanged=�.��6j   UpLoad6r   �� 5      ��6   �� *UserGoodsList+$ PropertyChanged=�.��6d   	YourGoods6o   �� 5      ��6   �� *UserHistoryTrade+$ PropertyChanged=�.��6g   HistoryTrade6u   5      5      � 5      $��1��6   .+�5      �� .+�5      �� $��Center=�6    Trading Goods6L   �� 5      $��0 10 0 0q�6    ��62   �� *	Message+6M   5       5!      � 5"      $��2��6   .+�5#      �� $ 
Horizontal=�6   $��Right=�66   .+�5$      �� $��Right=�6    $��0 0 10 0q�6z   ��6<   �� *
Username+$ PropertyChanged=�6�   �� 5%      $��Right=�6   ��69   �� *LogoutButtonClicked+.��6a   Logout6i   5&      5'      5(      � 5)   
   $��1��6   .+�5*      � $��Center=�6   $��50��6.   .+�5+      �� $ 
Horizontal=�6   $��Center=�66   .+�5,      �� $��40��6`   $	��300��6l   $��Center=�6x   $��Center=�6�   ��6   �� *SearchValue+$ PropertyChanged=�6�   �� 5-      $��40��6   $	��100��6)   ��65   �� *SearchButtonClicked+.��6]   Search6e   5.      5/      50      � 51   
   $��2��6    52      �� 53      $
��0.1* �6    60   �� 54      $
��0.8* �6    60   �� 55      $
��0.1* �6    60   .+�57      � $��Right=�6   .+�58      �� $��↻ Refresh��6=   $��5 5 5 5q�6Q   ��6   �� *refreshBtnClick+6d   59      �� 5:      $��1��6   .��5;      ��  �� SelectedItem 6   �� *
GoodChoice+��6?   �� *
AllGoods+ �� View 5<      �� 5=      .P�5>      ��  �� Width$	 140��6-   $��Product��69    �� DisplayMemberBinding 5?   
   �� *Name+�� 5@      $	 140��6-   $��Price��69    5A   
   �� *Price+�� 5B      $	 140��6-   $��Description��69    5C   
   �� *Description+�� 5D      $	 140��6-   $��Username��69    5E   
   �� *User.UserName+5F      5H      5I      � 5J      $��3��6   $��Center=�6    .+�5K      �� ��6   �� *TradeButtonCliked+.��6?   Trade6F   5L      5M      5N      5O      