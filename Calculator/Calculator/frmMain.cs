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
    public partial class frmMain : Form
    {

        #region fields

        private Ops _op;
        private Signs _sign;
        private string _number;

        #endregion

        #region enums

        public enum Ops
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Square,
            Sqrt,
            OneOverX
        }

        public enum Signs
        {
            Positive,
            Negative
        }

        #endregion

        #region constructors

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region main calc operations

        private double calc(string num1, string num2)
        {
            double calc1 = double.Parse(num1);
            double calc2 = double.Parse(num2);

            switch(Op)
            {
                case Ops.Add:
                    return calc1 + calc2;
                case Ops.Subtract:
                    return calc1 - calc2;
                case Ops.Multiply:
                    return calc1 * calc2;
                case Ops.Divide:
                    return calc1 / calc2;
                case Ops.Square:
                    return calc1 * calc2;
                case Ops.Sqrt:
                    return Math.Sqrt(calc1);
                case Ops.OneOverX:
                    return 1 / calc1;
                default:
                    return 0;
            }
        }

        #endregion

        #region utilities

        private void addDigit(string digit)
        {
            txtMain.Text += digit;
        }

        private void storeNumber()
        {
            Number = txtMain.Text;
            txtMain.Clear();
            addDigit("0");
        }

        private void removeDigit()
        {
            txtMain.Text = txtMain.Text.Substring(0, txtMain.Text.Length - 2);
        }

        private Signs reverseSign(Signs sign)
        {
            if(sign == Signs.Negative)
            {
                return Signs.Positive;
            }
            return Signs.Negative;
        }

        #endregion

        #region event handlers

        #region numbers

        private void Btn9_Click(object sender, EventArgs e)
        {
            addDigit("9");
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            addDigit("8");
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            addDigit("7");
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            addDigit("6");
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            addDigit("5");
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            addDigit("4");
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            addDigit("3");
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            addDigit("2");
        }
        private void Btn1_Click(object sender, EventArgs e)
        {
            addDigit("1");
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            addDigit("0");
        }

        #endregion

        private void BtnPosNeg_Click(object sender, EventArgs e)
        {
            Sign = reverseSign(Sign);
        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {
            addDigit(".");
        }

        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            removeDigit();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtMain.Text = "";
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            Op = Ops.Add;
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            Op = Ops.Subtract;
        }

        private void BtnTimes_Click(object sender, EventArgs e)
        {
            Op = Ops.Multiply;
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            Op = Ops.Divide;
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            txtMain.Text = calc(Number, txtMain.Text).ToString();
        }

        #endregion

        #region properties

        private Ops Op
        {
            get
            {
                return _op;
            }
            set
            {
                _op = value;
            }
        }

        private Signs Sign
        {
            get
            {
                return _sign;
            }
            set
            {
                _sign = value;
            }
        }

        private string Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }

        #endregion
        
    }
}
