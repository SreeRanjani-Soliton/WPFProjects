   M S B A M L   `   `   `  ����C  ?Triggers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TriggersTriggers  5   	       Triggers.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Triggers     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �� .+�5
   
   �� .��6   31Property Trigger-Changing Value on Property value6C   �� 5   
   $��Hello, styled world!��6   $��28(�60   $��Center=�6>   $��Center=�6[   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ��  �6B    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  � ��
 �  ��6;   �� 5       � ��$ 	Underline{�6@   5      5      5      �� 5   
   .��6   Data Trigger6   �� 5   
   -   5        $��cbSample��5      $��Hello World��6#   �� 5   
   $��Center=�6   $��0,20,0,0q�61   $��48(�6C   ��5      �� 5      " ��6   .�5      ��  � ��$ No��6-   �� 5       � ��
 �  ��63    5      �� 5        �� Binding 6&   ��  �� ElementName$ cbSample��	 �� Path$	 	IsChecked�
 �� Value
 True6_   .a�5!      ��  � ��$
 Yes!��65   �� 5"       � ��
 � � �6;   5#      5%      5'      �� 5(   
   -   5        $��	lblStyled��5(      $��Hello, styled world!��6%   $��18(�6A   $��Center=�6O   $��Center=�6l   ��5)      �� 5*      " ��6    5+      :� 5,       :� RoutedEvent$ 
MouseEnter��6'   [�5-      �� 5.   "   .��5/   &   �� .��50   *   W�  g� Duration$ 	0:0:0.300D�6:    �� TargetProperty$ FontSize�6O   	 W� To$ 28X�6t   51   '   52   #   54      :� 55      $ 
MouseLeave��6'   [�56      �� 57   "   .��58   &   �� .��59   *   W� $ 	0:0:0.800D�6:   $ FontSize�6O   $ 18X�6t   5:   '   5;   #   5=      5?      5A      5B      5C      