using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MagicTicTakToe
{
    public partial class MainWindow : Window
    {
        private bool isCrossTurn = true;

        public MainWindow()
        {
            InitializeComponent();
            btn1.Click += Button_Click;
            btn2.Click += Button_Click;
            btn3.Click += Button_Click;
            btn4.Click += Button_Click;
            btn5.Click += Button_Click;
            btn6.Click += Button_Click;
            btn7.Click += Button_Click;
            btn8.Click += Button_Click;
            btn9.Click += Button_Click;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton.Content == null)
            {
                clickedButton.Content = isCrossTurn ? "X" : "O";
                clickedButton.IsEnabled = false;
                CheckForWin();
                isCrossTurn = !isCrossTurn; 
                if (!isCrossTurn) 
                {
                    MakeRobotMove();
                }
            }
        }

        private void MakeRobotMove()
        {
            List<Button> emptyButtons = GetEmptyButtons();
            if (emptyButtons.Count > 0)
            {
                int randomIndex = new Random().Next(emptyButtons.Count);
                Button randomButton = emptyButtons[randomIndex];
                randomButton.Content = "O";
                randomButton.IsEnabled = false;
                CheckForWin();
                isCrossTurn = !isCrossTurn; 
            }
        }

        private void CheckForWin()
        {
            if (btn1.Content == "" && btn2.Content == "" && btn3.Content == "" ||
                btn4.Content == "" && btn5.Content == "" && btn6.Content == "" ||
                btn7.Content == "" && btn8.Content == "" && btn9.Content == "" ||
                btn1.Content == "" && btn4.Content == "" && btn7.Content == "" ||
                btn2.Content == "" && btn5.Content == "" && btn8.Content == "" ||
                btn3.Content == "" && btn6.Content == "" && btn9.Content == "" ||
                btn1.Content == "" && btn5.Content == "" && btn9.Content == "" ||
                btn3.Content == "" && btn5.Content == "" && btn7.Content == "")
            {
                UpdateGameResult("Крестики победили!");
                DisableButtons();
            }
            else if (btn1.Content == "" && btn2.Content == "" && btn3.Content == "" ||
                btn4.Content == "" && btn5.Content == "" && btn6.Content == "" ||
                btn7.Content == "" && btn8.Content == "" && btn9.Content == "" ||
                btn1.Content == "" && btn4.Content == "" && btn7.Content == "" ||
                btn2.Content == "" && btn5.Content == "" && btn8.Content == "" ||
                btn3.Content == "" && btn6.Content == "" && btn9.Content == "" ||
                btn1.Content == "" && btn5.Content == "" && btn9.Content == "" ||
                btn3.Content == "" && btn5.Content == "" && btn7.Content == "")
            {
                UpdateGameResult("Нолики победили!");
                DisableButtons();
            }
            else if (GetEmptyButtons().Count == 0)
            {
                UpdateGameResult("Ничья!");
                DisableButtons();
            }
        }

        private void DisableButtons()
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            btn7.IsEnabled = false;
            btn8.IsEnabled = false;
            btn9.IsEnabled = false;

        }

        private void UpdateGameResult(string result)
        {
            MessageBox.Show(result, "Результат игры", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private List<Button> GetEmptyButtons()
        {
            List<Button> emptyButtons = new List<Button>();
            if (btn1.Content == null) emptyButtons.Add(btn1);
            if (btn2.Content == null) emptyButtons.Add(btn2);
            if (btn3.Content == null) emptyButtons.Add(btn3);
            if (btn4.Content == null) emptyButtons.Add(btn4);
            if (btn5.Content == null) emptyButtons.Add(btn5);
            if (btn6.Content == null) emptyButtons.Add(btn6);
            if (btn7.Content == null) emptyButtons.Add(btn7);
            if (btn8.Content == null) emptyButtons.Add(btn8);
            if (btn9.Content == null) emptyButtons.Add(btn9);
            return emptyButtons;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            ClearBoard();
            EnableButtons();
        }

        private void ClearBoard()
        {
            btn1.Content = null;
            btn2.Content = null;
            btn3.Content = null;
            btn4.Content = null;
            btn5.Content = null;
            btn6.Content = null;
            btn7.Content = null;
            btn8.Content = null;
            btn9.Content = null;
        }

        private void EnableButtons()
        {
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;
            btn6.IsEnabled = true;
            btn7.IsEnabled = true;
            btn8.IsEnabled = true;
            btn9.IsEnabled = true;
        }
    }
}