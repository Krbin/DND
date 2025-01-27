using System;
using System.IO;
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
using static System.Net.WebRequestMethods;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> employees = new List<Employee> { };
        StreamWriter employeeStreamWriter = new StreamWriter("employees.csv");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(birthyearBox.Text, out int tryParsedBirthyearInt))
            {
                return;
            }

            if (!decimal.TryParse(grossWageBox.Text, out decimal tryParsedGrossWageDecimal))
            {
                return;
            }

            employeeStreamWriter.WriteLine(String.Join(",",new Array ( nameBox.Text, surnameBox.Text, birthyearBox.Text, positionBox.Text, grossWageBox.Text )));
            employees.Add(new Employee(nameBox.Text, surnameBox.Text, tryParsedBirthyearInt, positionBox.Text, tryParsedGrossWageDecimal));
        }

        private void nameBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (nameBox.Text.Trim() == "")
            {
                nameWarningBox.Text = "* Name is a required field";
            }
        }
        private void surnameBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (surnameBox.Text.Trim() == "")
            {
                surnameWarningBox.Text = "* Surname is a required field";
            }

        }
        private void birthyearBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (birthyearBox.Text.Trim() == "")
            {
                birthyearWarningBox.Text = "* Year of Birth is a required field";
            }

            if (int.TryParse(birthyearBox.Text, out int x))
            {
                birthyearWarningBox.Text = "* Invalid year format";
            }

        }

        private void positionBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (positionBox.Text.Trim() == "")
            {
                positionWarningBox.Text = "* Position is a required field";
            }


        }

        private void grossWageBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (grossWageBox.Text.Trim() == "")
            {
                grossWageWarningBox.Text = "* Gross Wage is a required field";
            }

            if (decimal.TryParse(grossWageBox.Text, out decimal tryParsedGrossWageDecimal))
            {
                grossWageWarningBox.Text = "* Invalid Gross Wage format";
            }


        }
    }

    public class Employee
    {
        public string Name;
        public string Surname;
        public int Birthyear;
        public string Position;
        public decimal GrossWage;

        public Employee(string name, string surname, int birthyear, string position, decimal grossWage)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthyear = birthyear;
            this.Position = position;
            this.GrossWage = grossWage;
        }
    }

}
