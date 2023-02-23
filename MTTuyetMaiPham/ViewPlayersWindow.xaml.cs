using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MTTuyetMaiPham
{
    /// <summary>
    /// Interaction logic for ViewPlayersWindow.xaml
    /// </summary>
    public partial class ViewPlayersWindow : Window
    {
        private List<Player> _selectedPlayers;
        private List<Player> allPlayers;

        public ViewPlayersWindow(List<Player> selectedPlayers, List<Player> players)
        {
            InitializeComponent();
            lstPlayers.ItemsSource = null;
            _selectedPlayers = selectedPlayers;
            allPlayers = players;

            PlayerType type = _selectedPlayers[0].PlayerType;

            switch(type)
            {
                case PlayerType.HockeyPlayer:
                    this.Title = "View Hockey Players";
                    break;
                case PlayerType.BasketballPlayer:
                    this.Title = "View Baskketball Players";
                    break;
                case PlayerType.BaseballPlayer:
                    this.Title = "View Baseball Players";
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            var names = from player in _selectedPlayers select player.PlayerName;
            lstPlayers.ItemsSource = null;
            lstPlayers.ItemsSource = names;
        }

        private void lstPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstPlayers.SelectedIndex == -1)
            { return; }

            Player player = _selectedPlayers[lstPlayers.SelectedIndex];

            txtId.Text = player.PlayerId.ToString();
            txtName.Text = player.PlayerName;
            txtTeam.Text = player.TeamName;
            txtGames.Text = player.GamesPlayed.ToString();
            txtPoints.Text = player.Points().ToString();

            switch(player.PlayerType)
            {
                case PlayerType.HockeyPlayer:
                    HockeyPlayer hockeyPlayer = (HockeyPlayer)player;
                    txtOptional1.Text = hockeyPlayer.Assists.ToString();
                    txtOptional2.Text = hockeyPlayer.Goals.ToString();
                    break;
                case PlayerType.BasketballPlayer:
                    BasketballPlayer basketballPlayer = (BasketballPlayer)player;
                    txtOptional1.Text = basketballPlayer.FieldGoals.ToString();
                    txtOptional2.Text = basketballPlayer.ThreePointers.ToString();
                    break;
                case PlayerType.BaseballPlayer:
                    BaseballPlayer baseballPlayer = (BaseballPlayer)player;
                    txtOptional1.Text = baseballPlayer.Runs.ToString();
                    txtOptional2.Text = baseballPlayer.HomeRuns.ToString();
                    break;
                default:
                    break;
            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            Player newPlayer = null;

            int id = 1;
            if (allPlayers.Count() > 0)
            {
                id = allPlayers.Last().PlayerId + 1;
            }

            string name = txtName.Text;
            string team = txtTeam.Text;

            int games;
            bool success1 = int.TryParse(txtGames.Text, out games);
            int op1;
            bool success2 = int.TryParse(txtOptional1.Text, out op1);
            int op2;
            bool success3 = int.TryParse(txtOptional2.Text, out op2);

            if (!success1 || !success2 || !success3)
            {
                MessageBox.Show("Incorrect input. Try Again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name == "" || name == null || team == "" || team == null)
            {
                MessageBox.Show("Missing input. Try Again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                PlayerType type = _selectedPlayers[0].PlayerType;

                switch (type)
                {
                    case PlayerType.HockeyPlayer:
                        newPlayer = new HockeyPlayer(PlayerType.HockeyPlayer, id, name, team, games, op1, op2);
                        break;
                    case PlayerType.BasketballPlayer:
                        newPlayer = new BasketballPlayer(PlayerType.BasketballPlayer, id, name, team, games, op1, op2);
                        break;
                    case PlayerType.BaseballPlayer:
                        newPlayer = new BaseballPlayer(PlayerType.BaseballPlayer, id, name, team, games, op1, op2);
                        break;
                    default:
                        break;
                }
            }

            if(newPlayer != null)
            {
                allPlayers.Add(newPlayer);
                _selectedPlayers.Add(newPlayer);
                RefreshListBox();
                MessageBox.Show("Player is Added!", "Add Player", MessageBoxButton.OK, MessageBoxImage.Information);               
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {           
            Player playerToEdit = findPlayer(allPlayers, lstPlayers);
            if (playerToEdit != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to edit this player information?", "Edit Player", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    playerToEdit.PlayerName = txtName.Text;
                    playerToEdit.TeamName = txtTeam.Text;
                    int games, op1, op2;
                    bool success1 = int.TryParse(txtGames.Text, out games);
                    bool success2 = int.TryParse(txtOptional1.Text, out op1);
                    bool success3 = int.TryParse(txtOptional2.Text, out op2);
                    if (success1 && success2 && success3)
                    {
                        playerToEdit.GamesPlayed = games;

                        PlayerType type = _selectedPlayers[0].PlayerType;

                        switch (type)
                        {
                            case PlayerType.HockeyPlayer:
                                HockeyPlayer hockeyPlayer = (HockeyPlayer)playerToEdit;
                                hockeyPlayer.Assists = op1;
                                hockeyPlayer.Goals = op2;

                                break;
                            case PlayerType.BasketballPlayer:
                                BasketballPlayer basketballPlayer = (BasketballPlayer)playerToEdit;
                                basketballPlayer.FieldGoals = op1;
                                basketballPlayer.ThreePointers = op2;

                                break;
                            case PlayerType.BaseballPlayer:
                                BaseballPlayer baseballPlayer = (BaseballPlayer)playerToEdit;
                                baseballPlayer.Runs = op1;
                                baseballPlayer.HomeRuns = op2;

                                break;
                        }

                        RefreshListBox();

                        MessageBox.Show("Player is Edited!", "Edit Player", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect input. Try Again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            Player playerToDelete = findPlayer(allPlayers, lstPlayers);

            if (playerToDelete != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete this player information?", "Edit Player", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    allPlayers.Remove(playerToDelete);
                    _selectedPlayers.Remove(playerToDelete);
                    txtId.Text = txtName.Text = txtTeam.Text = txtGames.Text = txtOptional1.Text = txtOptional2.Text = txtPoints.Text = "";

                    RefreshListBox();
                  
                    MessageBox.Show("Player is Deleted!", "Delete Player", MessageBoxButton.OK, MessageBoxImage.Information);
                }               
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = txtName.Text = txtTeam.Text = txtGames.Text = txtOptional1.Text = txtOptional2.Text = txtPoints.Text = "";
        }

        private Player findPlayer(List<Player> players, ListBox box)
        {
            Player player = null;
            string name = box.SelectedItem as string;

            if(name!= null)
            {
                foreach(Player p in players)
                {
                    if(p.PlayerName == name)
                    {
                        player = p;
                        break;
                    }
                }
            }
            return player;
        }

        
    }
}
