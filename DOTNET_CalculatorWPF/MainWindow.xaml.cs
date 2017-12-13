using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace DOTNET_CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        double number = 0;
        private string operation = "";
        private bool operationClicked = false;
        public MainWindow()
        {
            InitializeComponent();
            resultTextBlock.Text = "0";
        }

        private void InsertNumber(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button) sender;

            if (resultTextBlock.Text == "0" || operationClicked)
            {
                resultTextBlock.Text = pressedButton.Content.ToString();
            }
            else 
            {
                resultTextBlock.Text += pressedButton.Content.ToString();
            }

            operationClicked = false;

        }
        private void InsertDot(object sender, RoutedEventArgs e)
        {
            
            if (resultTextBlock.Text == "0")
            {
                resultTextBlock.Text = "0,";
                
            }
            else if(!resultTextBlock.Text.Contains(","))
            {
                resultTextBlock.Text += ",";
            }
        }

        private void Operation(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            if (number != 0)
            {
                
                Equals(this, null); //operacje bez używania znaku "="
                operationClicked = true;
                operation = button.Content.ToString();
                memoryTextBlock.Text = resultTextBlock.Text + operation;
            }
            else
            {

                number = Double.Parse(resultTextBlock.Text);
                operation = button.Content.ToString();
                memoryTextBlock.Text = resultTextBlock.Text + operation;

                operationClicked = true;
            }
        }

        private void Equals(object sender, RoutedEventArgs e)
        {
            
            switch (operation)
            {
                case "+":
                    resultTextBlock.Text = (number + Double.Parse(resultTextBlock.Text)).ToString();
                    break;
                case "-":
                    resultTextBlock.Text = (number - Double.Parse(resultTextBlock.Text)).ToString();
                    break;
                case "*":
                    resultTextBlock.Text = (number * Double.Parse(resultTextBlock.Text)).ToString();
                    break;
                case "/":
                    if (Double.Parse(resultTextBlock.Text) != 0)
                        resultTextBlock.Text = (number / Double.Parse(resultTextBlock.Text)).ToString();
                    else
                        MessageBox.Show("Nie dziel przez zero!");
                    break;
                    
                  
            }
            number = Double.Parse(resultTextBlock.Text);
            memoryTextBlock.Text = "";
            operationClicked = false;
            operation = "";

        }


        private void CeClicked(object sender, RoutedEventArgs e)
        {
            resultTextBlock.Text = "0";
        }

        private void CClicked(object sender, RoutedEventArgs e)
        {
            resultTextBlock.Text = "0";
            memoryTextBlock.Text = "";
            number = 0;
        }
    }
}
