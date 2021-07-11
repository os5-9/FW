using JustWork.Models;
using System.Linq;
using System.Windows;

namespace JustWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Model model = new Model();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
            dgT.ItemsSource = model.Specialties.ToList();
        }
    }
}
