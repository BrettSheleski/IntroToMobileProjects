using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioToolbox;
using AVFoundation;
using Foundation;
using UIKit;

namespace UndehydrationCalculator.iOS
{
    public class IosAudioPlayer : IAudioPlayer
    {
        public void Play(string path)
        {
            NSUrl url = NSUrl.FromFilename("Sounds/tap.aif");
            SystemSound systemSound = new SystemSound(url);

            systemSound.PlaySystemSound();

        }
    }
}