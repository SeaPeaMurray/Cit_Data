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
using System.Windows.Shapes;

namespace USAspendingWindow
{
    /// <summary>
    /// Interaction logic for loaddetails.xaml
    /// </summary>
    public partial class loaddetails : Window
    {
        public loaddetails()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaddetailsviewmodel vm;
            // this creates an instance of the ViewModel     
            vm = this.DataContext as loaddetailsviewmodel;
            // this sets the newly created ViewModel as the DataContext for the View     
            if (vm.CloseAction == null) // so we can close from the view model        
                vm.CloseAction = new Action(() => this.closedialog());
          
        }

        public void closedialog()
        {

            this.Close();

        }
    }
}
