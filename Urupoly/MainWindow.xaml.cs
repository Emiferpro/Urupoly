using Microsoft.UI;
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
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(AppTitleBar);
            InitGame();
        }

        private void InitGame()
        { 
            int boardSize = 11; // El tamaño es 11x11

            // Usamos un solo bucle para recorrer cada lado
            for (int i = 0; i < boardSize; i++)
            {
                // --- FILA INFERIOR (de izquierda a derecha) ---
                // El row es siempre el último (10) y la columna va de 0 a 10
                AddTile(boardSize - 1, i, $"Inferior {i}", new SolidColorBrush(Colors.LightGreen));

                // --- FILA SUPERIOR (de derecha a izquierda para que siga el orden del juego) ---
                // El row es siempre el primero (0) y la columna va de 10 a 0
                AddTile(0, boardSize - 1 - i, $"Superior {i}", new SolidColorBrush(Colors.Pink));

                // --- COLUMNAS LATERALES ---
                // Nos saltamos las esquinas (i=0 y i=10) porque ya las dibujamos
                // con las filas superior e inferior.
                if (i > 0 && i < boardSize - 1)
                {
                    // COLUMNA IZQUIERDA (de abajo hacia arriba)
                    // La columna es siempre la primera (0)
                    AddTile(boardSize - 1 - i, 0, $"Izq. {i}", new SolidColorBrush(Colors.LightBlue));

                    // COLUMNA DERECHA (de arriba hacia abajo)
                    // La columna es siempre la última (10)
                    AddTile(i, boardSize - 1 + i, $"Der. {i}", new SolidColorBrush(Colors.Orange));
                }
            }
        }

        private void AddTile(int row, int column, string text, SolidColorBrush color)
        {
            // 1. Instanciamos nuestro UserControl
            Tile tile = new Tile();

            // 2. Le pasamos los datos a través de las propiedades que creamos
            tile.Title = text;

            // Si no tiene color (esquina, suerte, etc.), hacemos la franja transparente
            tile.StripeColor = color ?? new SolidColorBrush(Colors.Transparent);



            // 4. Lo posicionamos en la grilla
            Grid.SetRow(tile, row);
            Grid.SetColumn(tile, column);

            // 5. Lo agregamos a los hijos del Grid
            BoardGrid.Children.Add(tile);
        }


    }
}
