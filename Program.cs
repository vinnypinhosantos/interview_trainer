using InterviewTrainer.Readers;
using InterviewTrainer.Services;

Console.WriteLine("Welcome to the Interview Trainer!");

var reader = new JsonQuestionsReader();
var questions = reader.Read("Data/questions.json");

var recorder = new AudioRecorderService();
var interview = new InterviewService(recorder);

await interview.StartAsync(questions);
