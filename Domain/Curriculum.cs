namespace MyUniversityAPIGateway.Domain;

public class Curriculum {
    public Curriculum() {
        StudentId = "";
        Subjects = [];
    }

    public string StudentId { get; set; }
    public List<Subject> Subjects { get; set; }
}