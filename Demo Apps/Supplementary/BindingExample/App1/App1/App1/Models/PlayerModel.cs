using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App1.Models
{
    public class PlayerModel : INotifyPropertyChanged
    {
        public PlayerModel()
        {
            this.AddArmorCommand = new Command(IncrementArmor);
            this.RemoveArmorCommand = new Command(DecrementArmor);

            this.AddHitPointsCommand = new Command(IncrementHitPoints);
            this.RemoveHitPointsCommand = new Command(DecrementHitPoints);
        }

        private string _name;
        private int _hitPoints, _armor;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged();
            }
        }

        public int Armor
        {
            get { return _armor; }
            set
            {
                _armor = value;
                OnPropertyChanged();
            }
        }
        
        public Command AddHitPointsCommand { get; }
        public Command RemoveHitPointsCommand { get; }
        public Command AddArmorCommand { get; }
        public Command RemoveArmorCommand { get; }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void IncrementHitPoints()
        {
            this.HitPoints++;
        }

        void DecrementHitPoints()
        {
            this.HitPoints--;
        }

        void IncrementArmor()
        {
            this.Armor++;
        }

        void DecrementArmor()
        {
            this.Armor--;
        }
    }
}
