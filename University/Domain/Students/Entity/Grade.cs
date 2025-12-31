using University.Infra;

namespace University.Domain.Students.Entity;

internal class Grade : Entity<Guid>
{
    internal Grade(Guid lessonId, int score)
    {
        if (lessonId == Guid.Empty)
            throw new ArgumentException("LessonId cannot be empty.", nameof(lessonId));

        if (score < 0 || score > 100)
            throw new ArgumentException("Score must be between 0 and 100.", nameof(score));

        LessonId = lessonId;
        Score = score;
    }

    public Guid LessonId { get; private set; }
    public int Score { get; }
    public int? ResitScore { get; private set; }
    public int FinalScore => ResitScore.HasValue && ResitScore > Score ? ResitScore.Value : Score;

    public void AddResitGrade(int resitScore)
    {
        if (resitScore < 0 || resitScore > 100)
            throw new ArgumentException("Score must be 0-100");

        if (ResitScore.HasValue)
            throw new InvalidOperationException("Resit grade already exists.");

        ResitScore = resitScore;
    }
}