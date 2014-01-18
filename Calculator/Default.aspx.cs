using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CalculatorDB;

namespace Calculator
{   
    public partial class Default : System.Web.UI.Page
    {
        public List<Operation> list { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            list = db.GetOperation();

            myRepeater.DataSource = list;
            myRepeater.DataBind();
        } 

        // обработчик кнопок цифр
        protected void btnDigit_Click(object sender, EventArgs e)
        {   
            Button btn = (Button)sender;

            if ((ViewState["last_operation"] != null && ViewState["last_operation"].ToString() == "=") || editWide.Text == "ERROR: CANNOT DIVIDE")
            {
                editWide.Text = string.Empty;
                ViewState["last_operation"] = string.Empty;
            }


            if (ViewState["last_operation"] != null && ViewState["last_operation"].ToString() == "/" && btn.Text == "0" && editWide.Text.Length == 0)
            {
                ViewState["first_number"] = null;
                ViewState["last_operation"] = null;
                editWide.Text = "ERROR: CANNOT DIVIDE";
            }
            else
            {
                editWide.Text += btn.Text;
            }
        }

        // обработчик кнопок операций
        protected void btnOperation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (editWide.Text.Length != 0)
            {
                ViewState["content"] += editWide.Text + " " + btn.Text + " ";
            }
            
            if (editWide.Text.Length != 0 && ViewState["first_number"] == null)
            {
                ViewState.Add("first_number", editWide.Text);
                ViewState.Add("last_operation", btn.Text);
                editWide.Text = string.Empty;
            }
            else if(editWide.Text.Length != 0 && ViewState["first_number"] != null) 
            {
                double answer = operationWithNumbers(ViewState["first_number"].ToString(), editWide.Text);
                editWide.Text = string.Empty;
                ViewState["first_number"] = answer;
                ViewState["last_operation"] = btn.Text;
            }
        }

        // обработчик кнопки "%"
        protected void btnPercent_Click(object sender, EventArgs e)
        {
            if ((editWide.Text.Length != 0) && (ViewState["first_number"] != null))
            {
                double first_number = Convert.ToDouble(ViewState["first_number"]);
                double second_number = Convert.ToDouble(editWide.Text);

                double answer = first_number / 100 * second_number;
                editWide.Text = answer.ToString();
            }
        }

        // обработчик кнопки "+/-"
        protected void btnNeg_Click(object sender, EventArgs e)
        {
            if (editWide.Text.Length != 0)
            {
                double number = Convert.ToDouble(editWide.Text);
                
                number *= -1;
                editWide.Text = number.ToString();
            }
        }

        // обработчик кнопки "C"
        protected void btnClear_Click(object sender, EventArgs e)
        {
            editWide.Text = string.Empty;
        }

        // обработчик кнопки "="
        protected void btnEqual_Click(object sender, EventArgs e)
        {
            if (editWide.Text.Length != 0 && ViewState["last_operation"].ToString() != "=")  
            {
                double answer = operationWithNumbers(ViewState["first_number"].ToString(), editWide.Text);
                ViewState["first_number"] = null;
                ViewState["content"] += editWide.Text + " = " + answer.ToString();
                editWide.Text = answer.ToString();

                createOperation();
            }

            ViewState["last_operation"] = "=";
        }

        // метод для сложения двух чисел
        private double addNumbers(double first_number, double second_number)
        {
            double answer = first_number + second_number;
            return answer;
        }

        // метод для вычитания двух чисел
        private double subtrackNumbers(double first_number, double second_number)
        {
            double answer = first_number - second_number;
            return answer;
        }

        // метод для умножения двух чисел
        private double multiplyNumbers(double first_number, double second_number) 
        {
            double answer = first_number * second_number;
            return answer;
        }

        // метод для деления двух чисел
        private double divideNumbers(double first_number, double second_number)
        {
            double answer = first_number / second_number;
            return answer;
        }

        // метод определения операции
        private double operationWithNumbers(string first_string, string second_string)
        {
            double first_number = Convert.ToDouble(first_string);
            double second_number = Convert.ToDouble(second_string);
            double answer = 0;

            switch (ViewState["last_operation"].ToString())
            {
                case "+":
                    answer = addNumbers(first_number, second_number);
                    break;
                case "-":
                    answer = subtrackNumbers(first_number, second_number);
                    break;
                case "*":
                    answer = multiplyNumbers(first_number, second_number);
                    break;
                case "/":
                    answer = divideNumbers(first_number, second_number);
                    break;
            }

            return answer;
        }

        // метод для создания операции в базу данных
        private void createOperation()
        {
            DataAccess db = new DataAccess();
            Operation operation = new Operation();

            operation.Content = ViewState["content"].ToString();
            ViewState["content"] = null;
            operation.Created_at = DateTime.Now;

            db.Insert(operation);
        }

        // метод для очищения базы данных
        protected void btnClearEntry_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            db.Remove();
        }
    }
}