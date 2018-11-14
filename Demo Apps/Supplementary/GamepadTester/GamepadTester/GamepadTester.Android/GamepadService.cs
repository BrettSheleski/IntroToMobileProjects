using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GamepadTester.Droid
{
    public class GamepadService : IGamepadService
    {

        public GamepadService()
        {

        }

        private static readonly Dictionary<int, GamepadModelWrapper> gamepads = new Dictionary<int, GamepadModelWrapper>();

        public IEnumerable<GamepadModel> GetGamepads()
        {
            int[] deviceIds = InputDevice.GetDeviceIds();

            List<GamepadModel> models = new List<GamepadModel>(deviceIds.Length);

            InputDevice device;
            GamepadModelWrapper wrapper;
            for(int i = 0; i < deviceIds.Length; ++i)
            {
                if (!gamepads.ContainsKey(deviceIds[i]))
                {
                    device = InputDevice.GetDevice(deviceIds[i]);

                    if ((device.Sources & InputSourceType.Gamepad) == InputSourceType.Gamepad)
                    {
                        wrapper = new GamepadModelWrapper(device);

                        gamepads.Add(deviceIds[i], wrapper);

                        models.Add(wrapper.GamepadModel);
                    }
                }
                else
                {
                    models.Add(gamepads[deviceIds[i]].GamepadModel);
                }
            }

            return models.ToArray();
        }

        

        class GamepadModelWrapper
        {
            readonly Dictionary<Axis, GamepadAxisModel> axisMap = new Dictionary<Axis, GamepadAxisModel>();

            public GamepadModelWrapper(InputDevice device)
            {
                this.Device = device;

                this.GamepadModel.Name = device.Name;

                GamepadAxisModel axis;
                
                foreach(var motionRange in device.MotionRanges)
                {
                    if (!axisMap.ContainsKey(motionRange.Axis))
                    {
                        axis = new GamepadAxisModel
                        {
                            Name = motionRange.Axis.ToString(),
                            Minimum = motionRange.Min,
                            Maximum = motionRange.Max
                        };

                        axisMap[motionRange.Axis] = axis;

                        this.GamepadModel.Axes.Add(axis);
                    }
                }

                

                
            }

            public GamepadModel GamepadModel { get; } = new GamepadModel();
            public InputDevice Device { get; }

            internal bool HandleMotionEvent(MotionEvent e)
            {
                if (e.DeviceId == this.Device.Id)
                {
                    switch (e.Action)
                    {
                        case MotionEventActions.ButtonPress:
                            return HandleButtonPress(e);
                        case MotionEventActions.Move:
                            return HandleAxisChange(e);
                    }

                }

                return false;
            }

            private bool HandleAxisChange(MotionEvent e)
            {

                foreach(var axis in axisMap.Keys)
                {
                    axisMap[axis].Value = e.GetAxisValue(axis);
                }

                return true;
            }

            private bool HandleButtonPress(MotionEvent e)
            {
                return false;
            }
        }

        public bool HandleMotionEvent(MotionEvent e)
        {
            if (gamepads.ContainsKey(e.DeviceId))
            {
                return gamepads[e.DeviceId].HandleMotionEvent(e);
            }

            return false;
        }
    }
}