   M S B A M L   `   `   `  ����F  BGoodTrading, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GoodTrading.ViewsGoodTrading.Views  5   	   !    GoodTrading.Views.UserGoods   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GoodTrading.Views     5   	     � Title$  	UserGoods��5   	   $	��450��6   $	��800��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.1* �6   6,   �� 5      $
��0.9* �6   6,   .+�5   
   � $��0��6   .+�5      �� $��20(�6   $��Center=�6&   Your Product6Q   5      � 5   
   $��1��6   .+�5      �� ��6   �� *ListOfGoods+ �� View 5      �� 5      .P�5      ��  �� Width$	 140��6)   $��Product��65    �� DisplayMemberBinding 5   
   �� *Name+�� 5      $	 140��6)   $��Price��65    5   
   �� *Price+�� 5      $	 140��6)   $��Description��65    5   
   �� *Description+5      5      5      5       5!      