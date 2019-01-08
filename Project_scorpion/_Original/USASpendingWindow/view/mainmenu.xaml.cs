using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace USAspendingWindow
{
    /// <summary>
    /// Interaction logic for mainmenu.xaml
    /// </summary>
    public partial class mainmenu : UserControl
    {
        public mainmenu()
        {
            InitializeComponent();
        }

     
          private void MenuItemFullscreen_Click(object sender, RoutedEventArgs e)
        {
            PrismAppShell main = System.Windows.Window.GetWindow(this) as PrismAppShell;
            
            if (main.WindowState == WindowState.Normal)
            {
                main.WindowState = WindowState.Maximized;
            }
        }

        private void MenuItemNormalscreen_Click(object sender, RoutedEventArgs e)
        {
            PrismAppShell main = System.Windows.Window.GetWindow(this) as PrismAppShell;

            main.WindowState = WindowState.Normal;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          
                mainmenuviewmodel vm;
                // this creates an instance of the ViewModel     
                vm = this.DataContext as mainmenuviewmodel;
                // this sets the newly created ViewModel as the DataContext for the View     
                if (vm.CloseAction == null) // so we can close from the view model        
                    vm.CloseAction = new Action(() => this.printScreen());
          
        }

        public void printScreen()
        {

            PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            if (printDlg.ShowDialog() == true)
            {
                Window parentwindow = Window.GetWindow(this);

                //now print the visual to printer to fit on the one page.
                printDlg.PrintVisual(parentwindow, String.Empty);
            }

        }

        
    }
}
