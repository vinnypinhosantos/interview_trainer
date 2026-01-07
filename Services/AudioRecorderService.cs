using System;
using NAudio.Wave;
using System.Threading;

namespace InterviewTrainer.Services;

public class AudioRecorderService
{
    public async Task RecordAsync(
        int questionId,
        int maxSeconds,
        CancellationToken cancellationToken)
    {

        var outputPath = $"Output/answer_{questionId}.wav";

        using var waveIn = new WaveInEvent();
        using var writer = new WaveFileWriter(outputPath, waveIn.WaveFormat);

        waveIn.DataAvailable += (s, e) =>
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                writer.Write(e.Buffer, 0, e.BytesRecorded);
            }
        };

        waveIn.StartRecording();
        Console.WriteLine("🎙️ Recording... Press Enter to stop early.");

        try
        {
            await Task.Delay(TimeSpan.FromSeconds(maxSeconds), cancellationToken);
        }
        catch (TaskCanceledException)
        {
            // esperado quando o usuário interrompe
        }

        waveIn.StopRecording();

        Console.WriteLine($"🛑 Recording saved to {outputPath}");
    }
}
