using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
namespace USAspendingWindow
{
   
 public static class ExposeControl
        {
            static readonly object NoObject = new object();

            public static readonly DependencyProperty AsProperty = DependencyProperty.RegisterAttached("As", typeof(object), typeof(ExposeControl),
                new FrameworkPropertyMetadata(NoObject, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, AsChanged));
            public static object GetAs(DependencyObject obj) { return obj.GetValue(AsProperty); }
            public static void SetAs(DependencyObject obj, object value) { obj.SetValue(AsProperty, value); }

            public delegate void del();
            static void AsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
            {
                del DEL;
                DEL = () => obj.SetCurrentValue(AsProperty, obj);
                if (args.NewValue != obj)
                    obj.Dispatcher.BeginInvoke(DEL);
            }
        }
    

}
