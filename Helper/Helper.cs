using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class Helper
    {
        StudentDal sdal = null;
        CourseDal cdal = null;
        ExamDal edal = null;
        Exam exam = null;
        public Helper()
        {
            sdal = new StudentDal();
            cdal = new CourseDal();
            edal = new ExamDal();
            exam = new Exam();
        }

        public bool AddStudent(Student s)
        {
            return sdal.InsertStudent(s);
        }
        public bool AddCourse(Course c)
        {
            return cdal.InsertCourse(c);
        }

        public bool AddExamDetails(Exam e)
        {
            return edal.InsertExam(e);
        }
        public bool ValidStudent(int s)
        {
            return sdal.isContain(s);
        }
        public int getCourseId(int s)
        {
            return sdal.FindCourseId(s);
        }
        public int StartExam()
        {
            exam.CreateQuesPaper();
            return exam.WriteExam();

        }
    }
}
