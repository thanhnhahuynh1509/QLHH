   M S B A M L   `   `   `  ����N  JDoAnQuanLyBanHangCN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DoAnQuanLyBanHangCNDoAnQuanLyBanHangCN  5   	   $    DoAnQuanLyBanHangCN.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:DoAnQuanLyBanHangCN     5   	   W SFontAwesome5.Net, Version=2.1.4.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5   	   -   5        $��r0c0i Linotte)�5	   	     � WindowStyle$
  None=�5
   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��900��6   $
��1500��6)   .��5      �� -   5         ��Name$ BackgroundWindow��5       �� CornerRadius$ 15��6'   ���#0C4271._�5   
   � .+�5      �� -   5        $ BackgroundWindowCorner��5      ���#0C4271$ 15,0,1800,0��6J   $��0,0,600,100q�6e   6|   � 5       � RowDefinitions 5      �� 5      �� 5      $��6* �6$   .+�5!      � $��0��6   .+�5$      ��  �� Orientation$ 
Horizontal=�6!   $
��Left=�5%   !   $��Center=�5&   !   $��10,0,0,0q�5'   !   .+�5)      �� $	 600��6!   ���#fff$��90��5+   !   $��80��5,   !   $��0,0,10,0q�5-   !   ._�5.      �� $��./Images/1.png��6$   6>   5/      �� 52      $��CELL PHONE F��6$   $��Center=�53   $   $��Center=�54   $   $��30(�55   $   $��Heavy"�56   $   ���#fff$��0,0,50,0q�58   $   68   �� 5;      -   5         ��Name$ 
BtnHangHoa��5;   W      ButtonTopMenu#��[  6!   $��18(�6I   ��5<      �� 5>   "   $ 
Horizontal=�6-   $��Center=�6F   .+�5?   &   �� 	 �� Padding$	 	10,0,10,0q�60   
HÀNG HÓA5A   '   5B   #   5D      �� 5F      -   5        $ 	BtnDichVu��5F   H   #��[  6!   $��18(�6s   ��5G      �� 5H   "   $	 	10,0,10,0q�6,   DỊCH VỤ5J   #   5L      �� 5N      -   5        $ BtnAbout��5N   H   #��[  6!   $��18(�6q   ��5O      �� 5P   "   $	 	10,0,10,0q�6,   VỀ CHÚNG TÔI5R   #   5T      �� 5V      -   5        $ 
BtnGioHang��5V   H   #��[  6!   $��18(�6u   ��5W      �� 5X   "   $	 	10,0,10,0q�6,   GIỎ HÀNG CỦA BẠN5Z   #   5\      5]      �� 5`      $ 
Horizontal=�6!   $��Right=�5a   !   $��Center=�5b   !   .+�5c      �� -   5        $ BtnUser��5g   !     ButtonToolExitTopMenu#��[ 5c   !   $
��auto��5d   !   $
��auto��5e   !   $��	0,0,30,70q�5f   !   ��5i        FontAwesome5.ImageAwesome  5j   "   
   Icon$
 
Solid_User=�63      
Foreground �#EAE7C6$��25��6Z   5l      �� 5m      -	   5        $ 	BtnLogout��5q   !   #��[ 5m   !   $
��auto��5n   !   $
��auto��5o   !   $��	0,0,30,70q�5p   !   ��5s        5t   "   $
 Solid_SignOutAlt=�63    �#333$��25��6]   5v      �� 5w      -
   5        $ BtnExit��5{   !   #��[ 5w   !   $
��auto��5x   !   $
��auto��5y   !   $��	0,0,10,70q�5z   !   ��5}        5~   "   $
 Solid_PowerOff=�63    �#F54748$��25��6^   5�      5�      5�      �� 5�      $��1��6!   ��6.   �� 5�      5�      5�      5�      