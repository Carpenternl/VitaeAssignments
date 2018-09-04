using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToeV2
{
    /// <summary>
    /// Interaction logic for GameField.xaml
    /// </summary>
    public partial class GameField : UserControl
    {
        Player2[] Players;
        int ActivePlayerIndex;
        int WinThreshold;



        public static int GetOwner(DependencyObject obj)
        {
            return (int)obj.GetValue(OwnerProperty);
        }

        public static void SetOwner(DependencyObject obj, int value)
        {
            obj.SetValue(OwnerProperty, value);
        }

        // Using a DependencyProperty as the backing store for Owner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.RegisterAttached("Owner", typeof(int), typeof(GameField), new PropertyMetadata(-1));



        public GameField()
        {
            InitializeComponent();
        }
        //Starts the game
        public void StartGame(Player2[] players, int fieldSize, int winThreshold)
        {
            CreateField(fieldSize);
            Players = players;
            Random Rand = new Random();
            WinThreshold = winThreshold;
            ActivePlayerIndex = Rand.Next(0, Players.Count());
        }

        internal void EndGame()
        {
            Container.Children.Clear();
            Container.RowDefinitions.Clear();
            Container.ColumnDefinitions.Clear();
        }

        private void CreateField(int fieldSize)
        {
            for (int i = 0; i < fieldSize; i++)
            {
                Container.ColumnDefinitions.Add(new ColumnDefinition());
                Container.RowDefinitions.Add(new RowDefinition());
            }
            PopulateField(fieldSize);
        }

        /// <summary>
        /// Fills the grid with buttons
        /// </summary>
        /// <param name="fieldSize"> The size of the field</param>
        private void PopulateField(int fieldSize)
        {
            for (int rIndex = 0; rIndex < fieldSize; rIndex++)
            {
                for (int cIndex = 0; cIndex < fieldSize; cIndex++)
                {
                    Container.Children.Add(NewFieldButton(rIndex, cIndex));
                }
            }
        }

        /// <summary>
        /// Create a new button for the grid
        /// </summary>
        /// <param name="x"> columnlocation</param>
        /// <param name="y"> rowlocation </param>
        /// <returns></returns>
        private Button NewFieldButton(int x, int y)
        {
            Button nButton = new Button();
            //Set Button Location
            Grid.SetColumn(nButton, x);
            Grid.SetRow(nButton, y);
            nButton.Click += FieldButtonClick;
            nButton.Background = new SolidColorBrush(Colors.Transparent);
            nButton.IsMouseDirectlyOverChanged += NButton_IsMouseDirectlyOverChanged;
            return nButton;
            ///throw new NotImplementedException();
        }

        private void NButton_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Button Caller = sender as Button;
            if (GetOwner(Caller)== -1)
            {
                Caller.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void FieldButtonClick(object sender, RoutedEventArgs e)
        {
            //Get the button that was clicked
            Button target = sender as Button;
            // Set the owner of the button
            SetOwner(target, Players[ActivePlayerIndex].ID);
            target.Background = new SolidColorBrush(Players[ActivePlayerIndex].PlayerColor);
            target.Click -= FieldButtonClick;
            bool WeHaveAWinner = CheckForWinner(target);
            if (WeHaveAWinner)
            {
                GameCompleted();
            }
            else
            {
                UpdateStatus();
            }
            // Remove its event (it can only be clicked once
        }

        private void UpdateStatus()
        {
            //set the next player
            ActivePlayerIndex = (ActivePlayerIndex + 1) % Players.Length;

            
        }

        private void GameCompleted()
        {
            Window WinnerShowCase = new Window();
            WinnerShowCase.SizeToContent = SizeToContent.WidthAndHeight;
            WinnerShowCase.Content = $"{Players[ActivePlayerIndex].ID} {Players[ActivePlayerIndex].PlayerName} Has WON!";
            WinnerShowCase.ShowDialog();
            EndGame();
           // throw new NotImplementedException();
        }

        private bool CheckForWinner(Button sender)
        {
            Button[] ButtonsinField = Container.Children.Cast<Button>().ToArray();

            int SenderY = Grid.GetRow(sender);
            int SenderX = Grid.GetColumn(sender);

            Button[] HorizontalLine = (from Buttons in ButtonsinField where Grid.GetRow(Buttons) == SenderY select Buttons).Cast<Button>().ToArray();
            Button[] VerticalLine = (from Buttons in ButtonsinField where Grid.GetColumn(Buttons) == SenderX select Buttons).Cast<Button>().ToArray();

            int b = SenderY - SenderX;
            Button[] DiagonalLineUp = (from buttons in ButtonsinField where Grid.GetRow(buttons) == Grid.GetColumn(buttons) + b select buttons).Cast<Button>().ToArray();

            b = SenderY + SenderX;
            Button[] DiagonalLineDown = (from buttons in ButtonsinField where Grid.GetRow(buttons) == -Grid.GetColumn(buttons) + b select buttons).Cast<Button>().ToArray();

            Button[][] LineColletion = { HorizontalLine, VerticalLine, DiagonalLineUp, DiagonalLineDown };

            int HighScore = 0;
            for (int row = 0; row < LineColletion.Length; row++)
            {
                //Get the longest row in each line, horizontal, vertical, diagonal1 and diagonal2
                HighScore = Math.Max(HighScore, GetMaxScore(LineColletion[row]));
                if (HighScore >= WinThreshold)
                {
                    return true;
                }
            }
            return false;

        }

        private int GetMaxScore(Button[] line)
        {
            int maxScore = 0;
            int score = 0;
            foreach (var item in line)
            {

                int owner = GetOwner(item);
                if (owner == Players[ActivePlayerIndex].ID)
                {
                    score++;
                }
                else
                {
                    score = 0;
                }
                maxScore = Math.Max(maxScore, score);
            }
            return maxScore;
        }
    }
}
