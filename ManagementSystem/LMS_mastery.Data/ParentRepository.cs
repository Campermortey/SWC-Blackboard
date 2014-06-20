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
    public class ParentRepository
    {
        public List<ParentDashboard> GetChildren(string parentId)
        {
            //uses Dapper. Creates a connection string
            using (var cn = new SqlConnection(Config.GetConnectionString()))
            {
                //get the dynamic parameter
                var p = new DynamicParameters();

                //binding the parameter
                p.Add("@UserId", parentId);

                //returns a stored procedure to the StudentDashboard 
                return
                    cn.Query<ParentDashboard>("ParentGetChildren", p, commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        } 
    }
}
