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
    /// Логика взаимодействия для NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        public NewGameWindow()
        {
            InitializeComponent();
        }

        private void StartNewGame(object sender, RoutedEventArgs e)
        {
            string BotName = "QuoridorBot v1"; 
            bool blueBot = (FindName("BluePlayer") as RadioButton).IsChecked == true;
            bool redBot = (FindName("RedPlayer") as RadioButton).IsChecked == true;
            string blueName = blueBot ? BotName : (FindName("BluePlayerName") as TextBox).Text;
            string redName = redBot ? BotName : (FindName("RedPlayerName") as TextBox).Text;
            (Owner as MainWindow).redBot = redBot; 
            (Owner as MainWindow).blueBot = blueBot;
            (Owner as MainWindow).NewGame(redName, blueName);
            this.Close();
        }
    }
}
