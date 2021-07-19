using System.Windows;
using JustWork.ViewModel;

namespace JustWork
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CommonViewModel();
        }
    }
}
