using MyUniversityAPIGateway.Domain;

namespace MyUniversityAPIGateway.Data.Mock {
    public static class DbInitializer {
        public static void Seed(UniversityDbContext context) {
            context.Database.EnsureCreated();

            if (!context.Students.Any()) {
                context.Students.Add(new Student { 
                    Id = "0610191", 
                    Name = "John Doe", 
                    Email = "john@example.com" 
                });
            }

            if (!context.Courses.Any()) {
                context.Courses.Add(new Course { 
                    Id = "1", 
                    Code = "BCS",
                    Description = "Bachelor of Science in Computer Science",
                });

                context.Courses.Add(new Course { 
                    Id = "2", 
                    Code = "BHR",
                    Description = "Bachelor of Science in Hospitality and Restaurant Management",
                });
            }

            if (!context.Subjects.Any()) {
                context.Subjects.Add(new Subject { 
                    Id = "1",
                    Code = "COMIT01",
                    Name = "Programming Language I",
                    Year = 2006,
                    Semester = 1
                });
            }

            

            context.SaveChanges();
        }
    }
}