using System.Windows;
using Codon;

namespace CommandBehaviorDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = Dependency.Resolve<ViewModel1>();
            
        }
    }
}
