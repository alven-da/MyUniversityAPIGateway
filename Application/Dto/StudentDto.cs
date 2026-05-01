namespace MyUniversityAPIGateway.Application.Dto {
    public class StudentDto {
        public StudentDto() {
            Id = "";
            Name = "";
            Email = "";
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}