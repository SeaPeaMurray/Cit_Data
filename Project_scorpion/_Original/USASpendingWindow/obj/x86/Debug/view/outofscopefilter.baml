   M S B A M L   `   `   `  ����L  HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow  5      ,    &USAspendingWindow.outofscopefilterview   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:USAspendingWindow     5      -   5        $	��722��5      $	��924��6     � Cursor  6;   �� *cursor+ � DataContext 5      1  +USAspendingWindow.outofscopefilterviewmodel  5   
   .��5	      � .+�5
   
   �� -   5        $��
rectangle1��5
   O   $	��329��6   $
��Left=�6!   $��	41,63,0,0q�6<   
���   �$	��Top=�6p   $	��710��6�   �� 5   
   -   5        $��	comboBox1��5   �    �� DisplayMemberPath$ Display��66    �� SelectedValuePath$ Value��6R   $��23��6�   $��278,124,0,0q�6�   $	��Top=�6�   $
��Left=�6/  $	��120��6J  ��6   �� *
fielditems+ �� SelectedValue 6l   �� *selectfield+ �� SelectedIndex 6�   �� *
fieldindex+6J  �� 5   
   -   5        $��	comboBox2��5   �   $ Display��69   $ Value��6U   $��23��6�   $
��Left=�6�   $��403,124,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *stringopitems+ 6o   �� *selectstringop+6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePicker1��5   u   $��25��69   $
��Left=�6E   $��529,122,0,0q�6`   $	��Top=�6�   $	��115��6�      SelectedDate 6   �� *
selectdate+6�   �� 5   
   -   5        $��textBox1��5   �   $��23��6`   $
��Left=�6l   $��529,124,0,0q�6�   $	��Top=�6�   $	��208��6�   ��6   �� *
numstrtext+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5   
   -   5        $��button1��5   �   $	��add��67   $	��Add��6N   $��23��6\   $
��Left=�6h   $��
74,201,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   �� 5   
   -   5        $��textBox2��5   �   $	��127��6`   $
��Left=�6m   $��
63,243,0,0q�6�   $	��Top=�6�   $	��627��6�   	 �� 
IsReadOnly	 . "
 �� VerticalScrollBarVisibility$

 Auto=�6�    �� TextWrapping$
 Wrap=�6  ��6   �� *
filtertext+$ PropertyChanged=�$ TwoWay=�6  �� 5   
   -	   5        $��	comboBox3��5   �   $ Display��63   $ Value��6O   $��23��6�   $
��Left=�6�   $��403,124,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *	opitems+ 6i   �� *
selectop+6�   �� 5   
   -
   5        $��button2��5   �   $	��try��67   $	��Try��6O   $��23��6]   $
��Left=�6i   $��189,201,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   �� 5   
   -   5        $��label1��5   g   $��Expression builder��6   $��32��6-   $
��Left=�69   $��	84,76,0,0q�6T   $	��Top=�6u   $	��303��6�   $��Arial)�6�   $��16(�6�   �� 5   
   -   5        $��label2��5   o   $ ��Out of Scope record filter��6   $��49��65   $
��Left=�6A   $��	41,12,0,0q�6\   $	��Top=�6}   $	��447��6�   $��24(�6�   $��Arial)�6�   �� 5   
   -   5        $��button3��5   �   $��clear��67   $��Clear��6P   $��23��6`   $
��Left=�6l   $��312,201,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   �� 5   
   -   5        $��button4��5   �   $
��save��67   $
��Save��6O   $��23��6^   $
��Left=�6j   $��426,202,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dataGrid1��5   �      AutoGenerateColumns .  $	��254��6S   $
��Left=�6`   $��
41,444,0,0q�6{   $	��Top=�6�   $	��710��6�      CanUserAddRows .  ��6   �� *filteritems+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$ 	Filter.id�  5      $ Agency��6%    65   �� $ Filter.agency�  5      $ Insert Date��6%    6:   �� $ Filter.insertdate�  5      $ Insert User��6%    6:   �� $ Filter.insertuser�  5      $ Filter��6%    65   �� $ Filter.filter�4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Select��6p    6)   �� $ Selected�$ PropertyChanged=�6p   5       �� 5!   
   -   5        $��button5��5!   �   $��testallfilters��67   $��Test agency filters��6Y   $��23��6w   $
��Left=�6�   $��346,407,0,0q�6�   $	��Top=�6�   $	��127��6�   ��6   �� *ViewSwitchCommand+6�   �� 5"   
   -   5        $��button6��5"   �   $��deletefilter��68   $��Delete filter��6X   $��23��6p   $
��Left=�6|   $��573,407,0,0q�6�   $	��Top=�6�   $	��141��6�   ��6   �� *ViewSwitchCommand+6�   �� 5#   
   -   5        $��	comboBox4��5#   �   $ Display��67   $ Value��6S   $��23��6�   $
��Left=�6�   $��
84,124,0,0q�6�   $	��Top=�6�   $	��188��6�   ��6   �� *agencyitems+ 6m   �� *selectfilteragency+6�   �� 5$   
   -   5        $��label3��5$   b   $��Filter value��6   $��28��6'   $
��Left=�63   $��
549,98,0,0q�6N   $	��Top=�6p   �� 5%   
   -   5        $��label4��5%   _   $��	Operation��6   $��28��6$   $
��Left=�60   $��
425,98,0,0q�6K   $	��Top=�6m   �� 5&   
   -   5        $��label5��5&   [   $��Field��6   $��28��6    $
��Left=�6,   $��
323,98,0,0q�6G   $	��Top=�6i   �� 5'   
   -   5        $��label6��5'   \   $��Agency��6   $��28��6!   $
��Left=�6-   $��
155,98,0,0q�6H   $	��Top=�6j   �� 5(   
   -   5        $��	comboBox5��5(   �   $ Display��67   $ Value��6S   $��23��6�   $��Right=�6�   $��0,407,668,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *agencyitems+ 6m   �� *selecttestagency+6�   �� 5)   
   -   5        $��label7��5)   a   $��Test agency��6   $��28��6&   $
��Left=�62   $��
41,406,0,0q�6M   $	��Top=�6o   5*      5+      