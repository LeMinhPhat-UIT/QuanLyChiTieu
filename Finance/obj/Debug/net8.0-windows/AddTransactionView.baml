   M S B A M L   `   `   `  ����B  >Finance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FinanceFinance  5   	   G(clr-namespace:Finance.UserControlFinanceFinance.UserControlFinance  5	   	        Finance.AddTransactionView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Finance     5   	   7uc(clr-namespace:Finance.UserControlFinance     5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � Title$ Thêm giao dịch��5   	   $	��500��6    $	��800��6-   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5       -   'Finance.UserControlFinance.ControlBarUC  
 � Tag 6   �� *Title+	 �� ElementName$	 window��6J   5!      � 5#   
   $��1��6    5$      �� 5%      $
��auto �6    60   �� 5&      $
��auto �6    60   �� 5'      6"   .+�5+      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5,      � .+�5-      �� )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Tên giao dịch��6   $��5 5 15 5q�6M    % !MaterialDesignFloatingHintTextBox#��[ 6�   $��Center=�6�   ��6_   �� *TransactionName+6�   �� 5.      $
 Số tiền��6   $��5 5 15 5q�6G   #��[ 6{   $��Center=�6�   ��6Y   �� *TransactionMoney+6�   �� 50      $
 Dòng tiền��6   $��	5 5 15 -3q�6J      HintOpacity$	 .26Q�51       �� 
IsEditable$ False��52      ��53      �� *CatalogMoneyFlow+ �� Mode$ TwoWay=� �� SelectedItem 54      �� *SelectedCatalogMoneyFlow+59      �� 5;      $
 
Danh mục��6   $��	5 5 15 -3q�6I   $	 .26Q�5<      $ False��5=      ��5>      �� *CatalogName+$ TwoWay=� 5?      �� *SelectedCatalogName+5C      �� 5E      $
 
Ví tiền��6   $��	5 5 15 -3q�6H   $	 .26Q�5F      $ False��5G       �� DisplayMemberPath$ 
WalletName��5H      ��5I      �� *
WalletList+$ TwoWay=� 5J      �� *SelectedWallet+5O      (  "System.Windows.Controls.DatePicker  5Q      $	��100��6J   $��5 5 15 5q�6V   $
 Ngày giao dịch��6h    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6!   �� *TransactionDate+6�   5R      5S        5U      $��1��6"   $��5q�6/   .��5V      � $��0 0 0 10q�6   .+�5W      �� $��Thêm��6<   $��5q�6K   $	��100��6V   ��6   �� *
AddCommand+6d   �� 5X      $��Sửa��6=   $��5q�6K   $	��100��6V   ��6   �� *EditCommand+6d   �� 5Y      $
��Xóa��6?   $��5q�6M   $	��100��6X   ��6   �� *DeleteCommand+6f   5Z      5[        5]      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5^      �� $
��Auto=�6   .��5_      �� -   5         �� SelectionMode$ Multiple=�5_   �   ��6   �� *TransactionList+ 6G   �� *SelectedTransactions+$ OneWayToSource=� �� View 5`      �� 5a      .P�5b   "   �� $��Tên giao dịch��61    �� DisplayMemberBinding 6H   �� *TransactionName+6{   �� 5c   "   $��Số tiền��61    6B   �� *TransactionMoney+6v   �� 5d   "   $��Dòng tiền��61    6D   �� *TransactionMoneyFlow+6|   �� 5e   "   $��
Danh mục��61    6C   �� *TransactionCatalog+6y   �� 5f   "   $��
Ví tiền��61    6B   �� *
WalletID+6n   �� 5g   "   $��Ngày giao dịch��61    6I   �� *TransactionDate+6|   5h      5j      5k      5l      5m      5n      5o      