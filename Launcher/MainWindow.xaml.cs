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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launcher {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public bool isGameSelected;
        public string gamePath;

        public MainWindow() {
            InitializeComponent();
        }

        private void CloseWindow() {
            this.Close();
        }

        private void SelectGame(string game) {
            isGameSelected = true;
            gamePath = GameLauncher.GetGamePath(game);
            //TODO: Remove because unnecessary
            PlaceholderLabel.Content = gamePath;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            CloseWindow();
        }

        private void LaunchGameButton_Click(object sender, RoutedEventArgs e) {
            if (isGameSelected) {
                try {
                    GameLauncher.PlayGame(gamePath);
                    CloseWindow();
                }
                catch (Exception err) {
                    Console.WriteLine(err);
                    MessageBox.Show(err.Message, "Cannot find path");
                }
            }
            else {
                MessageBox.Show("Select game first", "Game not selected");
            }
        }

        private void FateRoute_Click(object sender, RoutedEventArgs e) {
            FateImage.Opacity = 0.7;
            UBWImage.Opacity = 1.0;
            HFImage.Opacity = 1.0;
            SelectGame("fate");
        }

        private void UBWRoute_Click(object sender, RoutedEventArgs e) {
            FateImage.Opacity = 1.0;
            UBWImage.Opacity = 0.7;
            HFImage.Opacity = 1.0;
            SelectGame("ubw");
        }

        private void HFRoute_Click(object sender, RoutedEventArgs e) {
            FateImage.Opacity = 1.0;
            UBWImage.Opacity = 1.0;
            HFImage.Opacity = 0.7;
            SelectGame("hf");
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }
    }
}
