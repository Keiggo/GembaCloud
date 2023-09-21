using GembaCloud.Web.Helpers;
using System.Data;
using System.Data.SqlClient;
using GembaCloud.Web.Models.MemberViewModels;

namespace GembaCloud.PlaywrightTests.Data
{
    public class MemberDataAccess
    {
        private readonly string _connectionString;

        public MemberDataAccess()
        {
            _connectionString = new ConfigDataAccess().GetConnectionStringAsync().Result;
        }


        public bool DoesMemberExist(string username)
        {
            try
            {
                return GetUserIDByUserName(username).HasValue;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int? GetUserIDByUserName(string username)
        {
            try
            {
                int? result = null;
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("USER_S_NewUserCheck", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

                    con.Open();
                    try
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            result = Convert.ToInt32(rdr["UserID"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw;
                    }
                    con.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //To View all Members details    
        public IEnumerable<Member> GetAllMembers(bool sysAdminOnly)
        {
            try
            {
                List<Member> lstMember = new List<Member>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USER_S_GetAllUsers", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@SysAdminOnly", (object)sysAdminOnly ?? DBNull.Value);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        lstMember.Add(new Member()
                        {
                            MembershipUserID = new Guid(rdr["MembershipUserID"].ToString()),
                            UserID = Convert.ToInt32(rdr["UserID"]),
                            TenantID = new Guid(rdr["TenantID"].ToString()),
                            FirstName = rdr["FirstName"].ToString(),
                            Initial = rdr["Initial"].ToString(),
                            LastName = rdr["LastName"].ToString(),
                            CultureID = rdr["CultureID"] == DBNull.Value ? 49 : Convert.ToInt32(rdr["CultureID"]),
                            UserCulture = rdr["UserCulture"].ToString(),
                            TimeZoneOffset = rdr["TimeZoneOffset"] == DBNull.Value ? -60 : Convert.ToInt32(rdr["TimeZoneOffset"]),
                            LastUpdatedDate = (DateTime)rdr["LastUpdatedDate"],
                            UserName = rdr["UserName"].ToString(),
                            PostCount = Convert.ToInt32(rdr["PostCount"]),
                            Joined = (DateTime)rdr["Joined"],
                            Avatar = rdr["Avatar"].ToString(),
                            EmailFormat = rdr["EmailFormat"].ToString(),
                            HPLAGroupID = Convert.ToInt32(rdr["HPLAGroupID"]),
                            TenantName = rdr["TenantName"].ToString(),
                            EmailConfirmed = Convert.ToBoolean(rdr["EmailConfirmed"]),
                            AccessFailedCount = Convert.ToInt32(rdr["AccessFailedCount"]),
                            LockoutEnabled = Convert.ToBoolean(rdr["LockoutEnabled"]),
                            LockoutEnd = rdr["LockoutEnd"] == DBNull.Value ? null : (DateTimeOffset?)rdr["LockoutEnd"],
                            DisplayName = rdr["DisplayName"].ToString(),
                            BatchEmails = Convert.ToBoolean(rdr["BatchEmails"]),
                            BatchEmailInterval = Convert.ToInt32(rdr["BatchEmailIntervalMins"]),
                            LastLoginTime = Convert.ToDateTime(rdr["LastLoginTime"]),
                            DefaultAvatarText = rdr["DefaultAvatarText"].ToString(),
                            DefaultAvatarColour = rdr["DefaultAvatarColour"].ToString()
                        });
                    }
                    con.Close();
                }
                return lstMember;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<IEnumerable<Member>> GetMembers(Guid tenantId)
        {
            return Task.Run(() =>
            {
                try
                {
                    List<Member> lstMember = new List<Member>();

                    using (SqlConnection con = new SqlConnection(_connectionString))
                    using (SqlCommand cmd = new SqlCommand("USER_S_GetUsersForTenant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);

                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            lstMember.Add(new Member()
                            {
                                MembershipUserID = new Guid(rdr["MembershipUserID"].ToString()),
                                UserID = Convert.ToInt32(rdr["UserID"]),
                                TenantID = new Guid(rdr["TenantID"].ToString()),
                                FirstName = rdr["FirstName"].ToString(),
                                Initial = rdr["Initial"].ToString(),
                                LastName = rdr["LastName"].ToString(),
                                CultureID = rdr["CultureID"] == DBNull.Value ? 49 : Convert.ToInt32(rdr["CultureID"]),
                                UserCulture = rdr["UserCulture"].ToString(),
                                TimeZoneOffset = rdr["TimeZoneOffset"] == DBNull.Value ? -60 : Convert.ToInt32(rdr["TimeZoneOffset"]),
                                LastUpdatedDate = (DateTime)rdr["LastUpdatedDate"],
                                UserName = rdr["UserName"].ToString(),
                                PostCount = Convert.ToInt32(rdr["PostCount"]),
                                Joined = (DateTime)rdr["Joined"],
                                Avatar = rdr["Avatar"].ToString(),
                                EmailFormat = rdr["EmailFormat"].ToString(),
                                HPLAGroupID = Convert.ToInt32(rdr["HPLAGroupID"]),
                                TenantName = rdr["TenantName"].ToString(),
                                EmailConfirmed = Convert.ToBoolean(rdr["EmailConfirmed"]),
                                AccessFailedCount = Convert.ToInt32(rdr["AccessFailedCount"]),
                                LockoutEnabled = Convert.ToBoolean(rdr["LockoutEnabled"]),
                                LockoutEnd = rdr["LockoutEnd"] == DBNull.Value ? null : (DateTimeOffset?)rdr["LockoutEnd"],
                                DisplayName = rdr["DisplayName"].ToString(),
                                BatchEmails = Convert.ToBoolean(rdr["BatchEmails"]),
                                BatchEmailInterval = Convert.ToInt32(rdr["BatchEmailIntervalMins"]),
                                LastLoginTime = Convert.ToDateTime(rdr["LastLoginTime"]),
                                DefaultAvatarText = rdr["DefaultAvatarText"].ToString(),
                                DefaultAvatarColour = rdr["DefaultAvatarColour"].ToString()
                            });
                        }
                        con.Close();
                    }
                    return (IEnumerable<Member>)lstMember;
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }

        public IEnumerable<RelevantMember> GetRelevantMembers(Guid tenantId, bool includeGuests, bool includeSysAdmins)
        {
            try
            {
                var lstMember = new List<RelevantMember>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("USER_S_GetRelevantUsersForTenant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IncludeGuests", (object)includeGuests ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IncludeSysAdmins", (object)includeSysAdmins ?? DBNull.Value);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        lstMember.Add(new RelevantMember()
                        {
                            UserID = Convert.ToInt32(rdr["UserID"]),
                            DisplayName = rdr["DisplayName"].ToString(),
                            IsSysAdmin = Convert.ToBoolean(rdr["IsSysAdmin"]),
                            IsGuest = Convert.ToBoolean(rdr["IsGuest"]),
                            DefaultAvatarText = rdr["DefaultAvatarText"].ToString(),
                            DefaultAvatarColour = rdr["DefaultAvatarColour"].ToString(),
                            UserName = rdr["UserName"].ToString()
                        });
                    }
                    con.Close();
                }
                return lstMember;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //To Add new Member record    
        public int AddMember(Member member, Guid tenantId, string auditUserName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USER_X_ProcessUserAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Action", "ADD");

                    cmd.Parameters.AddWithValue("@MembershipUserID", (object)member.MembershipUserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FirstName", (object)member.FirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Initial", (object)member.Initial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", (object)member.LastName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CultureID", (object)-1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserCulture", (object)member.UserCulture ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TimeZoneOffset", (object)member.TimeZoneOffset ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastUpdatedDate", (object)DateTime.Now ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserName", (object)member.UserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PostCount", (object)member.PostCount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Joined", (object)DateTime.Now ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AuditUserName", (object)auditUserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmailFormat", (object)member.EmailFormat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HPLAGroupID", (object)member.HPLAGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BatchEmailIntervalMins", (object)member.BatchEmailInterval ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BatchEmail", (object)member.BatchEmails ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DefaultAvatarText", member.DefaultAvatarText);
                    cmd.Parameters.AddWithValue("@DefaultAvatarColour", member.DefaultAvatarColour);

                    SqlParameter NewUserID = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewUserID);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    int userId = Convert.ToInt32(cmd.Parameters["@NewUserID"].Value);

                    con.Close();
                    return userId;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //To Update the records of a particular Member  
        public void UpdateMember(Member member, string auditUserName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USER_X_ProcessUserAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Action", "MODIFY");

                    cmd.Parameters.AddWithValue("@MembershipUserID", (object)member.MembershipUserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)member.TenantID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FirstName", (object)member.FirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Initial", (object)member.Initial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", (object)member.LastName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CultureID", -1);
                    cmd.Parameters.AddWithValue("@UserCulture", (object)member.UserCulture ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TimeZoneOffset", (object)member.TimeZoneOffset ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastUpdatedDate", SqlHelper.IsDateTimeValidSqlDatetime(member.LastUpdatedDate) ? member.LastUpdatedDate : DateTime.Now);
                    cmd.Parameters.AddWithValue("@UserName", (object)member.UserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PostCount", (object)member.PostCount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Joined", SqlHelper.IsDateTimeValidSqlDatetime(member.Joined) ? member.Joined : DateTime.Now);
                    cmd.Parameters.AddWithValue("@EmailFormat", (object)member.EmailFormat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AuditUserName", (object)auditUserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HPLAGroupID", (object)member.HPLAGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BatchEmailIntervalMins", (object)member.BatchEmailInterval ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BatchEmail", (object)member.BatchEmails ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ConnectHealthAlertMinimumSeverity", (object)member.ConnectHealthAlertMinimumSeverity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AnomalyAlertLevel", (object)member.AnomalyAlertLevel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DefaultAvatarText", member.DefaultAvatarText);
                    cmd.Parameters.AddWithValue("@DefaultAvatarColour", member.DefaultAvatarColour);

                    SqlParameter NewUserID = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewUserID);

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

        //Get the details of a particular Member  
        public Task<Member> GetMemberData(Guid? id, Guid tenantId, bool isSysAdmin)
        {
            return Task.Run(() =>
            {
                try
                {
                    Member member = new Member();

                    using (SqlConnection con = new SqlConnection(_connectionString))
                    using (SqlCommand cmd = new SqlCommand("USER_S_GetUserForTenant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TenantID", SqlDbType.UniqueIdentifier).Value = tenantId;
                        cmd.Parameters.Add("@MembershipUserID", SqlDbType.UniqueIdentifier).Value = id.HasValue ? id : (object)DBNull.Value;
                        cmd.Parameters.Add("@IsSysAdmin", SqlDbType.Bit).Value = isSysAdmin;

                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            member.MembershipUserID = new Guid(rdr["MembershipUserID"].ToString());
                            member.UserID = Convert.ToInt32(rdr["UserID"]);
                            member.TenantID = new Guid(rdr["TenantID"].ToString());
                            member.FirstName = rdr["FirstName"].ToString();
                            member.Initial = rdr["Initial"].ToString();
                            member.LastName = rdr["LastName"].ToString();
                            member.CultureID = rdr["CultureID"] == DBNull.Value ? 49 : Convert.ToInt32(rdr["CultureID"]);
                            member.UserCulture = rdr["UserCulture"].ToString();
                            member.TimeZoneOffset = rdr["TimeZoneOffset"] == DBNull.Value ? -60 : Convert.ToInt32(rdr["TimeZoneOffset"]);
                            member.LastUpdatedDate = rdr.GetDateTime(rdr.GetOrdinal("LastUpdatedDate"));
                            member.UserName = rdr["UserName"].ToString();
                            member.PostCount = Convert.ToInt32(rdr["PostCount"]);
                            member.Joined = (DateTime)rdr["Joined"];
                            member.Avatar = rdr["Avatar"].ToString();
                            member.EmailFormat = rdr["EmailFormat"].ToString();
                            member.HPLAGroupID = Convert.ToInt32(rdr["HPLAGroupID"]);
                            member.TenantName = rdr["TenantName"].ToString();
                            member.EmailConfirmed = Convert.ToBoolean(rdr["EmailConfirmed"]);
                            member.AccessFailedCount = Convert.ToInt32(rdr["AccessFailedCount"]);
                            member.LockoutEnabled = Convert.ToBoolean(rdr["LockoutEnabled"]);
                            member.LockoutEnd = rdr["LockoutEnd"] == DBNull.Value ? null : (DateTimeOffset?)rdr["LockoutEnd"];
                            member.DisplayName = rdr["DisplayName"].ToString();
                            member.BatchEmails = Convert.ToBoolean(rdr["BatchEmails"]);
                            member.BatchEmailInterval = Convert.ToInt32(rdr["BatchEmailIntervalMins"]);
                            member.LastLoginTime = Convert.ToDateTime(rdr["LastLoginTime"]);
                            member.DefaultAvatarText = rdr["DefaultAvatarText"].ToString();
                            member.DefaultAvatarColour = rdr["DefaultAvatarColour"].ToString();
                        }
                    }
                    return member;
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }

        //Get the details of a particular Admin
        internal Task<Member> GetMemberByMembershipUserId(Guid? id)
        {
            return Task.Run(() =>
            {
                try
                {
                    Member member = null;

                    using (SqlConnection con = new SqlConnection(_connectionString))
                    using (SqlCommand cmd = new SqlCommand("USER_S_GetUserByMembershipUserId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@MembershipUserID", SqlDbType.UniqueIdentifier).Value = id.HasValue ? id : (object)DBNull.Value;

                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            member = new Member()
                            {
                                MembershipUserID = new Guid(rdr["MembershipUserID"].ToString()),
                                UserID = Convert.ToInt32(rdr["UserID"]),
                                TenantID = new Guid(rdr["TenantID"].ToString()),
                                FirstName = rdr["FirstName"].ToString(),
                                Initial = rdr["Initial"].ToString(),
                                LastName = rdr["LastName"].ToString(),
                                CultureID = rdr["CultureID"] == DBNull.Value ? 49 : Convert.ToInt32(rdr["CultureID"]),
                                UserCulture = rdr["UserCulture"].ToString(),
                                TimeZoneOffset = rdr["TimeZoneOffset"] == DBNull.Value ? -60 : Convert.ToInt32(rdr["TimeZoneOffset"]),
                                LastUpdatedDate = rdr.GetDateTime(rdr.GetOrdinal("LastUpdatedDate")),
                                UserName = rdr["UserName"].ToString(),
                                PostCount = Convert.ToInt32(rdr["PostCount"]),
                                Joined = rdr.GetDateTime(rdr.GetOrdinal("Joined")),
                                Avatar = rdr["Avatar"].ToString(),
                                EmailFormat = rdr["EmailFormat"].ToString(),
                                HPLAGroupID = Convert.ToInt32(rdr["HPLAGroupID"]),
                                TenantName = rdr["TenantName"].ToString(),
                                EmailConfirmed = Convert.ToBoolean(rdr["EmailConfirmed"]),
                                AccessFailedCount = Convert.ToInt32(rdr["AccessFailedCount"]),
                                LockoutEnabled = Convert.ToBoolean(rdr["LockoutEnabled"]),
                                LockoutEnd = rdr["LockoutEnd"] == DBNull.Value ? null : (DateTimeOffset?)rdr["LockoutEnd"],
                                DisplayName = rdr["DisplayName"].ToString(),
                                BatchEmails = Convert.ToBoolean(rdr["BatchEmails"]),
                                BatchEmailInterval = Convert.ToInt32(rdr["BatchEmailIntervalMins"]),
                                NewFeaturesFlag = Convert.ToBoolean(rdr["NewFeaturesFlag"]),
                                LastLoginTime = Convert.ToDateTime(rdr["LastLoginTime"]),
                                DefaultAvatarText = rdr["DefaultAvatarText"].ToString(),
                                DefaultAvatarColour = rdr["DefaultAvatarColour"].ToString()
                            };
                        }
                    }
                    return member;
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }

        public void DeleteMember(Member member, string auditUserName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USER_X_ProcessUserAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Action", "DELETE");

                    cmd.Parameters.AddWithValue("@MembershipUserID", (object)member.MembershipUserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)member.TenantID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FirstName", (object)member.FirstName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Initial", (object)member.Initial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", (object)member.LastName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CultureID", -1);
                    cmd.Parameters.AddWithValue("@UserCulture", (object)member.UserCulture ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TimeZoneOffset", (object)member.TimeZoneOffset ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastUpdatedDate", SqlHelper.IsDateTimeValidSqlDatetime(member.LastUpdatedDate) ? member.LastUpdatedDate : DateTime.Now);
                    cmd.Parameters.AddWithValue("@UserName", (object)member.UserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PostCount", (object)member.PostCount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Joined", SqlHelper.IsDateTimeValidSqlDatetime(member.Joined) ? member.Joined : DateTime.Now);
                    cmd.Parameters.AddWithValue("@EmailFormat", (object)member.EmailFormat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AuditUserName", (object)auditUserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HPLAGroupID", (object)member.HPLAGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BatchEmailIntervalMins", (object)member.BatchEmailInterval ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BatchEmail", (object)member.BatchEmails ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ConnectHealthAlertMinimumSeverity", (object)member.ConnectHealthAlertMinimumSeverity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AnomalyAlertLevel", (object)member.AnomalyAlertLevel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DefaultAvatarText", member.DefaultAvatarText);
                    cmd.Parameters.AddWithValue("@DefaultAvatarColour", member.DefaultAvatarColour);

                    SqlParameter NewUserID = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewUserID);

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

        public IEnumerable<Culture> GetCultures()
        {
            try
            {
                List<Culture> lstCulture = new List<Culture>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CULT_S_GetCultures", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        lstCulture.Add(new Culture()
                        {
                            CultureID = Convert.ToInt32(rdr["CultureID"]),
                            Name = rdr["Name"].ToString(),
                            DisplayName = rdr["DisplayName"].ToString()
                        });
                    }

                    con.Close();
                }
                return lstCulture;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task UpdateLastLoginInfo(string userAgentInfo, Guid tenantId, int userId)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(_connectionString))
                    using (SqlCommand cmd = new SqlCommand("USER_U_UpdateLastLoginInfo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TenantID", tenantId);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@UserAgentInfo", userAgentInfo);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }

        public Task<bool> GetUserNewFeatureFlag(Guid membershipUserId)
        {
            return Task.Run(() =>
            {
                bool newFeatureFlag;

                try
                {
                    using (SqlConnection con = new SqlConnection(_connectionString))
                    using (SqlCommand cmd = new SqlCommand("USER_S_GetNewFeatureFlag", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MembershipUserID", membershipUserId);

                        con.Open();
                        newFeatureFlag = (bool)cmd.ExecuteScalar();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                return newFeatureFlag;
            });
        }

        public async Task<Member> GetMemberByUsername(string username, Guid tenantId)
        {
            try
            {
                var allMembers = await GetMembers(tenantId);
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
