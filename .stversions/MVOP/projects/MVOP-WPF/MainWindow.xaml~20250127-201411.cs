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
using System.Text.RegularExpressions;

namespace MVOP_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Dictionary<char, Regex> calculationRegexes = new Dictionary<char, Regex>()
        {
            {'*',new Regex(@"\d+\*\d+")},
            {'/',new Regex(@"\d+\/\d+")},
            {'+',new Regex(@"\d+\+\d+")},
            {'-',new Regex(@"\d+\-\d+")},
        };

        private string input = "";

        private int index1 = -1,
                    index2 = -1;

        private string calculationString = "";
        private int calculationIndex = -1;

        private int calculationNumber1 = 0,
                    calculationNumber2 = 0;

        private string op = "";

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            input = inputTextBox.Text.Trim();

            if (verifyInput(input))
            {
                while (true)
                {
                    calculationNumber1 = calculationNumber2 = 0;

                    index1 = input.IndexOf('*');
                    index2 = input.IndexOf('/');
                    if (index1 == index2)
                    {
                        break;
                    }

                    if (index1 < index2 && index1 != -1)
                    {
                        input = calculateOneOperation(input, '*');
                    }
                    else
                    {
                        input = calculateOneOperation(input, '/');
                    }
                }

                while (true)
                {
                    calculationNumber1 = calculationNumber2 = 0;

                    index1 = input.IndexOf('+');
                    index2 = input.IndexOf('-');

                    if (index1 == index2)
                    {
                        break;
                    }

                    if (index1 < index2 && index1 != -1)
                    {
                        input = calculateOneOperation(input, '+');
                    }
                    else
                    {
                        input = calculateOneOperation(input, '-');
                    }



                }
            }
        }
        private bool verifyInput(string input)
        {
            return (new Regex(@"^[\d\+\-\*\/]+$")).Match(input).Value.Length > 0;

        }

        //Calculates first occurenes of given operator and the numbers surrounding it
        private string calculateOneOperation(string input, char op)
        {

            string calculationString = "";
            string originalCalculationString = "";

            int calculationIndex = -1;

            int calculationNumber1 = 0,
                calculationNumber2 = 0;


            calculationString = calculationRegexes[op].Match(input).Value;


            calculationIndex = calculationString.IndexOf(op);

            int.TryParse(calculationString.Substring(0, calculationIndex),
                out calculationNumber1);

            int.TryParse(calculationString.Substring(calculationIndex + 1, calculationString.Length - calculationIndex - 1),
                out calculationNumber2);



            switch (op)
            {
                case '*':
                    calculationString = (calculationNumber1 * calculationNumber2).ToString();
                    break;
                case '/':
                    calculationString = (calculationNumber1 / calculationNumber2).ToString();
                    break;
                case '+':
                    calculationString = (calculationNumber1 + calculationNumber2).ToString();
                    break;
                case '-':
                    calculationString = (calculationNumber1 - calculationNumber2).ToString();
                    break;
            }

            return input.Replace(calculationRegexes[op].Match(input).Value, calculationString);

        }
    }
