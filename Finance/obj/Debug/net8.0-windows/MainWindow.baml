   M S B A M L   `   `   `  ����B  >Finance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FinanceFinance  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5
   	   G(clr-namespace:Finance.UserControlFinanceFinance.UserControlFinance  5   	       Finance.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Finance     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5
   	   7uc(clr-namespace:Finance.UserControlFinance     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��
mainWindow��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   ���#F2F2F2  MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    
 MainVM � DataContext# [ 5   	    � Title$' !Phần Mềm Quản Lý Chi Tiêu��5   	   $	��700��6+   $	��625��68    � 	Resources 5         Finance.IndexConverter  IndexConverter��%   &	         5   
   6   5       .  (System.Windows.Interactivity.Interaction   Triggers 5#      /  )System.Windows.Interactivity.EventTrigger  5$   
   	   	EventName$	 Loaded��6   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5%      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedWindowCommand+5&      .��5(      �  � RowDefinitions 5)   
   �� 5*      $
��auto �6   6,   �� 5+      6   .+�5.   
   � $��0��6   .+�5/      -   'Finance.UserControlFinance.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ 
mainWindow��6N   50      � 52   
   $��1��6    53      �� 54      $
��auto �6    60   �� 55      6"   .+�59      � $��0��6   .+�5:      � $��Stretch=�6   $��Stretch=�65   
������  5;       �� 
TargetType �� Property �� Value��%�   '��       �� 5<      " ��6    .�5=      ��  � ��$ 2 4 2 4q�67   6I   �� 5>       � ��
 �����6O   5?      5@       � ColumnDefinitions 5B      �� 5C      6-   �� 5D      6-   �� 5E      6-   .+�5H      �� $��1��6   
������� � ToolTip$ Thêm giao dịch��6}   ��6O   �� *AddTransactionViewCommand+.��5I      �  5J      �� 5K   "   62   �� 5L   "   62   .+�5O      � $��0��6#   .+�5P   "   �� $��Center=�6,   $��Thêm giao dịch��6I   6a   5Q      � 5S      $��1��6#   .+�5T   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6:   $��25��6E   $��Center=�6Q      Kind$ 
WalletPlus=�6n   5U      5V      5W      �� 5Y      $��0��6   
�������$ Số dư��6v   ��6P   �� *BudgetViewCommand+.��5Z      �  5[      �� 5\   "   62   �� 5]   "   62   .+�5`      � $��0��6#   .+�5a   "   �� $��Center=�6,   $��Số dư��6I   6X   5b      � 5d      $��1��6#   .+�5e   "     $��25��6:   $��25��6E   $��Center=�6Q   $ Cash100=�6n   5f      5g      5h      �� 5j      $��2��6   
�������$ Thống kê��6v   ��6O   �� *ReportsViewCommand+.��5k      �  5l      �� 5m   "   62   �� 5n   "   62   .+�5q      � $��0��6#   .+�5r   "   �� $��Center=�6,   $��Thống kê��6I   6[   5s      � 5u      $��1��6#   .+�5v   "     $��25��6:   $��25��6E   $��Center=�6Q   $ ViewGrid=�6n   5w      5x      5y      5z      5{      � 5~      $��1��6    5      �� 5�      $	��200 �6$   63   �� 5�      6&   .+�5�      � $��0��6   .+�5�      #	  LiveCharts.Wpf.CartesianChart	  &
   LiveCharts.Wpf.Charts.Base.Chart 
  LegendLocation$ Right=�6M   
���   � 
  Series 6)   �� *SeriesCollection+ 
  AxisY 5�        LiveCharts.Wpf.Axis     Title$	 VND��6'      MinValue$ 0Q�6Y      LabelFormatter 63   �� *
YFormatter+6h    
  AxisX 5�        $ Ngày��6'      Labels 64   �� *Labels+6P   5�      5�      #  MaterialDesignThemes.Wpf.Card  5�      ���#3E4A59$��1��6;   $��5q�6H   $��Stretch=�6S   .��5�      �  5�      �� 5�      $
��auto �6,   6<   �� 5�      $
��auto �6,   6<   �� 5�      6.   .+�5�      � $��0��6   $��5q�6,    5�      �� 5�   "   $
��auto �63   6B   �� 5�   "   $
��auto �63   6B   �� 5�   "   $
��auto �63   6B   .+�5�      � $��0��6#   .+�5�   "   (  "System.Windows.Controls.DatePicker  $��Center=�6-   $
��Left=�6H   $	��100��6c   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ngày bắt đầu��6o    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6�   �� *	StartDate+5�      � 5�      $��1��6#   .+�5�   "     $��Center=�6-   $
��Left=�6H   $	��100��6c   $ Ngày kết thúc��6o   #��[ 6�    6�   �� *	EndDate+5�      � 5�      $��2��6#   .+�5�   "   ��   GradientMaterialButtonStyle#��[ 6)   $��5q�6^   $	��100��5�   )   $��Lọc��5�   )   $/ )Resource name: MaterialDesignRaisedButton��5�   )   ��5�   )   �� *Filter+5�   #   5�      5�      � 5�      $��1��6   .+�5�      �� 6*   5�      � 5�      $��2��6   .+�5�      ��  �� AlternationCount$
 1000��6D   ��6'   �� *List+  �� View  5�   "   �� 5�   &   .P�5�   *   �� $	��STT��69   ! �� CellTemplate! 5�   .   �� 5�   2   .R�5�   6   �� $��Right=�6@   ��6\   �� " �� RelativeSource" �� # �� AncestorType# ListViewItem$ �� Path$%$ (ItemsControl.AlternationIndex)�% �� StringFormat$% {0:0}��& �� 	Converter#& [ 5�   3   5�   +   �� 5�   *   $��Tên giao dịch��69   ' �� DisplayMemberBinding' 6P   �� *TransactionName+6�   �� 5�   *   $��Số tiền��69   ' 6J   �� *TransactionMoney+6~   �� 5�   *   $��Ngày��69   ' 6G   �� *TransactionDate+6z   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      