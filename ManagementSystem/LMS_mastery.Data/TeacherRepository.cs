using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS_mastery.Models.DTOsPerTable;
using LMS_mastery.Models.DTOsStoredProcedure;
using LMS_mastery.Models.DTOsView;

namespace LMS_mastery.Data
{
    public class TeacherRepository
    {
        public TeacherDashboard GetCourseInformation(int courseId)
        {
            TeacherDashboard course = null;

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetCourseInformation", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseId", courseId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        course = new TeacherDashboard()
                        {                           
                            //UserId = dr["UserId"].ToString(),
                            
                            //DepartmentId = (int)dr["DepartmentId"],
                            //DepartmentName = dr["DepartmentName"].ToString(),
                            //Detail = dr["Detail"].ToString(),
                            //GradeLevel = (byte)dr["GradeLevel"],
                            //Room = dr["Room"].ToString(),
                            //Start = (DateTime)dr["Start"],
                            //Finish = (DateTime)dr["Finish"], 
                            CourseId = (int)dr["CourseId"],
                            CourseName = dr["CourseName"].ToString(),
                            SectionId = (int)dr["SectionId"],
                            TeacherId = (int)dr["TeacherId"],
                            Period = (byte)dr["Period"],
                            IsArchived = (bool)dr["IsArchived"],
                            StudentCount = (byte)dr["StudentCount"]
                                              
                        };
                    }
                }
            }

            return course;
        }

        //public List<Course> GetCoursesFor(string teacherId)
        //{
        //    List<Course> courses = new List<Course>();

        //    using (var cn = new SqlConnection(Config.GetConnectionString()))
        //    {
        //        var cmd = new SqlCommand("ClassGetListForUser", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@UserId", teacherId);

        //        cn.Open();

        //        using (var dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                courses.Add(new Course()
        //                {
        //                    ClassId = (int)dr["ClassId"],
        //                    UserId = dr["UserId"].ToString(),
        //                    Name = dr["Name"].ToString(),
        //                    GradeLevel = (byte)dr["GradeLevel"],
        //                    IsArchived = (bool)dr["IsArchived"],
        //                    Subject = dr["Subject"].ToString(),
        //                    StartDate = (DateTime)dr["StartDate"],
        //                    EndDate = (DateTime)dr["EndDate"],
        //                    Description = dr["Description"].ToString()
        //                });
        //            }
        //        }
        //    }

        //    return courses;
        //}
    }
}
