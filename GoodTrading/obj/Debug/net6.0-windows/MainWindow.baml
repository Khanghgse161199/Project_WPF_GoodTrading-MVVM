   M S B A M L   `   `   `  ����F  BGoodTrading, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GoodTradingGoodTrading  5   	       GoodTrading.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GoodTrading     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.1* �6   6,   �� 5      $
��0.8* �6   6,   �� 5      $
��0.1* �6   6,   .+�5   
   � .+�5      �� $��Center=�6   $��Center=�63   $��20(�6P   TrandingPlace5      5      � 5   
   $��1��6   .+�5      �� .+�5      �� .@�5      �� $��SignIn��6   .��5      �  5   "   �� 5   &   $
��0.2* �64   6D   �� 5   &   $
��0.6* �64   6D   �� 5   &   $
��0.2* �64   6D   .+�5   "   � $��1��6'   .+�5    "   �� $	��118��6-   $	��Top=�6:   .+�5!   &   �� $	��300��6,   .��69   
UserName6C   �� 5"   &   $	��300��6.   ��6:   �� *
UserName+6V   �� 5#   &   $	��300��6,   .��68   
PassWord6B   �� 5$   &   $	��300��6.   ��6:   �� *
Password+6V   �� 5%   &   $��0 2 0 0q�6-   $	��100��6>   $��30��6J   $��login��6V   ��6f   �� *LoginButton+6�   5&   #   5'   #   5(      5*      �� 5+      $��SignUp��6   .��5-      �  5.      �� 5/   "   $
��0.2* �60   6@   �� 50   "   $
��0.6* �60   6@   �� 51   "   $
��0.2* �60   6@   .+�53      � $��1��6#   .+�54   "   �� ��6,   �� *	Message+6G   55      � 56      $��2��6#   .+�57   "   �� $	��118��6-   $	��Top=�6:   .+�58   &   �� $	��300��6,   .��68   
UserName6B   �� 59   &   $	��300��6.   ��6:   �� *
UserName+6V   �� 5:   &   $	��300��6,   .��68   
PassWord6B   �� 5;   &   $	��300��6.   ��6:   �� *
Password+6V   �� 5<   &   $��0 2 0 0q�6-   $	��100��6>   $��30��6t   $��Register��6�   ��6J   �� *RegisterButtonClicked+6�   5=   #   5>      5?      5A      5B      5C      5D      5E      5F      