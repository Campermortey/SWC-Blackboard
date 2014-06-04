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
        public List<TeacherDashboard> GetSectionsFor(string teacherId)
        {
            List<TeacherDashboard> courses = new List<TeacherDashboard>();

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetSectionsFor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", teacherId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        courses.Add(new TeacherDashboard()
                        {
                            CourseId = (int)dr["CourseId"],
                            CourseName = dr["CourseName"].ToString(),
                            SectionId = (int)dr["SectionId"],
                            StudentCount = (byte)dr["StudentCount"],
                            IsArchived = (bool)dr["IsArchived"],
                            Period = (byte)dr["Period"]
                        });
                    }
                }
            }

            return courses;
        }


        //public CourseInfo GetCourseInformation(int courseId)
        //{
        //    CourseInfo course = null;

        //    using (var cn = new SqlConnection(Config.GetConnectionString()))
        //    {
        //        var cmd = new SqlCommand("GetCourseInformation", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CourseId", courseId);

        //        cn.Open();

        //        using (var dr = cmd.ExecuteReader())
        //        {
        //            if (dr.Read())
        //            {
        //                course = new CourseInfo()
        //                {                           
        //                    UserId = dr["UserId"].ToString(),
        //                    CourseId= (int)dr["CourseId"],
        //                    CourseName = dr["CourseName"].ToString(),
        //                    DepartmentId = (int)dr["DepartmentId"],
        //                    DepartmentName = dr["DepartmentName"].ToString(),
        //                    Detail = dr["Detail"].ToString(),
        //                    GradeLevel = (byte)dr["GradeLevel"],
        //                    SectionId = (int)dr["SectionId"],
        //                    TeacherId = (int)dr["TeacherId"],
        //                    Period = (int)dr["Period"],
        //                    Room = dr["Room"].ToString(),
        //                    Start = (DateTime)dr["Start"],
        //                    Finish = (DateTime)dr["Finish"], 
        //                    IsArchived = (bool)dr["IsArchived"]
                                              
        //                };
        //            }
        //        }
        //    }

        //    return course;
        //}

        //public List<TeacherDashboard> GetCoursesFor(string teacherId)
        //{
        //    List<TeacherDashboard> courses = new List<TeacherDashboard>();

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
        //                    CourseId = (int)dr["CourseId"],
        //                    CourseName = dr["CourseName"].ToString(),
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
