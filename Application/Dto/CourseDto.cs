namespace MyUniversityAPIGateway.Application.Dto {
    public class CourseDto {
        public CourseDto() {
            Id = "";
            Description = "";
            Code = "";
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }   
}