   M S B A M L   `   `   `  ���� L  HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow  ,    &USAspendingWindow.outofscopefilterview   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     1localclr-namespace:USAspendingWindow     -   $	��722��$	��924��  � Cursor  �� *cursor+ � DataContext 1  +USAspendingWindow.outofscopefilterviewmodel  .��� .+��� -   $��
rectangle1��$	��329��$
��Left=�$��	41,63,0,0q�
���   �$	��Top=�$	��710���� -   $��	comboBox1�� �� DisplayMemberPath$ Display�� �� SelectedValuePath$ Value��$��23��$��278,124,0,0q�$	��Top=�$
��Left=�$	��120������ *
fielditems+ �� SelectedValue �� *selectfield+ �� SelectedIndex �� *
fieldindex+�� -   $��	comboBox2��$ Display��$ Value��$��23��$
��Left=�$��403,124,0,0q�$	��Top=�$	��120������ *stringopitems+ �� *selectstringop+(  "System.Windows.Controls.DatePicker  -   $��datePicker1��$��25��$
��Left=�$��529,122,0,0q�$	��Top=�$	��115��   SelectedDate �� *
selectdate+�� -   $��textBox1��$��23��$
��Left=�$��529,124,0,0q�$	��Top=�$	��208������ *
numstrtext+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� -   $��button1��$	��add��$	��Add��$��23��$
��Left=�$��
74,201,0,0q�$	��Top=�$��75������ *ViewSwitchCommand+�� -   $��textBox2��$	��127��$
��Left=�$��
63,243,0,0q�$	��Top=�$	��627��	 �� 
IsReadOnly	 . "
 �� VerticalScrollBarVisibility$

 Auto=� �� TextWrapping$
 Wrap=����� *
filtertext+$ PropertyChanged=�$ TwoWay=��� -	   $��	comboBox3��$ Display��$ Value��$��23��$
��Left=�$��403,124,0,0q�$	��Top=�$	��120������ *	opitems+ �� *
selectop+�� -
   $��button2��$	��try��$	��Try��$��23��$
��Left=�$��189,201,0,0q�$	��Top=�$��75������ *ViewSwitchCommand+�� -   $��label1��$��Expression builder��$��32��$
��Left=�$��	84,76,0,0q�$	��Top=�$	��303��$��Arial)�$��16(��� -   $��label2��$ ��Out of Scope record filter��$��49��$
��Left=�$��	41,12,0,0q�$	��Top=�$	��447��$��24(�$��Arial)��� -   $��button3��$��clear��$��Clear��$��23��$
��Left=�$��312,201,0,0q�$	��Top=�$��75������ *ViewSwitchCommand+�� -   $��button4��$
��save��$
��Save��$��23��$
��Left=�$��426,202,0,0q�$	��Top=�$��75������ *ViewSwitchCommand+&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .  $	��254��$
��Left=�$��
41,444,0,0q�$	��Top=�$	��710��   CanUserAddRows .  ���� *filteritems+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ 	Filter.id�  $ Agency�� �� $ Filter.agency�  $ Insert Date�� �� $ Filter.insertdate�  $ Insert User�� �� $ Filter.insertuser�  $ Filter�� �� $ Filter.filter�4  .System.Windows.Controls.DataGridCheckBoxColumn  $ Select�� �� $ Selected�$ PropertyChanged=��� -   $��button5��$��testallfilters��$��Test agency filters��$��23��$
��Left=�$��346,407,0,0q�$	��Top=�$	��127������ *ViewSwitchCommand+�� -   $��button6��$��deletefilter��$��Delete filter��$��23��$
��Left=�$��573,407,0,0q�$	��Top=�$	��141������ *ViewSwitchCommand+�� -   $��	comboBox4��$ Display��$ Value��$��23��$
��Left=�$��
84,124,0,0q�$	��Top=�$	��188������ *agencyitems+ �� *selectfilteragency+�� -   $��label3��$��Filter value��$��28��$
��Left=�$��
549,98,0,0q�$	��Top=��� -   $��label4��$��	Operation��$��28��$
��Left=�$��
425,98,0,0q�$	��Top=��� -   $��label5��$��Field��$��28��$
��Left=�$��
323,98,0,0q�$	��Top=��� -   $��label6��$��Agency��$��28��$
��Left=�$��
155,98,0,0q�$	��Top=��� -   $��	comboBox5��$ Display��$ Value��$��23��$��Right=�$��0,407,668,0q�$	��Top=�$	��120������ *agencyitems+ �� *selecttestagency+�� -   $��label7��$��Test agency��$��28��$
��Left=�$��
41,406,0,0q�$	��Top=