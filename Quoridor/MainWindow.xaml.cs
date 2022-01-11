using System;
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
using System.Windows.Shapes;

namespace Quoridor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CoordinateButton[][] figureCells = {
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9]
            };
        CoordinateButton[][] wallCells = {
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8]
            }; 
        CoordinateButton[][] horizontalWalls = {
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9],
             new CoordinateButton[9]
            };
        CoordinateButton[][] verticalWalls = {
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8],
             new CoordinateButton[8]
            };
        public MainWindow()
        {
            InitializeComponent();
            InitBoard();
        }
        void InitBoard()
        {
            Grid Board = FindName("Board") as Grid;
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    CoordinateButton coordinateButton = new CoordinateButton();
                    Grid.SetRow(coordinateButton, i);
                    Grid.SetColumn(coordinateButton, j);
                    Board.Children.Add(coordinateButton);
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            figureCells[i / 2][j / 2] = coordinateButton;
                        }
                        else
                        {
                            verticalWalls[i / 2][(j - 1) / 2] = coordinateButton;
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            horizontalWalls[(i - 1) / 2][j / 2] = coordinateButton;
                        }
                        else
                        {
                            wallCells[(i - 1) / 2][(j - 1) / 2] = coordinateButton;
                        }
                    }
                }
            }
        }
    }
}
