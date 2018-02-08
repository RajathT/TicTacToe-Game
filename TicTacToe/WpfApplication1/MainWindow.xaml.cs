using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        /// <summary>
        /// Array to represent the state of every cell of the game.
        /// </summary>
        private MarkType[] mResults;
        /// <summary>
        /// True: Player 1 chance(X) ? Player 2 chance(O)
        /// </summary>
        private bool mPlayer1;
        /// <summary>
        /// True :Game Ended
        /// </summary>
        private bool mGameResult;
        #endregion
        #region Default Constuctor
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        #endregion
        #region New Game
        /// <summary>
        /// Starts a new game and resets the buttons
        /// </summary>
        private void NewGame() {
            mResults = new MarkType[9];
            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            mPlayer1 = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            }
            );
            mGameResult = false;
        }
        #endregion
        /// <summary>
        /// OnClick Funtion
        /// </summary>
        /// <param name="sender">Button the will get Clicked</param>
        /// <param name="e">Event that will get called</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameResult)
            {
                NewGame();
                return;
            }
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + row * 3;

            if (mResults[index] != MarkType.Free)
                return;
            mResults[index] = mPlayer1 ? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayer1 ? 'X' : 'O';

            if (!mPlayer1)
                button.Foreground = Brushes.Red; 

            mPlayer1 ^= true;

            checkWinner();

        }
        private void checkWinner()
        {
            if (!mResults.Any(result => result == MarkType.Free))
            {
                mGameResult = true;
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
            if(mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameResult = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameResult = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameResult = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameResult = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameResult = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameResult = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameResult = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[02])
            {
                mGameResult = true;
                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
            }
        }
    }
}
