   M S B A M L   `   `   `  ����B  >Finance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FinanceFinance  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	   	   G(clr-namespace:Finance.UserControlFinanceFinance.UserControlFinance  5
   	       Finance.ReportsView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Finance     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5	   	   7uc(clr-namespace:Finance.UserControlFinance     5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � Title$ Thống Kê Trong Ngày��5   	   $	��800��6%   $	��700��62   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5    
   � $��0��6   .+�5!      -   'Finance.UserControlFinance.ControlBarUC  
 � Tag 6   �� *Title+	 �� ElementName$	 window��6J   5"      � 5$   
   $��1��6    5%      �� 5&      $
��auto �6    60   �� 5'      $	��130 �6    6/   �� 5(      $
��auto �6    60   �� 5)      $	��130 �6    6/   �� 5*      $
��auto �6    60   �� 5+      $
��auto �6    60   �� 5,      6"   .+�5I      #  MaterialDesignThemes.Wpf.Card  $��1��6"   $��5q�6/   
�������
���   �.��5J      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart
   LegendLocation$

 Left=�6I   
���   �   Series 6%   �� *SeriesCollection+   AxisX 5L        LiveCharts.Wpf.Axis     Title$ Loại chi tiêu��6#      
Foreground
 �   �   Labels 69   �� *Labels+6h      AxisY 5O        $	 VND��6#   
 �   �   LabelFormatter 6/   �� *	Formatter+6i   5Q      5R        5T      $��2��6"   $��5q�6/   $��Stretch=�6:   
����  �
�������$��8q�5W   "   .��5X      �� $��Center=�6   $��16(�5Y      $(��"Biểu đồ thống kê chi tiêu��5Z      5[      5\        5^      $��3��6"   $��5q�6/   
�������
���   �.��5_        $

 Left=�6J   
���   � 6%   �� *SeriesCollection2+ 5a        $ Loại thu nhập��6#   
 �   � 69   �� *	Labels2+6i    5d        $	 VND��6#   
 �   � 6/   �� *
Formatter2+6j   5f      5g        5j      $��4��6"   $��5q�6/   $��Stretch=�6:   
����  �
�������$��8q�5m   "   .��5n      �� $��Center=�5o      $��16(�5p      $)��#Biểu đồ thống kê thu nhập��5q      5r      5s        5v      $��5��6"   $��5q�6/   $��Stretch=�6:   
�������.��5w      � $��0��6   $��5q�6$    5x      �� 5y      6*   �� 5z      6*   .+�5}      � $��0��6    � ColumnDefinitions 5~      �� 5      $	��130 �6/   6=   �� 5�      61   .+�5�      �� $��Tổng thu nhập/Ngày: ��6$   $��0��6@   $��5 5 5 15q�6P   
�������6v   �� 5�      $��1��6<   $��5 5 5 15q�6L   
���   ���6$   �� *Income+6s   5�      � 5�      $��1��6    5�      �� 5�      $	��130 �6/   6=   �� 5�      $	��69* �6/   6=   �� 5�      $
��481* �6/   .+�5�      �� $��Tổng chi tiêu/Ngày: ��6$   $��0��6@   $��5,5,5,15q�6P   
�������6v   �� 5�      $��1��6;   $��5 5 5 15q�6K   $��2��6]   
���   ���6$   �� *Spend+6�   5�      5�      5�        5�      ���#3E4A59$��6��67   $��5q�6D   $��Stretch=�6O   .��5�      �� $
��Auto=�6   .��5�      �� ��6   �� *List+ �� SelectedItem 6<   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5�      �� 5�      .P�5�   "   �� $��Tên giao dịch��61    �� DisplayMemberBinding 6H   �� *TransactionName+6{   �� 5�   "   $��Số tiền��61    6B   �� *TransactionMoney+6v   �� 5�   "   $��Loại giao dịch��61    6I   �� *TransactionCatalog+6   5�      5�      5�      5�      5�      5�      5�      