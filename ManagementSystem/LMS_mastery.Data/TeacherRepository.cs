﻿using System;
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
        public List<TeacherDashboard> GetCourseSummariesFor(string teacherId)
        {
            List<TeacherDashboard> courses = new List<TeacherDashboard>();

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("ClassSummaryGetList", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", teacherId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
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

            return courses;
        }

        public Course GetCourseById(int courseId)
        {
            Course course = null;

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("ClassGetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClassId", courseId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
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
            List<Course> courses = new List<Course>();

            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                var cmd = new SqlCommand("ClassGetListForUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", teacherId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
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

            return courses;
        }
    }
    }
