   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	       Library.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	     � Title$  
MainWindow��5   	    	  Login#��[  6    � WindowStartupLocation$ CenterScreen=�6;   .��5	      �� .+�5
   
   �� $��./Images/pngegg.png��6   $	��178��6-   $	��146��69   $��	0 14 0 28q�6F   6[   �� 5   
     LoginLabels#��[ 6   $��55 0 0 0q�65   .��6G   Логин:6O   �� 5   
   -   5         ��Name$	 log��5        	LoginPass#��[ 6   6D   �� 5   
     	LoginLine#��[ 6   $��0 0 0 20q�62   6F   �� 5   
   #��[ 6   $��55 0 0 0q�65   .��6G   Пароль:6P   G� 5   
   -   5         G�Name$
 pass��5      6&   �� 5   
   #��[ 6   $��0 0 0 20q�62   6F   �� 5   
   -   5         ��Name$ isKioskCheckBox��5      $��	60 0 0 25q�6,   .��6?   Войти как гость6P   �� 5   
    �� Orientation$ 
Horizontal=�6   $	��240��6.   .+�5      �� -   5        $��
Войти��5        LoginButton#��[ 62   6Y   �� 5      -   5          	LoginExit#��[ 5   "   $��10 0 0 0q�6E   .��5      �� $��./Images/exit.png��6   5      5      5      5      