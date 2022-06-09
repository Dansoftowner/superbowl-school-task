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

namespace SuperBowlGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> table;
        private Dictionary<string, string> reversedTable;

        public MainWindow()
        {
            InitializeComponent();
            CreateTables();
        }

        private void CreateTables()
        {
            table = new Dictionary<string, string>();
            table.Add("I", "1");
            table.Add("II", "2");
            table.Add("III", "3");
            table.Add("IV", "4");
            table.Add("V", "5");
            table.Add("VI", "6");
            table.Add("VII", "7");
            table.Add("VIII", "8");
            table.Add("IX", "9");
            table.Add("X", "10");
            // UGLY solution
            reversedTable = new Dictionary<string, string>();
            foreach(var keyValue in table)
            {
                reversedTable.Add(keyValue.Value, keyValue.Key);
            }
        }

        private void ArrowButton_Click(object sender, RoutedEventArgs e)
        {
            RomanNumberField.Text = "";
            ArabicNumberField.Text = "";
            ArrowButton.Content = ReverseArrow(ArrowButton.Content.ToString());
            ReverseActiveState(RomanNumberField);
            ReverseActiveState(ArabicNumberField);
        }

        private void ReverseActiveState(TextBox tb)
        {
            tb.IsEnabled = !tb.IsEnabled;
        }

        private string ReverseArrow(string arrow)
        {
            string arrowRight = "--->";
            string arrowLeft = "<---";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add(arrowLeft, arrowRight);
            dict.Add(arrowRight, arrowLeft);
            return dict[arrow];
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            bool fromRomanToArabic = RomanNumberField.IsEnabled;
            try
            {
                if (fromRomanToArabic)
                {
                    ArabicNumberField.Text = table[RomanNumberField.Text.ToUpper()];
                }
                else
                {
                    RomanNumberField.Text = reversedTable[ArabicNumberField.Text];
                }
            } 
            catch(Exception)
            {
                MessageBox.Show("Helytelen adat!");
            }
            
        }
    }
}
