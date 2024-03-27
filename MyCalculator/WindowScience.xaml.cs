using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

public static class MathConstants
{
    public const double E = 2.71828182845904523536;// 自然数 E
}

namespace MyCalculator
{
    /// <summary>
    /// WindowScience.xaml 的交互逻辑
    /// </summary>
    public partial class WindowScience : Window, INotifyPropertyChanged
    {
        public WindowScience() { 
        
            InitializeComponent();
            B_M2_Clean.IsEnabled = false;
            B_M2_Add.IsEnabled = false;
            B_M2_Recall.IsEnabled = false;
            B_M2_Minus.IsEnabled = false;
            B_2_ySx.IsEnabled = false;
            B_2_xy.IsEnabled = false;

            this.Closing += MainWindow_Closing;

        }
        public event PropertyChangedEventHandler? PropertyChanged;
        // temp用于临时存储操作数，oper存储最近一次的运算符
        private double m_temp, m_op1, m_op2, m_memory, m_result;
        private string m_oper = null;
        private string m_src = "";
        private static bool m_next;// next用来表示是否要输入新的操作数
        private bool m_Isclean;// 判断是否清空了文本框
        private Stack<string> m_stack;

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 在窗口关闭前执行操作

            // 默认退出应用程序
            Application.Current.Shutdown();
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)// 切换窗体
        {
            MenuItem menuItem = (MenuItem)sender;
            string selectedWindowName = menuItem.Header.ToString();

            // 获取当前程序集
            Assembly assembly = Assembly.GetExecutingAssembly();

            // 根据窗体名称获取类型
            Type windowType = assembly.GetType("MyCalculator." + selectedWindowName);

            // 创建窗体实例并显示
            Window window = (Window)Activator.CreateInstance(windowType);
            this.Hide();
            window.Show();
        }

