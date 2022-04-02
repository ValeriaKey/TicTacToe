using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicTacToe_Rules : ContentPage
    {
        Label headingRules, textRules;
        Frame frame;
        Image image;
        public TicTacToe_Rules()
        {
            // HEADING

            headingRules = new Label
            {
                Text = "Tic Tac Toe - Rules",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
                TextDecorations = TextDecorations.Underline,
                FontSize = 20
            };
            // TEXT / RULES
            textRules = new Label
            {
                Text = "1. The game is played on a grid that's 3 squares by 3 squares. 2. You are X, your friend (or the computer in this case) is O. Players take turns putting their marks in empty squares. 3. The first player to get 3 of her marks in a row (up, down, across, or diagonally) is the winner. 4. When all 9 squares are full, the game is over. If no player has 3 marks in a row, the game ends in a tie.",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
                FontSize = 20
            };
            image = new Image
            {
                Source = "ttt.png"
            };
            frame = new Frame
            {
                Content = textRules,
                BorderColor = Color.FromRgb(20, 120, 255),
                CornerRadius = 20,
            };

            StackLayout st = new StackLayout
            {
                Children = { headingRules, image, frame }
            };

            Content = st;
        }
    }
}