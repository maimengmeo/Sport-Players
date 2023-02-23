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

namespace MTTuyetMaiPham
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> players;
        List<Player> selectedPlayers = new List<Player>();
        ViewPlayersWindow playersWindow;
        public MainWindow()
        {
            InitializeComponent();
            players = new List<Player>
                        { new HockeyPlayer(PlayerType.HockeyPlayer, 1, "Cleo Doggo", "Maple Leafs", 12, 2,3),
                        new HockeyPlayer(PlayerType.HockeyPlayer, 2, "Tweety Bird", "Maple Leafs", 23, 4, 5),
                        new HockeyPlayer(PlayerType.HockeyPlayer, 3, "Bugs Bunny", "Boston Bruins", 121, 2,3),
                        new HockeyPlayer(PlayerType.HockeyPlayer, 4, "Daffy Duck", "Boston Bruins", 112, 12, 23),
                        new HockeyPlayer(PlayerType.HockeyPlayer, 5, "Mickey Mouse", "Vancouver Canucks", 142, 24,36),
                        new BasketballPlayer(PlayerType.BasketballPlayer, 6, "Kitty Cat", "Raptors", 2, 23, 12),
                        new BasketballPlayer(PlayerType.BasketballPlayer, 7, "Donald Duck", "Raptors", 21, 27, 62),
                        new BasketballPlayer(PlayerType.BasketballPlayer, 8, "Winnie Pooh", "Lakers", 112, 213, 142),
                        new BasketballPlayer(PlayerType.BasketballPlayer, 9, "Pink Panther", "Lakers", 62, 56, 77),
                        new BasketballPlayer(PlayerType.BasketballPlayer, 10, "Porky Pig", "Warriors", 2, 23, 12),
                        new BaseballPlayer(PlayerType.BaseballPlayer, 11, "Road Runner", "Blue Jays", 23, 34, 45),
                        new BaseballPlayer(PlayerType.BaseballPlayer, 12, "SpongeBob", "Blue Jays", 56, 67, 78),
                        new BaseballPlayer(PlayerType.BaseballPlayer, 13, "Garfiled", "Mets", 89, 98, 87),
                        new BaseballPlayer(PlayerType.BaseballPlayer, 14, "Simba", "Mets", 76, 65, 54),
                        new BaseballPlayer(PlayerType.BaseballPlayer, 15, "Minnie Mouse", "Dodgers", 43, 32, 21)};

            

        }

        private void Show_Player_Window()
        {
            playersWindow.Owner = this;
            playersWindow.ShowDialog();
        }

        private void btnViewHockey_Click(object sender, RoutedEventArgs e)
        {
            var hockeyPlayers = from hockeyPlayer in players where (hockeyPlayer.PlayerType == PlayerType.HockeyPlayer) select hockeyPlayer;

            selectedPlayers.Clear();
            selectedPlayers.AddRange(hockeyPlayers);
            
            playersWindow = new ViewPlayersWindow(selectedPlayers, players);
            playersWindow.lblToChange1.Content = "Assists";
            playersWindow.lblToChange2.Content = "Goals";

            Show_Player_Window();
        }

        private void btnViewBasketball_Click(object sender, RoutedEventArgs e)
        {
            var basketballPlayers = from basketballPlayer in players where (basketballPlayer.PlayerType == PlayerType.BasketballPlayer) select basketballPlayer;

            selectedPlayers.Clear();
            selectedPlayers.AddRange(basketballPlayers);

            playersWindow = new ViewPlayersWindow(selectedPlayers, players);
            playersWindow.lblToChange1.Content = "Field Goals";
            playersWindow.lblToChange2.Content = "Three Pointers";

            Show_Player_Window();
        }

        private void btnViewBaseball_Click(object sender, RoutedEventArgs e)
        {
            var baseballPlayers = from baseballPlayer in players where (baseballPlayer.PlayerType == PlayerType.BaseballPlayer) select baseballPlayer;

            selectedPlayers.Clear();
            selectedPlayers.AddRange(baseballPlayers);

            playersWindow = new ViewPlayersWindow(selectedPlayers, players);
            playersWindow.lblToChange1.Content = "Runs";
            playersWindow.lblToChange2.Content = "Home Runs";

            Show_Player_Window();
        }

        private void UpdatePlayersList(List<Player> updatedPlayers)
        {
            players = updatedPlayers;
        }
    }
}
