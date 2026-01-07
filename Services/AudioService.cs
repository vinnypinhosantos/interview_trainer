using System.Speech.Synthesis;

namespace InterviewTrainer.Services;

public class AudioService
{
    private readonly SpeechSynthesizer _synthesizer;

    public AudioService()
    {
        _synthesizer = new SpeechSynthesizer();
        _synthesizer.SetOutputToDefaultAudioDevice();
        _synthesizer.Rate = 0; // Normal speed
        _synthesizer.Volume = 100; // Max volume
    }

    public void Speak(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return;
                
        _synthesizer.Speak(text);
    }
}
