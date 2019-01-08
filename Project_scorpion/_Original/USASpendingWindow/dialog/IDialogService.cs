using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace USAspendingWindow
{
    public interface IDialogService
    {
        MessageBoxResult ShowMessageBox(string content,
        string title, MessageBoxButton buttons);
        void ShowDialog( Window dialog);
        String ShowFileDialog();
    }

}
