   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Library.ConvertersLibrary.Converters  5   	   !clr-namespace:LibraryLibrary  5   	       Library.VidBooks   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1conv clr-namespace:Library.Converters     5   	   'localclr-namespace:Library     5   	     � Title$  VidBooks��5	   	      AnotherWindows#��[  6    � WindowStartupLocation$ CenterScreen=�6B    � DataContext 6g   ��  �� Mode$ OneWay=� �� RelativeSource �� *Self+ � 	Resources 5
      )  #Library.Converters.DateToBackground  whh��%   &	         5   
   6    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��1* �6   .+�5   
   �� $��./Images/pngegg.png��6   $	��103��6-   $��81��69   $��0��6E   $��0��6R   $��0 0 80 0q�6b   6v   �� 5   
   $��1��6   $��0��6"   $��0 30 0 0q�62   .+�5      �� -   5          
Navigation#��[ 5   &   $��0 0 0 20q�6J   $��
Назад��6\   6n   �� 5      -   5        #��[ 5   %   $��0 0 0 20q�6I   $��
Выход��6[   6m   5      �� 5   
   $��0��6   $��1��6"   .+�5      ��  
 Header#��[ 6   $��70 0 0 5q�64   .��6F   Выданные книги6V   �� 5       
 MenuUp#��[ 6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0 0 0 0q�66   .+�5      �� .��6   Поиск:6$   �� 5       -   5        	 ��Name$	 searchTextBox��5         
MenuSearch#��[ 65   6p   5!      5"      5#      �� 5$   
   $��1��6   $��1��6    $��Disabled=�61   ��6g   �� *	Readers+��5%      �� 5&      .R�5'      � $��0 0 0 0q�6n   ��6   �� 
 �� ElementName$

 what�� �� Path$
 Text� �� 	Converter# [  5(      �� 5)      $	��375 �6/   �� 5*      $	��127 �6/   �� 5+      $	��189 �6/   .+�5-      �� $��7q�6%   $��0��60   .+�5.      �� $��16(�6(   $
��Wrap=�66   Название: �� 5/   $   �6(   �� *BookNavigation.BookName+�� 50      Автор: �� 51   !   �6%   �� *BookNavigation.Author+�� 52      
Жанр: �� 53       �6$   �� *+)BookNavigation.GenreiNavigation.GenreName+�� 54      Год издания: �� 55   '   �6+   �� *BookNavigation.YearIzd+�� 56      Отдана: �� 58      �6   �� *ReaderNavigation.ReaderName+ �� 59   "   �6&   �� *ReaderNavigation.LastName+ �� 5:   "   �6&   �� *ReaderNavigation.SurName+�� 5;      Оформлено: �� 5<   %   �6)   �� *	DateExtra+�� 5=      Вернуть до: �� 5>   &   �6*   �� *
DateBack+ �� 5?   "   $y�Hidden=�6,   �� 5@   &    ��Name$
 what��6T   �6*   �� *
IsThatTrue+$ OneTime=�6T   5A   #    �� 5B   "    5C   &    �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value��%�   '��       �� 5D   *   " ��60   .�5E   .   ��  � y�$ Hidden=�6K    5F   .   �� 5G   2    6>   �� *
IsThatTrue+$ OneTime=� 06k   .a�5I   6   ��  � y�$ Visible=�6S   5J   3   5L   +   5M   '   �� 5N   &   $�Штраф: ��6*    �� 5O   &   �6*   �� *BookNavigation.Price+ �� 5P   &   $�руб.��6*   5Q   #   5R      5S      �� 5T      $��2��6%   $	��Top=�67   .+�5U      �� -   5          Help#��[ 5U   %   $��0 0 0 10q�6C   $��Right=�6U   .��5V   "   �� $��./Images/change.png��6(   5W      �� 5X      -   5          OformButton#��[ 5X   %   $��Bottom=�6J   $��Right=�6e   .��6�   Принять книгу6�   5Y      5Z      5[      ��5]      �� 5^      .R�5_      � 5`      5b      5c      5d      