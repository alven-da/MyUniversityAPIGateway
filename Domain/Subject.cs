namespace MyUniversityAPIGateway.Domain;

public class Subject {
    public Subject() {
        Id = "";
        Name = "";
        Code = "";
        Year = 0;
        Course = "";
        Semester = 0;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int Year { get; set; }
    public string Course { get; set; }
    public int Semester { get; set; }
}