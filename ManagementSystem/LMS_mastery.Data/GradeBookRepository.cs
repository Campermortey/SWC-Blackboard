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
        public void AddAssignment(Assignment assignment)
        {
            using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
            {
                //binds SQL parameters to Course
                var p = new DynamicParameters();
                p.Add("@ClassId", assignment.ClassId);
                p.Add("@Name", assignment.Name);
                p.Add("@PossiblePoints", assignment.PossiblePoints);
                p.Add("@DueDate", assignment.DueDate);
                p.Add("@Description", assignment.Description);
                p.Add("@AssignmentId", dbType:DbType.Int32, direction:ParameterDirection.Output);


                //Execute the stored procedure
                cn.Execute("AssignmentInsert", p, commandType: CommandType.StoredProcedure);

                assignment.AssignmentId = p.Get<int>("@AssignmentId");
            }
        }
        public void EditTheAssignment(EditAssignment edit)
        {
            //creates a new SQL connection string
            using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
            {
                //binds SQL parameters to Course
                var p = new DynamicParameters();
                p.Add("@AssignmentId", edit.AssignmentId);
                p.Add("@RosterId", edit.RosterId);
                p.Add("@Points", edit.Points);

                //Execute the stored procedure
                cn.Execute("InsertScoreIntoAssignment", p, commandType: CommandType.StoredProcedure);
            }
        }

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

                    // Set var "grade" equal to the GradebookLetterGrade object
                    var grade = GetCourseGrade(student.RosterId, courseId);

                    // If there is data in it, assign object.LetterGrade to the field student.LetterGrade
                    if (grade != null)
                        student.LetterGrade = grade.LetterGrade;
                    else
                        student.LetterGrade = "---";
                }
            }

            return result;
        }

        private GradebookLetterGrade GetCourseGrade(int rosterId, int courseId)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@RosterId", rosterId);
                p.Add("@ClassId", courseId);

                return cn.Query<GradebookLetterGrade>("GetLetterGrade", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
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
