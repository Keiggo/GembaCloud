using GembaCloud.Web.Models.TenantViewModels;
using System.Data;
using System.Data.SqlClient;

namespace GembaCloud.PlaywrightTests.Data
{
    public class TenantDataAccess
    {
        private readonly string _connectionString;

        public TenantDataAccess()
        {
            _connectionString = new ConfigDataAccess().GetConnectionStringAsync().Result;
        }


        public Task<List<Tenant>> GetTenantNamesAsync()
        {
            return Task.Run(() =>
            {
                List<Tenant> tenantList = new List<Tenant>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("TENA_S_GetTenants", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TimeZoneOffset", SqlDbType.Int).Value = -60;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        tenantList.Add(new Tenant
                        {
                            Name = rdr["Name"].ToString(),
                            TenantID = new Guid(rdr["TenantID"].ToString())
                        });
                    }
                }
                return tenantList;
            });
        }

/*        public Task<List<TenantForUser>> GetTenantNamesForUserAsync(int userId)
        {
            return Task.Run(() =>
            {
                List<TenantForUser> tenantList = new List<TenantForUser>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("TENA_S_GetTenantsForUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        tenantList.Add(new TenantForUser()
                        {
                            Name = rdr["Name"].ToString(),
                            TenantID = new Guid(rdr["TenantID"].ToString()),
                            HplaGroupId = Convert.ToInt32(rdr["HPLAGroupID"]),
                            IsDefault = Convert.ToBoolean(rdr["IsDefault"])
                        });
                    }
                }
                return tenantList;
            });
        }*/

        //To View all Tenants details    
        public IEnumerable<TenantDetails> GetAllTenants()
        {
            List<TenantDetails> lstTenant = new List<TenantDetails>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("TENA_S_GetTenants", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@TimeZoneOffset", SqlDbType.Int).Value = -60;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lstTenant.Add(new TenantDetails
                    {
                        TenantID = new Guid(rdr["TenantID"].ToString()),
                        TenantNumericID = Convert.ToInt32(rdr["TenantNumericID"]),
                        Name = rdr["Name"].ToString(),
                        StatusId = Convert.ToInt32(rdr["StatusID"]),
                        Status = rdr["Status"].ToString(),
                        Server = rdr["Server"].ToString(),
                        Database = rdr["Database"].ToString(),
                        Created = (DateTime)rdr["Created"],
                        Modified = rdr.GetDateTime(rdr.GetOrdinal("Modified")),
                        ModifiedBy = rdr["ModifiedBy"].ToString(),
                        ModifiedByAvatarText = rdr["ModifiedByAvatarText"].ToString(),
                        ModifiedByAvatarColour = rdr["ModifiedByAvatarColour"].ToString(),
                        MaintMode = Convert.ToBoolean(rdr["MaintMode"]),
                        IsDemo = Convert.ToBoolean(rdr["IsDemo"]),
                        AssetLimit = Convert.ToInt32(rdr["AssetLimit"]),
                        UserLimit = Convert.ToInt32(rdr["UserLimit"]),
                        MBUsed = (double)Math.Round((decimal)rdr["MBUsed"], 2, MidpointRounding.AwayFromZero),
                        DiskUsageLastUpdated = (DateTime)rdr["DiskUseageLastUpdated"]
                    });
                }
                con.Close();
            }
            return lstTenant;
        }

