using System;
namespace MyRunnerDemo
{
    public class RunCalculator
    {
        public RunCalculator()
        {
        }

        public TimeSpan Run1Time { get; set; }
        public double Run1Distance { get; set; }

        public TimeSpan Run2Time { get; set; }
        public double Run2Distance { get; set; }

        public TimeSpan Run3Time { get; set; }
        public double Run3Distance { get; set; }

        public TimeSpan TotalTime { get; private set; }
        public double TotalDistance { get; private set; }

        public double AverageSpeed { get; private set; }

        public void Update(){

            TotalTime = Run1Time + Run2Time + Run3Time;

            TotalDistance = Run1Distance + Run2Distance + Run3Distance;

            // D = R * T  -> R = D / T

            if (TotalTime > TimeSpan.Zero){
                AverageSpeed = TotalDistance / TotalTime.TotalHours;    
            }
            else{
                AverageSpeed = 0;
            }


        }
    }
}
