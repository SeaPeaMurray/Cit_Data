   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  L HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow $   USAspendingWindow.querynewpiid   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     1localclr-namespace:USAspendingWindow     -   $	��722��$	��924��  � Cursor  �� *cursor+ � DataContext - 'USAspendingWindow.querynewpiidviewmodel  .��� .+��� -   $��
rectangle1��$
��Left=�$��	41,63,0,0q�
���   �$	��710��$	��228��$	��Top=��� -   $��	comboBox1�� �� DisplayMemberPath$ Display�� �� SelectedValuePath$ Value��$��23��$��
369,98,0,0q�$	��Top=�$
��Left=�$	��120������ *
fielditems+ �� SelectedValue �� *selectfield+ �� SelectedIndex �� *
fieldindex+�� -   $��	comboBox2��$ Display��$ Value��$��23��$
��Left=�$��
495,98,0,0q�$	��Top=�$	��120������ *stringopitems+ �� *selectstringop+(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��25��$
��Left=�$��
621,98,0,0q�$	��Top=�$	��115��   SelectedDate �� *
selectdate+�� -   $��textBox1��$��23��$
��Left=�$��621,100,0,0q�$	��Top=�$	��115������ *
numstrtext+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� -   $��button1��$	��add��$	��Add��$��23��$
��Left=�$��
52,178,0,0q�$	��Top=�$��75������ *ViewSwitchCommand+�� -   $��textBox2��$��76��$
��Left=�$��
63,207,0,0q�$	��Top=�$	��627��	 �� 
IsReadOnly	 . "
 �� VerticalScrollBarVisibility$

 Auto=� �� TextWrapping$
 Wrap=����� *
filtertext+$ PropertyChanged=�$ TwoWay=��� -	   $��	comboBox3��$ Display��$ Value��$��23��$
��Left=�$��
495,98,0,0q�$	��Top=�$	��120������ *	opitems+ �� *
selectop+�� -
   $��button2��$	��try��$	��Try��$��23��$
��Left=�$��141,178,0,0q�$	��Top=�$��75������ *ViewSwitchCommand+�� -   $��label2��$��Query New PIIDs��$��49��$
��Left=�$��	41,12,0,0q�$	��Top=�$	��196��$��24(�$��Arial)��� -   $��button3��$��clear��$��Clear��$��23��$
��Left=�$��235,178,0,0q�$	��Top=�$��75������ *ViewSwitchCommand+�� -   $��button4��$��query��$��Query��$��23��$
��Left=�$��327,178,0,0q�$	��Top=�$��75������ *ViewSwitchCommand+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   SelectionMode$ Single=�   
IsReadOnly .    AutoGenerateColumns .  $	��323��$
��Left=�$��
41,297,0,0q�$	��Top=�$	��710��$ �� IsSynchronizedWithCurrentItem$
 TrueY�   CanUserAddRows .  ���� *
sumitems+ �� SelectedItem �� *
fieldindex+ J� InputBindings d�  d� MouseAction$ LeftDoubleClicke� �� Command �� *ClickCommand+ �� CommandParameter �� *	sumitems/+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Vendor Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
vendorname+  $ Product Service Code�� �� *productorservicecode+  $ Principal NAICS Code�� �� *principalnaicscode+  $ Contract Vehicle�� �� *contract_vehicle+  $
 PIID�� �� *piid+  $) #Description of Contract Requirement�� �� *" descriptionofcontractrequirement+�� -   $��	comboBox4��$ Display��$ Value��$��23��$
��Left=�$��	49,98,0,0q�$	��Top=�$	��188������ *agencyitems+ �� *selectfilteragency+�� -   $��label3��$��Filter value��$��28��$
��Left=�$��
635,63,0,0q�$	��Top=��� -   $��label4��$��	Operation��$��28��$
��Left=�$��
526,63,0,0q�$	��Top=��� -   $��label5��$��Field��$��28��$
��Left=�$��
400,63,0,0q�$	��Top=��� -   $��label6��$��Agency��$��28��$
��Left=�$��	89,63,0,0q�$	��Top=��� -   $��label7��$��Search Filter��$��35��$
��Left=�$��
305,26,0,0q�$	��Top=�$	��121��$��Arial)�$��16(��� -   $��button5��$��excelcsv��$��Details to Excel��$��23��$
��Left=�$��417,178,0,0q�$	��Top=�$��96������ *ViewSwitchCommand+�� -   $��button6��$��
excelpivot��$��Details to Excel Pivot��$��23��$��529,178,0,0q�$	��Top=�$
��Left=�$	��129������ *ViewSwitchCommand+�� -   $��label1��$��Table��$��28��$
��Left=�$��
283,63,0,0q�$	��Top=�$��52���� -   $��	comboBox5��$ Display��$ Value��$��23��$
��Left=�$��
243,98,0,0q�$	��Top=�$	��120������ *
tableitems+ �� *selecttable+�� -   $��label99��$
��Year��$��28��$
��Left=�$��283,122,0,0q�$	��Top=��� -   $��	comboBox6��$ Display��$ Value��$��23��$
��Left=�$��243,149,0,0q�$	��Top=�$	��120������ *	yearitems+ �� *
selectyear+