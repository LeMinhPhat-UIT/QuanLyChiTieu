   M S B A M L   `   `   `  ����B  >Finance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FinanceFinance  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5
   	   G(clr-namespace:Finance.UserControlFinanceFinance.UserControlFinance  5   	       Finance.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Finance     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5
   	   7uc(clr-namespace:Finance.UserControlFinance     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��
mainWindow��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    
 MainVM � DataContext# [ 5   	    � Title$' !Phần mềm quản lý chi tiêu��5   	   $	��700��6+   $	��625��68   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedWindowCommand+5       .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��auto �6   6,   �� 5%      6   .+�5(   
   � $��0��6   .+�5)      -   'Finance.UserControlFinance.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ 
mainWindow��6N   5*      � 5,   
   $��1��6    5-      �� 5.      $
��auto �6    60   �� 5/      6"   .+�53      � $��0��6   .+�54      � $��Stretch=�6   $��Stretch=�65   
������  � 	Resources 55       �� 
TargetType �� Property �� Value��%�   '��       �� 56      " ��6    .�57      ��  � ��$ 2 4 2 4q�67   6I   �� 58       � ��
 �����6O   59      5:       � ColumnDefinitions 5<      �� 5=      6-   �� 5>      6-   �� 5?      6-   .+�5B      �� $��0��6    � ToolTip$ Thêm giao dịch��6[   ��6-   �� *AddTransactionViewCommand+.��5C      �  5D      �� 5E   "   62   �� 5F   "   62   .+�5I      � $��0��6#   .+�5J   "   �� $��Center=�6,   $��Thêm giao dịch��6I   6a   5K      � 5M      $��1��6#   .+�5N   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6:   $��25��6E   $��Center=�6Q      Kind$ 
WalletPlus=�6n   5O      5P      5Q      �� 5S      $��1��6   $ Số dư��6S   ��6-   �� *BudgetViewCommand+.��5T      �  5U      �� 5V   "   62   �� 5W   "   62   .+�5Z      � $��0��6#   .+�5[   "   �� $��Center=�6,   $��Số dư��6I   6X   5\      � 5^      $��1��6#   .+�5_   "     $��25��6:   $��25��6E   $��Center=�6Q   $ Cash100=�6n   5`      5a      5b      �� 5d      $��2��6   $ Thống kê��6T   ��6-   �� *ReportsViewCommand+.��5e      �  5f      �� 5g   "   62   �� 5h   "   62   .+�5k      � $��0��6#   .+�5l   "   �� $��Center=�6,   $��Thống kê��6I   6[   5m      � 5o      $��1��6#   .+�5p   "     $��25��6:   $��25��6E   $��Center=�6Q   $ ViewGrid=�6n   5q      5r      5s      5t      5u      � 5x      $��1��6    5y      �� 5z      $	��200 �6$   63   �� 5{      6&   .+�5      � $��0��6   .+�5�      #  LiveCharts.Wpf.CartesianChart  &	   LiveCharts.Wpf.Charts.Base.Chart 	  LegendLocation$ Right=�6N    	  Series 6*   �� *SeriesCollection+ 	  AxisY 5�      
  LiveCharts.Wpf.Axis
   
  Title$	 VND��6'    
  LabelFormatter 63   �� *
YFormatter+6[    	  AxisX 5�      
  $ Tháng��6'    
  Labels 65   �� *Labels+6Q   5�      5�      #  MaterialDesignThemes.Wpf.Card  5�      $��1��6&   $��5q�63   $��Stretch=�6>   .��5�      �  5�      �� 5�      $
��auto �6,   6<   �� 5�      $
��auto �6,   6<   �� 5�      6.   .+�5�      � $��0��6   $��5q�6,    5�      �� 5�   "   $
��auto �63   6B   �� 5�   "   $
��auto �63   6B   �� 5�   "   $
��auto �63   6B   .+�5�      � $��0��6#   .+�5�   "   (  "System.Windows.Controls.DatePicker  $��Center=�6-   $
��Left=�6H   $	��100��6c   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ngày bắt đầu��6o    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6�   �� *	StartDate+5�      � 5�      $��1��6#   .+�5�   "     $��Center=�6-   $
��Left=�6H   $	��100��6c   $ Ngày kết thúc��6o   #��[ 6�    6�   �� *	EndDate+5�      � 5�      $��2��6#   .+�5�   "   ��   MaterialDesignRaisedButton#��[ 6)   $��5q�6]   $	��100��5�   )   $��Lọc��5�   )   $/ )Resource name: MaterialDesignRaisedButton��5�   )   ��5�   )   �� *Filter+5�   #   5�      5�      � 5�      $��1��6   .+�5�      �� 6*   5�      � 5�      $��2��6   .+�5�      �� ��6'   �� *List+ �� View 5�   "   �� 5�   &   .P�5�   *   �� $	��STT��69   6H   �� 5�   *   $��Tên giao dịch��69    �� DisplayMemberBinding 6P   �� *TransactionName+6�   �� 5�   *   $��Số tiền��69    6J   �� *TransactionMoney+6~   �� 5�   *   $��Ngày��69    6G   �� *TransactionDate+6z   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      