   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	       Library.AddVidWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	     � Title$  AddVidWindow��5   	      AnotherWindows#��[  6    � WindowStartupLocation$ CenterScreen=�6F   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��1* �6   .+�5   
   �� $��./Images/pngegg.png��6   $	��103��6-   $��81��69   $��0��6E   $��0��6R   $��0 0 80 0q�6b   6v   �� 5   
   $��1��6   $��0��6"   $��0 30 0 0q�62   .+�5      �� -   5          
Navigation#��[ 5   %   $��0 0 0 20q�6I   $��
Назад��6[   6m   �� 5      -   5        #��[ 5   #   $��0 0 0 20q�6G   $��
Выход��6Y   6k   �� 5      $"��Поиск читателя:��6   �� 5      -   5         ��Name$ searches��5        
MenuSearch#��[ 6(   6i   5      �� 5   
   -   5         ��Name$ titlee��5   `   $��0��6   $��1��6    
 Header#��[ 6-   $��	30 35 0 0q�6M   .��6p   #!Оформление выдачи6�   �� 5   
   $��1��6   $��1��6"   $��30,34,425,204q�62   .+�5      �� .��6   Книга:6   �� 5      -   5        $ booking��5      ${�False��6'   6;   �� 5      6   �� 5      .��6   $"Выберите читателя:6(   �� 5      -   5         ��Name$ searchReader��5   m   ��6   �� *	Readers+ �� SelectedItem 67   �� *Extradition.ReaderNavigation+��5       �� 5!      .R�5"      �� �� 5#   "   �6&   �� *
ReaderName+ �� 5$      �6"   �� *
LastName+ �� 5%      �6"   �� *	SurName+5&      5'      5)      �� 5*      $��0 30 0 0q�6   .��6&   '%Укажите дату выдачи:6<   (  "System.Windows.Controls.DatePicker  5+      -   5          Name$ vidDate��5+      	   SelectedDate	 6*   �� *	DateExtra+6O   �� 5,      6   �� 5-      .��6   %#Укажите дату сдачи:6)     5.      -   5        $ backDate��5.      	 6+   �� *
DateBack+6O   �� 5/      6   �� 50      
 �� Orientation$
 
Horizontal=�6   $	��423��62   $
��Left=�6>   $
��0 40q�6Y   .+�51      �� -	   5          OformButton#��[ 51   (   $��0 0 10 0q�6M   .��6_   Добавить6i   �� 52      -
   5        #��[ 52   (   $��	15 0 10 0q�6M   .��6`   Отменить6j   53      54      55      56      