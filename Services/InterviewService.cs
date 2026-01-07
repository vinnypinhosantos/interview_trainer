using System;
using InterviewTrainer.Domain;

namespace InterviewTrainer.Services;

public class InterviewService
{
    private readonly AudioRecorderService _recorder;
    private readonly AudioService _audioService = new AudioService();

    public InterviewService(AudioRecorderService recorder)
    {
        _recorder = recorder;
    }

    public async Task StartAsync(List<Question> questions)
    {
        foreach (var question in questions)
        {
            Console.Clear();
            Console.WriteLine($"Question: {question.Id}");
            Console.WriteLine(question.Text);
            Console.WriteLine("\n Hearing question...\n");

            _audioService.Speak(question.Text);

            Console.WriteLine($"You have 60 seconds to answer. Press Enter to start recording...");
            Console.ReadLine();
            Console.WriteLine("Recording... Press Enter to stop early.\n");
            using var cts = new CancellationTokenSource();

            var recordTask = _recorder.RecordAsync(
                question.Id,
                60,
                cts.Token
            );

            var stopTask = Task.Run(() =>
            {
                Console.ReadLine();
                cts.Cancel();
            });

            await Task.WhenAny(recordTask, stopTask);
        }
        Console.WriteLine("\nInterview session completed.");
    }

}
