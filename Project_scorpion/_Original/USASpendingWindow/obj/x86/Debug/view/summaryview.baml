   M S B A M L   `   `   `  ����L  HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow  5      #    USAspendingWindow.summaryview   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:USAspendingWindow     5        � Cursor  5   8   �� *cursor+ � DataContext 5	      (   "USAspendingWindow.SummaryViewModel  5
   
   .��5      � ��5   
   �� 5       �� ImageSource$N H/USAspendingWindow;component/1024215-1366x768-%5bDesktopNexus_com%5d.jpg��6   .+�5   
   �� -   5        $��label1��5   q   $"��Database and Loading Summary��6   $��64��67   $
��Left=�6C   $��	33,35,0,0q�6^   $	��Top=�6   $	��539��6�   $��Arial)�6�   $��32(�6�   
�������6�   �� 5   
   -   5        $��textBox1��5   c   $	��506��6'   $
��Left=�64   $��
33,105,0,0q�6O   $	��Top=�6s   $	��857��6�   $��Arial)�6�   $��18(�6�    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6   �� *Log+6�   �� 5   
   -   5        $��button1��5   �   $��refresh��67   $��Refresh��6R   $��23��6d   $
��Left=�6p   $��
658,53,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *ViewSwitchCommand+6�   �� 5   
   -   5        $��button2��5   �   $	��log��67   $��Update log details��6N   $��23��6k   $
��Left=�6w   $��
766,53,0,0q�6�   $	��Top=�6�   $	��153��6�   ��6   �� *ViewSwitchCommand+6�   5      5      