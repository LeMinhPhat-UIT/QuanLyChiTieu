   M S B A M L   `   `   `  ����B  >Finance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FinanceFinance  5   	   G(clr-namespace:Finance.UserControlFinanceFinance.UserControlFinance  5	   	       Finance.BudgetView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Finance     5   	   7uc(clr-namespace:Finance.UserControlFinance     5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � Title$ Số Dư��5   	   $	��500��6   $	��500��6$   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5       -   'Finance.UserControlFinance.ControlBarUC  
 � Tag 6   �� *Title+	 �� ElementName$	 window��6J   5!      � 5#   
   $��1��6    5$      �� 5%      $
��auto �6    60   �� 5&      $
��auto �6    60   �� 5'      6"   .+�5+      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5,      � $��0 0 0 10q�6   .+�5-      �� )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Tên ví tiền��6   $��5 5 15 5q�6K    % !MaterialDesignFloatingHintTextBox#��[ 6y   $��Center=�6�   ��6]   �� *
WalletName+6�   �� 5.      $
 Số tiền��6   $��5 5 15 5q�6G   #��[ 6p   $��Center=�6�   ��6Y   �� *Money+6�   �� 5/      -   5        $��walletTypeList��5/      $
 Loại ví tiền��65   $��	5 5 15 -3q�6c      HintOpacity$	 .26Q�50       �� 
IsEditable$ False��51      ��52      �� *
WalletType+ �� Mode$ TwoWay=� �� SelectedItem 53      �� *SelectedWalletType+54      (  "System.Windows.Controls.DatePicker  55      $	��100��6E   $��5 5 15 5q�6Q   $
 Ngày cập nhật��6c    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6!   �� *
UpdateDate+6�   56      57        59      $��1��6"   $��5q�6/   .��5:      � .+�5;      �� -   5        $	��Add��5;   R     GradientMaterialButtonStyle#��[ 6   $��Thêm��6|   $��5q�6�   $	��115��6�   ��6]   �� *
AddCommand+6�   �� 5<      #��[ 6   $��Sửa��6r   $��5q�6�   $	��115��6�   ��6R   �� *EditCommand+6�   �� 5=      #��[ 6   $
��Xóa��6t   $��5q�6�   $	��115��6�   ��6R   �� *DeleteCommand+6�   5>      5?        5A      ���#3E4A59$��2��67   $��5q�6D   $��Stretch=�6O   .��5B      �� $
��Auto=�6   .��5C      �� -   5         �� SelectionMode$ Multiple=�5C   �   ��6   �� *
WalletList+ 6B   �� *SelectedWallets+$ OneWayToSource=� �� View 5D      �� 5E      .P�5F   "   �� $��Tên ví tiền��61    �� DisplayMemberBinding 6F   �� *
WalletName+6t   �� 5G   "   $��Số tiền��61    6B   �� *Money+6k   �� 5H   "   $��Loại ví tiền��61    6G   �� *
WalletType+6u   �� 5I   "   $��Ngày cập nhật��61    6H   �� *
UpdateDate+6v   5J      5L      5M      5N      5O      5P      5Q      