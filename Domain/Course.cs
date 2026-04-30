namespace MyUniversityAPIGateway.Domain;

public class Course {
    public Course() {
        Name = "";
        Description = "";
        Code = "";
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
}