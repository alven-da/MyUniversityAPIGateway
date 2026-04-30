namespace MyUniversityAPIGateway.Domain;

public class Student {
    public Student()
    {
        Name = "";
        Email = "";
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}