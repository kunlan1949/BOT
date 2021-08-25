using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Media;

namespace BOT.Actions
{
    class SpeakAction
    {
        public void Speak()
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Configure the audio output.   
                synth.SetOutputToWaveFile(AppDomain.CurrentDomain.BaseDirectory + @"\T.wav",
                  new SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Stereo));

                // Create a SoundPlayer instance to play output audio file.  
                SoundPlayer m_SoundPlayer =
                  new(AppDomain.CurrentDomain.BaseDirectory + @"\T.wav");

                // Build a prompt.  
                PromptBuilder builder = new PromptBuilder();
                builder.AppendText("我看你就是个傻逼");

                // Speak the prompt.  
                synth.Speak(builder);
                m_SoundPlayer.Play();
            }
        }
    }
}
