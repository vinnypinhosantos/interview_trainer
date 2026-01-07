using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using InterviewTrainer.Domain;

namespace InterviewTrainer.Readers;

public class JsonQuestionsReader
{
    public List<Question> Read(string path)
    {
        var json = File.ReadAllText(path);

        var wrapper = JsonSerializer.Deserialize<QuestionWrapper>(json);
        Console.WriteLine("Deserialized JSON:");
        Console.WriteLine(wrapper.Questions.Count + " questions loaded.");
        return wrapper?.Questions ?? new();
    }

    private class QuestionWrapper
    {
        [JsonPropertyName("questions")]
        public List<Question> Questions { get; set; } = new();
    }
}
