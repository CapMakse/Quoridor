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
using System.Windows.Shapes;

namespace Quoridor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool blueBot { get; set; }
        public bool redBot { get; set; }
        bool boardInirializated = false;
        RadioButton verticalCheck;
        Label currentPlayerName;
        Label currentWallCount;
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
        Game game;
        public MainWindow()
        {
            InitializeComponent();
            verticalCheck = FindName("VerticalWalls") as RadioButton;
            currentPlayerName = FindName("PlayerName") as Label;
            currentWallCount = FindName("CountWalls") as Label;
        }
        void InitBoard()
        {
            boardInirializated = true;
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
                            coordinateButton.Click += MoveFigure;
                            coordinateButton.Row = i / 2;
                            coordinateButton.Column = j / 2;
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
                            coordinateButton.Click += AddWall;
                            coordinateButton.Row = (i - 1) / 2;
                            coordinateButton.Column = (j - 1) / 2;
                            wallCells[(i - 1) / 2][(j - 1) / 2] = coordinateButton;
                        }
                    }
                }
            }
        }
        private void AddWall(object sender, RoutedEventArgs e)
        {
            CoordinateButton button = sender as CoordinateButton;
            bool vertical = verticalCheck.IsChecked == true;
            if (game.TryPutWall(button.Row, button.Column, vertical))
            {
                UpdateBoardWalls(button.Row, button.Column, vertical);
                UpdatePlayerInfo();
            }
        }
        void UpdateBoardWalls(int row, int column, bool vertical)
        {
            wallCells[row][column].Background = new SolidColorBrush(Colors.Black);
            if (vertical == true)
            {
                verticalWalls[row][column].Background = new SolidColorBrush(Colors.Black);
                verticalWalls[row + 1][column].Background = new SolidColorBrush(Colors.Black);
            }
            else
            {
                horizontalWalls[row][column].Background = new SolidColorBrush(Colors.Black);
                horizontalWalls[row][column + 1].Background = new SolidColorBrush(Colors.Black);
            }
        }
        private void MoveFigure(object sender, RoutedEventArgs e)
        {
            CoordinateButton button = sender as CoordinateButton;
            int row = game.currentPlayer.Row;
            int column = game.currentPlayer.Column;
            if (game.TryMoveFigure(button.Row, button.Column))
            {
                button.Background = figureCells[row][column].Background;
                figureCells[row][column].Background = new SolidColorBrush(Colors.White); ;
                UpdatePlayerInfo();
            }
        }
        void UpdatePlayerInfo()
        {
            currentPlayerName.Content = game.currentPlayer.Name;
            currentWallCount.Content = game.currentPlayer.CountOfWalls;
        }
        public void NewGame(string redPlayer, string bluePlayer)
        {
            if (!boardInirializated) InitBoard();
            foreach (var line in figureCells)
            {
                foreach (var item in line)
                {
                    item.Background = new SolidColorBrush(Colors.White);
                }
            }
            foreach (var line in wallCells)
            {
                foreach (var item in line)
                {
                    item.Background = new SolidColorBrush(Colors.White);
                }
            }
            foreach (var line in horizontalWalls)
            {
                foreach (var item in line)
                {
                    item.Background = new SolidColorBrush(Colors.White);
                }
            }
            foreach (var line in verticalWalls)
            {
                foreach (var item in line)
                {
                    item.Background = new SolidColorBrush(Colors.White);
                }
            }
            figureCells[0][4].Background = new SolidColorBrush(Colors.Red);
            figureCells[8][4].Background = new SolidColorBrush(Colors.Blue);
            game = new Game(redPlayer, bluePlayer);
            UpdatePlayerInfo();
        }
        private void NewGame(object sender, RoutedEventArgs e)
        {
            NewGameWindow window = new NewGameWindow();
            window.Owner = this;
            window.Show();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
