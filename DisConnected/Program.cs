using BLL;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisConnected
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Institute Management System : \n");
            Console.WriteLine(" 1.Insert Students \n 2.Insert Course \n 3.Write Exam" );
            int ch = Int32.Parse(Console.ReadLine());
            Helper.Helper sh = new Helper.Helper();
           
            switch (ch)
            {
                case 1:
                    Student s = new Student();
                    Console.WriteLine("Enter Student ID : ");
                    s.StudentId = Int32.Parse( Console.ReadLine());
                    Console.WriteLine("Enter Student Name : ");
                    s.StudentName = Console.ReadLine();
                    Console.WriteLine("Enter Course ID :");
                    s.CourseId = Int32.Parse(Console.ReadLine());
                    bool ans = sh.AddStudent(s);
                    if (ans)
                    {
                        Console.WriteLine("Student Added Successfully....");
                    }
                    else
                    {
                        Console.WriteLine("Some Error Occured.......");
                    }
                    break;
                case 2:
                    Course c = new Course();
                    Console.WriteLine("Enter Course Id : ");
                    c.CourseId = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Course Name : ");
                    c.CourseName = Console.ReadLine();
                    Console.WriteLine("Enter Dept Id : ");
                    c.DeptId = Console.ReadLine();
                    Console.WriteLine("Enter Course Duration : ");
                    c.Duration =Int32.Parse( Console.ReadLine());
                    ans = sh.AddCourse(c);
                    if (ans)
                    {
                        Console.WriteLine("Course Added Successfully....");
                    }
                    else
                    {
                        Console.WriteLine("Some Error Occured.......");
                    }
                    break;
                case 3:
                    Exam exam = new Exam();
                    Console.WriteLine("Enter Student Id");
                    int id = Int32.Parse(Console.ReadLine());
                    if (sh.ValidStudent(id))
                    {
                        exam.StudentId = id;
                        Console.WriteLine("Enter Exam Id");
                        int eId = Int32.Parse(Console.ReadLine());
                        exam.ExamId = eId;
                        exam.CourseId =  sh.getCourseId(id);
                        exam.Marks =  sh.StartExam();

                        sh.AddExamDetails(exam);
                        
                      

                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid Student Id. ");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
