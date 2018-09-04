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

        #region Properties
        Player2[] Players;
        public int ActivePlayerIndex;
        int WinThreshold;
        #endregion
        #region DpProperties
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
        #endregion
        #region events
        public delegate void gameStartedHandler(object Sender, EventArgs e);
        public event gameStartedHandler GameStarted;

        public delegate void GameEndedHandler(object sender, EventArgs e);
        public event GameEndedHandler GameEnded;

        public delegate void GameUpdatedHandler(object sender, EventArgs e);
        public event GameUpdatedHandler GameUpdated;
        #endregion

        #region GameplayFlow
        //Start the game
        public void SetUpGame(Player2[] players, int fieldSize, int winthreshold)
        {
            CreateField(fieldSize);
            Players = players;
            ActivePlayerIndex = RandomPlayerStart(players.Length);
            WinThreshold = winthreshold;
            GameStarted(this, new EventArgs());
        }

        //Update the game when a player clicks a button
        public void UpdateGameState(Point ClickPosition)
        {
            if (FindWinner(ClickPosition))
            {
                FinishGame();
            }
            else
            {
                ActivePlayerIndex = (ActivePlayerIndex + 1) % Players.Length;
                GameUpdated(this, new EventArgs());
            }
        }

        private void FinishGame()
        {
            Window WinnerShowCase = new Window();
            WinnerShowCase.SizeToContent = SizeToContent.WidthAndHeight;
            WinnerShowCase.Content = $"{Players[ActivePlayerIndex].ID} {Players[ActivePlayerIndex].PlayerName} Has WON!";
            WinnerShowCase.ShowDialog();
            BeginendGame();
        }

        public void BeginendGame()
        {
            Players = null;
            Container.Children.Clear();
            Container.RowDefinitions.Clear();
            Container.ColumnDefinitions.Clear();
            GameEnded(this, new EventArgs());
        }
        #endregion


        public GameField()
        {
            InitializeComponent();
            GameStarted += GameField_GameStarted;
            GameUpdated += GameField_GameUpdated;
            GameEnded += GameField_GameEnded;
        }
        #region EventHandlers
        private void GameField_GameEnded(object sender, EventArgs e)
        {
            // Do nothing
        }

        private void GameField_GameStarted(object Sender, EventArgs e)
        {
            // Do nothing
            UpdateGameState(new Point(-1, -1));
        }

        private void GameField_GameUpdated(object sender, EventArgs e)
        {
           // Do nothing
        }
        #endregion
        //Starts the game
        public void StartGame(Player2[] players, int fieldSize, int winThreshold)
        {
            CreateField(fieldSize);
            Players = players;
            Random Rand = new Random();
            WinThreshold = winThreshold;
            ActivePlayerIndex = Rand.Next(0, Players.Count());
        }

        #region findwinner
        private bool FindWinner(Point pos)
        {
            Button[] ButtonsinField = Container.Children.Cast<Button>().ToArray();

            Button[] HorizontalLine = (from Aligned in ButtonsinField where Grid.GetRow(Aligned) == pos.X select Aligned).Cast<Button>().ToArray();
            Button[] VerticalLine = (from Buttons in ButtonsinField where Grid.GetColumn(Buttons) == pos.Y select Buttons).Cast<Button>().ToArray();

            int b = (int)(pos.Y - pos.X);
            Button[] DiagonalLineUp = (from buttons in ButtonsinField where Grid.GetRow(buttons) == Grid.GetColumn(buttons) + b select buttons).Cast<Button>().ToArray();

            b = (int)(pos.Y + pos.X);
            Button[] DiagonalLineDown = (from buttons in ButtonsinField where Grid.GetRow(buttons) == -Grid.GetColumn(buttons) + b select buttons).Cast<Button>().ToArray();

            Button[][] LineColletion = { HorizontalLine, VerticalLine, DiagonalLineUp, DiagonalLineDown };
            bool Lengthfound = FindWinningLine(LineColletion);
            return Lengthfound;
        }

        private bool FindWinningLine(Button[][] lineColletion)
        {

            foreach (var Line in lineColletion)
            {
                if (CanWin(Line))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CanWin(Button[] line)
        {
            int Score = 0;
            foreach (var item in line)
            {
                int owns = GetOwner(item);
                if (Players[ActivePlayerIndex].ID == owns)
                {
                    Score++;
                    if (Score >= WinThreshold)
                    {
                        return true;
                    }
                }
                else
                {
                    Score = 0;
                }
            }
            return false;

        }
        #endregion

        internal void EndGame()
        {
            Container.Children.Clear();
            Container.RowDefinitions.Clear();
            Container.ColumnDefinitions.Clear();
        }
        #region FieldMethods

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
            Grid.SetColumn(nButton, x);
            Grid.SetRow(nButton, y);
            nButton.Click += OnPlayerMove;
            nButton.Background = new SolidColorBrush(Colors.Transparent);
            // TODO change MouseOver Color
            return nButton;

        }
        #endregion

        /// <summary>
        /// Occurs whenever a player clicks a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPlayerMove(object sender, RoutedEventArgs e)
        {
            //Get the button that was clicked
            Button Caller = sender as Button;
            // Set the owner of the button
            SetOwner(Caller, Players[ActivePlayerIndex].ID);
            Caller.Background = new SolidColorBrush(Players[ActivePlayerIndex].PlayerColor);
            Caller.Click -= OnPlayerMove;
            Point CallerLoc = new Point(Grid.GetColumn(Caller), Grid.GetRow(Caller));
            UpdateGameState(CallerLoc);
            // Remove its event (it can only be clicked once
        }
        private int RandomPlayerStart(int total)
        {
            Random rand = new Random();
            int result = rand.Next(total);
            return result;
        }
    }
}
