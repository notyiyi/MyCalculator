using System;
using System.Text;
using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace MyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            B_M_Clean.IsEnabled = false;
            B_M_Add.IsEnabled = false;
            B_M_Recall.IsEnabled = false;
            B_M_Minus.IsEnabled = false;

            this.Closing += MainWindow_Closing;

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

        // temp用于临时存储操作数，oper存储最近一次的运算符
        private double m_temp, m_op1, m_op2, m_memory, m_result;
        private string m_oper = null;
        // next用来表示是否要输入新的操作数
        private bool m_next, m_Isclean;

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 在窗口关闭前执行操作

            // 默认退出应用程序
            System.Windows.Application.Current.Shutdown();
        }

        // 连续计算时先计算前面的结果
        private void Aut()
        {
            m_op2 = Convert.ToDouble(Out_1.Text);
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

            Out_1.Text = Convert.ToString(m_result);
        }

        private void B_Add_Click(object sender, RoutedEventArgs e)
        {

            
            Out_2.Text += Out_1.Text + "+";
            if (m_oper != null)
            {
                Aut();
            }
            m_op1 = Convert.ToDouble(Out_1.Text);
            m_oper = "+";
            m_next = true;
        }

        private void B_0_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text != "0")
            {
                Out_1.Text += "0";
            }
            if (m_next || m_Isclean)
            {
                Out_1.Text = "0";
                m_next = false;
                m_Isclean = false;
            }
        }

        private void B_1_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text == "0" || m_next || m_Isclean)
            {
                Out_1.Text = "1";
                if (m_next)
                {
                    m_next = false;
                }
                if (m_Isclean) m_Isclean = false;
            }
            else
                Out_1.Text += "1";
        }

        private void B_2_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text == "0" || m_next || m_Isclean)
            {
                Out_1.Text = "2";
                if (m_next)
                {
                    m_next = false;
                }
                if (m_Isclean) m_Isclean = false;
            }
            else
                Out_1.Text += "2";
        }

        private void B_3_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text == "0" || m_next || m_Isclean)
            {
                Out_1.Text = "3";
                if (m_next)
                {
                    m_next = false;
                }
                if (m_Isclean) m_Isclean = false;
            }
            else
                Out_1.Text += "3";
        }

        private void B_4_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text == "0" || m_next || m_Isclean)
            {
                Out_1.Text = "4";
                if (m_next)
                {
                    m_next = false;
                }
                if (m_Isclean) m_Isclean = false;
            }
            else
                Out_1.Text += "4";
        }

        private void B_5_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text == "0" || m_next || m_Isclean)
            {
                Out_1.Text = "5";
                if (m_next)
                {
                    m_next = false;
                }
                if (m_Isclean) m_Isclean = false;
            }
            else
                Out_1.Text += "5";
        }

        private void B_6_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text == "0" || m_next || m_Isclean)
            {
                Out_1.Text = "6";
                if (m_next)
                {
                    m_next = false;
                }
                if (m_Isclean) m_Isclean = false;
            }
            else
                Out_1.Text += "6";
        }

        private void B_7_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text == "0" || m_next || m_Isclean)
            {
                Out_1.Text = "7";
                if (m_next)
                {
                    m_next = false;
                }
                if (m_Isclean) m_Isclean = false;
            }
            else
                Out_1.Text += "7";
        }



        private void B_Equal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_op2 = Convert.ToDouble(Out_1.Text);

            }
            catch(Exception ex)// 非法输入归零
            {
                m_op2 = 0;
            }

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
            m_oper = null;
            Out_1.Text = Convert.ToString(m_result);
            Out_2.Text = "";  
        }

        private void B_Sub_Click(object sender, RoutedEventArgs e)
        {
            Out_2.Text += Out_1.Text + "-";
            if (m_oper != null)
            {
                Aut();
            }
            m_op1 = Convert.ToDouble(Out_1.Text);
            m_oper = "-";
            m_next = true;
        }

        private void B_Multiply_Click(object sender, RoutedEventArgs e)
        {
            Out_2.Text += Out_1.Text + "×";
            if (m_oper != null)
            {
                Aut();
            }
            m_op1 = Convert.ToDouble(Out_1.Text);
            m_oper = "×";
            m_next = true;
        }

        private void B_Divide_Click(object sender, RoutedEventArgs e)
        {
            Out_2.Text += Out_1.Text + "÷";
            if (m_oper != null)
            {
                Aut();
            }
            m_op1 = Convert.ToDouble(Out_1.Text);
            m_oper = "÷";
            m_next = true;
        }

        private void B_Sqrt_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_1.Text);
            m_temp = Math.Pow(m_temp, 0.5);
            Out_1.Text = Convert.ToString(m_temp);
        }

        private void B_Cube_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_1.Text);
            m_temp = Math.Pow(m_temp, 3);
            Out_1.Text = Convert.ToString(m_temp);
        }

        private void B_Reciprocal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_temp = Convert.ToDouble(Out_1.Text);
                m_temp = 1 / m_temp;
                
                Out_1.Text = Convert.ToString(m_temp);
            }
            catch (DivideByZeroException ex)
            {
                Out_1.Text = "除数不能为0";
            }
        }

        private void B_Invert_Click(object sender, RoutedEventArgs e)// 取反
        {
            m_temp = Convert.ToDouble(Out_1.Text);
            if (m_temp != 0)
            {
                m_temp = 0 - m_temp;
            }
            Out_1.Text = Convert.ToString(m_temp);
        }

        private void B_Point_Click(object sender, RoutedEventArgs e)
        {
            Out_1.Text += ".";
        }

        private void B_Per_Click(object sender, RoutedEventArgs e)// %
        {
            m_temp = Convert.ToDouble(Out_1.Text);
            m_temp = m_temp / 100;
            Out_1.Text = Convert.ToString(m_temp);
        }

        private void B_CE_Click(object sender, RoutedEventArgs e)// 清除主文本框的内容
        {
            Out_1.Text = "0";
            m_oper = null;
            m_Isclean = true;

        }

        private void B_C_Click(object sender, RoutedEventArgs e)// 清除算式文本框与主文本框的内容
        {
            Out_1.Text = "0";
            Out_2.Text = "";
            m_oper = null;
            m_Isclean = true;
        }

        private void B_delete_Click(object sender, RoutedEventArgs e)
        {
            if (!m_next)
            {
                if (Out_1.Text.Length == 1)
                {
                    Out_1.Text = "0";
                }
                else
                {
                    Out_1.Text = Out_1.Text.Substring(0, Out_1.Text.Length - 1);
                }
            }
        }

        private void B_M_Save_Click(object sender, RoutedEventArgs e)
        {
            m_memory = Convert.ToDouble(Out_1.Text);
            B_M_Clean.IsEnabled = true;
            B_M_Add.IsEnabled = true;
            B_M_Recall.IsEnabled = true;
            B_M_Minus.IsEnabled = true;
        }

        private void B_M_Clean_Click(object sender, RoutedEventArgs e)
        {
            m_memory = 0;
            B_M_Clean.IsEnabled = false;
            B_M_Add.IsEnabled = false;
            B_M_Recall.IsEnabled = false;
            B_M_Minus.IsEnabled = false;
        }

        private void B_M_Recall_Click(object sender, RoutedEventArgs e)
        {
            Out_1.Text = Convert.ToString(m_memory);
        }

        private void B_M_Add_Click(object sender, RoutedEventArgs e)
        {
            m_memory += Convert.ToDouble(Out_1.Text);
        }

        private void B_M_Minus_Click(object sender, RoutedEventArgs e)
        {
            m_memory -= Convert.ToDouble(Out_1.Text);
        }

        private void B_Square_Click(object sender, RoutedEventArgs e)
        {
            m_temp = Convert.ToDouble(Out_1.Text);
            m_temp = Math.Pow(m_temp, 2);
            Out_1.Text = Convert.ToString(m_temp);
        }

        private void B_8_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text == "0" || m_next || m_Isclean)
            {
                Out_1.Text = "8";
                if (m_next)
                {
                    m_next = false;
                }
                if (m_Isclean) m_Isclean = false;
            }
            else
                Out_1.Text += "8";
        }

        private void B_9_Click(object sender, RoutedEventArgs e)
        {
            if (Out_1.Text == "0" || m_next || m_Isclean)
            {
                Out_1.Text = "9";
                if (m_next)
                {
                    m_next = false;
                }
                if (m_Isclean) m_Isclean = false;
            }
            else
                Out_1.Text += "9";
        }





        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            //目标
            this.contextMenu.PlacementTarget = this.btnMenu;
            // 位置
            this.contextMenu.Placement = PlacementMode.Right;
            //显示菜单
            this.contextMenu.IsOpen = true;
        }

       
    }
}