   M S B A M L   `   `   `  ����H  DDesktopClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DesktopClient.UtilDesktopClient.Util  5      9!clr-namespace:DesktopClient.ViewsDesktopClient.Views  5      !    DesktopClient.Views.CarView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1util clr-namespace:DesktopClient.Util     5      3local!clr-namespace:DesktopClient.Views     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ Border��5      $��5q�6!   ���#fcc603$��
10,10,0,10q�6K   ._�5      �  � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��5* �6$   .+�5      �� .+�5      ]� $��10q�6    .+�5      ��  �� Orientation$ 
Horizontal=�6%   $
��Left=�6>   $��Center=�6Y   .+�5      �� $��30(�6C   ���#03a5fc$��Heavy"�6f   ��6(   �� *	Car.Brand+6f   �� 5      $�� ��6(   $��20(�61   �� 5      $��30(�6C   ���#03a5fc$��Heavy"�6f   ��6(   �� *	Car.Model+6f   5      �� 5      ���#03a5fc$��Right=�6:   $��Center=�6V   .+�5      �� $��10q�6)   
�������$��15(�6H   $��Heavy"�6V   ��6i   �� *
Car.Year+5      5       ]� 5!      $	��5,0q�6    .+�5"      �� $ 
Horizontal=�6%   $	��5,0q�6>   .+�5#      �� $
��Left=�6$   $��20��6?   $&�� \Resources\Images\icon_seats.gif��6K   �� 5$      $
��Left=�6(   $	��Top=�6C   ���#03a5fc��6[   �� *Car.Capacity+6y   5%      �� 5&      $ 
Horizontal=�6%   $	��5,0q�6>   .+�5'      �� $
��Left=�6$   $��20��6?   $'��!\Resources\Images\icon_diesel.gif��6K   �� 5(      $
��Left=�6(   $	��Top=�6C   ���#03a5fc$��10,0,0,0q�6�   ��6[   �� *Car.Consumation+6�   �� 5)      ���#03a5fc��6(   .   (DesktopClient.Util.LocalizationExtension  *
strPerKm+6L   5*      5+      5,      �� 5-      $��1��6   .+�5.      �� $��10q�68   $
��Fill=�6D   ��6   �� *
Car.Path+6D   5/      50      51      �� 52   
   $��1��6   $��Disabled=�6B   ��6"   �� *	Periods+��53      �� 54      .R�55      � ��6   ��  �� ElementName$ Border�� �� Path$ ActualWidth�  56      �� 57      $��* �6/   �� 58      $��* �6/   �� 59      $
��0.5* �6/   .+�5;      �� $��0��6%   .+�5<      �� $��15(�6L   ���#03a5fc��6(     *
strFrom:+6Z   �� 5=      $ 
Horizontal=�6)   .+�5>   "   �� $��20��6(   $��Center=�64   $%��\Resources\Images\date-icon.png��6O   �� 5?   "   $��5q�6,   $��20(�67   ��6E   �� *From+5@      5A      �� 5B      $��1��6%   .+�5C      �� $��15(�6J   ���#03a5fc��6(     *strTo:+6X   �� 5D      $ 
Horizontal=�6)   .+�5E   "   �� $��20��6(   $��Center=�64   $%��\Resources\Images\date-icon.png��6O   �� 5F   "   $��5q�6,   $��20(�67   ��6E   �� *To+5G      5H      �� 5I      $��2��6%   .+�5J      �� $��15(�6P   ���#03a5fc��6(     *strLocation:+6^   �� 5K      $ 
Horizontal=�6)   .+�5L   "   �� $��20��6(   $��Center=�64   $)��#\Resources\Images\location-icon.png��6O   �� 5M   "   $��5q�6,   $��20(�67   ��6E   �� *
Location+5N      5O      5P      5Q      5S      5T      5U      