/*        public Task<TenantInsertOutputValues> AddTenant(TenantDetails Tenant, string User)
        {
            try
            {
                return Task.Run(() =>
                {
                    try
                    {
                        TenantInsertOutputValues outputValues = new TenantInsertOutputValues(new Guid(), null);
                        using (SqlConnection con = new SqlConnection(_connectionString))
                        using (SqlCommand cmd = new SqlCommand("TENA_X_ProcessTenantAction", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            //OUTPUT PARAMETER
                            cmd.Parameters.Add(new SqlParameter("@NewTenantID", SqlDbType.UniqueIdentifier)
                            {
                                Direction = ParameterDirection.Output
                            });

                            cmd.Parameters.Add(new SqlParameter("@NewHPLAGroupID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            });

                            //ACTION TYPE
                            cmd.Parameters.AddWithValue("@Action", "ADD");

                            cmd.Parameters.AddWithValue("@CultureID", -1);
                            cmd.Parameters.AddWithValue("@TenantID", (object)Tenant.TenantID ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Name", (object)Tenant.Name ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Status", (object)Tenant.StatusId ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Database", (object)Tenant.Database ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Server", (object)Tenant.Server ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@User", (object)User ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaintMode", (object)Tenant.MaintMode ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@IsDemo", (object)Tenant.IsDemo ?? DBNull.Value);
                            cmd.Parameters.Add("@DemoSource", SqlDbType.VarChar).Value = Tenant.DemoSource ?? string.Empty;
                            cmd.Parameters.AddWithValue("@AssetLimit", (object)Tenant.AssetLimit ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@UserLimit", (object)Tenant.UserLimit ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Modules", (object)Tenant.Modules ?? DBNull.Value);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            outputValues.NewTenantGuid = new Guid(cmd.Parameters["@NewTenantID"].Value.ToString());
                            outputValues.NewHPLAGroupID = Convert.ToInt32(cmd.Parameters["@NewHPLAGroupID"].Value);
                            con.Close();
                        }
                        return outputValues;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                        throw;
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                throw;
            }

        }*/

        public Task UpdateTenant(TenantDetails tenant, string user)
        {
                return Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(_connectionString))
                    using (SqlCommand cmd = new SqlCommand("TENA_X_ProcessTenantAction", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //OUTPUT PARAMETER
                        cmd.Parameters.Add(new SqlParameter("@NewTenantID", SqlDbType.UniqueIdentifier)
                        {
                            Direction = ParameterDirection.Output
                        });

                        cmd.Parameters.Add(new SqlParameter("@NewHPLAGroupID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        });

                        //ACTION TYPE
                        cmd.Parameters.AddWithValue("@Action", "MODIFY");

                        cmd.Parameters.AddWithValue("@CultureID", -1);
                        cmd.Parameters.AddWithValue("@TenantID", (object)tenant.TenantID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Name", (object)tenant.Name ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Status", (object)tenant.StatusId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Database", (object)tenant.Database ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Server", (object)tenant.Server ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@User", (object)user ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaintMode", (object)tenant.MaintMode ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@IsDemo", (object)tenant.IsDemo ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DemoSource", tenant.DemoSource ?? "");
                        cmd.Parameters.AddWithValue("@AssetLimit", (object)tenant.AssetLimit ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@UserLimit", (object)tenant.UserLimit ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Modules", (object)tenant.Modules ?? DBNull.Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                });
        }

        public async Task<TenantDetails> GetTenantData(Guid? id)
        {
            return await Task.Run(() =>
            {
                TenantDetails tenant = null;

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("TENA_S_GetTenant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TenantID", (object)id ?? DBNull.Value);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        tenant = new TenantDetails()
                        {
                            TenantID = new Guid(rdr["TenantID"].ToString()),
                            Name = rdr["Name"].ToString(),
                            StatusId = Convert.ToInt32(rdr["Status"]),
                            Server = rdr["Server"].ToString(),
                            Database = rdr["Database"].ToString(),
                            Created = (DateTime)rdr["Created"],
                            Modified = rdr.GetDateTime(rdr.GetOrdinal("Modified")),
                            ModifiedBy = rdr["ModifiedBy"].ToString(),
                            MaintMode = Convert.ToBoolean(rdr["MaintMode"]),
                            IsDemo = Convert.ToBoolean(rdr["IsDemo"]),
                            AssetLimit = Convert.ToInt32(rdr["AssetLimit"]),
                            UserLimit = Convert.ToInt32(rdr["UserLimit"]),
                            MBUsed = (double)Math.Round((decimal)rdr["MBUsed"], 2),
                            DiskUsageLastUpdated = (DateTime)rdr["DiskUseageLastUpdated"],
                            Modules = Convert.ToInt32(rdr["Modules"])
                        };
                    }
                }
                return tenant;
            });
        }

        public void DeleteTenant(Guid? id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("TENA_X_RemoveTenant", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TenantID", (object)id ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Task<IDictionary<int, string>> GetTenantStatusLookup()
        {
            return Task.Run(() =>
            {
                IDictionary<int, string> statuses = new Dictionary<int, string>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("TENA_S_GetTenantStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TimeZoneOffset", SqlDbType.Int).Value = -60;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        statuses.Add(Convert.ToInt32(rdr["TenantStatusID"]), rdr["Status"].ToString());
                    }
                }
                return statuses;
            });
        }

        public List<Guid> SetMaintenanceModeAllTenants(bool targetMaintenanceValue, int auditUserId)
        {
            var updatedTenantIds = new List<Guid>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("TENA_U_AllTenantMaintenanceMode", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaintMode", targetMaintenanceValue);
                cmd.Parameters.AddWithValue("@UserID", auditUserId);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    updatedTenantIds.Add(new Guid(rdr["TenantID"].ToString()));
                }
                con.Close();
            }
            return updatedTenantIds;
        }

 /*       public Task<AccountSettings> GetAccountSettings(Guid? id)
        {
            try
            {
                return Task.Run(() =>
                {
                    AccountSettings accountSettings = null;

                    using (SqlConnection con = new SqlConnection(_connectionString))
                    using (SqlCommand cmd = new SqlCommand("PARM_S_GetSystemParameters", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TenantID", (object)id ?? DBNull.Value);
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            accountSettings = new AccountSettings()
                            {
                                TenantID = id ?? new Guid(),
                                Modified = rdr.GetDateTime(rdr.GetOrdinal("Modified")),
                                User = rdr["ModifiedBy"].ToString(),
                                UseUSAWeek1 = Convert.ToBoolean(rdr["UseUSAWeek1"]),
                                GridDecimalPlaces = Convert.ToInt32(rdr["GridDecimalPlaces"]) != -1
                                    ? Convert.ToInt32(rdr["GridDecimalPlaces"])
                                    : 2,
                                ParetoTopX = Convert.ToInt32(rdr["ParetoTopX"]),
                                DynamicYAxisScale = Convert.ToBoolean(rdr["DynamicYAxisScale"]),
                                DashboardTrendWeekThreshold = Convert.ToInt32(rdr["DashboardTrendWeekThreshold"]),

                                IPWhitelist = rdr["IPWhitelist"].ToString().Split(',').Where(ip => IPAddress.TryParse(ip, out _))
                                    .Select(ip => new IP { IPAddress = ip }).ToList(),

                                MandatoryActionFields = Convert.ToBoolean(rdr["MandatoryActionFields"]),

                                CategoryList = rdr["DashboardKeyDowntimeCategories"].ToString().Split(',').Where(catId => int.TryParse(catId, out _))
                                    .Select(catId => new Category() { ID = int.TryParse(catId, out int r) ? r : -1 }).ToList(),

                                CategoryDescriptionList = rdr["CategoryDescriptionList"].ToString(),
                                DashboardKeyDowntimeCategories = rdr["DashboardKeyDowntimeCategories"].ToString(),
                                DashboardKeyDowntimeAssets = rdr["DashboardKeyDowntimeAssets"].ToString(),
                                ReasonDisplayFormat = Convert.ToInt32(rdr["ReasonDisplayFormat"]),
                                AnomalyHistoryDays = Convert.ToInt32(rdr["AnomalyHistoryDays"])
                            };
                        }
                    }
                    return accountSettings;
                });
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                throw;
            }
        }*/

