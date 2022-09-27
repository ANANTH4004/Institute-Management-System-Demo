using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int Marks { get; set; }

        static Dictionary<string, string> questions = new Dictionary<string, string>();
        public void CreateQuesPaper()
        {
            questions.Add("What is your Name ", "anand");
            questions.Add("2nd Question ", "anand");
            questions.Add("3rd Question  ", "varun");
            questions.Add("4th Question  ", "anand");
        }

        public int WriteExam()
        {
            int mark = 0;
            foreach (var item in questions)
            {
                Console.WriteLine(item.Key);
                string ans = Console.ReadLine();
                if (ans.ToLower() == item.Value)
                {
                    Console.WriteLine("Correct Answer......");
                    mark += 2;
                }
                else
                {
                    Console.WriteLine("Wrong Answer........");
                }
            }
            return mark;
        }

    }
}
