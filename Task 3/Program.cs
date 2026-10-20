namespace Task_3
{

    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses;

        public bool Enroll(Course course)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }
            Courses.Add(course);
            return true;
        }

        public string PrintInfo()
        {
            string info = $"Student ID: {StudentId}\n";
            info += $"Name: {Name}\n";
            info += $"Age: {Age}\n";
            for (int i = 0; i < Courses.Count; i++)
            {
                info += $"Course {i + 1}: {Courses[i].Title}\n";
            }
            return info;
        }
    }



    class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public string PrintInfo()
        {
            return $"Instructor ID: {InstructorId}\nName: {Name}\nSpecialization: {Specialization}";
        }
    }

    class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public string PrintInfo()
        {
            return $"Course ID: {CourseId}\nTitle: {Title}\nInstructor: {Instructor.Name}";
        }
    }

    class School : Student
    {
        // لازم نعمل new للـ Lists هنا عشان ما تبقاش null
        public List<Student> Students { get; set; } = new List<Student>();
        public new List<Course> Courses { get; set; } = new List<Course>();
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();

        public bool AddStudent(Student student)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == student.StudentId)
                {
                    return false;
                }
            }
            Students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }
            Courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructor.InstructorId)
                {
                    return false;
                }
            }
            Instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }
            return null;
        }

        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }
            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }
            return null;
        }

        public bool DeleteStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    Students.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student == null || course == null)
            {
                return false;
            }
            return student.Enroll(course);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // School واحد بس طول البرنامج (مش كل مرة new)
            School school = new School();

            int choice;
            do
            {
                Console.WriteLine("1. Add a new Student");
                Console.WriteLine("2. View all Students");
                Console.WriteLine("3. Search for a Student by ID");
                Console.WriteLine("4. Update Student Information");
                Console.WriteLine("5. Delete a Student");
                Console.WriteLine("6. Add a new Course");
                Console.WriteLine("7. Add a new Instructor");
                Console.WriteLine("8. Enroll a Student in a Course");
                Console.WriteLine("9. View all Courses");
                Console.WriteLine("10. View all Instructors");
                Console.WriteLine("0. Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            // Add a new Student
                            List<Course> studentCourses = new List<Course>();
                            Console.WriteLine("Please enter the student's name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Please enter the student's age:");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please enter the student's ID:");
                            int id = Convert.ToInt32(Console.ReadLine());

                            bool added = school.AddStudent(new Student { Name = name, Age = age, StudentId = id, Courses = studentCourses });
                            if (added)
                            {
                                Console.WriteLine("Student added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("A student with this ID already exists.");
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 2:
                        {
                            // View all Students
                            if (school.Students.Count == 0)
                            {
                                Console.WriteLine("No students found.");
                            }
                            for (int i = 0; i < school.Students.Count; i++)
                            {
                                Console.WriteLine(school.Students[i].PrintInfo());
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 3:
                        {
                            // Search for a Student by ID
                            Console.WriteLine("Please enter the student's ID:");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            Student found = school.FindStudent(searchId);
                            if (found != null)
                            {
                                Console.WriteLine(found.PrintInfo());
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 4:
                        {
                            // Update Student Information
                            Console.WriteLine("Enter the Student ID:");
                            int idStudent = Convert.ToInt32(Console.ReadLine());
                            Student toUpdate = school.FindStudent(idStudent);
                            if (toUpdate == null)
                            {
                                Console.WriteLine("Student not found.");
                            }
                            else
                            {
                                Console.WriteLine("Enter the new Name:");
                                toUpdate.Name = Console.ReadLine();
                                Console.WriteLine("Enter the new Age:");
                                toUpdate.Age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Student updated successfully.");
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 5:
                        {
                            // Delete a Student
                            Console.WriteLine("Enter the Student ID to delete:");
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            if (school.DeleteStudent(deleteId))
                            {
                                Console.WriteLine("Student deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 6:
                        {
                            // Add a new Course
                            Console.WriteLine("Enter the Course ID:");
                            int courseId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Course Title:");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter the Instructor ID:");
                            int instId = Convert.ToInt32(Console.ReadLine());

                            Instructor instructor = school.FindInstructor(instId);
                            if (instructor == null)
                            {
                                Console.WriteLine("Instructor not found. Add the instructor first (option 7).");
                            }
                            else
                            {
                                bool courseAdded = school.AddCourse(new Course { CourseId = courseId, Title = title, Instructor = instructor });
                                if (courseAdded)
                                {
                                    Console.WriteLine("Course added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("A course with this ID already exists.");
                                }
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 7:
                        {
                            // Add a new Instructor
                            Console.WriteLine("Enter the Instructor ID:");
                            int instructorId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Instructor Name:");
                            string instructorName = Console.ReadLine();
                            Console.WriteLine("Enter the Specialization:");
                            string specialization = Console.ReadLine();

                            bool instructorAdded = school.AddInstructor(new Instructor { InstructorId = instructorId, Name = instructorName, Specialization = specialization });
                            if (instructorAdded)
                            {
                                Console.WriteLine("Instructor added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("An instructor with this ID already exists.");
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 8:
                        {
                            // Enroll a Student in a Course
                            Console.WriteLine("Enter the Student ID:");
                            int enrollStudentId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Course ID:");
                            int enrollCourseId = Convert.ToInt32(Console.ReadLine());

                            if (school.FindStudent(enrollStudentId) == null)
                            {
                                Console.WriteLine("Student not found.");
                            }
                            else if (school.FindCourse(enrollCourseId) == null)
                            {
                                Console.WriteLine("Course not found.");
                            }
                            else if (school.EnrollStudentInCourse(enrollStudentId, enrollCourseId))
                            {
                                Console.WriteLine("Student enrolled successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Student is already enrolled in this course.");
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 9:
                        {
                            // View all Courses
                            if (school.Courses.Count == 0)
                            {
                                Console.WriteLine("No courses found.");
                            }
                            for (int i = 0; i < school.Courses.Count; i++)
                            {
                                Console.WriteLine(school.Courses[i].PrintInfo());
                                Console.WriteLine();
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 10:
                        {
                            // View all Instructors
                            if (school.Instructors.Count == 0)
                            {
                                Console.WriteLine("No instructors found.");
                            }
                            for (int i = 0; i < school.Instructors.Count; i++)
                            {
                                Console.WriteLine(school.Instructors[i].PrintInfo());
                                Console.WriteLine();
                            }
                            Console.WriteLine("================================");
                            break;
                        }
                    case 0:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }
            while (choice != 0);

        }
    }
}


//class : اختصار او نسخة لمف اذا تم التعديل علي النسخة بياثر علي الاصل معاه
//Struct: نسخة حره مستقلة عن النسخة الاصلية لا تتاثر من النسخة الاصلية ولا تاثر عليها
//record : زي الكلاس بس بتبص ع المحتوي فقط عكس الكلاس بتبص ع الشئ نفسه او الكائن
