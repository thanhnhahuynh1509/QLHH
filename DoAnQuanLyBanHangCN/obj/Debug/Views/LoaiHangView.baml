   M S B A M L   `   `   `  ����N  JDoAnQuanLyBanHangCN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DoAnQuanLyBanHangCN.ViewsDoAnQuanLyBanHangCN.Views  5      ,    &DoAnQuanLyBanHangCN.Views.LoaiHangView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:DoAnQuanLyBanHangCN.Views     5      -   5        $��r0c0i Linotte)�5      .��5      � .+�5   
   ��   �� CornerRadius$  	0,0,15,15��6   $��2��5      ���#1b6d825      � 5   
   $��15q�6   .+�5      �� -   5         ��Name$ BtnAdd��5         ButtonToolExitTopMenu#��[  5      $��Right=�5      $	��Top=�5      ���#77D970���#fff$��Thêm��5      $��20(�5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ listLoaiHang��5"         AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�5         CanUserAddRows .   �� AlternationCount$ 100000��5       $	��700��5!         	CellStyle 5%      �� 5&       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   	 �� BasedOn	 5'      Z� .�5(      �� 
 �� Property
 �@�OverridesDefaultStyle �� Value . 6B   �� 5)      
 � ��$ Center=�6E   �� 5*      
 � ��$ Center=�6G   �� 5+      
 � �� 5,      �� 5-   "    �� 
TargetType"  62   .R�5.   &   �� #��z��6-   #��z��5/      #��z��50       J� SnapsToDevicePixels . ._�52   *   �� # z 6;   $��Center=�6w   $��Center=�6�   53   '   54   #   56      57         Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��5>         FontSize$ 18Q�5?         
Foreground �#333   
FontWeight$
 Bold"�5A         
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 5D      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5C      �� *AlternationIndex+ �� RelativeSource ��  �� AncestorType$ DataGridRowL�   HeaderStyle 5G      �� 5H      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5I   "   �� 
 � �� �#3335J   )   �� 5K   "   
 � ��$ Center=�5L   )   �� 5M   "   
 � ��$ 20q�5N   )   �� 5O   "   
 � ��$ 20(�6=   �� 5P   "   
 � ��$ Heavy"�6?   5R      5T        5Y      $ Tên Loại��5Z      $ 18Q�5[       �#333$
 Bold"�5]       . $	 350 5`       5_      ��  �� Path$	 Ten� 5c      �� 5d      "  6$   .�5e   "   �� 
 � �� �#3335f   )   �� 5g   "   
 � ��$ Center=�5h   )   �� 5i   "   
 � ��$ 20q�5j   )   �� 5k   "   
 � ��$ 20(�6=   �� 5l   "   
 � ��$ Heavy"�6?   5n      5p      4  .System.Windows.Controls.DataGridTemplateColumn  5r         MinWidth$	 120Q�6-      CellTemplate 5s      �� 5t      .R�5u   "   �� $ BtnSua��6)   -   5        $��Sửa��5v   )   #��[  5x   )   ���#FFC069���#fff5z   )   5{      5~        5�      $	 120Q�6-    5�      �� 5�      .R�5�   "   �� $ BtnXoa��6)   -   5        $
��Xóa��5�   )   $��10q�5�   )   #��[  5�   )   ���#A9333A���#fff5�   )   5�      5�      5�      �� 5�      $��/Images/4.png��6   $	��100��6+   $	��100��67   $��1360,80,10,457q�6D   �� 5�      $��/Images/5.png��6   $	��100��6+   $	��100��67   $��197,10,1173,527q�6D   �� 5�      $1��+/DoAnQuanLyBanHangCN;component/Images/6.png��6   $	��100��6I   $	��100��6U   $��65,270,1305,267q�6b   �� 5�      $1��+/DoAnQuanLyBanHangCN;component/Images/8.png��6   $	��100��6I   $	��100��6U   $��1271,486,99,51q�6b    J� RenderTransformOrigin$ 	0.38,0.75&�6z   �� 5�      $1��+/DoAnQuanLyBanHangCN;component/Images/7.png��6   $	��100��6I   $	��100��6U   $��1181,210,189,327q�6b   $ 	0.38,0.75&�6|   �� 5�      $1��+/DoAnQuanLyBanHangCN;component/Images/9.png��6   $	��100��6I   $	��100��6U   $��239,462,1131,75q�6b   $ 	0.38,0.75&�6{   5�      5�      5�      