
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;


namespace USAspendingWindow
{

    public class DialogService : IDialogService
    {

        public MessageBoxResult ShowMessageBox(string content,

        string title, MessageBoxButton buttons)
        {
            return MessageBox.Show(content, title, buttons);
        }

        /// <summary>
        /// Set the DataContext before calling.
        /// </summary>
        /// <param name="dialog"></param>
        public void ShowDialog(Window dialog)
        {

            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowInTaskbar = false;
            dialog.ShowDialog();
        }




        public string ShowFileDialog()
        {
            SaveFileDialog openFileDialog = new SaveFileDialog();
            openFileDialog.DefaultExt = "csv";
            
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;
            return String.Empty;

        }
    }
}

