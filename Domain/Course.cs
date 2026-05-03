namespace MyUniversityAPIGateway.Domain;

public class Course {
    public Course() {
        Id = "";
        Description = "";
        Code = "";
    }

    public string Id { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
}