using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL
{
    public class ExamDal
    {
        DataSet ds = null;
        SqlDataAdapter da = null;
        SqlConnection sql = null;
        public ExamDal()
        {
            ds = new DataSet();
            sql = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteCnStr"].ConnectionString);
        }
        private DataTable Connect()
        {
            da = new SqlDataAdapter("select * from Exam", sql);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "Exam");
            DataTable ExamTable = ds.Tables["Exam"];
            return ExamTable;
        }
        public bool InsertExam(Exam e)
        {
            DataTable ExamData = Connect();
            DataRow dr = ds.Tables["Exam"].NewRow();
            dr["examId"] = e.ExamId;
            dr["courseId"] = e.CourseId;
            dr["stuId"] = e.StudentId;
            dr["marks"] = e.Marks;
            ds.Tables["Exam"].Rows.Add(dr);
            SqlCommandBuilder sb = new SqlCommandBuilder(da);
            int i = da.Update(ds.Tables["Exam"]);
            bool status = false;
            if (i > 0)
            {
                status = true;
            }
            return status;

        }
    }
}
