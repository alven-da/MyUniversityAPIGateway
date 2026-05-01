namespace MyUniversityAPIGateway.Application.Dto {
    public class CourseDto {
        public CourseDto() {
            Id = "";
            Name = "";
            Description = "";
            Code = "";
            Semester = 0;
            Year = 0;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
    }   
}