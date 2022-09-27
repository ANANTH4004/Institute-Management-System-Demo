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
    public class CourseDal
    {
        DataSet ds = null;
        SqlDataAdapter da = null;
        SqlConnection sql = null;
        public CourseDal()
        {
            ds = new DataSet();
            sql = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteCnStr"].ConnectionString);
        }
        private DataTable Connect()
        {
            da = new SqlDataAdapter("select * from Course", sql);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "Course");
            DataTable CourseTable = ds.Tables["Course"];
            return CourseTable;
        }
        public bool InsertCourse(Course c)
        {
            DataTable ctable = Connect();
            DataRow dr = ctable.NewRow();
            dr["courseId"] = c.CourseId;
            dr["courseName"] = c.CourseName;
            dr["deptId"] = c.DeptId;
            dr["duration"] = c.Duration;
            ds.Tables["Course"].Rows.Add(dr);
            SqlCommandBuilder sb = new SqlCommandBuilder(da);
            int i = da.Update(ds.Tables["Course"]);
            bool status = false;
            if (i > 0)
            {
                status = true;
            }
            return status;

        }
    }
}
