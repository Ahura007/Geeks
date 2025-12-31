using University.Infra;

namespace University.Domain.Students.Entity;

internal class Grade : Entity<int>
{
    internal Grade(Guid lessonId, int score)
    {
        LessonId = lessonId;
        Score = score;
    }

    public Guid LessonId { get; }
    public int Score { get; }
    public int? ResitScore { get; private set; }
    public int FinalScore => ResitScore.HasValue && ResitScore > Score ? ResitScore.Value : Score;

    public void AddResitGrade(int resitScore)
    {
        if (resitScore < 0 || resitScore > 100)
            throw new ArgumentException("Score must be 0-100");

        ResitScore = resitScore;
    }
}