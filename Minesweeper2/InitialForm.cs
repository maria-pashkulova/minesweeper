using System;
using System.Windows.Forms;

namespace Minesweeper2
{
    public partial class InitialForm : Form
    {
        
        public InitialForm()
        {
            InitializeComponent();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            ValidateInputs(tbName, epName);
            
        }

        private void btnGoToGameForm_Click(object sender, EventArgs e)
        {
           
            if (!DetectDigits(tbName.Text) && tbName.Text!="")
            {
                if (tbName.Text.Trim()=="")
                {
                    MessageBox.Show("Въведохте само интервали", "Грешка!");
                    return;
                }
                string name = tbName.Text.Trim();
                Game mineSweeper = new Game(name);

                mineSweeper.Show();
                //Hide the main form (the starting form of the application)
                this.Hide();
            }
            else
            {
                MessageBox.Show("Въведете валидно име!","Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbName.Text = "";
            }
        }

        private void ValidateInputs(TextBox tb, ErrorProvider ep)
        {
            if (tb.Text == "")
            {
                ep.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                ep.BlinkRate = 200;
                ep.Icon = Properties.Resources.iconfinder_error_1646012;
                ep.SetError(tb, "Попълнете полето за име!");

                
            }
            else
            {
                ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                ep.Icon = Properties.Resources.iconfinder_check_1930264__1_;
                ep.SetError(tb, "Попълнихте полето за име");

                
            }
        }

        public static bool DetectDigits(string s)
        {
            foreach (char c in s)
            {
                if (Char.IsDigit(c))
                    return true;
            }
           
            return false;
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.bomb;
        }
    }
}
