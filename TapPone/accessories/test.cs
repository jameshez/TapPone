using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TapPone
{
    //class myGird : Grid
    //{
    //    public static readonly DependencyProperty CommandProperty =
    //            DependencyProperty.Register(
    //                    "Command",
    //                    typeof(ICommand),
    //                    typeof(myGird),
    //                    new PropertyMetadata((ICommand)null,
    //                        new PropertyChangedCallback(OnCommandChanged)));

    //    private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        myGird b = (myGird)d;
    //        b.OnCommandChanged((ICommand)e.OldValue, (ICommand)e.NewValue);
    //    }

    //    private void OnCommandChanged(ICommand oldCommand, ICommand newCommand)
    //    {
    //        if (oldCommand != null)
    //        {
    //            UnhookCommand(oldCommand);
    //        }
    //        if (newCommand != null)
    //        {
    //            HookCommand(newCommand);
    //        }
    //    }

    //    private void UnhookCommand(ICommand command)
    //    {
    //        CanExecuteChangedEventManager.RemoveHandler(command, OnCanExecuteChanged);
    //        UpdateCanExecute();
    //    }

    //    //private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    //{
    //    //    myGird b = (myGird)d;
    //    //    b.OnCommandChanged((ICommand)e.OldValue, (ICommand)e.NewValue);
    //    //}
    //}
}
