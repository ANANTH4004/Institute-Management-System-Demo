using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BLL;

namespace DAL
{
    public class StudentDal
    {
        DataSet ds = null;
        SqlDataAdapter da = null;
        SqlConnection sql = null;
        public StudentDal()
        {
            ds = new DataSet();
            sql = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteCnStr"].ConnectionString);
        }
        private DataTable Connect()
        {
            da = new SqlDataAdapter("select * from Student", sql);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "Student");
            DataTable StudentTable = ds.Tables["Student"];
            return StudentTable;
        }

        public bool InsertStudent(Student s)
        {
            DataTable stud = Connect();
            DataRow dr = stud.NewRow();
            dr["stuId"] = s.StudentId;
            dr["stuName"] = s.StudentName;
            dr["courseId"] = s.CourseId;
            ds.Tables["Student"].Rows.Add(dr);
            SqlCommandBuilder sb = new SqlCommandBuilder(da);
            int i = da.Update(ds.Tables["Student"]);
            bool status = false;
            if (i > 0)
            {
                status = true;
            }
            return status;
        }
        public  bool isContain(int StuId)
        {
            DataTable StuTable = Connect();
            DataRow sr = null;
            sr = ds.Tables["Student"].Rows.Find(StuId);
            if( sr != null)
            {
                return true;
            }
            return false;
        }
        public int FindCourseId(int StuId)
        {
            DataTable StuTable = Connect();
            DataRow sr = ds.Tables["Student"].Rows.Find(StuId);
            return (int)sr["courseId"];
        }

    }
}
