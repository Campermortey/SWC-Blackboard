using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LMS_mastery.Models.DTOsView;

namespace LMS_mastery.Data
{
    public class StudentRepository
    {
        public List<StudentDashboard> GetStudentClasses(string studentId)
        {
            //uses Dapper. Creates a connection string
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                //get the dynamic parameter
                var p = new DynamicParameters();

                //binding the parameter
                p.Add("@UserId", studentId);

                //returns a stored procedure to the StudentDashboard 
                return
                    cn.Query<StudentDashboard>("StudentGetClasses", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        }

        public StudentGrades GetStudentGrades(int rosterId)
        {
            StudentGrades result = new StudentGrades();
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                //get the dynamic parameter
                var p = new DynamicParameters();

                //binding the parameter
                p.Add("@RosterId", rosterId);

                result = cn.Query<StudentGrades>("StudentGetClassNameByRosterId", p, commandType: CommandType.StoredProcedure).First();
                result.Grades = cn.Query<AssignmentGrade>("StudentAssignmentGetGrades", p, commandType: CommandType.StoredProcedure)
                        .ToList();
                
                return result;

            }
        }
    }
}
