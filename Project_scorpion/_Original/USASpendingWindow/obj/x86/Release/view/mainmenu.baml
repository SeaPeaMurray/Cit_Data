   M S B A M L   `   `   `  ���� L  HUSAspendingWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:USAspendingWindowUSAspendingWindow       USAspendingWindow.mainmenu   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:USAspendingWindow     -     � DataContext  )  #USAspendingWindow.mainmenuviewmodel  .��� $��24��$
��1000��.+�o� -   $��menu1��$��23��$
��Left=�$	��Top=�$
��1000��.@�m� -   $
��Exit��$��_Exit�� m� CommandParameter$
 exit�� m� IsCheckable .   m� InputGestureText$  �� m� Command �� *ViewSwitchCommand+m� -   $
��View��$��_View��.@�m� -   $
��Load��$��_Load��$
 load�� �� *ViewSwitchCommand+m� -   $��Summary��$��_Summary��$ summary�� �� *ViewSwitchCommand+m� -   $��
GovWinload��$��_GovWinload��$ 
govwinload�� �� *ViewSwitchCommand+m� -   $��Reports��$��_Reports��{�. .@�m� $��_Paper Reports��.@�m� $��_Contract Test��$ contracttest�� �� *ViewSwitchCommand+m� $��_Screen Reports��.@�m� $��Query Contract��$ querycontract�� �� *ViewSwitchCommand+m� $��Query New PIIDs��$ querynewpiid�� �� *ViewSwitchCommand+m� -	   $��SpecialProcessing��$��Special _Processing��{�. .@�m� $��_Out Of Scope filter��$ outofscopefilter�� �� *ViewSwitchCommand+m� $��Out Of Scope _Summary��$ outofscopesummary�� �� *ViewSwitchCommand+m� $��Zero Out _Review Summary��$ zerosummary�� �� *ViewSwitchCommand+m� -
   $
��Help��$��_Help��.@�m� $��
User Guide��m� -   $��	Utilities��$��
_Utilities��.@�m� $��Print Screen��$ Print�� �� *ViewSwitchCommand+m� $��Window Size��.@�m� -   $��Full Screen��m� -   $��Normal Screen��m� -   $��Loadadvanced��$��Load Advanced��$ loadadvanced�� �� *ViewSwitchCommand+