using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CinemaHelper.Core.Data;
using CinemaHelper.Core.Service;
using System.Windows;



namespace NoteBook2_name
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
         private MainViewModel viewModel = new MainViewModel(new NoteService2(new NoteDataSource2()));
        public MainWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}


