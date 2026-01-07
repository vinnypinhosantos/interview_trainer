using System;
using System.Text.Json.Serialization;

namespace InterviewTrainer.Domain;

public class Question
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}
