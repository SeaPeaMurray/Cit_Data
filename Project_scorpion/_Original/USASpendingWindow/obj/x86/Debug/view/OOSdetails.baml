   M S B A M L   `   `   `  ����  USAspendingWindow"    USAspendingWindow.OOSdetails   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Out of scope details��5   	   $	��456��6&   $
��1047��63    � Cursor 6@   �� *	thecursor+.��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5   �      AutoGenerateColumns .  $	��349��6P   $
��Left=�6]   $��	12,68,0,0q�6x   $	��Top=�6�   $
��1013��6�   ��6   �� *
logitems+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Vendor Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Rec.vendorname+  5	      $ Product Service Code��6%    6C   �� *Rec.productorservicecode+  5
      $ Principal NAICS Code��6%    6C   �� *Rec.principalnaicscode+  5      $) #Description of Contract Requirement��6%    6R   �� *&$Rec.descriptionofcontractrequirement+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Select��6p    6)   ��  �� Path$ Selected� �� UpdateSourceTrigger$ PropertyChanged=�6p   5      �� 5   
   -   5        $��button1��5   z   $��Close��60   $��23��6@   $
��Left=�6L   $��	20,20,0,0q�6g   $	��Top=�6�   $��75��6�   {�6   �� *
canclose+6�   �� 5   
   -   5        $��button2��5   �   $��
savetofile��67   $��Save to file��6U   $��23��6l   $
��Left=�6x   $��
140,20,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   �� 5   
   -   5        $��button3��5   �   $��return��67   $%��Move selected back to USA Spend��6Q   $��23��6{   $
��Left=�6�   $��
294,20,0,0q�6�   $	��Top=�6�   $	��225��6�   ��6   �� *ViewSwitchCommand+6�   5      5      