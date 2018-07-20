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

namespace Calculator
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
        //Set down variables that will be used
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false; //used for confirmation if operation is performed

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {

            //Switch statement to check for each case 
            switch (operationPerformed)
            {
                case "+":
                    textBox_Results.Text = (resultValue + Double.Parse(textBox_Results.Text)).ToString();
                    break;
                case "-":
                    textBox_Results.Text = (resultValue - Double.Parse(textBox_Results.Text)).ToString();
                    break;
                case "*":
                    textBox_Results.Text = (resultValue * Double.Parse(textBox_Results.Text)).ToString();
                    break;
                case "/":
                    textBox_Results.Text = (resultValue / Double.Parse(textBox_Results.Text)).ToString();
                    break;
                default:
                    break;
            }


            resultValue = Double.Parse(textBox_Results.Text);
            labelCurrentOperation.Content = "";

        }

        private void Numbers_Click(object sender, RoutedEventArgs e)
        {
            //Linked all the number buttons to this event on the Mainwindow.xaml so all buttons are diverted here
            if ((textBox_Results.Text == "0") || (isOperationPerformed))
            {
                textBox_Results.Clear(); //Clear the Textbox if the is a 0 or if an operation has been preformed
            }
            isOperationPerformed = false;
            Button button = (Button)sender;   //Access the button propperties to get content
            if (button.Content == ".")   //use if else statement to check if the dot has already been added or not(not mathematically logical)
            {
                if (!textBox_Results.Text.Contains("."))
                {
                    textBox_Results.Text = textBox_Results.Text + button.Content;
                }

            }
            else
            {
                textBox_Results.Text = textBox_Results.Text + button.Content;
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                btnEqual_Click(this, null);
                operationPerformed = button.Content.ToString();
                labelCurrentOperation.Content = resultValue + " " + operationPerformed;
                isOperationPerformed = true;

            }
            else
            {
                operationPerformed = button.Content.ToString();
                resultValue = Double.Parse(textBox_Results.Text);
                labelCurrentOperation.Content = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }
        private void C_Click(object sender, RoutedEventArgs e)
        {
            textBox_Results.Text = "0";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textBox_Results.Text = "0";
            resultValue = 0;
        }


    }
}
