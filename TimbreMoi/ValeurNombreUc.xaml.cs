﻿using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour PrixNombreUC.xaml
    /// </summary>
    public partial class ValeurNombreUc : UserControl
    {
        public ValeurNombreUc()
        {
            InitializeComponent();
        }

        public ValeurNombre Value
        {
            get { return (ValeurNombre)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(ValeurNombre), typeof(ValeurNombreUc), new PropertyMetadata(new ValeurNombre(0.0, 0)));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ValeurNombreUc), new PropertyMetadata(null));

    }
}
