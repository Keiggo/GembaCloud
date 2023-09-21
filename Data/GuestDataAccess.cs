using GembaCloud.Web.Models.GuestModels;
using System.Data;
using System.Data.SqlClient;

namespace GembaCloud.PlaywrightTests.Data
{
    public class GuestDataAccess
    {
        private readonly string _connectionString;

        public GuestDataAccess()
        {
            _connectionString = new ConfigDataAccess().GetConnectionStringAsync().Result;
        }

        public IEnumerable<Guest> GetGuests(Guid tenantId)
        {
            try
            {
                List<Guest> lstGuest = new List<Guest>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GUES_S_GetGuests", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestID", DBNull.Value);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        lstGuest.Add(new Guest()
                        {
                            Id = Convert.ToInt32(rdr["GuestID"]),
                            UserId = Convert.ToInt32(rdr["UserID"]),
                            FirstName = rdr["FirstName"].ToString(),
                            Initial = rdr["Initial"].ToString(),
                            LastName = rdr["LastName"].ToString(),
                            DefaultAvatarText = rdr["DefaultAvatarText"].ToString(),
                            DefaultAvatarColour = rdr["DefaultAvatarColour"].ToString(),
                            HPLAGroupDescription = rdr["HPLAGroup"].ToString(),
                            HPLAGroupId = Convert.ToInt32(rdr["HPLAGroupID"]),
                            DefaultTenant = rdr["DefaultTenant"].ToString(),
                            Modified = Convert.ToDateTime(rdr["Modified"]),
                            ModifiedBy = Convert.ToInt32(rdr["ModifiedBy"]),
                            ModifiedByUser = rdr["ModifiedByUser"].ToString(),
                            ModifiedByAvatarText = rdr["ModifiedByAvatarText"].ToString(),
                            ModifiedByAvatarColour = rdr["ModifiedByAvatarColour"].ToString(),
                            UserName = rdr["UserName"].ToString()
                        });
                    }
                    con.Close();
                }
                return lstGuest;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Guest GetGuest(Guid tenantId, int guestId)
        {
            try
            {
                Guest guest = new Guest();

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("GUES_S_GetGuests", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestID", (object)guestId ?? DBNull.Value);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        guest.Id = Convert.ToInt32(rdr["GuestID"]);
                        guest.UserId = Convert.ToInt32(rdr["UserID"]);
                        guest.FirstName = rdr["FirstName"].ToString();
                        guest.Initial = rdr["Initial"].ToString();
                        guest.LastName = rdr["LastName"].ToString();
                        guest.DefaultAvatarText = rdr["DefaultAvatarText"].ToString();
                        guest.DefaultAvatarColour = rdr["DefaultAvatarColour"].ToString();
                        guest.HPLAGroupDescription = rdr["HPLAGroup"].ToString();
                        guest.HPLAGroupId = Convert.ToInt32(rdr["HPLAGroupID"]);
                        guest.DefaultTenant = rdr["DefaultTenant"].ToString();
                        guest.Modified = Convert.ToDateTime(rdr["Modified"]);
                        guest.ModifiedBy = Convert.ToInt32(rdr["ModifiedBy"]);
                        guest.ModifiedByUser = rdr["ModifiedByUser"].ToString();
                        guest.ModifiedByAvatarText = rdr["ModifiedByAvatarText"].ToString();
                        guest.ModifiedByAvatarColour = rdr["ModifiedByAvatarColour"].ToString();
                        guest.UserName = rdr["UserName"].ToString();
                    }
                }
                return guest;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int AddGuest(Guest guest, Guid tenantId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GUES_X_ProcessGuestAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Action", "ADD");

                    cmd.Parameters.AddWithValue("@GuestID", (object)guest.Id ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", (object)guest.UserId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HPLAGroupID", (object)guest.HPLAGroupId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedBy", (object)guest.ModifiedBy ?? DBNull.Value);
                    
                    SqlParameter newGuestId = new SqlParameter("@NewGuestID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(newGuestId);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    int userId = Convert.ToInt32(cmd.Parameters["@NewGuestID"].Value);

                    con.Close();
                    return userId;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateGuest(Guest guest, Guid tenantId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GUES_X_ProcessGuestAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Action", "MODIFY");

                    cmd.Parameters.AddWithValue("@GuestID", (object)guest.Id ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", (object)guest.UserId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HPLAGroupID", (object)guest.HPLAGroupId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)guest.Modified ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ModifiedBy", (object)guest.ModifiedBy ?? DBNull.Value);

                    SqlParameter newGuestId = new SqlParameter("@NewGuestID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(newGuestId);

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

        public void DeleteGuest(Guest guest, Guid tenantId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GUES_X_ProcessGuestAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Action", "DELETE");

                    cmd.Parameters.AddWithValue("@GuestID", (object)guest.Id ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", (object)guest.UserId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HPLAGroupID", (object)guest.HPLAGroupId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)guest.Modified ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ModifiedBy", (object)guest.ModifiedBy ?? DBNull.Value);

                    SqlParameter newGuestId = new SqlParameter("@NewGuestID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(newGuestId);

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

        public async Task<Guest> GetGuestByUsername(string username, Guid tenantId)
        {
            try
            {
                var allMembers = GetGuests(tenantId);
                var member = allMembers.ToList().Find(item => item.UserName == username);

                return member;
            }

            catch
            {
                throw new Exception("Can't find a member with that username");
            }

        }
    }
}
