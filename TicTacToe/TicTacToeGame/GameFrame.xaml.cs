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

namespace TicTacToeGame
{
    /// <summary>
    /// Interaction logic for GameFrame.xaml
    /// </summary>
    public partial class GameFrame : UserControl
    {
        /// <summary>
        /// The Size of the field in rows and Collumns
        /// </summary>
        public int FieldSize
        {
            get { return (int)GetValue(FieldSizeProperty); }
            set { SetValue(FieldSizeProperty, value); }
        }
        /// <summary>
        /// The Lenght that is needed to win
        /// </summary>
        public int ScoreToWin
        {
            get { return (int)GetValue(ScoreToWinProperty); }
            set { SetValue(ScoreToWinProperty, value); }
        }

        #region DependencyProperties
        // Using a DependencyProperty as the backing store for ScoreToWin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScoreToWinProperty =
            DependencyProperty.Register("ScoreToWin", typeof(int), typeof(GameFrame), new PropertyMetadata(3));



        // Using a DependencyProperty as the backing store for FieldSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FieldSizeProperty =
            DependencyProperty.Register("FieldSize", typeof(int), typeof(GameFrame), new PropertyMetadata(3));


        #endregion

        public static int GetOwner(DependencyObject obj)
        {
            return (int)obj.GetValue(OwnerProperty);
        }

        public static void SetOwner(DependencyObject obj, int value)
        {
            obj.SetValue(OwnerProperty, value);
        }

        // Using a DependencyProperty as the backing store for Team.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.RegisterAttached("Owner", typeof(int), typeof(GameFrame), new PropertyMetadata(0));




        private Player[] players;

        public Player[] Players
        {
            get { return players; }
            set { players = value; }
        }
        public int ActivePlayerID { get; set; }

        public GameFrame()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Start The game
        /// </summary>
        /// <param name="fieldSize"></param>
        /// <param name="scoreToWin"></param>
        /// <param name="players"></param>
        /// <param name="StartingPlayerID"></param>
        public void StartGame(int fieldSize, int scoreToWin, Player[] players)
        {
            SetupGrid(fieldSize);
            ScoreToWin = scoreToWin;
            Players = players;
            ActivePlayerID = Players[new Random().Next(Players.Length)].PlayerID;
        }

        private void SetupGrid(int fieldSize)
        {
            FieldContainer.ColumnDefinitions.Clear();
            FieldContainer.RowDefinitions.Clear();
            for (int count = 0; count < fieldSize; count++)
            {
                FieldContainer.ColumnDefinitions.Add(new ColumnDefinition());
                FieldContainer.RowDefinitions.Add(new RowDefinition());
            }
            FieldContainer.Children.Clear();
            Populate(fieldSize);
        }

        private void Populate(int fieldSize)
        {
            for (int Row = 0; Row < fieldSize; Row++)
            {
                for (int Column = 0; Column < fieldSize; Column++)
                {
                    FieldContainer.Children.Add(MyButton(Column, Row));
                }
            }
        }

        private UIElement MyButton(int column, int row)
        {
            Button Result = new Button();
            Grid.SetRow(Result, row);
            Grid.SetColumn(Result, column);
            Result.Click += Square_click;
            return Result;
           // throw new NotImplementedException();
        }

        private void Square_click(object sender, RoutedEventArgs e)
        {
            //The Button that Was Clicked
            Button Caller = sender as Button;
            //check IF the Button has NO OWNER
            if (GetOwner(Caller) == 0)
            {
                //Set The Owner
                SetOwner(Caller, ActivePlayerID);
                //Change The Color Of the Caller Based upon the Player
                Player Owner = GetPlayer(ActivePlayerID);
                //Get The Location of the Button (Based off of grid)
                Point CallerLocation = new Point(Grid.GetColumn(Caller), Grid.GetRow(Caller));
                Button[] AllButtons = new Button[FieldContainer.Children.Count];
                FieldContainer.Children.CopyTo(AllButtons,0);
                IEnumerable<Button> Hori = from Button in AllButtons where Grid.GetRow(Button) == CallerLocation.Y select Button ;
                IEnumerable<Button> Vert = from Button in AllButtons where Grid.GetColumn(Button) == CallerLocation.X select Button;
                int b = (int)( CallerLocation.X - CallerLocation.Y);
                int negB = (int)(CallerLocation.X + CallerLocation.Y);
                IEnumerable<Button> Dia_Up = from Button in AllButtons where Grid.GetRow(Button) == Grid.GetColumn(Button) + b select Button;
                IEnumerable<Button> Dia_Down = from Button in AllButtons where Grid.GetRow(Button) == Grid.GetColumn(Button)*-1 + negB select Button;
                int maxscore = GetMaxScore(Hori, Vert, Dia_Up, Dia_Down, ActivePlayerID);
                if (maxscore >= ScoreToWin)
                {
                    SetWinner(Owner);
                    return;
                }
                Caller.Background = new SolidColorBrush(Owner.PlayerColor);
                //set the next Active Player
                ActivePlayerID = players[(players.ToList().IndexOf(Owner) + 1) % players.Length].PlayerID;
            }
            
            Grid.GetRow(Caller);
        }

        private int GetMaxScore(IEnumerable<Button> hori, IEnumerable<Button> vert, IEnumerable<Button> dia_Up, IEnumerable<Button> dia_Down, int activePlayerID)
        {
            int result = Math.Max(getScore(hori.ToArray(), activePlayerID), Math.Max(getScore(vert.ToArray(), activePlayerID), Math.Max(getScore(dia_Up.ToArray(), activePlayerID), getScore(dia_Up.ToArray(), activePlayerID))));
            return result;
        }

        public int getScore(Button[] buttons,int playerid)
        {
            int MaxScore = 0;
            int CurrentScore = 0;
            foreach (var item in buttons)
            {
                if (GetOwner(item) == playerid)
                {
                    CurrentScore++;
                    MaxScore = Math.Max(MaxScore, CurrentScore);
                }
                else
                {
                    CurrentScore = 0;
                }
            }
            return MaxScore;
        }

        private void SetWinner(Player owner)
        {
            Window f = new Window();
            f.Content = $"{owner.PlayerName} Has won!";
            f.ShowDialog();
            FieldContainer.Children.Clear();
            FieldContainer.ColumnDefinitions.Clear();
            FieldContainer.RowDefinitions.Clear();
        }

        private Player GetPlayer(int activePlayerID)
        {
            return players.Where(x => x.PlayerID == activePlayerID).ToArray()[0];
        }
    }
}
