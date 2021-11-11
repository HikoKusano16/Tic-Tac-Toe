using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_Work_TTT
{
    public partial class Game : Form
    {
        string[][] ButtonTable;
        Button[] AllButtons;
        Color buttonColorDefault, buttonColorX, buttonColorO;
        public Game()
        {
            InitializeComponent();
            ButtonTable = new[]
             {
                new [] {button1.Text, button4.Text, button7.Text},
                new [] {button2.Text, button5.Text, button8.Text},
                new [] {button3.Text, button6.Text, button9.Text}
            };
            AllButtons = new[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            buttonColorDefault = button1.BackColor;
            buttonColorX = Color.FromArgb(255, 255, 0, 0); ;
            buttonColorO = Color.FromArgb(255, 0, 0, 255); ;
        }

        private void field_Click(object sender, EventArgs e)
        {
            if (XorO.Text == "X")
            {
                (sender as Button).Text = "X";
                XorO.Text = "O";
                (sender as Button).Enabled = false;
                (sender as Button).BackColor = buttonColorX;
            }
            else
            {
                (sender as Button).Text = "O";
                XorO.Text = "X";
                (sender as Button).Enabled = false;
                (sender as Button).BackColor = buttonColorO;
            }

            ButtonTable = new[]
             {
                new [] {button1.Text, button4.Text, button7.Text},
                new [] {button2.Text, button5.Text, button8.Text},
                new [] {button3.Text, button6.Text, button9.Text}
            };

            string winner = checkWinner();
            if (winner != null)
            {
                runWin(winner);
            }
        }

        private string checkWinner()
        {
            bool wonX = didPlayerWon("X"), wonO = didPlayerWon("O");
            Console.WriteLine(wonX);
            if (wonX) return "X";
            else if (wonO) return "O";
            return null;
        }

        private bool didPlayerWon(string player)
        {
            bool won = false;

            for (int x = 0; x < 3; x++)
            {
                if (ButtonTable[x][0] == player && ButtonTable[x][1] == player && ButtonTable[x][2] == player)
                {
                    won = true;
                    break;
                }
            }
            for (int y = 0; y < 3; y++)
            {
                if (ButtonTable[0][y] == player && ButtonTable[1][y] == player && ButtonTable[2][y] == player)
                {
                    won = true;
                    break;
                }
            }
            if ((ButtonTable[0][0] == player && ButtonTable[1][1] == player && ButtonTable[2][2] == player) ||
                (ButtonTable[2][0] == player && ButtonTable[1][1] == player && ButtonTable[0][2] == player))
                won = true;

            return won;
        }

        private void reset()
        {
            foreach (Button button in AllButtons)
            {
                button.Text = "";
                button.Enabled = true;
                button.BackColor = buttonColorDefault;
            }
        }

        private void runWin(string winner)
        {
            DialogResult message = MessageBox.Show(this, "Winner is " + winner, "Winner is " + winner, MessageBoxButtons.OK);
            reset();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
