using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class MainPage : ContentPage


    {
        Label headingLbl;
        Grid gameBoard, page_grid;
        Button newGame, choosePlayer, gameRules;
        BoxView box;
        int[,] T = new int[3, 3];
        bool first = false;
        bool result;
        public int win;


        public MainPage()
        {

            // DEFAULT GRID

            page_grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(3,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                }
            };
            // HEADING

            headingLbl = new Label
            {
                Text = "Tic Tac Toe - Game",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
                TextDecorations = TextDecorations.Underline,
                FontSize = 20
            };

            // ** BUTTON **

            // NEW GAME
            newGame = new Button
            {
                Text = "New Game",
                BackgroundColor = Color.WhiteSmoke,
                TextColor = Color.Black
            };
            newGame.Clicked += newGame_Clicked;
            // CONTROL / CHECK

            int gameCheck()
            {
                if (T[0, 0] == 1 && T[1, 0] == 1 && T[2, 0] == 1 || T[0, 1] == 1 && T[1, 1] == 1 && T[2, 1] == 1 || T[0, 2] == 1 && T[1, 2] == 1 && T[2, 2] == 1)
                {
                    win = 1;
                }
                else if (T[0, 0] == 1 && T[0, 1] == 1 && T[0, 2] == 1 || T[1, 0] == 1 && T[1, 1] == 1 && T[1, 2] == 1 || T[2, 0] == 1 && T[2, 1] == 1 && T[2, 2] == 1)
                {
                    win = 1;
                }
                else if (T[0, 0] == 1 && T[1, 1] == 1 && T[2, 2] == 1 || T[0, 2] == 1 && T[1, 1] == 1 && T[2, 0] == 1)
                {
                    win = 1;
                }
                else if (T[0, 0] == 2 && T[1, 0] == 2 && T[2, 0] == 2 || T[0, 1] == 2 && T[1, 1] == 2 && T[2, 1] == 2 || T[0, 2] == 2 && T[1, 2] == 2 && T[2, 2] == 2)
                {
                    win = 2;
                }
                else if (T[0, 0] == 2 && T[0, 1] == 2 && T[0, 2] == 2 || T[1, 0] == 2 && T[1, 1] == 2 && T[1, 2] == 2 || T[2, 0] == 2 && T[2, 1] == 2 && T[2, 2] == 2)
                {
                    win = 2;
                }
                else if (T[0, 0] == 2 && T[1, 1] == 2 && T[2, 2] == 2 || T[0, 2] == 2 && T[1, 1] == 2 && T[2, 0] == 2)
                {
                    win = 2;
                }
                else if (T[0, 0] != 0 && T[1, 0] != 0 && T[2, 0] != 0 && T[0, 1] != 0 && T[1, 1] != 0 && T[2, 1] != 0 && T[0, 2] != 0 && T[1, 2] != 0 && T[2, 2] != 0)
                {
                    win = 3;
                }

                return win;
            }
            // ALERTS 1/2 WIN, TIE

            async void gameOver()
            {
                if (win == 1)
                {
                    result = await DisplayAlert("BLUE(2) player has won!", "Try again?", "Yes", "No");

                    if (result)
                    {
                        makeGameBoard();
                    }
                    else
                    {
                        System.Environment.Exit(0);
                    }

                }
                else if (win == 2)
                {
                    result = await DisplayAlert("RED(1) player has won!", "Try again?", "Yes", "No");

                    if (result)
                    {
                        makeGameBoard();
                    }
                    else
                    {
                        System.Environment.Exit(0);
                    }

                }
                else if (win == 3)
                {
                    result = await DisplayAlert("Friendship has won!", "Try again?", "Yes", "No");

                    if (result)
                    {
                        makeGameBoard();
                    }
                    else
                    {
                        System.Environment.Exit(0);
                    }
                }
            }
            // ** BUTTON **
            // CHOOSE PLAYER

            choosePlayer = new Button
            {
                Text = "Choose first player",
                BackgroundColor = Color.WhiteSmoke,
                TextColor = Color.Black
            };
            choosePlayer.Clicked += choosePlayer_Clicked;
            void newGame_Clicked(object sender, EventArgs e)
            {
                makeGameBoard();
            }

            void choosePlayer_Clicked(object sender, EventArgs e)
            {
                choosePlayerQ();
            }

            async void choosePlayerQ()
            {
                string result = await DisplayPromptAsync("Who is FIRST?", "1 - RED, 2 - BLUE", maxLength: 1, keyboard: Keyboard.Numeric);

                if (result == "2")
                {
                    first = true;
                    makeGameBoard();
                }
                else
                {
                    first = false;
                    makeGameBoard();
                }
            }
            // BOARD
            void makeGameBoard()
            {
                win = 0;
                gameBoard = new Grid();
                for (int i = 0; i < 3; i++)
                {
                    gameBoard.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    gameBoard.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                };

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        box = new BoxView { Color = Color.DarkGray, WidthRequest = 200, HeightRequest = 200 };
                        gameBoard.Children.Add(box, j, i);
                        TapGestureRecognizer tap = new TapGestureRecognizer();
                        tap.Tapped += Tap_Tapped; ;
                        box.GestureRecognizers.Add(tap);
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        T[i, j] = 0;
                    }
                }
                page_grid.Children.Add(gameBoard);
            }




            // CHANGE COLOR WHEN CLICK ON BOXVIEW 1 - RED, 2 - BLUE

            async void Tap_Tapped(object sender, EventArgs e)
            {
                var box = (BoxView)sender;
                var row = Grid.GetRow(box);
                var col = Grid.GetColumn(box);

                if (first)
                {
                    first = false;
                    box.Color = Color.Blue;
                    T[row, col] = 1;
                }
                else
                {
                    first = true;
                    box.Color = Color.Red;
                    T[row, col] = 2;
                }

                gameCheck();
                gameOver();
            }
            // ** BUTTON **
            // RULES
            gameRules = new Button
            {
                Text = "Rules",
                BackgroundColor = Color.WhiteSmoke,
                TextColor = Color.Black
            };
            gameRules.Clicked += gameRules_Clicked;


            StackLayout st = new StackLayout
            { Children = { headingLbl, page_grid, newGame, choosePlayer, gameRules } };
            Content = st;
        }



        private void gameRules_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TicTacToe_Rules());
        }
    }
}
