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
        private readonly ObservableCollection<ValeurNombre> _valeurNombres = new ObservableCollection<ValeurNombre>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Init()
        {
            _valeurNombres.Add(new ValeurNombre(6.15));
            _valeurNombres.Add(new ValeurNombre(5.10));
            _valeurNombres.Add(new ValeurNombre(5.05));
            _valeurNombres.Add(new ValeurNombre(4.45));
            _valeurNombres.Add(new ValeurNombre(3.95));
            _valeurNombres.Add(new ValeurNombre(1.25));
            _valeurNombres.Add(new ValeurNombre(1.15));
            _valeurNombres.Add(new ValeurNombre(0.85));
            _valeurNombres.Add(new ValeurNombre(0.73));
            _valeurNombres.Add(new ValeurNombre(0.1));
            _valeurNombres.Add(new ValeurNombre(0.05));
            _valeurNombres.Add(new ValeurNombre(0.01));
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Init();

            ValeurNombreList.ItemsSource = _valeurNombres;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            double value;

            foreach (var timbre in _valeurNombres)
            {
                timbre.Nombre = 0;
            }

            if (double.TryParse(TxtAffranchissement.Text, out value))
            {
                ProcessNumber(value);
            }
        }

        private void ProcessNumber(double value)
        {
            var maxV = (from t in _valeurNombres where t.Valeur <= value orderby t.Valeur descending select t).FirstOrDefault();

            if (maxV == null)
            {
                return;
            }

            var nb = (uint) (value/maxV.Valeur);

            maxV.Nombre = nb;

            var reste = Math.Round(value %maxV.Valeur,2);

            if (reste >= 0)
            {
                ProcessNumber(reste);
            }
        }
    }
}
