   M S B A M L   `   `   `  ����F  BGoodTrading, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GoodTrading.ViewsGoodTrading.Views  5   	   #    GoodTrading.Views.TradeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GoodTrading.Views     5   	     � Title$  TradeWindow��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.3* �6   6,   �� 5      $
��0.6* �6   6,   �� 5      $
��0.1* �6   6,   .+�5   
   � $��0��6    5      �� 5      $
��0.2* �6    60   �� 5      $
��0.8* �6    60   .+�5      �� $��0��6   .��6!   Your Chosen Product66   � 5      $��1��6    5      �� 5      $
��0.5* �6$   64   �� 5      6&    � ColumnDefinitions 5      �� 5      $
��0.2* �6'   66   �� 5      $
��0.1* �6'   66   �� 5      $
��0.5* �6'   66   �� 5      $
��0.2* �6'   66   .+�5       �� $��Center=�6   $��Center=�69   Product Name6b   �� 5!      $��1��6   $��Center=�6,   $��Center=�6I   Product Price6s   �� 5"      $��2��6   $��Center=�6,   $��Center=�6I   Product Description6y   �� 5#      $��3��6   $��Center=�6,   $��Center=�6I   User6j   �� 5$      $��1��6   $��Center=�6)   $��0��6F   ��6V   �� *UserGoodChoice.Name+6}   �� 5%      $��1��6   $��Center=�6)   $��1��6F   ��6V   �� *UserGoodChoice.Price+6   �� 5&      $��1��6   $��Center=�6)   $��2��6F   ��6V   �� *UserGoodChoice.Description+6�   5(      5)      � 5*   
   $��1��6    5+      �� 5,      $
��0.1* �6    60   �� 5-      $
��0.8* �6    60   .+�5/      �� $��0��6   .��6!   Can trade products (of you)6>   � 50      $��1��6   .+�51      �� $��1��6   .��52      ��  �� SelectedItem 6    �� *ToGood+��6A   �� *	UserGoods+ �� View 53      �� 54      .P�55   "   ��  �� Width$	 140��61   $��Product��6=    �� DisplayMemberBinding 56   
   �� *Name+�� 57   "   $	 140��61   $��Price��6=    58   
   �� *Price+�� 59   "   $	 140��61   $��Description��6=    5:   
   �� *Description+�� 5;   "   $	 140��61   $��Username��6=    5<   
   �� *User.UserName+5=      5?      5@      5A      5B      � 5C   
   $��2��6   .+�5D      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5E      �� $	��100��6?   $��5 5 5 5q�6K   ��6   �� *ConfrimBtnClicked+.��6\   	Confirm6e   �� 5F      $	��100��6>   $��5 5 5 5q�6J   ��6   �� *cancelBtnClicked+.��6[   Cancel6c   5G      5H      5I      5J      