using Academy.Core.DTOS;
using Academy.Core.Repositories;
using Academy.Core.Services;
using Academy.Repositories;
using Academy.Services;
using Microsoft.Extensions.DependencyInjection;
var serviceCollection = new ServiceCollection();
ConfigureService(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();
var studentService = serviceProvider.GetService<IStudentService>();
Console.WriteLine("WellCome To Academy Management System");
Console.WriteLine("Press\n1 To Add Student \n2 To Remove Student \n3 To Update Student \n4 To Gell All Students");
var Option = Convert.ToInt32(Console.ReadLine());
switch (Option)
{
    case 1:
        {
            Console.WriteLine("Add Student Data");
            Console.Write("Student Name :");
            var studentName = Console.ReadLine();
            Console.Write("Father Name :");
            var fatherName = Console.ReadLine();
            StudentDto studentDto = new StudentDto();
            studentDto.Id = 1;
            studentDto.Name = studentName;
            studentDto.F_Name = fatherName;
            await studentService.AddStudentAsync(studentDto);
            break;
        }
    case 2:
        {
            Console.WriteLine("Delete student Data");
            Console.Write("Student Id :");
            var student_ID = Convert.ToInt16(Console.ReadLine());
            await studentService.RemoveStudentAsync(student_ID);
            break;


        }
    case 3:
        {
            Console.WriteLine("Update Data");
            Console.Write("member ID :  ");
            var StudentID = Convert.ToByte(Console.ReadLine());
            Console.Write("Name : ");
            var StudentName = Console.ReadLine();
            Console.Write("Father Name : ");
            var FatherName = Console.ReadLine();
            StudentDto student = new StudentDto();
            student.Id = StudentID;
            student.Name = StudentName;
            student.F_Name = FatherName;
            await studentService.UpdateStudentAsync(student);
            break;
        }
    case 4:
        {
            Console.WriteLine("Get All Data");
            List<StudentDto> students = await studentService.GetAllStudentAsync();

            foreach (var s in students)
            {
                Console.Write(s.Id + "  " + s.Name + "  " + s.F_Name + "\n");
            }
            break;
        }

    default:
        break;
}

void ConfigureService(ServiceCollection serviceCollection)
{
    serviceCollection.AddTransient<IStudentService, StudentService>();

    serviceCollection.AddTransient<IStudentRepository, StudentRepository>();
}