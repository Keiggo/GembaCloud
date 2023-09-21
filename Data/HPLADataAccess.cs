using GembaCloud.Web.Models.HPLAViewModels;
using System.Data;
using System.Data.SqlClient;

namespace GembaCloud.PlaywrightTests.Data
{
    public class HPLADataAccess
    {
        private readonly string _cs;

        public HPLADataAccess()
        {
            _cs = new ConfigDataAccess().GetConnectionStringAsync().Result;
        }

        //To View all HPLAs details 
        public IEnumerable<HPLA> GetHplaGroups(Guid TenantID)
        {
            try
            {
                List<HPLA> lstHPLA = new List<HPLA>();
                using (SqlConnection con = new SqlConnection(_cs))
                {
                    using (SqlCommand cmd = new SqlCommand("HPLA_S_GetHPLAGroups", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TenantID", SqlDbType.UniqueIdentifier).Value = TenantID;
                        cmd.Parameters.Add("@CultureID", SqlDbType.Int).Value = 49;
                        cmd.Parameters.Add("@TimeZoneOffset", SqlDbType.Int).Value = -60;


                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            HPLA HPLA = new HPLA
                            {
                                HPLAGroupID = Convert.ToInt32(rdr["HPLAGroupID"]),
                                Description = rdr["Description"].ToString(),
                                Active = Convert.ToBoolean(rdr["Active"]),
                                Created = rdr.GetDateTime(rdr.GetOrdinal("Created")),
                                Modified = rdr.GetDateTime(rdr.GetOrdinal("Modified")),
                                ModifiedBy = rdr["ModifiedBy"].ToString(),
                                ModifiedByAvatarText = rdr["ModifiedByAvatarText"].ToString(),
                                ModifiedByAvatarColour = rdr["ModifiedByAvatarColour"].ToString(),
                                IsTopLevel = Convert.ToBoolean(rdr["IsTopLevel"])
                            };

                            lstHPLA.Add(HPLA);
                        }
                        con.Close();
                    }
                }
                return lstHPLA;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public HPLA GetHplaGroupByDescription(Guid tenantId, string description)
        {
            var allGroups = GetHplaGroups(tenantId);
            foreach (var group in allGroups)
            { 
                if (group.Description == description)
                {
                    return group;
                }
            }

            throw new Exception("HPLA Group not found");
        }

        //To Add new HPLA record    
        public void AddHPLA(HPLA HPLA, Guid TenantID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("HPLA_X_ProcessHPLAGroupAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Action", "ADD");

                    cmd.Parameters.AddWithValue("@TenantID", (object)TenantID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CultureID", (object)49 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HPLAGroupID", (object)HPLA.HPLAGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", (object)HPLA.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EntityList", (object)HPLA.EntityList ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Active", (object)HPLA.Active ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)DateTime.Now ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@User", (object)HPLA.ModifiedBy ?? DBNull.Value);

                    SqlParameter NewHPLAGroupID = new SqlParameter("@NewHPLAGroupID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewHPLAGroupID);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    int HPLAGroupID = Convert.ToInt32(cmd.Parameters["@NewHPLAGroupID"].Value);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //To Update the records of a particluar HPLA  
        public void UpdateHPLA(HPLA HPLA, Guid TenantID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("HPLA_X_ProcessHPLAGroupAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Action", "MODIFY");

                    cmd.Parameters.AddWithValue("@TenantID", (object)TenantID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CultureID", 49);
                    cmd.Parameters.AddWithValue("@HPLAGroupID", (object)HPLA.HPLAGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", (object)HPLA.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EntityList", (object)HPLA.EntityList ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Active", (object)HPLA.Active ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)HPLA.Modified ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@User", (object)HPLA.ModifiedBy ?? DBNull.Value);
                    //cmd.Parameters.AddWithValue("@AssetLimit", 100); // TODO:
                    //required output parameter
                    SqlParameter NewHPLAGroupID = new SqlParameter("@NewHPLAGroupID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewHPLAGroupID);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    //int HPLAGroupID = Convert.ToInt32(cmd.Parameters["@NewHPLAGroupID"].Value);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Get the details of a particular HPLA  
        public HPLA GetHPLAData(int? id, Guid TenantID)
        {
            try
            {
                HPLA HPLA = new HPLA();

                using (SqlConnection con = new SqlConnection(_cs))
                {
                    using (SqlCommand cmd = new SqlCommand("HPLA_S_GetHPLAGroups", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TenantID", SqlDbType.UniqueIdentifier).Value = TenantID;
                        cmd.Parameters.Add("@CultureID", SqlDbType.Int).Value = 49;
                        cmd.Parameters.Add("@TimeZoneOffset", SqlDbType.Int).Value = -60;
                        cmd.Parameters.Add("@HPLAGroupID", SqlDbType.Int).Value = id.HasValue ? id : (object)DBNull.Value;

                        con.Open();


                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            HPLA.HPLAGroupID = Convert.ToInt32(rdr["HPLAGroupID"]);

                            HPLA.Description = rdr["Description"].ToString();
                            HPLA.Active = Convert.ToBoolean(rdr["Active"]);
                            HPLA.Created = rdr.GetDateTime(rdr.GetOrdinal("Created"));
                            HPLA.Modified = rdr.GetDateTime(rdr.GetOrdinal("Modified"));
                            HPLA.ModifiedBy = rdr["ModifiedBy"].ToString();
                        }
                    }
                }
                return HPLA;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string[] GetHPLAEntities(int? id, Guid TenantID)
        {
            try
            {
                List<string> result = new List<string>();
                using (SqlConnection con = new SqlConnection(_cs))
                {
                    using (SqlCommand cmd = new SqlCommand("HPLA_S_GetEntitiesForHPLAGroup", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TenantID", SqlDbType.UniqueIdentifier).Value = TenantID;
                        cmd.Parameters.Add("@HPLAGroupID", SqlDbType.Int).Value = id.HasValue ? id : (object)DBNull.Value;

                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            result.Add(rdr["EntityID"].ToString());
                        }
                    }
                }
                return result.ToArray();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //To Delete the record on a particular HPLA  
        public void DeleteHPLA(HPLA HPLA, Guid TenantID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_cs))
                {
                    SqlCommand cmd = new SqlCommand("HPLA_X_ProcessHPLAGroupAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Action", "DELETE");

                    cmd.Parameters.AddWithValue("@TenantID", (object)TenantID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CultureID", 49);
                    cmd.Parameters.AddWithValue("@HPLAGroupID", (object)HPLA.HPLAGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", (object)HPLA.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EntityList", (object)HPLA.EntityList ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Active", (object)HPLA.Active ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)HPLA.Modified ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@User", (object)HPLA.ModifiedBy ?? DBNull.Value);
                    // TODO:
                    //required output parameter
                    SqlParameter NewHPLAGroupID = new SqlParameter("@NewHPLAGroupID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewHPLAGroupID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
