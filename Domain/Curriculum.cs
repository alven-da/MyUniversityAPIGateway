namespace MyUniversityAPIGateway.Domain;

public class Curriculum {
    public string StudentId { get; set; }
    public List<Subject> Subjects { get; set; }
}