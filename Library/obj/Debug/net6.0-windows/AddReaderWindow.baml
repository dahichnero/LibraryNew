   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	       Library.AddReaderWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	     � Title$  AddReaderWindow��5   	      AnotherWindows#��[  6!    � WindowStartupLocation$ CenterScreen=�6I   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��1* �6   .+�5   
   �� $��./Images/pngegg.png��6   $	��103��6-   $��81��69   $��0��6E   $��0��6R   $��0 0 80 0q�6b   6v   �� 5   
   $��1��6   $��0��6"   $��0 30 0 0q�62   .+�5      �� -   5          
Navigation#��[ 5   %   $��0 0 0 20q�6I   $��
Назад��6[   6m   �� 5      -   5        #��[ 5   #   $��0 0 0 20q�6G   $��
Выход��6Y   6k   5      �� 5   
   -   5         ��Name$
 what��5      $��0��6   $��1��6+    
 Header#��[ 6;   $��	30 35 0 0q�6[   .��6o   Читатели6y   �� 5   
   $��1��6   $��1��6"   $��30,30,0,191q�62   .+�5      �� .��6   Фамилия:6   �� 5      -   5         ��Name$ lastnameText��5      .��6E   ��5      �� 5       �� Path$ Readerr.LastName�6    �� NotifyOnValidationError$
 True��66    �� UpdateSourceTrigger$ PropertyChanged=�6U   	 �� ValidationRules	 5      5  /System.Windows.Controls.DataErrorValidationRule  5      5       .��5!       5"      �� 5#      6   �� 5$      .��6   	Имя:6   �� 5%      -   5        $ nameText��5%      .��6A   ��5&      �� 5'      $ Readerr.ReaderName�6   $
 True��68   $ PropertyChanged=�6W   	 5(        5)      5+      .��5,       5-      �� 5.      6   �� 5/      .��6   Отчество:6   �� 50      -   5        $ surnmaeText��50      .��6D   ��51      �� 52      $ Readerr.SurName�6   $
 True��65   $ PropertyChanged=�6T   	 53        54      56      .��57       58      �� 59      6   �� 5:      .��6   $"Электронная почта:6(   �� 5;      -   5        $ 	emailText��5;      .��6B   ��5<      �� 5=      $ Readerr.ReaderEmail�6   $
 True��69   $ PropertyChanged=�6X   	 5>        5?      5A      .��5B       5C      �� 5D      6   �� 5E      .��6   Телефон:6   �� 5F      -   5        $ 	phoneText��5F      .��6B   ��5G      �� 5H      $ Readerr.Phone�6   $
 True��63   $ PropertyChanged=�6R   	 5I        5J      5L      .��5M       5N      �� 5O      6   �� 5P      
 �� Orientation$
 
Horizontal=�6   $	��276��62   $
��Left=�6>   $
��0 20q�6Y   .+�5Q      �� -	   5         ��Name$	 add��5Q        OformButton#��[ 64   $��0 0 10 0q�6Y   .��6k   Добавить6u   �� 5R      -
   5        $
 addC��5R      #��[ 64   $��	15 0 10 0q�6Y   .��6l   Отменить6v   5S      5T      5U      5V      