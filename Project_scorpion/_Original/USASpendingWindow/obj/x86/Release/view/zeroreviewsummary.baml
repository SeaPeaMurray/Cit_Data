   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  L HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow )   #USAspendingWindow.zeroreviewsummary   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     1localclr-namespace:USAspendingWindow       � Cursor  �� *	thecursor+ � DataContext 2 ,USAspendingWindow.zeroreviewsummaryviewmodel  .��� .+��� -   $��
rectangle1��$��87��$
��Left=�$��	41,63,0,0q�
���   �$	��Top=�$	��710���� -   $��	comboBox4�� �� DisplayMemberPath$ Display�� �� SelectedValuePath$ Value��$��23��$
��Left=�$��
66,109,0,0q�$	��Top=�$	��188������ *agencyitems+ �� SelectedValue �� *selectfilteragency+�� -   $��label2��$!��Zero Out review and summary��$��49��$
��Left=�$��	41,12,0,0q�$	��Top=�$	��447��$��24(�$��Arial)��� -   $��button1��$��query��$��Query��$��23��$
��Left=�$��600,109,0,0q�$	��Top=�$��75������ *ViewSwitchCommand+�� -   $��label6��$��Agency��$��28��$
��Left=�$��
103,75,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   SelectionMode$ Single=�   
IsReadOnly .    AutoGenerateColumns .  $	��200��$
��Left=�$��
41,179,0,0q�$	��Top=�$	��710��$ �� IsSynchronizedWithCurrentItem$
 TrueY����� *
sumitems+	 �� SelectedItem	 �� *
fieldindex+
 � 	Resources
 $  USAspendingWindow.BindingProxy 	  proxy   Data��%   &	           ��  J� InputBindings d�  d� MouseAction$ LeftDoubleClicke� �� Command �� *ClickCommand+ �� CommandParameter �� *	sumitems/+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Agency��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ agency�  $
 Year�� �� $
 year�   �� *Data.fieldname+ �� Source# [   �� $ field�  $ Records�� �� $ records��� -   $��label5��$��Field��$��28��$
��Left=�$��
483,75,0,0q�$	��Top=��� -   $��	comboBox1��$ Display��$ Value��$��23��$��441,109,0,0q�$	��Top=�$
��Left=�$	��120������ *
fielditems+ �� *selectfield+�� -	   $��	comboBox2��$ Display��$ Value��$��23��$
��Left=�$��288,109,0,0q�$	��Top=�$	��120������ *	yearitems+ �� *
selectyear+�� -
   $��label1��$
��Year��$��28��$
��Left=�$��
323,75,0,0q�$	��Top=