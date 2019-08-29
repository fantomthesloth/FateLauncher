using System; //asd
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Launcher {
    class GameLauncher {
        public static void PlayGame(string path) {
            Process.Start(path);
        }

        public static string GetGamePath(string gameName) {
            string currentPath = Directory.GetCurrentDirectory();
            string[] gamePath = Directory.GetFiles(currentPath, gameName + ".exe", SearchOption.AllDirectories);

            try {
                return gamePath[0];
            } catch (IndexOutOfRangeException) {
                MessageBox.Show("Cannot find path of the selected game", "Cannot find path");
                return null;
            }
         
        }

    }
}
