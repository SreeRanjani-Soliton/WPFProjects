   M S B A M L   `   `   `  ����G  CTreeViewDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TreeViewDemoTreeViewDemo  5   	       TreeViewDemo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TreeViewDemo     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	       �� 
TargetType �� Property �� Value��%Q   'Q�       �� 5
   
   " Q�6   .�5      ��  � ��$ 5q�6'   5      5      .��5      �� .+�5   
   R� .@�5      Q� $
��Menu��6    Q� 
IsExpanded . .@�5      Q� $��Child1��6    . .@�5      Q� $��	Child 1.1��6#    . .@�5      Q� ��5      �� 5   "    �� Orientation$ 
Horizontal=�6-   .+�5   &   �� 61   �� 5   &   Child 1.1.16=   5   #   5      Q� 5      $��
Child1.1.2��6'   6=   5      Q� 5      $��	Child 1.2��6#   68   5      Q� 5      $��Child2��6    . .@�5       Q� $��	Child 2.1��6#   68   Q� 5!      $��	Child 2.2��6#   68   5"      5#      5$      R� 5%   
   -   5        $��trvMenu��5%      ��5&      �� 5'       �� DataType   TreeViewDemo.MenuItem"  6+    �� ItemsSource 6N   �� *Items+.R�5(      �� ��6    �� *Title+69   5)      5+      5,      5-      