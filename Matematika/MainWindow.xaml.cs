using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Matematika
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rn = new Random();
        int level = 1;
        int vysledek;
        int score = 0;
        int cislo1;
        int cislo2;

        int testCislo = -10;

        string znaminko = "";

        /*static string path = @"C:/Users/home/Desktop/Projects/C#/github/Matematika/jsonFile.json";
        static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
        static string jsonFromFile = File.ReadAllText(path);
        //private List<Save> saves = JsonConvert.DeserializeObject<List<Save>>(jsonFromFile, settings);*/

        private bool jeNula(int cislo)
        {
            if (cislo == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private int cisloGenerate()
        {
            int cislo = vysledek + rn.Next(-10, 10);

            if (jeNula(cislo))
            {
                cislo++;
            }

            return cislo;
        }

        private void prikladGenerate()
        {
            cislo1 = rn.Next(1, level * 10);
            cislo2 = rn.Next(1, level * 10);
            int cislo1Nasobeni = rn.Next(0, level) + 5;
            int cislo2Nasobeni = rn.Next(0, level) + 5;
            int spravneTlacitko = rn.Next(1, 5);

            string prikladText;

            if (level >= 5)
            {
                int priklad = rn.Next(1, 4);

                if(priklad == 1)
                {
                    vysledek = cislo1 + cislo2;
                    znaminko = " + ";
                }
                if (priklad == 2)
                {
                    vysledek = cislo1 - cislo2;
                    znaminko = " - ";
                }
                if (priklad == 3)
                {
                    cislo1 = cislo1Nasobeni;
                    cislo2 = cislo2Nasobeni;

                    vysledek = cislo1 * cislo2;
                    znaminko = " * "; ;
                }
            }
            else if (level >= 2 && level < 5)
            {
                int priklad = rn.Next(1, 3);

                if (priklad == 1)
                {
                    vysledek = cislo1 + cislo2;
                    znaminko = " + ";
                }
                if (priklad == 2)
                {
                    vysledek = cislo1 - cislo2;
                    znaminko = " - ";
                }
            }
            else
            {
                vysledek = cislo1 + cislo2;
                znaminko = " + ";
            }

            prikladText = cislo1.ToString() + znaminko + cislo2.ToString() + " =";

            priklad.Content = prikladText;

            button1.Content = cisloGenerate();
            button2.Content = cisloGenerate();
            button3.Content = cisloGenerate();
            button4.Content = cisloGenerate();

            if (spravneTlacitko == 1)
            {
                button1.Content = vysledek;
            }
            else if (spravneTlacitko == 2)
            {
                button2.Content = vysledek;
            }
            else if (spravneTlacitko == 3)
            {
                button3.Content = vysledek;
            }
            else if (spravneTlacitko == 4)
            {
                button4.Content = vysledek;
            }
        }

        private bool jeSpravnaOdpoved(int odpoved, int vysledek)
        {
            return odpoved == vysledek;
        }

        private void leveling()
        {

            if (level*level + 3 <= score)
            {
                level++;
            }
            if (level*level + 3 > score && score > 3)
            {
                level--;
            }

            levelLabel.Content = "Level: " + level;
        }

        private void nextRound(int odpoved)
        {
            if (jeSpravnaOdpoved(odpoved, vysledek))
            {
                score++;
            }
            else
            {
                if (score > 0)
                {
                    score--;
                }
            }
            scoreLabel.Content = "Score: " + score;

            prikladGenerate();
        }

        public MainWindow()
        {
            InitializeComponent();
            prikladGenerate();
        }

        private void odpoved_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            string odpovedPom = button.Content.ToString();

            int odpoved = Int32.Parse(odpovedPom);

            nextRound(odpoved);

            leveling();
        }

        private Znaminko GetZnaminko()
        {
            if (znaminko == " + ")
            {
                return Znaminko.plus;
            }
            else if (znaminko == " - ")
            {
                return Znaminko.minus;
            }
            else
            {
                return Znaminko.krat;
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Znaminko znaminkop = GetZnaminko();

            Priklad priklad = new Priklad(cislo1, cislo2, znaminkop);
            //Save save = new Save(saves.Count() + 1, level, score, priklad);

            //saves.Add(save);
        }
    }
}
