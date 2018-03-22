using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App1.Models
{
    public class MainPageModel
    {
        public MainPageModel()
        {
            this.AddPlayerCommand = new Command(AddPlayer);
        }

        public ObservableCollection<PlayerModel> Players { get; } = new ObservableCollection<PlayerModel>();


        public Command AddPlayerCommand { get; }

        void AddPlayer()
        {
            this.Players.Add(new PlayerModel
            {
                Name = "My New Player",
                HitPoints = 100,
                Armor = -12
            });
            
        }

    }
}
