   M S B A M L   `   `   `  ����G  CListViewDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ListViewDemoListViewDemo  5   	       ListViewDemo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ListViewDemo     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��400��6)   .��5	      �� .+�5
   
   �� .��6   Simple List View6"   �� 5   
   .@�5      �� .��6   Apple6"   �� 5      .��6   Orange6#   �� 5      .��6   Mango6"   5      �� 5   
   .��6   List View with DataBinding6,   �� 5   
   -   5        $��LVDataTemplate��5      ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� ��6$   ��  �� Path$
 Name� �� StringFormat$ Name:{0}��6X   �� 5      ��6$   �� $	 Age�$ ;Age:{0}��6W   �� 5      ��6$   �� $ Email�$ ({0})��6W   5      5      5      �� 5   
   .��6   List View with GridCiew6)   �� 5   
   -   5        $��
LVGridView��5       � 	Resources 5       �� 
TargetType �� Property �� Value��%T   '��       �� 5      " ��6   .�5       ��  � ��$
 Left=�6C   5!      5"       �� View 5#      �� 5$      .P�5%      �� $
��Name��6%   	 �� Width$		 120��63   
 �� DisplayMemberBinding
 6?   �� $
 Name�6l   �� 5&      $	��Age��6%   $	 50��62   
 6=   �� $	 Age�6i   �� 5'      $��Email��6%   $		 150��64    �� CellTemplate 5(      �� 5)      .R�5*   "   �� $��	Underline{�6I   
����  � � Cursor$
 Hand��6w   ��6-   �� $ Email�6�   5+      5-      5.      50      51      52      