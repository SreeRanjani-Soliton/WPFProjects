   M S B A M L   `   `   `  ����L  HDesktopContactApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DesktopContactAppDesktopContactApp  5   	   (    "DesktopContactApp.NewContactWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DesktopContactApp     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ NewContactWindow��5
   	   $	��300��6"   $	��400��6/   .��5      �� $��10q�6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� $��0��6   .��6$   Name6*   �� 5      -   5         ��Name$ nameTextBox��5   &   $��1��6   $��0,0,0,5q�6;   $
��Auto��6L   �� 5      $��1��6   $��0��6!   .��61   Email68   �� 5      -   5        $ emailTextBox��5   3   $��1��6   $��1��6#   $��0,0,0,5q�6I   $
��Auto��6Z   �� 5      $��2��6   $��0��6!   .��61   Phone Number6?   �� 5      -   5        $ phoneTextBox��5   3   $��2��6   $��1��6#   $��0,0,0,5q�6I   $
��Auto��6Z   5      �� 5   
   -   5        $
��Save��5      6    5      5       