   M S B A M L   `   `   `  ����B  >Finance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FinanceFinance  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	   	   G(clr-namespace:Finance.UserControlFinanceFinance.UserControlFinance  5
   	       Finance.ReportsView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Finance     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5	   	   7uc(clr-namespace:Finance.UserControlFinance     5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � Title$ Thống kê��5   	   $	��800��6   $	��700��6'   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5!   
   � $��0��6   .+�5"      -   'Finance.UserControlFinance.ControlBarUC  
 � Tag 6   �� *Title+	 �� ElementName$	 window��6J   5#      � 5%   
   $��1��6    5&      �� 5'      $
��auto �6    60   �� 5(      $	��130 �6    6/   �� 5)      $
��auto �6    60   �� 5*      $	��130 �6    6/   �� 5+      $
��auto �6    60   �� 5,      $
��auto �6    60   �� 5-      6"   .+�5J      #  MaterialDesignThemes.Wpf.Card  $��1��6"   $��5q�6/   .��5K      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart
   LegendLocation$

 Left=�6I      Series 6%   �� *SeriesCollection+   AxisX 5M        LiveCharts.Wpf.Axis     Title$ Loại chi tiêu��6#      Labels 69   �� *Labels+6U      AxisY 5P        $	 VND��6#      LabelFormatter 6/   �� *	Formatter+6V   5R      5S        5U      $��2��6"   $��5q�6/   $��Stretch=�6:   
����  �
�������$��8q�5X   "   .��5Y      �� $��Center=�6   $��16(�5Z      $(��"Biểu đồ thống kê chi tiêu��5[      5\      5]        5_      $��3��6"   $��5q�6/   .��5`        $

 Left=�6J    6%   �� *SeriesCollection2+ 5b        $ Loại thu nhập��6#    69   �� *	Labels2+6V    5e        $	 VND��6#    6/   �� *
Formatter2+6W   5g      5h        5k      $��4��6"   $��5q�6/   $��Stretch=�6:   
����  �
�������$��8q�5n   "   .��5o      �� $��Center=�5p      $��16(�5q      $)��#Biểu đồ thống kê thu nhập��5r      5s      5t        5w      $��5��6"   $��5q�6/   $��Stretch=�6:   .��5x      � $��0��6   $��5q�6$    5y      �� 5z      6*   �� 5{      6*   .+�5~      � $��0��6    � ColumnDefinitions 5      �� 5�      $
��auto �6/   6>   �� 5�      61   .+�5�      �� $��Tổng thu nhập/Ngày: ��6$   $��0��6@   $��5 5 5 15q�6P   
�������6v   �� 5�      $��1��6<   $��5 5 5 15q�6L   ��6$   �� *Income+6`   5�      � 5�      $��1��6    5�      �� 5�      $��124.58 �6/   6@   �� 5�      61   .+�5�      �� $��Tổng chi tiêu/Ngày: ��6$   $��0��6@   $��5 5 5 15q�6P   
�������6v   �� 5�      $��1��6;   $��5 5 5 15q�6K   ��6$   �� *Spend+6_   5�      5�      5�        5�      $��6��6"   $��5q�6/   $��Stretch=�6:   .��5�      �� $
��Auto=�6   .��5�      �� ��6   �� *List+ �� SelectedItem 6<   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5�      �� 5�      .P�5�   "   �� $��Tên giao dịch��61    �� DisplayMemberBinding 6H   �� *TransactionName+6{   �� 5�   "   $��Số tiền��61    6B   �� *TransactionMoney+6v   �� 5�   "   $��Loại giao dịch��61    6I   �� *TransactionCatalog+6   5�      5�      5�      5�      5�      5�      5�      