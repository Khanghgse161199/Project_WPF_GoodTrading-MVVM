   M S B A M L   `   `   `  ����F  BGoodTrading, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GoodTrading.ViewsGoodTrading.Views  5   	   *    $GoodTrading.Views.HistoryTradeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GoodTrading.Views     5   	     � Title$  HistoryTradeWindow��5   	   $	��450��6$   $	��800��61   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.1* �6   6,   �� 5      $
��0.8* �6   6,   �� 5      $
��0.1* �6   6,   .+�5   
   � $��0��6   .+�5      ��  J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 3Q�6'      Opacity$	 0.3Q�67   6G   ._�5      �� $��Center=�6   $��20(�69   $��0 10 0 0q�6G   History-Trading5      5      5      � 5   
   $��1��6   .+�5      �� $��5q�6   $��0q�6"   ��66   �� *SourceHistoryItem+ �� View 5      �� 5      .P�5      �� .��5      �� .��64   
FromGood5        �� CellTemplate 5!      �� 5"   "   .R�5#   &   � .+�5$   *   �� 
���   �$��DemiBold"�6G   $��Center=�6w   ��6]   �� *
FromGood+6�   5%   '   5&   #   5(      �� 5)      .��5*      �� .��64   ToGood5,       5-      �� 5.   "   .R�5/   &   � .+�50   *   �� 
���   �$��DemiBold"�6G   $��Center=�6u   ��6]   �� *ToGood+6�   51   '   52   #   54      �� 55      .��56      �� .��64   ToUser58       59      �� 5:   "   .R�5;   &   � .+�5<   *   �� 
���   �$��DemiBold"�6G   $��Center=�6u   ��6]   �� *ToUser+6�   5=   '   5>   #   5@      �� 5A      .��5B      �� .��64   Date5D       5E      �� 5F   "   .R�5G   &   � .+�5H   *   �� 
���   �$��DemiBold"�6G   $��Center=�6y   ��6]   �� *
CreateDate+6�   5I   '   5J   #   5L      5M      5O      5P      � 5Q   
   $��2��6   .+�5R      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5S      �� -   5        $��	btnCancel��5S      .��6B   Cancel6J   5T      5U      5V      5W      