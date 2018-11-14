using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GamepadTester
{
    public class GamepadModel : ModelBase
    {
        private string _name;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

        public ObservableCollection<GamepadAxisModel> Axes { get; } = new ObservableCollection<GamepadAxisModel>();
        public ObservableCollection<GamepadButtonModel> Buttons { get; } = new ObservableCollection<GamepadButtonModel>();
    }

    public class GamepadAxisModel : ModelBase
    {
        private float _value, _minimum, _maximum;
        private string _name;

        public float Value { get => _value; set { _value = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public float Minimum { get => _minimum; set { _minimum = value; OnPropertyChanged(); } }
        public float Maximum { get => _maximum; set { _maximum = value; OnPropertyChanged(); } }
    }

    public class GamepadButtonModel : ModelBase
    {
        private string _name;
        private bool _isPressed;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public bool IsPressed { get => _isPressed; set { _isPressed = value; OnPropertyChanged(); } }


    }

    public interface IGamepadService
    {
        IEnumerable<GamepadModel> GetGamepads();
    }
}
