using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Urupoly
{
    public sealed partial class Tile : UserControl
    {
        public Tile()
        {
            InitializeComponent();
        }
        public string Title
        {
            get { return PropertyName.Text; }
            set { PropertyName.Text = value; }
        }

        // Propiedad p�blica para el color de la franja
        public Brush StripeColor
        {
            get { return ColorBar.Background; }
            set { ColorBar.Background = value; }
        }
    }
}
