  using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class querynewpiid : UserControl
    {
        public querynewpiid()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            querynewpiidviewmodel vm;
            // this creates an instance of the ViewModel     
            vm = this.DataContext as querynewpiidviewmodel;
            // this sets the newly created ViewModel as the DataContext for the View     
            if (vm.CloseAction == null) // so we can close from the view model        
                vm.CloseAction = new Action(() => this.reset());
            screenreset();

        }

        void screenreset()
        {
            comboBox2.Visibility = Visibility.Hidden;
            comboBox3.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Hidden;
            datePicker1.Visibility = Visibility.Hidden;

            textBox1.Text = String.Empty;
            datePicker1.SelectedDate = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox2.Text = String.Empty;


        }
        void controlreset()
        {
            comboBox2.Visibility = Visibility.Hidden;
            comboBox3.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Hidden;
            datePicker1.Visibility = Visibility.Hidden;

            textBox1.Text = String.Empty;
            datePicker1.SelectedDate = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

        }


        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                if (comboBox1.SelectedValue.ToString() == "DateTime")
                {

                    comboBox2.Visibility = Visibility.Hidden;
                    comboBox3.Visibility = Visibility.Visible;
                    textBox1.Visibility = Visibility.Hidden;
                    datePicker1.Visibility = Visibility.Visible;

                }
                else if (comboBox1.SelectedValue.ToString() == "String")
                {

                    comboBox2.Visibility = Visibility.Visible;
                    comboBox3.Visibility = Visibility.Hidden;
                    textBox1.Visibility = Visibility.Visible;
                    datePicker1.Visibility = Visibility.Hidden;

                }
                else if (comboBox1.SelectedValue.ToString() == "decimal")
                {

                    comboBox2.Visibility = Visibility.Hidden;
                    comboBox3.Visibility = Visibility.Visible;
                    textBox1.Visibility = Visibility.Visible;
                    datePicker1.Visibility = Visibility.Hidden;
                }
            }
        }

        public void reset()
        {
       
            controlreset();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<govwinmodel> display;

            String[] piids = new String[2]
                {
                     "TIRNO11D00007",
                     "TIRNO11D00005"
                };



            display = govwinservice.getgovwin(piids);

            showdia(display);
        }

        private void showdia(ObservableCollection<govwinmodel> list)
        {


            if (!Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    DialogService service = new DialogService();
                    govwindetails dia = new govwindetails();
                    govwindetailsviewmodel vm = new govwindetailsviewmodel();
                    dia.DataContext = vm;
                    vm.logitems = list;
                    service.ShowDialog(dia);
                }));

            }
            else
            {
                DialogService service = new DialogService();
                govwindetails dia = new govwindetails();
                govwindetailsviewmodel vm = new govwindetailsviewmodel();
                dia.DataContext = vm;
                vm.logitems = list;
                service.ShowDialog(dia);
            }

        }

       

       
    }
}
