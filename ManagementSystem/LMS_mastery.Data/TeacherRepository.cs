using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS_mastery.Models.DTOsPerTable;
using LMS_mastery.Models.DTOsStoredProcedure;
using LMS_mastery.Models.DTOsView;
using Dapper;
using LMS_mastery.UI.Models.Teacher;


namespace LMS_mastery.Data
{
    //Using ADO.net and Dapper, these methods bind database data to the dtos
    public class TeacherRepository
    {
        public List<TeacherDashboard> GetCourseSummariesFor(string teacherId)
        {
            List<TeacherDashboard> courses = new List<TeacherDashboard>();

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                //Stored procedure name
                var cmd = new SqlCommand("ClassSummaryGetList", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                //the parameter being passed in
                cmd.Parameters.AddWithValue("@UserId", teacherId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //what you are binding to the dto
                        courses.Add(new TeacherDashboard()
                        {
                            ClassId = (int)dr["ClassId"],
                            Name = dr["Name"].ToString(),
                            IsArchived = (bool)dr["IsArchived"],
                            NumberOfStudents = (int)dr["NumberOfStudents"]
                        });
                    }
                }
            }
            //return the list of courses
            return courses;
        }

        public Course GetCourseById(int courseId)
        {
            Course course = null;

            //establish the SQL connection
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                //the stored procedure name
                var cmd = new SqlCommand("TeacherClassGetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //the parameter being passed in
                cmd.Parameters.AddWithValue("@ClassId", courseId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        //binds the SQL data to the Course DTO
                        course = new Course()
                        {
                            ClassId = (int)dr["ClassId"],
                            UserId = dr["UserId"].ToString(),
                            Name = dr["Name"].ToString(),
                            GradeLevel = (byte)dr["GradeLevel"],
                            IsArchived = (bool)dr["IsArchived"],
                            Subject = dr["Subject"].ToString(),
                            StartDate = (DateTime)dr["StartDate"],
                            EndDate = (DateTime)dr["EndDate"],
                            Description = dr["Description"].ToString()
                        };
                    }
                }
            }

            return course;
        }

        public List<Course> GetCoursesFor(string teacherId)
        {
            //create a list of courses
            List<Course> courses = new List<Course>();

            //connection string
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                //stored procedure name
                var cmd = new SqlCommand("ClassGetListForUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parameter being passed in
                cmd.Parameters.AddWithValue("@UserId", teacherId);

                cn.Open();

                //reads the data from SQL
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //bind SQL to Course DTO
                        courses.Add(new Course()
                        {
                            ClassId = (int)dr["ClassId"],
                            UserId = dr["UserId"].ToString(),
                            Name = dr["Name"].ToString(),
                            GradeLevel = (byte)dr["GradeLevel"],
                            IsArchived = (bool)dr["IsArchived"],
                            Subject = dr["Subject"].ToString(),
                            StartDate = (DateTime)dr["StartDate"],
                            EndDate = (DateTime)dr["EndDate"],
                            Description = dr["Description"].ToString()
                        });
                    }
                }
            }

            //return a list of courses
            return courses;
        }

        public List<TeacherRoster> GetRosterBy(int courseId)
        {
            //uses Dapper. Creates a connection string
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                //get the dynamic parameter
                var p = new DynamicParameters();

                //binding the parameter
                p.Add("@ClassId", courseId);

                //returns a stored procedure to the TeacherRoster 
                return
                    cn.Query<TeacherRoster>("TeacherGetClassRoster", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        }

        public void RemoveStudent(string UserId, int ClassId)
        {
            //creates a SQL connection
            using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
            {
                //the two parameters are stored
                var p = new DynamicParameters();
                p.Add("@UserId", UserId);
                p.Add("@ClassId", ClassId);

                //executes the stored procedure
                cn.Execute("RosterDeleteStudent", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void EditCourse(Course course)
        {
            //creates a new SQL connection string
            using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
            {
                //binds SQL parameters to Course
                var p = new DynamicParameters();
                p.Add("@UserId", course.UserId);
                p.Add("@Name", course.Name);
                p.Add("@GradeLevel", course.GradeLevel);
                p.Add("@Subject", course.Subject);
                p.Add("@IsArchived", course.IsArchived);
                p.Add("@StartDate", course.StartDate);
                p.Add("@EndDate", course.EndDate);
                p.Add("@Description", course.Description);
                p.Add("@ClassId", course.ClassId);

                //Execute the stored procedure
                cn.Execute("TeacherClassUpdate", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddCourse(Course course)
        {
            //establish the SQL connection
            using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
            {
                //bind the SQL data to the DTO
                var p = new DynamicParameters();
                p.Add("@UserId", course.UserId);
                p.Add("@Name", course.Name);
                p.Add("@GradeLevel", course.GradeLevel);
                p.Add("@Subject", course.Subject);
                p.Add("@StartDate", course.StartDate);
                p.Add("@EndDate", course.EndDate);
                p.Add("@Description", course.Description);
                p.Add("@ClassId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                //executes the stored procedure. Execute for insert, update, delete
                cn.Execute("TeacherClassInsert", p, commandType: CommandType.StoredProcedure);

                //ClassId stored output
                course.ClassId = p.Get<int>("@ClassId");
            }
        }

        // Get a list of Analytics
        public List<Analytics> GetClassGrades(int ClassId)
        {
            using (SqlConnection cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassId", ClassId);

                //Query the Stored Procedure
                return 
                    cn.Query<Analytics>("TeacherGetClassGrades", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TeacherSearch> Search(RosterSearchRequest request)
        {
            if (string.IsNullOrEmpty(request.LastName))
            {
                return RosterSearchByGradeLevel(request);
            }

            if (request.GradeLevel == null)
            {
                return RosterSearchByLastName(request);
            }

            return RosterSearchByLastNameAndGradeLevel(request);
        }

        //search by only grade level and return a list of students
        private List<TeacherSearch> RosterSearchByGradeLevel(RosterSearchRequest request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassId", request.ClassId);
                p.Add("@GradeLevel", request.GradeLevel);

                return
                    cn.Query<TeacherSearch>("RosterSearchByGradeLevel", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        }

        //search by last name and grade level both. Return list of students
        private List<TeacherSearch> RosterSearchByLastNameAndGradeLevel(RosterSearchRequest request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassId", request.ClassId);
                p.Add("@GradeLevel", request.GradeLevel);
                p.Add("@LastName", request.LastName);

                return
                    cn.Query<TeacherSearch>("RosterSearchByLastNameAndGradeLevel", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        }

        //Search by last name only for a student. Return list of students
        private List<TeacherSearch> RosterSearchByLastName(RosterSearchRequest request)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@ClassId", request.ClassId);
                p.Add("@LastName", request.LastName);
                
                

                return
                    cn.Query<TeacherSearch>("RosterSearchByLastName", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        }

        //Add a student to the Roster
        public void AddToRoster(string UserId, int ClassId)
        {
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var p = new DynamicParameters();
                
                p.Add("@UserId", UserId);
                p.Add("@ClassId", ClassId);

                cn.Execute("RosterInsert", p, commandType: CommandType.StoredProcedure);

            }
        }
    }
}

