using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimbreMoi.Annotations;

namespace TimbreMoi
{
    public class ValeurNombre : INotifyPropertyChanged
    {
        public double Valeur { get; }

        public uint Nombre
        {
            get { return _nombre; }
            set
            {
                if (value == _nombre) return;
                _nombre = value;
                OnPropertyChanged();
            }
        }

        private uint _nombre;

        public ValeurNombre(double valeur, uint nombre)
        {
            Valeur = valeur;
            _nombre = nombre;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}