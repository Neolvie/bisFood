   M S B A M L   `   `   `  ����H  DManagerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ManagerClient.View.PagesManagerClient.View.Pages  5      7 clr-namespace:ManagerClient.ViewManagerClient.View  5      '    !ManagerClient.View.Pages.MainPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ManagerClient.View.Pages     5      2views clr-namespace:ManagerClient.View     5        � DataContext  5	      ��  �� RelativeSource �� *Self+.��5      �  � ColumnDefinitions 5   
   �� 5      $	��33* �6   �� 5      $	��33* �6   �� 5      $	��33* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6$   $��
Блюдо��61   �� 5   
   -   5        $��DishList��5      $��0��5      $��1��6"   ��6/   �� *Dishes+ �� SelectedItem 5      �� *SelectedDish+��5      �� 5      .R�5      �� ��6    �� *Name+5       5"      �� 5$   
   $��1��6   $��0��6$   $��Полуфабрикат��61   �� 5%   
   -   5        $��PrepackList��5'      $��1��5%      $��1��6"   ��6/   �� *
Prepacks+ 5&      �� *SelectedPrepack+��5)      �� 5*      .R�5+      �� ��6    �� *Name+5,      5.      �� 50   
   $��2��6   $��0��6$   $��Продукт��61   �� 51   
   -   5        $��ProductList��53      $��2��51      $��1��6"   ��6/   �� *
Products+ 52      �� *SelectedProduct+��55      �� 56      .R�57      �� ��6    �� *Name+58      5:      �� 5<   
   $��3��6   $��3��6"   $��0��66   .+�5=      �� -   5        $��LoadAll��5=   )   $��Загрузить��6   68   5>      5?      5@      