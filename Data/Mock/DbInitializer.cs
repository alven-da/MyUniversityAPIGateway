using MyUniversityAPIGateway.Domain;

namespace MyUniversityAPIGateway.Data.Mock {
    public static class DbInitializer {
        public static void Seed(UniversityDbContext context) {
            context.Database.EnsureCreated();

            if (context.Students.Any()) {
                return;
            }

            context.Students.Add(new Student { 
                Id = "0610191", 
                Name = "John Doe", 
                Email = "john@example.com" 
            });

            if (context.Courses.Any()) {
                return;
            }

            context.Courses.Add(new Course { 
                Id = "1", 
                Code = "COMIT01",
                Name = "Introduction to Information Technology",
                Description = "An introductory course on Information Technology covering basic concepts and applications.",
                Year = 2006,
                Semester = 1
            });

            context.Courses.Add(new Course { 
                Id = "2", 
                Code = "COMIT02",
                Name = "Programming Language I",
                Year = 2006,
                Semester = 1
            });

            context.SaveChanges();
        }
    }
}