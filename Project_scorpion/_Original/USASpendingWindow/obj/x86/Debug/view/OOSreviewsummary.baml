   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      L HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow 5      (   "USAspendingWindow.OOSreviewsummary   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      1localclr-namespace:USAspendingWindow     5        � Cursor  5	   7   �� *	thecursor+ � DataContext 5
      1 +USAspendingWindow.OOSreviewsummaryviewmodel  5   
   .��5      � .+�5   
   �� -   5        $��
rectangle1��5   N   $��87��6   $
��Left=�6    $��	41,63,0,0q�6;   
���   �$	��Top=�6o   $	��710��6�   �� 5   
   -   5        $��	comboBox4��5   �    �� DisplayMemberPath$ Display��67    �� SelectedValuePath$ Value��6S   $��23��6�   $
��Left=�6�   $��
66,109,0,0q�6�   $	��Top=�6�   $	��188��6�   ��6   �� *agencyitems+ �� SelectedValue 6m   �� *selectfilteragency+6�   �� 5   
   -   5        $��label2��5   t   $%��Out of Scope review and summary��6   $��49��6:   $
��Left=�6F   $��	41,12,0,0q�6a   $	��Top=�6�   $	��447��6�   $��24(�6�   $��Arial)�6�   �� 5      -   5        $��button1��5   �   $��query��6/   $��Query��6H   $��23��6X   $
��Left=�6d   $��600,109,0,0q�6   $	��Top=�6�   $��75��6�   ��6	   �� *ViewSwitchCommand+6�   �� 5      -   5        $��label6��5   T   $��Agency��6   $��28��6   $
��Left=�6%   $��
103,75,0,0q�6@   $	��Top=�6b   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dataGrid1��5   �      SelectionMode$ Single=�6      
IsReadOnly .    AutoGenerateColumns .  $	��200��6�   $
��Left=�6�   $��
41,179,0,0q�6�   $	��Top=�6�   $	��710��6  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6  ��6>   �� *
sumitems+	 �� SelectedItem	 6_   �� *
fieldindex+
 � 	Resources
 5      $  USAspendingWindow.BindingProxy 	  proxy   Data��%&   &	          5       63   �� 5       J� InputBindings 5      d� 5       d� MouseAction$ LeftDoubleClicke�5       �� Command 5      �� *ClickCommand+ �� CommandParameter 5      �� *	sumitems/+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Agency��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   ��  �� Path$ agency�  5       $
 Year��6%    63   �� $
 year�  5!       6%   �� *Data.fieldname+ �� Source# [   6g   �� $ field�  5"      $ Records��6%    66   �� $ records�5%      �� 5&   
   -   5        $��label5��5&   [   $��Field��6   $��28��6    $
��Left=�6,   $��
483,75,0,0q�6G   $	��Top=�6i   �� 5'   
   -   5        $��	comboBox1��5'   �   $ Display��66   $ Value��6R   $��23��6�   $��441,109,0,0q�6�   $	��Top=�6�   $
��Left=�6�   $	��120��6�   ��6   �� *
fielditems+ 6l   �� *selectfield+6�   �� 5(   
   -	   5        $��	comboBox2��5(   �   $ Display��65   $ Value��6Q   $��23��6�   $
��Left=�6�   $��288,109,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *	yearitems+ 6k   �� *
selectyear+6�   �� 5)   
   -
   5        $��label1��5)   Z   $
��Year��6   $��28��6   $
��Left=�6+   $��
323,75,0,0q�6F   $	��Top=�6h   5*      5+      