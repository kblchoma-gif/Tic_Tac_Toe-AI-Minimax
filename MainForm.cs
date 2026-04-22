// MainForm.cs
using System;
using System.Windows.Forms;

namespace TicTacToeAI_WinForms
{
    public class MainForm : Form
    {
        private Button[,] buttons = new Button[3, 3]; // UI buttons
        private char[,] board = new char[3, 3];        // Game board state
        private char player = 'X';                     // Player symbol
        private char ai = 'O';                         // AI symbol

        public MainForm()
        {
            this.Text = "Tic Tac Toe - Player (X) vs AI (O)";
            this.ClientSize = new System.Drawing.Size(300, 300);
            InitBoard(); // Setup UI and board
        }

        // Initialize the button grid and board state
        private void InitBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' '; // Empty board
                    buttons[i, j] = new Button();
                    buttons[i, j].SetBounds(j * 100, i * 100, 100, 100); // Position button
                    buttons[i, j].Font = new System.Drawing.Font("Arial", 24);
                    buttons[i, j].Tag = new Tuple<int, int>(i, j); // Store row,col
                    buttons[i, j].Click += PlayerClick; // Event handler
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        // Handle player button click
        private void PlayerClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var (i, j) = (Tuple<int, int>)btn.Tag;
            if (board[i, j] != ' ') return; // Ignore if not empty

            board[i, j] = player;
            buttons[i, j].Text = player.ToString();
            buttons[i, j].Enabled = false;

            if (CheckWinner(player)) { EndGame("You win!"); return; }
            if (IsFull()) { EndGame("Draw!"); return; }

            AIMove();
            if (CheckWinner(ai)) { EndGame("AI wins!"); return; }
            if (IsFull()) { EndGame("Draw!"); return; }
        }

        // AI determines best move using Minimax
        private void AIMove()
        {
            int bestScore = int.MinValue;
            int moveRow = -1, moveCol = -1;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        board[i, j] = ai;
                        int score = Minimax(board, false);
                        board[i, j] = ' ';
                        if (score > bestScore)
                        {
                            bestScore = score;
                            moveRow = i;
                            moveCol = j;
                        }
                    }
                }

            board[moveRow, moveCol] = ai;
            buttons[moveRow, moveCol].Text = ai.ToString();
            buttons[moveRow, moveCol].Enabled = false;
        }

        // Minimax recursive algorithm to evaluate best score
        private int Minimax(char[,] state, bool isMaximizing)
        {
            if (CheckWinner(ai)) return 1;
            if (CheckWinner(player)) return -1;
            if (IsFull()) return 0;

            int bestScore = isMaximizing ? int.MinValue : int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, j] == ' ')
                    {
                        state[i, j] = isMaximizing ? ai : player;
                        int score = Minimax(state, !isMaximizing);
                        state[i, j] = ' ';
                        bestScore = isMaximizing ? Math.Max(score, bestScore) : Math.Min(score, bestScore);
                    }
                }
            }

            return bestScore;
        }

        // Check if the specified player has won
        private bool CheckWinner(char sym)
        {
            for (int i = 0; i < 3; i++)
                if ((board[i, 0] == sym && board[i, 1] == sym && board[i, 2] == sym) ||
                    (board[0, i] == sym && board[1, i] == sym && board[2, i] == sym)) return true;

            if ((board[0, 0] == sym && board[1, 1] == sym && board[2, 2] == sym) ||
                (board[0, 2] == sym && board[1, 1] == sym && board[2, 0] == sym)) return true;

            return false;
        }

        // Check if the board is completely filled
        private bool IsFull()
        {
            foreach (char c in board)
                if (c == ' ') return false;
            return true;
        }

        // Show result and reset the game
        private void EndGame(string message)
        {
            MessageBox.Show(message);
            ResetBoard();
        }

        // Reset the board and UI buttons for a new game
        private void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
        }
    }
}
