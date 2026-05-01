namespace MyUniversityAPIGateway.Domain;

public class Course {
    public Course() {
        Name = "";
        Description = "";
        Code = "";
        Year = 0;
        Semester = 0;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public int Semester { get; set; }
    public int Year { get; set; }
}