   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      L HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow 5      $   USAspendingWindow.querynewpiid   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      1localclr-namespace:USAspendingWindow     5      -   5        $	��722��5      $	��924��6     � Cursor  6;   �� *cursor+ � DataContext 5      - 'USAspendingWindow.querynewpiidviewmodel  5   
   .��5
      � .+�5   
   �� -   5        $��
rectangle1��5   B   $
��Left=�6   $��	41,63,0,0q�6/   
���   �$	��710��6c   $	��228��6o   $	��Top=�6|   �� 5   
   -   5        $��	comboBox1��5   �    �� DisplayMemberPath$ Display��66    �� SelectedValuePath$ Value��6R   $��23��6�   $��
369,98,0,0q�6�   $	��Top=�6�   $
��Left=�6.  $	��120��6I  ��6   �� *
fielditems+ �� SelectedValue 6l   �� *selectfield+ �� SelectedIndex 6�   �� *
fieldindex+6I  �� 5   
   -   5        $��	comboBox2��5   �   $ Display��69   $ Value��6U   $��23��6�   $
��Left=�6�   $��
495,98,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *stringopitems+ 6o   �� *selectstringop+6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePicker1��5   t   $��25��69   $
��Left=�6E   $��
621,98,0,0q�6`   $	��Top=�6�   $	��115��6�      SelectedDate 6   �� *
selectdate+6�   �� 5   
   -   5        $��textBox1��5   �   $��23��6`   $
��Left=�6l   $��621,100,0,0q�6�   $	��Top=�6�   $	��115��6�   ��6   �� *
numstrtext+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5   
   -   5        $��button1��5   �   $	��add��67   $	��Add��6N   $��23��6\   $
��Left=�6h   $��
52,178,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   �� 5   
   -   5        $��textBox2��5   �   $��76��6`   $
��Left=�6l   $��
63,207,0,0q�6�   $	��Top=�6�   $	��627��6�   	 �� 
IsReadOnly	 . "
 �� VerticalScrollBarVisibility$

 Auto=�6�    �� TextWrapping$
 Wrap=�6  ��6   �� *
filtertext+$ PropertyChanged=�$ TwoWay=�6  �� 5   
   -	   5        $��	comboBox3��5   �   $ Display��63   $ Value��6O   $��23��6�   $
��Left=�6�   $��
495,98,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *	opitems+ 6i   �� *
selectop+6�   �� 5   
   -
   5        $��button2��5   �   $	��try��67   $	��Try��6O   $��23��6]   $
��Left=�6i   $��141,178,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   �� 5   
   -   5        $��label2��5   d   $��Query New PIIDs��6   $��49��6*   $
��Left=�66   $��	41,12,0,0q�6Q   $	��Top=�6r   $	��196��6�   $��24(�6�   $��Arial)�6�   �� 5   
   -   5        $��button3��5   �   $��clear��67   $��Clear��6P   $��23��6`   $
��Left=�6l   $��235,178,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   �� 5   
   -   5        $��button4��5   �   $��query��67   $��Query��6P   $��23��6`   $
��Left=�6l   $��327,178,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dataGrid1��5   �      SelectionMode$ Single=�6      
IsReadOnly .    AutoGenerateColumns .  $	��323��6�   $
��Left=�6�   $��
41,297,0,0q�6�   $	��Top=�6�   $	��710��6  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6     CanUserAddRows .  ��6>   �� *
sumitems+ �� SelectedItem 6_   �� *
fieldindex+ J� InputBindings 5      d� 5       d� MouseAction$ LeftDoubleClicke�5       �� Command 5      �� *ClickCommand+ �� CommandParameter 5      �� *	sumitems/+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Vendor Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
vendorname+  5       $ Product Service Code��6%    6C   �� *productorservicecode+  5!      $ Principal NAICS Code��6%    6C   �� *principalnaicscode+  5"      $ Contract Vehicle��6%    6?   �� *contract_vehicle+  5#      $
 PIID��6%    63   �� *piid+  5$      $) #Description of Contract Requirement��6%    6R   �� *" descriptionofcontractrequirement+5(      �� 5)   
   -   5        $��	comboBox4��5)   �   $ Display��67   $ Value��6S   $��23��6�   $
��Left=�6�   $��	49,98,0,0q�6�   $	��Top=�6�   $	��188��6�   ��6   �� *agencyitems+ 6m   �� *selectfilteragency+6�   �� 5*   
   -   5        $��label3��5*   b   $��Filter value��6   $��28��6'   $
��Left=�63   $��
635,63,0,0q�6N   $	��Top=�6p   �� 5+   
   -   5        $��label4��5+   _   $��	Operation��6   $��28��6$   $
��Left=�60   $��
526,63,0,0q�6K   $	��Top=�6m   �� 5,   
   -   5        $��label5��5,   [   $��Field��6   $��28��6    $
��Left=�6,   $��
400,63,0,0q�6G   $	��Top=�6i   �� 5-   
   -   5        $��label6��5-   [   $��Agency��6   $��28��6!   $
��Left=�6-   $��	89,63,0,0q�6H   $	��Top=�6i   �� 5.   
   -   5        $��label7��5.   c   $��Search Filter��6   $��35��6(   $
��Left=�64   $��
305,26,0,0q�6O   $	��Top=�6q   $	��121��6�   $��Arial)�6�   $��16(�6�   �� 5/   
   -   5        $��button5��5/   �   $��excelcsv��67   $��Details to Excel��6S   $��23��6n   $
��Left=�6z   $��417,178,0,0q�6�   $	��Top=�6�   $��96��6�   ��6   �� *ViewSwitchCommand+6�   �� 50   
   -   5        $��button6��50   �   $��
excelpivot��67   $��Details to Excel Pivot��6U   $��23��6v   $��529,178,0,0q�6�   $	��Top=�6�   $
��Left=�6�   $	��129��6�   ��6   �� *ViewSwitchCommand+6�   �� 51   
   -   5        $��label1��51   [   $��Table��6   $��28��6    $
��Left=�6,   $��
283,63,0,0q�6G   $	��Top=�6i   $��52��6�   �� 52   
   -   5        $��	comboBox5��52   �   $ Display��66   $ Value��6R   $��23��6�   $
��Left=�6�   $��
243,98,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *
tableitems+ 6l   �� *selecttable+6�   �� 53   
   -   5        $��label99��53   [   $
��Year��6   $��28��6   $
��Left=�6+   $��283,122,0,0q�6F   $	��Top=�6j   �� 54   
   -   5        $��	comboBox6��54   �   $ Display��65   $ Value��6Q   $��23��6�   $
��Left=�6�   $��243,149,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *	yearitems+ 6k   �� *
selectyear+6�   �� 55   
   -   5        $��button7��55   e   $��Lookup GovWin��6   $��23��6)   $
��Left=�65   $��529,140,0,0q�6P   $	��Top=�6t   $	��129��6�   6�   56      57      