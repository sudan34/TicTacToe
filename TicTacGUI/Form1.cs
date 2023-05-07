using BoardLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacGUI
{
    public partial class Form1 : Form
    {
        Board game = new Board();
        Button[] buttons = new Button[9];
        Random random= new Random();

        public Form1()
        {
            InitializeComponent();
            game = new Board();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            // add a common click event to each button
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtonClick;
                buttons[i].Tag = i;
            }
        }

        private void handleButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
           // MessageBox.Show("Button " + clickedButton.Tag + " was Clicked");

            int gameSquareNumber = (int)clickedButton.Tag;
            game.Grid[gameSquareNumber] = 1;

            updateBoard();

            if (game.isBoardFull() == true)
            {
                MessageBox.Show("The board is full");
                disableAllButton();

            } else if (game.checkForWinner() == 1)
            {
                MessageBox.Show("Player human wins!");
                disableAllButton();
            }
            else
            {
                //computer turn
                computerChoose();
            }
        }

        private void disableAllButton()
        {
            foreach(Button item in buttons)
            {
                item.Enabled = false;
            }
        }

        private void computerChoose()
        {
            // computer pick random number
            int ComputerTurn = random.Next(9);
            while (ComputerTurn == -1 || game.Grid[ComputerTurn] != 0)
            {
                ComputerTurn = random.Next(9);
                Console.WriteLine("Computer chooses " + ComputerTurn);
            }

            game.Grid[ComputerTurn] = 2;
            updateBoard();

            //check for winer

            if (game.isBoardFull() == true)
            {
                MessageBox.Show("The board is full");
                disableAllButton();

            }
            else if (game.checkForWinner() == 2)
            {
                MessageBox.Show("Player Computer wins!");
                disableAllButton();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateBoard();
        }

        private void updateBoard()
        {
            // assign an X or O to the text of each button based on value
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text= "";
                    buttons[i].Enabled = true;
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                    buttons[i].Enabled = false;
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    buttons[i].Enabled = false;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            game = new Board();
            enableAllButtons();
        }

        private void enableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = true;
            }
            updateBoard();
        }
    }
}
