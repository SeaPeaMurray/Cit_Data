   M S B A M L   `   `   `  ���� L  HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow  1    +USAspendingWindow.USASpendingloaderadvanced   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:USAspendingWindow     a ]Awesomium.Windows.Controls, Version=1.7.5.1, Culture=neutral, PublicKeyToken=7a34e179b8b61c39,awe"http://schemas.awesomium.com/winfx  -   $	��722��$	��924��.��� ����   �� ImageSource$N  H/USAspendingWindow;component/1024215-1366x768-%5bDesktopNexus_com%5d.jpg��.+��� -   $��button1��$
��Load��$��23��$
��Left=�$��481,212,0,0q�$	��Top=�$��75���� -   $��label1��$C��=Pick the Fiscal Year, or nothing to default the current year.��$��36��$
��Left=�$��	17,97,0,0q�$	��Top=�$	��335��
�������$��18(��� -   $��	comboBox1��$��23��$
��Left=�$��
17,147,0,0q�$	��Top=�$	��120���� -   $��label2��$F��@Pick the date of the year to update from, or nothing for default��$
��Left=�$��
17,166,0,0q�
�������$��36��$	��Top=�$��18(��� -   $��label3��$4��.USASpending.gov downloader and database update��$��63��$
��Left=�$��	17,41,0,0q�$	��Top=�$��24(�$	��621��$��Bookman Old Style)�
�������(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��25��$
��Left=�$��111,212,0,0q�$	��Top=�$	��115��   DisplayDate �� *DateTime.Now+�� -   $��textBox1�� �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$
 Auto=�" �� VerticalScrollBarVisibility$
 Auto=�$
��Left=�$	��141��$	��408��$	��Top=�$��
14,261,0,0q�+  %Awesomium.Windows.Controls.WebControl  -	   $��webControl1��$��168,261,12,0q�$	��408��$	��Top=��� -
   $��	comboBox2��$��23��$
��Left=�$��481,147,0,0q�$	��Top=�$	��260���� -   $��label4��$��Agency��$��36��$��Right=�$��
0,97,353,0q�$	��Top=�$��68��
�������$��18(��� -   $��image1��$	��129��$
��Left=�$��
673,12,0,0q�$
��Fill=�$	��Top=�$	��200��$/��)/USAspendingWindow;component/USA-icon.png��  -   $��datePicker2��$��25��$
��Left=�$��330,211,0,0q�$	��Top=�$	��115�� �� *DateTime.Now+�� -   $��label6��$	��End��$��18(�
�������$��36��$
��Left=�$��275,205,0,0q�$	��Top=�$��49���� -   $��label7��$��Start��$��18(�
�������$��36��$
��Left=�$��
52,205,0,0q�$	��Top=�$��53���� -   $��label8��$+��%WARNING!!!!! ADVANCED LOADING WINDOW!��$��37��$
��Left=�$��
135,12,0,0q�$	��Top=�$	��569��$��Arial)�
���  ��$��20(