        static int Precedence(char op)// 优先级
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }

        static string InfixToPostfix(string infix)// 中缀转后
        {
            string postfix = "";
            Stack<char> stack = new Stack<char>();

            foreach (char c in infix)
            {
                if (char.IsDigit(c))
                {
                    postfix += c;
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }
                    stack.Pop(); // 弹出左括号
                }
                else
                {
                    while (stack.Count > 0 && Precedence(c) <= Precedence(stack.Peek()))
                    {
                        postfix += stack.Pop();
                    }
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
            {
                postfix += stack.Pop();
            }

            return postfix;
        }

        static double EvaluatePostfix(string postfix)// 后缀表达式的计算
        {
            Stack<double> stack = new Stack<double>();

            foreach (char c in postfix)
            {
                if (char.IsDigit(c))
                {
                    stack.Push(c - '0');
                }
                else
                {
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();

                    switch (c)
                    {
                        case '+':
                            stack.Push(operand1 + operand2);
                            break;
                        case '-':
                            stack.Push(operand1 - operand2);
                            break;
                        case '*':
                            stack.Push(operand1 * operand2);
                            break;
                        case '/':
                            stack.Push(operand1 / operand2);
                            break;
                    }
                }
            }

            if (m_next)
                EvaluatePostfix("");
            return stack.Pop();
        }


        private void B_2_3_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "3";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "3";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;
            B_2_ySx.IsEnabled = true;
            B_2_xy.IsEnabled = true;
        }

        private void B_2_4_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "4";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "4";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;
            B_2_ySx.IsEnabled = true;
            B_2_xy.IsEnabled = true;
        }

        private void B_2_5_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "5";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "5";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;
            B_2_ySx.IsEnabled = true;
            B_2_xy.IsEnabled = true;
        }

        private void B_2_6_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "6";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "6";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;
            B_2_ySx.IsEnabled = true;
            B_2_xy.IsEnabled = true;
        }

        private void B_2_7_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "7";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "7";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;
            B_2_ySx.IsEnabled = true;
            B_2_xy.IsEnabled = true;
        }

        private void B_2_8_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "8";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "8";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;
            B_2_ySx.IsEnabled = true;
            B_2_xy.IsEnabled = true;
        }

        private void B_2_9_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "9";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "9";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;
            B_2_ySx.IsEnabled = true;
            B_2_xy.IsEnabled = true;
        }

        private void B_2_Add_Click(object sender, RoutedEventArgs e)
        {
            //Out_2_1.Text += "+";
            //Out_2_2.Text += Out_2_1.Text ;
            //if (m_oper != null)
            //{
            //    //Aut();

            //}
            //m_op1 = Convert.ToDouble(Out_2_1.Text);
            Out_2_1.Text += "+";
            Out_2_2.Text = Out_2_1.Text;
            m_src = Out_2_2.Text;
            m_oper = "+";
            m_next = true;
        }

        private void B_2_Eq_Click(object sender, RoutedEventArgs e)
        {
            #region
            //try
            //{
            //    m_op2 = Convert.ToDouble(Out_2_1.Text);

            //}
            //catch (Exception ex)// 非法输入归零
            //{
            //    m_op2 = 0;
            //}

            //switch (m_oper)
            //{
            //    case "+":
            //        m_result = m_op1 + m_op2;
            //        break;
            //    case "-":
            //        m_result = m_op1 - m_op2;
            //        break;
            //    case "×":
            //        m_result = m_op1 * m_op2;
            //        break;
            //    case "÷":
            //        m_result = m_op1 / m_op2;
            //        break;
            //    default:
            //        break;

            //}
            //m_oper = null;
            //Out_2_1.Text = Convert.ToString(m_result);
            //Out_2_2.Text = "";
            #endregion

            string temp = m_src;
            Out_2_2.Text = m_src;
            m_src = InfixToPostfix(temp);
            
            m_result = EvaluatePostfix(m_src);
            Out_2_1.Text = Convert.ToString(m_result);

            
            m_src = "";
        }

        private void B_2_Sub_Click(object sender, RoutedEventArgs e)
        {
            #region
            //Out_2_2.Text += Out_2_1.Text + "-";
            //if (m_oper != null)
            //{
            //    Aut();
            //}
            //m_op1 = Convert.ToDouble(Out_2_1.Text);
            //m_oper = "-";
            //m_next = true;
            #endregion
            Out_2_1.Text += "-";
            Out_2_2.Text = Out_2_1.Text;
            m_src = Out_2_2.Text;
            m_oper = "-";
            m_next = true;

        }

        private void B_2_Multiply_Click(object sender, RoutedEventArgs e)
        {
            //Out_2_2.Text += Out_2_1.Text + "×";
            //if (m_oper != null)
            //{
            //    Aut();
            //}
            //m_op1 = Convert.ToDouble(Out_2_1.Text);
            //m_oper = "×";
            //m_next = true;

            Out_2_1.Text += "*";
            Out_2_2.Text = Out_2_1.Text;
            m_src = Out_2_2.Text;
            m_oper = "*";
            m_next = true;
        }

        private void B_2_Divide_Click(object sender, RoutedEventArgs e)
        {
            #region
            //Out_2_2.Text += Out_2_1.Text + "÷";
            //if (m_oper != null)
            //{
            //    Aut();
            //}
            //m_op1 = Convert.ToDouble(Out_2_1.Text);
            //m_oper = "÷";
            //m_next = true;
            #endregion
            Out_2_1.Text += "/";
            Out_2_2.Text = Out_2_1.Text;
            m_src = Out_2_2.Text;
            m_oper = "/";
            m_next = true;
        }

        private void B_2_delete_Click(object sender, RoutedEventArgs e)
        {
            if (!m_next)
            {
                if (Out_2_1.Text.Length == 1)
                {
                    Out_2_1.Text = "0";
                }
                else
                {
                    Out_2_1.Text = Out_2_1.Text.Substring(0, Out_2_1.Text.Length - 1);
                }
            }
        }

        private void B_2_CE_Click(object sender, RoutedEventArgs e)
        {
            Out_2_1.Text = "0";
            m_oper = null;
            m_Isclean = true;

        }

        private void B_2_C_Click(object sender, RoutedEventArgs e)
        {
            Out_2_1.Text = "0";
            Out_2_2.Text = "";
            m_oper = null;
            m_Isclean = true;
        }

        private void B_2_Invert_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            if (m_temp != 0)
            {
                m_temp = 0 - m_temp;
            }
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_2_Sqrt_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Pow(m_temp, 0.5);
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_2_Per_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = m_temp / 100;
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_2_Reciprocal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_temp = Convert.ToDouble(Out_2_1.Text);
                m_temp = 1 / m_temp;

                Out_2_1.Text = Convert.ToString(m_temp);
            }
            catch (DivideByZeroException ex)
            {
                Out_2_1.Text = "除数不能为0";
            }
        }

        private void B_2_Point_Click(object sender, RoutedEventArgs e)
        {
            Out_2_1.Text += ".";
        }

        private void B_LeftPar_Click(object sender, RoutedEventArgs e)
        {
            if(Out_2_1.Text.Equals("0"))
            {
                Out_2_1.Text = "(";
            }
            else
            {
                Out_2_1.Text += "(";
                //m_src += "(";
            }
            m_src = Out_2_1.Text;

        }

        private void B_RightPar_Click(object sender, RoutedEventArgs e)
        {
            if(Out_2_1.Text.Length == 0) 
            {
                MessageBox.Show("输入有误！！");
                Out_2_1.Text = "0";
            }
            else
            {
                Out_2_1.Text += ")";
                m_src += ")";
            }
        }

        private void B_2_Square_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Pow(m_temp, 2);
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_2_Cube_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Pow(m_temp, 3);
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_2_3Sx_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            //double x = 16; // 要开根号的数
            int y = 3; // 开根号的次数

            m_temp = Math.Pow(m_temp, 1.0 / y);
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_2_10Mx_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Pow(10, m_temp);
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_2_Log_Click(object sender, RoutedEventArgs e)// 以10为底数
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Log10(m_temp);
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_M2_Save_Click(object sender, RoutedEventArgs e)
        {
            m_memory = Convert.ToDouble(Out_2_1.Text);
            B_M2_Clean.IsEnabled = true;
            B_M2_Add.IsEnabled = true;
            B_M2_Recall.IsEnabled = true;
            B_M2_Minus.IsEnabled = true;
        }

        private void B_M2_Clean_Click(object sender, RoutedEventArgs e)
        {
            m_memory = 0;
            B_M2_Clean.IsEnabled = false;
            B_M2_Add.IsEnabled = false;
            B_M2_Recall.IsEnabled = false;
            B_M2_Minus.IsEnabled = false;
        }

        private void B_M2_Recall_Click(object sender, RoutedEventArgs e)
        {
            Out_2_1.Text = Convert.ToString(m_memory);
        }

        private void B_M2_Add_Click(object sender, RoutedEventArgs e)
        {
            m_memory += Convert.ToDouble(Out_2_1.Text);
        }

        private void B_M2_Minus_Click(object sender, RoutedEventArgs e)
        {
            m_memory -= Convert.ToDouble(Out_2_1.Text);
        }

        private void B_2_xy_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void B_2_ySx_Click(object sender, RoutedEventArgs e)// 先输入x再y
        {
            // TODO
        }

        private void B_Factorial_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text); // 要计算阶乘的数
            long factorial = 1;

            for (int i = 1; i <= m_temp; i++)
            {
                factorial *= i;
            }
            Out_2_1.Text = Convert.ToString(factorial);
        }

        private void B_Tan_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Tan(m_temp * Math.PI / 180);// 将角度转换为弧度并计算正切值
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_Ln_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Log(m_temp, MathConstants.E);// 计算 x 的自然对数
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_Int_Click(object sender, RoutedEventArgs e)
        {   // TODO： 切换成 Frac 当 B_Int.Content = "Frac";
            //if (true)
            //{
                
            //}

            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Floor(m_temp);// 取 x 的整数部分（向下取整）
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_Cos_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Cos(m_temp);// （以弧度为单位）
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_Sin_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_2_1.Text);
            m_temp = Math.Sin(m_temp);// （以弧度为单位）
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_Dms_Click(object sender, RoutedEventArgs e)
        {// DMS（度分秒）功能通常用于将角度值表示为度、分、秒的形式，或者将度、分、秒转换为十进制角度
           
        }

        private void B_Pai_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Math.PI;
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_FE_Click(object sender, RoutedEventArgs e)
        {// 以科学计数法的形式显示出来
            // 将数值转换为浮点数
            double number = double.Parse(Out_2_1.Text);

            // 使用指数符号将数值转换为科学计数法表示
            string scientificNotation = number.ToString("E");

            // 更新文本框中的数值为科学计数法表示
            Out_2_1.Text = scientificNotation;
        }

        private void B_Exp_Click(object sender, RoutedEventArgs e)
        {// exp键就是乘与10的次方键,比如你要写12000,可以直接按12000,也可以按1.2再按exp再按4
            //m_temp = Convert.ToDouble(Out_2_1.Text);
            //m_temp = Math.Pow(m_temp, 10);// 
            //Out_2_1.Text = m_temp.ToString("0.0E+0");
        }

        private void B_Deg_Checked(object sender, RoutedEventArgs e)
        {
            // TODO “度”的状态
            B_Deg.IsChecked = true;
        }

        private void B_Radian_Checked(object sender, RoutedEventArgs e)
        {
            // TODO “弧度”的状态
            B_Radian.IsChecked = true;

        }

        private void B_Gradient_Checked(object sender, RoutedEventArgs e)
        {
            // TODO “梯度”的状态
            B_Gradient.IsChecked = true;
        }

        private void B_Tanh_Click(object sender, RoutedEventArgs e)
        {
            // 将角度转换为弧度
            //double radians = angle * Math.PI / 180;
            Out_2_2.Text = "";
            Out_2_2.Text =  "tanh(" + Out_2_1.Text + ")";
            m_temp = Convert.ToDouble(Out_2_1.Text);
            // 计算tanh值
            double tanhValue = Math.Tanh(m_temp);
            m_temp = tanhValue;
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_Cosh_Click(object sender, RoutedEventArgs e)
        {
            // 将角度转换为弧度
            //double radians = angle * Math.PI / 180;
            Out_2_2.Text = "";
            Out_2_2.Text = "Cosh(" + Out_2_1.Text + ")";
            m_temp = Convert.ToDouble(Out_2_1.Text);
            // 计算tanh值
            double tanhValue = Math.Cosh(m_temp);
            m_temp = tanhValue;
            Out_2_1.Text = Convert.ToString(m_temp);
        }

        private void B_Inv_Click(object sender, RoutedEventArgs e)
        {

        }

        // 连续计算时先计算前面的结果
        private void Aut()
        {
            m_op2 = Convert.ToDouble(Out_2_1.Text);
            switch (m_oper)
            {
                case "+":
                    m_result = m_op1 + m_op2;
                    break;
                case "-":
                    m_result = m_op1 - m_op2;
                    break;
                case "×":
                    m_result = m_op1 * m_op2;
                    break;
                case "÷":
                    m_result = m_op1 / m_op2;
                    break;
                default:
                    break;

            }

            Out_2_1.Text = Convert.ToString(m_result);
        }


        private void B_2_2_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "2";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "2";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;
            B_2_ySx.IsEnabled = true;
            B_2_xy.IsEnabled = true;
        }

        private void B_2_1_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "1";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "1";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;
            B_2_ySx.IsEnabled = true;
            B_2_xy.IsEnabled = true;
        }

        private void B_2_0_Click(object sender, RoutedEventArgs e)
        {
            if (Out_2_1.Text != "0" || !m_Isclean || Out_2_1.Text.Equals("("))
            {
                Out_2_1.Text += "0";
            }
            else
            {
                if (m_Isclean) m_Isclean = false;
                Out_2_1.Text = "0";
            }
            if (m_next)
            {
                m_next = false;
            }
            m_src = Out_2_1.Text;



            //if (Out_2_1.Text != "0")
            //{
            //    Out_2_1.Text += "0";
            //}
            //if (m_next || m_Isclean)
            //{
            //    Out_2_1.Text = "0";
            //    m_next = false;
            //    m_Isclean = false;
            //}

            //m_src += "0";
        }
    }
}
