/*
Calculator assignment 
PROG 37721 C# and .NET
Group Members:
Alexander Kearney   991579862
Nabeel Ahmed Mahdee 991532760
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        // Numbers to be calculated
        double x,y;
        // memory variable
        double memory;
        //operand for the operation
        string operand;
        //clear text field bool and is label has text in it
        bool cleartext = false, isText = false, clearerror = false;
        public Form1()
        {
            InitializeComponent();
        }

        //Addition button clicked        
        private void Addition_Click(object sender, EventArgs e)
        {
            addOperand("+");
        }

        //Equals button clicked
        private void Equals_Click(object sender, EventArgs e)
        {
            //check if label and operand is empty and label is not text
            if (label1.Text != null && !isText)
            {
                //Parse label into y variable
                y = double.Parse(label1.Text);
                //declare results variable
                double result;
                //set the program to cleartext on next input
                cleartext = true;
                clearerror = true;

                if(operand != null)
                {
                    label2.Text = $"{x} {operand} {y} = ";
                }
                //Get the correct operation to execute
                switch (operand)
                {
                    case "+":
                        result = x + y;
                        label1.Text = result.ToString();
                        break;
                    case "-":
                        result = x - y;
                        label1.Text = result.ToString();
                        break;
                    case "*":
                        result = x * y;
                        label1.Text = result.ToString();
                        break;
                    case "%":
                        result = (int) x % (int) y;
                        label1.Text = result.ToString();
                        break;
                    case "^":
                        result = Math.Pow(x, y);
                        label1.Text = result.ToString();
                        break;
                    case "/":
                        //check if case is a divide by zero
                        if (y == 0)
                        {
                            label2.Text = "Undefined: divide by Zero";
                            break;
                        }
                        result = x / y;
                        label1.Text = result.ToString();
                        break;
                    default:
                        result = y;
                        label1.Text = result.ToString();
                        break;
                }
                //erase the operand
                operand = null;
            }
        }

        //Subtraction button is clicked
        private void Subtraction_Click(object sender, EventArgs e)
        {
            addOperand("-");
        }

        //Multiply button is clicked
        private void Multiplication_Click(object sender, EventArgs e)
        {
            addOperand("*");
        }

        //Division button is clicked
        private void Division_Click(object sender, EventArgs e)
        {
            addOperand("/");
        }

        //MOD button is clicked
        private void Modulus_Click(object sender, EventArgs e)
        {
            addOperand("%");
        }

        //Factorial button is clicked
        private void Factorial_Click(object sender, EventArgs e)
        {
            //check if label is empty or text
            if(label1.Text != null && !isText)
            {
                //Get integer value from label
                int factorial = (int) double.Parse(label1.Text);
                //intialize result variable
                double result = 1;
                //remove any operand
                operand = null;

                //check if integer is greater than 0
                if (factorial > 0)
                {
                    //Calculate factorial
                    for(int i=1; i <= factorial; i++)
                    {
                        result *= i;
                    }
                    label2.Text = $"{factorial}! = ";
                    clearerror = true;
                    //Output result
                    label1.Text = result.ToString();
                    //Set text in clear on next input
                    cleartext = true;
                }
                else
                {
                    //Display error meesage
                    label2.Text = "Cannot use a negative number for factorial";
                    clearerror = true;
                }
            }
            else
            {
                //Display error meesage
                label2.Text = "Invalid Input";
                clearerror = true;
            }
        }

        //Absolute button is clicked
        private void Abslolute_Click(object sender, EventArgs e)
        {
            //Check if label is empty or text
            if(label1.Text != null && !isText)
            {
                //Remove any operand
                operand = null;
                //get value from label
                double abs = double.Parse(label1.Text);

                label2.Text = $"|{abs}| = ";
                clearerror = true;
                //check and make value postive
                if (abs < 0) abs = 0 - abs;
                //output value back to label
                label1.Text = abs.ToString();
            }
            else
            {
                //Display error meesage
                label2.Text = "Invalid Input";
                clearerror = true;
            }
        }

        //Power button is clicked
        private void Power_Click(object sender, EventArgs e)
        {
            addOperand("^");
        }

        //Log button is clicked
        private void Log_Click(object sender, EventArgs e)
        {
            //Check if label is empty or text
            if (label1.Text != null && !isText)
            {
                //Remove any operand
                operand = null;
                cleartext = true;
                //get value from label
                double log = double.Parse(label1.Text);
                //check if label is greater than 0
                if (log > 0)
                {
                    label2.Text = $"Log10({log})";
                    clearerror = true;
                    log = Math.Log10(log);
                    //output value back to label
                    label1.Text = log.ToString();
                }
                else
                {
                    //Display error meesage
                    label2.Text = "Cannot use negative number for Log";
                    clearerror = true;
                }
            }
            else
            {
                //Display error meesage
                label2.Text = "Invalid Input";
                clearerror = true;
            }
        }

        //Ln button is clicked
        private void Ln_Click(object sender, EventArgs e)
        {
            //Check if label is empty or text
            if (label1.Text != null && !isText)
            {
                //Remove any operand
                operand = null;
                cleartext = true;
                //get value from label
                double ln = double.Parse(label1.Text);
                //check if label is greater than 0
                if (ln > 0)
                {
                    label2.Text = $"Ln({ln})";
                    clearerror = true;
                    ln = Math.Log(ln);
                    //output value back to label
                    label1.Text = ln.ToString();
                }
                else
                {
                    //Display error meesage
                    label2.Text = "Cannot use negative number for Ln";
                    clearerror = true;
                }
            }
            else
            {
                //Display error meesage
                label2.Text = "Invalid Input";
                clearerror = true;
            }
        }

        //1/x button is clicked
        private void Inverse_Click(object sender, EventArgs e)
        {
            //Check if label is empty or text
            if (label1.Text != null && !isText)
            {
                //Remove any operand
                operand = null;
                cleartext = true;
                //get value from label
                double inv = double.Parse(label1.Text);
                //if inv is not zero get inverse
                if (inv != 0)
                {
                    label2.Text = $"1 / {inv} = ";
                    clearerror = true;
                    inv = 1 / inv;
                    //output value back to label
                    label1.Text = inv.ToString();
                }
                else
                {
                    //Display error meesage
                    label2.Text = "Cannot divide by zero";
                    clearerror = true;
                }
            }
            else
            {
                //Display error meesage
                label2.Text = "Invalid Input";
                clearerror = true;
            }
        }

        //SQRT button is clicked
        private void Sqroot_Click(object sender, EventArgs e)
        {
            //Check if label is empty or text
            if (label1.Text != null && !isText)
            {
                //Remove any operand
                operand = null;
                cleartext = true;
                //get value from label
                double sqrt = double.Parse(label1.Text);
                //if sqrt is greater thanor equal to zero
                if (sqrt >= 0)
                {
                    label2.Text = $"sqrt({sqrt})";
                    clearerror = true;
                    sqrt = Math.Sqrt(sqrt);
                    //output value back to label
                    label1.Text = sqrt.ToString();
                }
                else
                {
                    //Display error meesage
                    label2.Text = "Cannot use negative number for square root";
                    clearerror = true;
                }
            }
            else
            {
                //Display error meesage
                label2.Text = "Invalid Input";
                clearerror = true;
            }
        }

        //Clear button is clicked
        private void Clear_Click(object sender, EventArgs e)
        {
            //reset variables
            label1.Text = "";
            label2.Text = "";
            x = 0;
            y = 0;
            cleartext = false;
            clearerror = false;
            isText = false;
        }

        private void MemoryAdd_Click(object sender, EventArgs e)
        {
            //Check if label is empty
            if(label1.Text != null && !isText)
            {
                //add label to memory
                memory = double.Parse(label1.Text);
            }
            else
            {
                //Display error message
                label2.Text = "Cannot add an invalid value to Memory";
                clearerror = true;
            }
        }

        private void MemroyRecall_Click(object sender, EventArgs e)
        {
            //set label as the value in memory
            label1.Text = $"{memory}";
        }

        private void MemoryClear_Click(object sender, EventArgs e)
        {
            //reset memory
            memory = 0;
        }

        private void Exponential_Click(object sender, EventArgs e)
        {
            // code needs to be added
            if(label1.Text != null && !label1.Text.Contains('E'))
            {
                //Add 'E' to label
                label1.Text += "E";
                isText = true;
            }
            else
            {
                //Display error message
                label2.Text = "Invalid Input";
                clearerror = true;
            }
        }

        //keypress handler
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //check if keychar is a number or '.'
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '.')
            {
                //Check if label2 needs to be cleared
                if (clearerror)
                {
                    label2.Text = "";
                    clearerror = false;
                }
                //Check if label1 needs to be cleared
                if (cleartext)
                {
                    //clear label
                    label1.Text = "";
                    //reset cleartext bool
                    cleartext = false;
                    //reset istext bool
                    isText = false;
                }
                //check if input is a decimal
                if (e.KeyChar == '.')
                {
                    //check if the label already has a decimal point
                    if (!label1.Text.Contains('.') && !label1.Text.Contains('E'))
                    {
                        //add decimal point to label
                        label1.Text += '.';
                    }
                    else if (label1.Text.Contains('.'))
                    {
                        //Display error message
                        label2.Text = "Cannot add another decimal";
                        clearerror = true;
                    }
                    else if (label1.Text.Contains('E'))
                    {
                        //Display error message
                        label2.Text = "Cannot add a decimal to E";
                        clearerror = true;
                    }

                }
                else
                {
                    //add input to the label
                    label1.Text += e.KeyChar;
                    isText = false;
                }
            }
            else
            {
                //Check operands
                switch (e.KeyChar)
                {
                    case '+':
                        addOperand("+");
                        break;
                    case '-':
                        addOperand("-");
                        break;
                    case '*':
                        addOperand("*");
                        break;
                    case '/':
                        addOperand("/");
                        break;
                    case '%':
                        addOperand("%");
                        break;
                    case '^':
                        addOperand("^");
                        break;
                    case '=':
                        Equals_Click(new object(), new EventArgs());
                        break;
                }
            }
        }

        private void posneg_Click(object sender, EventArgs e)
        {
            //check if label is empty or text
            if(label1.Text != null && !isText){
                //get new value and display it
                y = double.Parse(label1.Text) * -1;
                label1.Text = $"{y}";
            }
            else if(label1.Text != null)
            {
                //check if 'E' is in label and if it is last char
                int index = label1.Text.IndexOf('E');

                if ((index + 1) == label1.Text.Length) label1.Text += "-";
                else if (label1.Text[(index + 1)] != '-')
                {
                    //get negative of value
                    y = double.Parse(label1.Text) * -1;
                    label1.Text = $"{y}";
                }
            }
            
        }

        //function for adding an operand and setting x variable
        private void addOperand(string input)
        {
            //check if label is empty or text
            if (label1.Text != null && !isText)
            {
                //set operand to the input string
                operand = input;
                //parse label into x variable
                
                x = double.Parse(label1.Text);
                //Set to clear text on next input
                cleartext = true;

                //Display operation
                label2.Text = $"{x} {operand} ";
                clearerror = false;
            }
            else
            {
                //Display error message
                label2.Text = "Invalid Input";
                clearerror = true;
            }
        }

        //Any input button is clicked
        private void addInput(object sender, MouseEventArgs e)
        {
            //Get the text property of the clicked button
            string input =  ((Button) sender).Text;

            //Check if label2 needs to be cleared
            if (clearerror)
            {
                label2.Text = "";
                clearerror = false;
            }
            //Check if label1 needs to be cleared
            if (cleartext)
            {
                //clear label
                label1.Text = "";
                //reset cleartext bool
                cleartext = false;
                //reset istext bool
                isText = false;
            }
            //check if input is a decimal
            if (input == ".")
            {
                //check if the label already has a decimal point
                if (!label1.Text.Contains('.') && !label1.Text.Contains('E'))
                {
                    //add decimal point to label
                    label1.Text += '.';
                }
                else if (label1.Text.Contains('.'))
                {
                    //Display error message
                    label2.Text = "Cannot add another decimal";
                    clearerror = true;
                }
                else if (label1.Text.Contains('E'))
                {
                    //Display error message
                    label2.Text = "Cannot add a decimal to E";
                    clearerror = true;
                }

            }
            else
            {
                //add input to the label
                label1.Text += input;
                isText = false;
            }
        }
    }
} 