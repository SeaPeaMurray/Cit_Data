   M S B A M L   `   `   `  ����L  HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow  5      1    +USAspendingWindow.USASpendingloaderadvanced   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:USAspendingWindow     5      a ]Awesomium.Windows.Controls, Version=1.7.5.1, Culture=neutral, PublicKeyToken=7a34e179b8b61c39,awe"http://schemas.awesomium.com/winfx  5      -   5        $	��722��5
      $	��924��6   .��5      � ��5   
   �� 5        �� ImageSource$N  H/USAspendingWindow;component/1024215-1366x768-%5bDesktopNexus_com%5d.jpg��6   .+�5   
   �� -   5        $��button1��5   ]   $
��Load��6   $��23��6!   $
��Left=�6-   $��481,212,0,0q�6H   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $��label1��5   �   $C��=Pick the Fiscal Year, or nothing to default the current year.��6   $��36��6X   $
��Left=�6d   $��	17,97,0,0q�6   $	��Top=�6�   $	��335��6�   
�������$��18(�6�   �� 5   
   -   5        $��	comboBox1��5   O   $��23��6   $
��Left=�6    $��
17,147,0,0q�6;   $	��Top=�6`   $	��120��6x   �� 5   
   -   5        $��label2��5   �   $F��@Pick the date of the year to update from, or nothing for default��6   $
��Left=�6[   $��
17,166,0,0q�6v   
�������$��36��6�   $	��Top=�6�   $��18(�6�   �� 5   
   -   5        $��label3��5   �   $4��.USASpending.gov downloader and database update��6   $��63��6I   $
��Left=�6U   $��	17,41,0,0q�6p   $	��Top=�6�   $��24(�6�   $	��621��6�   $��Bookman Old Style)�6�   
�������6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePicker1��5   w   $��25��6;   $
��Left=�6G   $��111,212,0,0q�6b   $	��Top=�6�   $	��115��6�      DisplayDate 6   �� *DateTime.Now+6�   �� 5   
   -   5        $��textBox1��5       �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$
 Auto=�67   " �� VerticalScrollBarVisibility$
 Auto=�6\   $
��Left=�6   $	��141��6�   $	��408��6�   $	��Top=�6�   $��
14,261,0,0q�6�   +  %Awesomium.Windows.Controls.WebControl  5   
   -	   5        $��webControl1��5   /   $��168,261,12,0q�6   $	��408��6v   $	��Top=�6�   �� 5   
   -
   5        $��	comboBox2��5   O   $��23��6   $
��Left=�6   $��481,147,0,0q�6:   $	��Top=�6`   $	��260��6x   �� 5   
   -   5        $��label4��5   ]   $��Agency��6   $��36��6!   $��Right=�6-   $��
0,97,353,0q�6I   $	��Top=�6k   $��68��6�   
�������$��18(�6�   �� 5   
   -   5        $��image1��5   L   $	��129��6   $
��Left=�6   $��
673,12,0,0q�68   $
��Fill=�6Z   $	��Top=�6i   $	��200��6�   $/��)/USAspendingWindow;component/USA-icon.png��6�     5   
   -   5        $��datePicker2��5   v   $��25��6:   $
��Left=�6F   $��330,211,0,0q�6a   $	��Top=�6�   $	��115��6�    6   �� *DateTime.Now+6�   �� 5   
   -   5        $��label6��5   z   $	��End��6   $��18(�6   
�������$��36��6>   $
��Left=�6J   $��275,205,0,0q�6e   $	��Top=�6�   $��49��6�   �� 5   
   -   5        $��label7��5   {   $��Start��6   $��18(�6    
�������$��36��6@   $
��Left=�6L   $��
52,205,0,0q�6g   $	��Top=�6�   $��53��6�   �� 5    
   -   5        $��label8��5    {   $+��%WARNING!!!!! ADVANCED LOADING WINDOW!��6   $��37��6@   $
��Left=�6L   $��
135,12,0,0q�6g   $	��Top=�6�   $	��569��6�   $��Arial)�6�   
���  ��$��20(�6�   5!      5#      