/*        public void UpdateSystemParameters(AccountSettings AccountSettings, Guid id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("PARM_U_UpdateSystemParameters", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TenantID", (object)id ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)AccountSettings.Modified ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@User", (object)AccountSettings.User ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UseUSAWeek1", (object)AccountSettings.UseUSAWeek1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GridDecimalPlaces", (object)AccountSettings.GridDecimalPlaces ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParetoTopX", (object)AccountSettings.ParetoTopX ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DynamicYAxisScale", (object)AccountSettings.DynamicYAxisScale ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IPWhitelist", AccountSettings.IPWhitelist == null ? string.Empty : string.Join(",", AccountSettings.IPWhitelist.Select(i => i.IPAddress)));
                    cmd.Parameters.AddWithValue("@DashboardTrendWeekThreshold", (object)AccountSettings.DashboardTrendWeekThreshold ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MandatoryActionFields", (object)AccountSettings.MandatoryActionFields ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DashboardKeyDowntimeCategories", AccountSettings.CategoryList == null ? string.Empty : string.Join(",", AccountSettings.CategoryList.Where(i => i.Selected).Select(i => i.ID)));
                    cmd.Parameters.AddWithValue("@DashboardKeyDowntimeAssets", (object)AccountSettings.DashboardKeyDowntimeAssets ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReasonDisplayFormat", (object)AccountSettings.ReasonDisplayFormat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AnomalyHistoryDays", AccountSettings.AnomalyHistoryDays);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                throw;
            }
        }*/

/*        internal IEnumerable<Category> GetCategoryList(Guid guid, int? id = null)
        {
            try
            {
                List<Category> categoryList = new List<Category>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("EVEN_S_GetEventCategories", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TenantID", SqlDbType.UniqueIdentifier).Value = guid;
                    cmd.Parameters.Add("@CultureID", SqlDbType.Int).Value = 49;
                    cmd.Parameters.Add("@TimeZoneOffset", SqlDbType.Int).Value = -60;
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = id.HasValue ? id : (object)DBNull.Value;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        if (Convert.ToInt32(rdr["Unplanned"]) == 1)
                        {
                            Category Category = new Category
                            {
                                ID = Convert.ToInt32(rdr["CategoryID"]),
                                Description = rdr["Description"].ToString()
                            };

                            categoryList.Add(Category);
                        }                            
                    }
                }
                return categoryList;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                throw;
            }
        }*/

/*        public IEnumerable<Module> GetModules(int? id = null)
        {
            try
            {
                List<Module> modules = new List<Module>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("MODU_S_GetModules", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Module Module = new Module
                        {
                            ID = Convert.ToInt32(rdr["ID"]),
                            Description = rdr["Description"].ToString()
                        };

                        modules.Add(Module);
                    }
                }
                return modules;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                throw;
            }
        }*/

/*        public Task<Guid> GetSysAdminTenantIdAsync()
        {
            return Task.Run(() =>
            {
                Guid sysAdminTenantId;

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("TENA_S_GetSysAdminTenantID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@TenantID", SqlDbType.UniqueIdentifier)
                    {
                        Direction = ParameterDirection.Output
                    });

                    con.Open();
                    cmd.ExecuteNonQuery();
                    sysAdminTenantId = new Guid(cmd.Parameters["@TenantID"].Value.ToString());
                    con.Close();
                }
                return sysAdminTenantId;
            });
        }*/

        public async Task<Guid> GetTenantId(string tenantName)
        {
            List<Tenant> allTenants = await GetTenantNamesAsync();
            Tenant tenant = allTenants.Find(item => item.Name == tenantName);

            return tenant.TenantID;
        }
    }
}
