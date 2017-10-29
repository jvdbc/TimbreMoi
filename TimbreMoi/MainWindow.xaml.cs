using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimbreMoi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<double> _valeurPossibles = new ObservableCollection<double>();
        private readonly ObservableCollection<ValeurNombre> _valeurEffectives = new ObservableCollection<ValeurNombre>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Init()
        {
            _valeurPossibles.Add(6.15);
            _valeurPossibles.Add(5.10);
            _valeurPossibles.Add(5.05);
            _valeurPossibles.Add(4.45);
            _valeurPossibles.Add(3.95);
            _valeurPossibles.Add(1.25);
            _valeurPossibles.Add(1.15);
            _valeurPossibles.Add(0.85);
            _valeurPossibles.Add(0.73);
            _valeurPossibles.Add(0.1);
            _valeurPossibles.Add(0.05);
            _valeurPossibles.Add(0.01);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Init();

            ICValeurPossible.ItemsSource = _valeurPossibles;
            ICValeurNombre.ItemsSource = _valeurEffectives;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            double value;

            _valeurEffectives.Clear();

            if (double.TryParse(TxtAffranchissement.Text.Replace(".",","), out value))
            {
                ProcessNumber(value);
            }
        }

        private void ProcessNumber(double value)
        {
            var maxV = (from t in _valeurPossibles where t <= value orderby t descending select t).FirstOrDefault();

            if (maxV == 0.0)
            {
                return;
            }

            var nb = (uint) (value/maxV);

            _valeurEffectives.Add(new ValeurNombre(maxV,nb));

            var reste = Math.Round(value %maxV,2);

            if (reste >= 0)
            {
                ProcessNumber(reste);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double value = 0.0;

            if (double.TryParse(TxtNewValue.Text.Replace(".", ","), out value))
            {
                if (!_valeurPossibles.Contains(Math.Round(value, 2)))
                {
                    _valeurPossibles.Add(value);
                    ICValeurPossible.ItemsSource = new ObservableCollection<double>(_valeurPossibles.OrderByDescending(v => v));
                }
            }
            
        }
    }
}
