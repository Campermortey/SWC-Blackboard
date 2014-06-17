using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LMS_mastery.Models.DTOsView;
using LMS_mastery.Models.Interfaces;

namespace LMS_mastery.Data
{
    public class GradeBookRepository : IGradebookRepository
    {
        public GradebookView GetGradebookFor(int courseId)
        {
            GradebookView result = new GradebookView();

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassId", courseId);

                result = cn.Query<GradebookView>("ClassSelectName", p, commandType: CommandType.StoredProcedure).First();
                result.Assignments = cn.Query<GradebookAssignment>("AssignmentSelectByClass", p, commandType: CommandType.StoredProcedure).ToList();
                result.Students = cn.Query<GradebookStudent>("RosterGetStudents", p, commandType: CommandType.StoredProcedure).ToList();

                foreach (var student in result.Students)
                {
                    student.Grades = GetGradesFor(student.RosterId, courseId);
                }
            }

            return result;
        }

        private List<GradebookStudentGrade> GetGradesFor(int rosterId, int courseId)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@RosterId", rosterId);
                p.Add("@ClassId", courseId);

                return cn.Query<GradebookStudentGrade>("GradesSelectForStudent", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
