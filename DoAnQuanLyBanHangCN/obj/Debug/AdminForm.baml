   M S B A M L   `   `   `  ����N  JDoAnQuanLyBanHangCN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DoAnQuanLyBanHangCNDoAnQuanLyBanHangCN  5   	   #    DoAnQuanLyBanHangCN.AdminForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:DoAnQuanLyBanHangCN     5   	   W SFontAwesome5.Net, Version=2.1.4.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5   	   -   5        $��r0c0i Linotte)�5   	     � WindowStyle$
  None=�5	   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��900��6   $
��1500��6)   .��5      �� -   5         ��Name$ BackgroundWindow��5       �� CornerRadius$ 15��6'   ���#A2D2FF._�5   
   � .+�5      �� -   5        $ BackgroundWindowCorner��5      ���#B5DEFF$ 15,0,1800,0��6J   $��0,0,600,100q�6e   6|   � 5       � RowDefinitions 5      �� 5      �� 5      $��6* �6$   .+�5       � $��0��6   .+�5#      ��  �� Orientation$ 
Horizontal=�6!   $
��Left=�5$   !   $��Center=�5%   !   $��10,0,0,0q�5&   !   .+�5(      �� $	 600��6!   ���#fff$��90��5*   !   $��80��5+   !   $��0,0,10,0q�5,   !   ._�5-      �� $��./Images/1.png��6$   6>   5.      �� 51      $��CELL PHONE F��6$   $��Center=�52   $   $��Center=�53   $   $��30(�54   $   $��Heavy"�55   $   ���#fff$��0,0,50,0q�57   $   68   �� 5:      -   5         ��Name$ 
BtnHangHoa��5:   W      ButtonTopMenu#��[  6!   $��18(�6I   ��5;      �� 5=   "   $ 
Horizontal=�6-   $��Center=�6F   .+�5>   &   �� 	 �� Padding$	 	10,0,10,0q�60   
HÀNG HÓA5@   '   5A   #   5C      �� 5E      -   5        $ BtnLoaiHang��5E   H   #��[  6!   $��18(�6w   ��5F      �� 5G   "   $	 	10,0,10,0q�6,   LOẠI HÀNG5I   #   5K      �� 5M      -   5        $ BtnHangHanHoa��5M   H   #��[  6!   $��18(�6{   ��5N      �� 5O   "   $	 	10,0,10,0q�6,   HÃNG HÀNG HÓA5Q   #   5S      �� 5U      -   5        $ BtnDonDatHang��5U   H   #��[  6!   $��18(�6{   ��5V      �� 5W   "   $	 	10,0,10,0q�6,   ĐƠN ĐẶT HÀNG5Y   #   5[      5\      �� 5_      $ 
Horizontal=�6!   $��Right=�5`   !   $��Center=�5a   !   .+�5b      �� -   5        $ 	BtnLogout��5f   !     ButtonToolExitTopMenu#��[ 5b   !   $
��auto��5c   !   $
��auto��5d   !   $��	0,0,20,70q�5e   !   ��5h        FontAwesome5.ImageAwesome  5i   "   
   Icon$
 Solid_SignOutAlt=�63      
Foreground �#333$��25��6]   5k      �� 5l      -	   5        $ BtnExit��5p   !   #��[ 5l   !   $
��auto��5m   !   $
��auto��5n   !   $��	0,0,10,70q�5o   !   ��5r        5s   "   $
 Solid_PowerOff=�63    �#F54748$��25��6^   5u      5v      5x      �� 5|      $��1��6!   ��6.   �� 5~      5�      5�      5�      