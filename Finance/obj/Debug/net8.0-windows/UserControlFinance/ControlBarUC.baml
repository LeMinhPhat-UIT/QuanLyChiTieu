   M S B A M L   `   `   `  ����B  >Finance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Finance.UserControlFinanceFinance.UserControlFinance  5      -    'Finance.UserControlFinance.ControlBarUC   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Finance.UserControlFinance     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5        $��ucControlBar��5      .  (System.Windows.Interactivity.Interaction    Triggers  5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *MouseMoveWindowCommand+   CommandParameter 5   $   ��  �� ElementName$ ucControlBar��5      .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Custom=�6#   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,0&�67   .��5      � 	 � Color$	 #8E44AD��6#   
 � Offset$	
 0.0Q�63   � 5      $	 #C0392B��6#   $	
 1.0Q�63   5      .��5      ]� .+�5      �� $��Right=�6   
������  �� Orientation$ 
Horizontal=�6M    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6    .�5       ��  � ��$ 2 4 2 4q�67   6I   �� 5!       � ��$ 40��66   6C   5"      5#      .+�5%      �� 
������ $��0q�66   
������  � ToolTip$ 	Thu nhỏ��5(       c� OverflowMode$ AsNeeded=�6/   
���������5&      �� *MinimizeWindowCommand+��5'      �� $ ucControlBar��.��5*      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�62   5+      �� 5-      
������ $��0q�66   
������ $ 	Phóng to��50      $ AsNeeded=�60   
���������5.      �� *MaximizeWindowCommand+��5/      �� $ ucControlBar��.��52        $ WindowMaximize=�62   53      �� 55      
������ $��0q�66   
������ $ Đóng��58      $ AsNeeded=�6,   
���������56      �� *CloseWindowCommand+��57      �� $ ucControlBar��.��5:        $ WindowClose=�62   5;      5<      �� 5>      $��Right=�6   $ Vertical=�64   .+�5?      �� $��Center=�6    $��Center=�5@       $
��Bold"�5A       
�������$��	125 5 0 0q�5C       ��63   �� *Tag+$ ucControlBar��5D      5E      5G      5H      5I      5J      