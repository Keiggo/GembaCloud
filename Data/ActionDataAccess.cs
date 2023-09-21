using GembaCloud.Web.Models.ActionViewModels;
using GembaCloud.Web.Models.UploadModels;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace GembaCloud.PlaywrightTests.Data
{
    public class ActionDataAccess
    {
        private readonly string _connectionString;

        // connection to db
        public ActionDataAccess()
        {
            _connectionString = new ConfigDataAccess().GetConnectionStringAsync().Result;
        }

        //To View Searched Actions
        public IEnumerable<GembaAction> SearchAllActions(Guid TenantID, int UserID, ActionSearch Search)
        {
            try
            {
                List<GembaAction> lstAction = new List<GembaAction>();
                if (TenantID != Search.TenantID) return lstAction;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("ACTI_S_ActionSearch", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddRange(Search.BuildSqlParametersCollection());
                        cmd.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            GembaAction Action = new GembaAction();
                            #region Header
                            Action.ActionID = Convert.ToInt32(rdr["ActionID"]);
                            Action.TenantID = new Guid(rdr["TenantID"].ToString());
                            Action.ParentActionID = rdr["ParentActionID"] as int?;
                            Action.ParentTitle = rdr["ParentTitle"].ToString();
                            Action.ChildActionID = rdr["ChildActionID"] as int?;
                            Action.ChildTitle = rdr["ChildTitle"].ToString();
                            Action.Title = rdr["Title"].ToString();
                            Action.TeamID = Convert.ToInt32(rdr["TeamID"]);
                            Action.TeamName = rdr["TeamName"].ToString();
                            Action.OwnerID = Convert.ToInt32(rdr["OwnerID"]);
                            Action.Owner = rdr["Owner"].ToString();
                            Action.OwnerAvatarText = rdr["OwnerAvatarText"].ToString();
                            Action.OwnerAvatarColour = rdr["OwnerAvatarColour"].ToString();
                            Action.AssignedID = rdr["AssignedID"] as int?;
                            Action.Assignee = rdr["Assignee"].ToString();
                            Action.AssigneeAvatarText = rdr["AssigneeAvatarText"].ToString();
                            Action.AssigneeAvatarColour = rdr["AssigneeAvatarColour"].ToString();
                            Action.DateRaised = (DateTime)rdr["RaisedDate"];
                            Action.DateDue = (DateTime)rdr["DueDate"];
                            Action.CategoryID = Convert.ToInt32(rdr["CategoryID"]);
                            Action.PriorityID = Convert.ToInt32(rdr["PriorityID"]);
                            Action.Priority = rdr["Priority"].ToString();
                            Action.Modified = rdr.GetDateTime(rdr.GetOrdinal("Modified"));
                            Action.ModifiedBy = rdr["ModifiedBy"].ToString();
                            Action.Closed = Convert.ToByte(rdr["Closed"]);
                            Action.ClosedDate = rdr["ClosedDate"] == DBNull.Value ? null : (DateTime?)rdr["ClosedDate"];
                            Action.ClosedBy = rdr["ClosedBy"].ToString();
                            Action.StatusProgress = Convert.ToInt32(rdr["StatusProgress"]);
                            Action.Progress = rdr["Progress"].ToString();
                            Action.StatusDescription = rdr["StatusDescription"].ToString();

                            #endregion Header

                            #region Misc
                            Action.EntityID = Convert.ToInt32(rdr["EntityID"]);
                            Action.CategoryDescription = rdr["CategoryDescription"].ToString();
                            Action.Entity = rdr["Entity"].ToString();
                            Action.Shift = rdr["Shift"].ToString();
                            Action.Part = rdr["Part"].ToString();
                            #endregion Misc

                            #region Describe

                            Action.ShiftID = Convert.ToInt32(rdr["ShiftID"]);
                            Action.PartID = Convert.ToInt32(rdr["PartID"]);
                            Action.Detail = rdr["Detail"].ToString();
                            #endregion Describe

                            #region Investigate
                            Action.ImmediateAction = rdr["ImmediateAction"].ToString();
                            Action.RootCause = rdr["RootCause"].ToString();
                            Action.InvestigationComplete = Convert.ToBoolean(rdr["InvestigationComplete"]);
                            #endregion Investigate

                            #region Identify Countermeasure
                            Action.Countermeasure = rdr["Countermeasure"].ToString();
                            Action.CountermeasurePlanned = Convert.ToBoolean(rdr["CountermeasurePlanned"]);
                            Action.CountermeasurePlannedDate = rdr["CountermeasurePlannedDate"] == DBNull.Value ? null : (DateTime?)rdr["CountermeasurePlannedDate"];
                            #endregion Identify Countermeasure

                            #region Countermeasure Implementation
                            Action.Implementation = rdr["Implementation"].ToString();
                            Action.CountermeasureImplemented = Convert.ToBoolean(rdr["Implemented"]);

                            #endregion Countermeasure Implementation

                            #region Review
                            Action.ResultDetails = rdr["Review"].ToString();
                            #endregion Review

                            lstAction.Add(Action);
                        }
                        con.Close();
                    }
                }
                return lstAction;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //To View all Action details 
        public IEnumerable<GembaAction> GetAllActions(Guid TenantID)
        {
            try
            {
                List<GembaAction> lstAction = new List<GembaAction>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("ACTI_S_GetAction", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TenantID", SqlDbType.UniqueIdentifier).Value = TenantID;
                        cmd.Parameters.Add("@CultureID", SqlDbType.Int).Value = 49;
                        cmd.Parameters.Add("@TimeZoneOffset", SqlDbType.Int).Value = -60;


                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            GembaAction Action = new GembaAction();
                            #region Header
                            Action.ActionID = Convert.ToInt32(rdr["ActionID"]);
                            Action.TenantID = new Guid(rdr["TenantID"].ToString());
                            Action.ParentActionID = rdr["ParentActionID"] as int?;
                            Action.ParentTitle = rdr["ParentTitle"].ToString();
                            Action.ChildActionID = rdr["ChildActionID"] as int?;
                            Action.ChildTitle = rdr["ChildTitle"].ToString();
                            Action.Title = rdr["Title"].ToString();
                            Action.TeamID = Convert.ToInt32(rdr["TeamID"]);
                            Action.TeamName = rdr["TeamName"].ToString();
                            Action.OwnerID = Convert.ToInt32(rdr["OwnerID"]);
                            Action.Owner = rdr["Owner"].ToString();
                            Action.AssignedID = rdr["AssignedID"] as int?;
                            Action.Assignee = rdr["Assignee"].ToString();
                            Action.DateRaised = (DateTime)rdr["RaisedDate"];
                            Action.DateDue = (DateTime)rdr["DueDate"];
                            Action.CategoryID = Convert.ToInt32(rdr["CategoryID"]);
                            Action.PriorityID = Convert.ToInt32(rdr["PriorityID"]);
                            Action.Modified = rdr.GetDateTime(rdr.GetOrdinal("Modified"));
                            Action.ModifiedBy = rdr["ModifiedBy"].ToString();
                            Action.Closed = Convert.ToByte(rdr["Closed"]);
                            Action.ClosedDate = rdr["ClosedDate"] == DBNull.Value ? null : (DateTime?)rdr["ClosedDate"];
                            Action.ClosedBy = rdr["ClosedBy"].ToString();
                            Action.StatusProgress = Convert.ToInt32(rdr["StatusProgress"]);
                            Action.Progress = rdr["Progress"].ToString();
                            Action.StatusDescription = rdr["StatusDescription"].ToString();

                            #endregion Header

                            #region Misc
                            Action.EntityID = Convert.ToInt32(rdr["EntityID"]);
                            Action.CategoryDescription = rdr["CategoryDescription"].ToString();
                            Action.Entity = rdr["Entity"].ToString();
                            Action.Shift = rdr["Shift"].ToString();
                            Action.Part = rdr["Part"].ToString();
                            #endregion Misc

                            #region Describe

                            Action.ShiftID = Convert.ToInt32(rdr["ShiftID"]);
                            Action.PartID = Convert.ToInt32(rdr["PartID"]);
                            Action.Detail = rdr["Detail"].ToString();
                            #endregion Describe

                            #region Investigate
                            Action.ImmediateAction = rdr["ImmediateAction"].ToString();
                            Action.RootCause = rdr["RootCause"].ToString();
                            Action.InvestigationComplete = Convert.ToBoolean(rdr["InvestigationComplete"]);
                            #endregion Investigate

                            #region Identify Countermeasure
                            Action.Countermeasure = rdr["Countermeasure"].ToString();
                            Action.CountermeasurePlanned = Convert.ToBoolean(rdr["CountermeasurePlanned"]);
                            Action.CountermeasurePlannedDate = rdr["CountermeasurePlannedDate"] == DBNull.Value ? null : (DateTime?)rdr["CountermeasurePlannedDate"];
                            #endregion Identify Countermeasure

                            #region Countermeasure Implementation
                            Action.Implementation = rdr["Implementation"].ToString();
                            Action.CountermeasureImplemented = Convert.ToBoolean(rdr["Implemented"]);

                            #endregion Countermeasure Implementation

                            #region Review
                            Action.ResultDetails = rdr["Review"].ToString();
                            #endregion Review

                            lstAction.Add(Action);
                        }
                        con.Close();
                    }
                }
                return lstAction;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Get the details of a particular Action  
        public IEnumerable<GembaAction> GetActionDashboard(int? id, Guid TenantID, int? OwnerID = null, int? AssigneeID = null)
        {
            try
            {
                if (!id.HasValue) throw new ApplicationException("No id in GetActionData request");
                List<GembaAction> lstAction = new List<GembaAction>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("ACTI_S_GetActionDashboard", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TenantID", SqlDbType.UniqueIdentifier).Value = TenantID;
                        cmd.Parameters.Add("@CultureID", SqlDbType.Int).Value = 49;
                        cmd.Parameters.Add("@TimeZoneOffset", SqlDbType.Int).Value = -60;
                        cmd.Parameters.Add("@TeamID", SqlDbType.Int).Value = id.HasValue ? id : (object)DBNull.Value;
                        cmd.Parameters.Add("@OwnerID", SqlDbType.VarChar).Value = (object)OwnerID ?? DBNull.Value;
                        cmd.Parameters.Add("@AssigneeID", SqlDbType.VarChar).Value = (object)AssigneeID ?? DBNull.Value;

                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            GembaAction action = new GembaAction();
                            #region Header
                            action.ActionID = Convert.ToInt32(rdr["ActionID"]);
                            action.TenantID = new Guid(rdr["TenantID"].ToString());
                            action.ParentActionID = rdr["ParentActionID"] as int?;
                            //Action.ChildActionID = rdr["ChildActionID"] as int?;
                            action.Title = rdr["Title"].ToString();
                            action.TeamID = Convert.ToInt32(rdr["TeamID"]);
                            action.TeamName = rdr["TeamName"].ToString();

                            action.OwnerID = Convert.ToInt32(rdr["OwnerID"]);
                            action.Owner = rdr["Owner"].ToString();
                            action.OwnerAvatarText = rdr["OwnerAvatarText"].ToString();
                            action.OwnerAvatarColour = rdr["OwnerAvatarColour"].ToString();

                            action.AssignedID = rdr["AssignedID"] as int?;
                            action.Assignee = rdr["Assignee"].ToString();
                            action.AssigneeAvatarText = rdr["AssigneeAvatarText"].ToString();
                            action.AssigneeAvatarColour = rdr["AssigneeAvatarColour"].ToString();

                            action.DateRaised = (DateTime)rdr["RaisedDate"];
                            action.DateDue = (DateTime)rdr["DueDate"];
                            action.CategoryID = Convert.ToInt32(rdr["CategoryID"]);
                            action.PriorityID = Convert.ToInt32(rdr["PriorityID"]);
                            action.Priority = rdr["Priority"].ToString();
                            action.Modified = rdr.GetDateTime(rdr.GetOrdinal("Modified"));
                            action.ModifiedBy = rdr["ModifiedBy"].ToString();
                            action.Closed = Convert.ToByte(rdr["Closed"]);
                            action.ClosedDate = rdr["ClosedDate"] == DBNull.Value ? null : (DateTime?)rdr["ClosedDate"];
                            action.ClosedBy = rdr["ClosedBy"].ToString();
                            action.StatusProgress = Convert.ToInt32(rdr["StatusProgress"]);
                            action.Progress = rdr["Progress"].ToString();
                            action.StatusDescription = rdr["StatusDescription"].ToString();

                            #endregion Header

                            #region Misc
                            action.EntityID = Convert.ToInt32(rdr["EntityID"]);
                            action.CategoryDescription = rdr["CategoryDescription"].ToString();
                            action.Entity = rdr["Entity"].ToString();
                            action.Shift = rdr["Shift"].ToString();
                            action.Part = rdr["Part"].ToString();
                            #endregion Misc

                            #region Describe

                            action.ShiftID = Convert.ToInt32(rdr["ShiftID"]);
                            action.PartID = Convert.ToInt32(rdr["PartID"]);
                            action.Detail = rdr["Detail"].ToString();
                            #endregion Describe

                            #region Investigate
                            action.ImmediateAction = rdr["ImmediateAction"].ToString();
                            action.RootCause = rdr["RootCause"].ToString();
                            action.InvestigationComplete = Convert.ToBoolean(rdr["InvestigationComplete"]);
                            #endregion Investigate

                            #region Identify Countermeasure
                            action.Countermeasure = rdr["Countermeasure"].ToString();
                            action.CountermeasurePlanned = Convert.ToBoolean(rdr["CountermeasurePlanned"]);
                            action.CountermeasurePlannedDate = rdr["CountermeasurePlannedDate"] == DBNull.Value ? null : (DateTime?)rdr["CountermeasurePlannedDate"];
                            #endregion Identify Countermeasure

                            #region Countermeasure Implementation
                            action.Implementation = rdr["Implementation"].ToString();
                            action.CountermeasureImplemented = Convert.ToBoolean(rdr["Implemented"]);

                            #endregion Countermeasure Implementation

                            #region Review
                            action.ResultDetails = rdr["Review"].ToString();
                            #endregion Review

                            action.FileCount = Convert.ToInt32(rdr["FileCount"]);
                            action.HasNonSystemComments = Convert.ToBoolean(rdr["HasNonSystemComments"]);

                            lstAction.Add(action);
                        }
                    }
                    return lstAction;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Get the details of a particular Action  
        public GembaAction GetActionData(int? id, Guid TenantID)
        {
            try
            {
                if (!id.HasValue) throw new ApplicationException("No id in GetActionData request");
                GembaAction action = new GembaAction();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("ACTI_S_GetAction", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TenantID", SqlDbType.UniqueIdentifier).Value = TenantID;
                        cmd.Parameters.Add("@CultureID", SqlDbType.Int).Value = 49;
                        cmd.Parameters.Add("@TimeZoneOffset", SqlDbType.Int).Value = -60;
                        cmd.Parameters.Add("@ActionID", SqlDbType.Int).Value = id.HasValue ? id : (object)DBNull.Value;

                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            #region Header
                            action.ActionID = Convert.ToInt32(rdr["ActionID"]);
                            action.TenantID = new Guid(rdr["TenantID"].ToString());
                            action.ParentActionID = rdr["ParentActionID"] as int?;
                            action.ParentTitle = rdr["ParentTitle"].ToString();
                            action.ChildActionID = rdr["ChildActionID"] as int?;
                            action.ChildTitle = rdr["ChildTitle"].ToString();
                            action.Title = rdr["Title"].ToString();
                            action.TeamID = Convert.ToInt32(rdr["TeamID"]);
                            action.OwnerID = Convert.ToInt32(rdr["OwnerID"]);
                            action.Owner = rdr["Owner"].ToString();
                            action.AssignedID = rdr["AssignedID"] as int?;
                            action.Assignee = rdr["Assignee"].ToString();
                            action.DateRaised = (DateTime)rdr["RaisedDate"];
                            action.DateDue = (DateTime)rdr["DueDate"];
                            action.CategoryID = Convert.ToInt32(rdr["CategoryID"]);
                            action.PriorityID = Convert.ToInt32(rdr["PriorityID"]);
                            //Action.Priority = rdr["Priority"].ToString();
                            action.Modified = rdr.GetDateTime(rdr.GetOrdinal("Modified"));
                            action.ModifiedBy = rdr["ModifiedBy"].ToString();
                            action.Closed = Convert.ToByte(rdr["Closed"]);
                            action.ClosedDate = rdr["ClosedDate"] == DBNull.Value ? null : (DateTime?)rdr["ClosedDate"];
                            action.ClosedBy = rdr["ClosedBy"].ToString();
                            action.StatusProgress = Convert.ToInt32(rdr["StatusProgress"]);

                            #endregion Header

                            #region Misc
                            action.EntityID = Convert.ToInt32(rdr["EntityID"]);
                            action.TeamName = rdr["TeamName"].ToString();
                            action.Progress = rdr["Progress"].ToString();
                            action.StatusDescription = rdr["StatusDescription"].ToString();
                            action.CategoryDescription = rdr["CategoryDescription"].ToString();
                            action.Entity = rdr["Entity"].ToString();
                            action.Shift = rdr["Shift"].ToString();
                            action.Part = rdr["Part"].ToString();
                            #endregion Misc

                            #region Describe

                            action.ShiftID = Convert.ToInt32(rdr["ShiftID"]);
                            action.PartID = Convert.ToInt32(rdr["PartID"]);
                            action.Detail = rdr["Detail"].ToString();
                            #endregion Describe

                            #region Investigate
                            action.ImmediateAction = rdr["ImmediateAction"].ToString();
                            action.RootCause = rdr["RootCause"].ToString();
                            action.InvestigationComplete = Convert.ToBoolean(rdr["InvestigationComplete"]);
                            #endregion Investigate

                            #region Identify Countermeasure
                            action.Countermeasure = rdr["Countermeasure"].ToString();
                            action.CountermeasurePlanned = Convert.ToBoolean(rdr["CountermeasurePlanned"]);
                            action.CountermeasurePlannedDate = rdr["CountermeasurePlannedDate"] == DBNull.Value ? null : (DateTime?)rdr["CountermeasurePlannedDate"];
                            #endregion Identify Countermeasure

                            #region Countermeasure Implementation
                            action.Implementation = rdr["Implementation"].ToString();
                            action.CountermeasureImplemented = Convert.ToBoolean(rdr["Implemented"]);

                            #endregion Countermeasure Implementation

                            #region Review
                            action.ResultDetails = rdr["Review"].ToString();
                            #endregion Review

                            action.FileCount = Convert.ToInt32(rdr["FileCount"]);
                        }
                    }
                    return action;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<UploadedFile> GetActionFiles(Guid tenantId, int actionId, int userId)
        {
            try
            {
                List<UploadedFile> uploadFiles = new List<UploadedFile>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("ACTI_S_GetActionFiles", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@TenantID", SqlDbType.UniqueIdentifier).Value = tenantId;
                        cmd.Parameters.Add("@ActionID", SqlDbType.Int).Value = actionId;
                        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;

                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            UploadedFile log = new UploadedFile
                            {
                                Id = Convert.ToInt32(rdr["ID"]),
                                FileId = Guid.Parse(rdr["FileID"].ToString()),
                                UserId = Convert.ToInt32(rdr["UserID"]),
                                OriginalFileName = rdr["OriginalFileName"].ToString(),
                                Path = rdr["Path"].ToString(),
                                Extension = rdr["Extension"].ToString(),
                                ContentDispositionInline = Convert.ToBoolean(rdr["ContentDispositionInline"]),
                                FontawesomeIcon = rdr["FontawesomeIcon"].ToString(),
                                MimeType = rdr["MIMEType"].ToString(),
                                SizeBytes = Convert.ToInt32(rdr["Bytes"]),
                                IsAttachment = Convert.ToBoolean(rdr["IsAttachment"]),
                                FileStatus = (UploadedFileStatus)Convert.ToInt32(rdr["FileStatusID"]),
                                Uploaded = Convert.ToDateTime(rdr["Uploaded"]),
                                UploadedBy = rdr["UploadedBy"].ToString()
                            };

                            uploadFiles.Add(log);
                        }
                        con.Close();
                    }
                }
                return uploadFiles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //To Add new Action record    
        public int AddGembaAction(GembaAction action, Guid tenantId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ACTI_X_ProcessActionAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Action", "ADD");
                    cmd.Parameters.AddWithValue("@CultureID", 49);

                    #region Header

                    cmd.Parameters.AddWithValue("@ActionID", (object)action.ActionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParentActionID", (object)action.ParentActionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Title", (object)action.Title ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TeamID", (object)action.TeamID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OwnerID", (object)action.OwnerID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@AssignedID", (object)action.AssignedID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@RaisedDate", (object)action.DateRaised ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@DueDate", (object)action.DateDue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", (object)action.CategoryID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Priority", (object)action.PriorityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)DateTime.Now ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", (object)action.ModifiedByID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@User", (object)action.ModifiedBy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Closed", (object)action.Closed ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClosedBy", (object)action.ClosedBy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClosedDate", (object)DBNull.Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StatusProgress", (object)action.StatusProgress ?? DBNull.Value);

                    #endregion Header

                    #region Misc
                    cmd.Parameters.AddWithValue("@EntityID", (object)action.EntityID ?? DBNull.Value);
                    #endregion Misc

                    #region Describe

                    cmd.Parameters.AddWithValue("@ShiftID", (object)action.ShiftID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PartID", (object)action.PartID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Detail", (object)action.Detail ?? DBNull.Value);
                    #endregion Describe

                    #region Investigate
                    cmd.Parameters.AddWithValue("@ImmediateAction", (object)action.ImmediateAction ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RootCause", (object)action.RootCause ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvestigationComplete", (object)action.InvestigationComplete ?? DBNull.Value);
                    #endregion Investigate

                    #region Identify Countermeasure
                    cmd.Parameters.AddWithValue("@Countermeasure", (object)action.Countermeasure ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountermeasurePlanned", (object)action.CountermeasurePlanned ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountermeasurePlannedDate", (object)action.CountermeasurePlannedDate ?? DBNull.Value);
                    #endregion Identify Countermeasure

                    #region Countermeasure Implementation
                    cmd.Parameters.AddWithValue("@Implementation", (object)action.Implementation ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Implemented", (object)action.CountermeasureImplemented ?? DBNull.Value);

                    #endregion Countermeasure Implementation

                    #region Review
                    cmd.Parameters.AddWithValue("@Review", (object)action.ResultDetails ?? DBNull.Value);
                    #endregion Review

                    if (action.UploadedFiles != null && action.UploadedFiles.Count() > 0)
                    {
                        cmd.Parameters.AddWithValue("FileJSON", JsonConvert.SerializeObject(action.UploadedFiles));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FileJSON", DBNull.Value);
                    }

                    SqlParameter NewActionID = new SqlParameter("@NewActionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewActionID);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    int ActionID = Convert.ToInt32(cmd.Parameters["@NewActionID"].Value);
                    con.Close();
                    return ActionID;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //To Update the records of a particluar Action  
        public void UpdateGembaAction(GembaAction action, Guid tenantId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ACTI_X_ProcessActionAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Action", "MODIFY");
                    cmd.Parameters.AddWithValue("@CultureID", 49);

                    #region Header

                    cmd.Parameters.AddWithValue("@ActionID", (object)action.ActionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)tenantId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParentActionID", (object)action.ParentActionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Title", (object)action.Title ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TeamID", (object)action.TeamID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OwnerID", (object)action.OwnerID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@AssignedID", (object)action.AssignedID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@RaisedDate", (object)action.DateRaised ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DueDate", (object)action.DateDue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", (object)action.CategoryID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Priority", (object)action.PriorityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)action.Modified ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", (object)action.ModifiedByID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@User", (object)action.ModifiedBy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClosedDate", (object)action.ClosedDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Closed", (object)action.Closed ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StatusProgress", (object)action.StatusProgress ?? DBNull.Value);

                    #endregion Header

                    #region Misc
                    cmd.Parameters.AddWithValue("@EntityID", (object)action.EntityID ?? DBNull.Value);
                    #endregion Misc

                    #region Describe

                    cmd.Parameters.AddWithValue("@ShiftID", (object)action.ShiftID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PartID", (object)action.PartID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Detail", (object)action.Detail ?? DBNull.Value);
                    #endregion Describe

                    #region Investigate
                    cmd.Parameters.AddWithValue("@ImmediateAction", (object)action.ImmediateAction ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RootCause", (object)action.RootCause ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvestigationComplete", (object)action.InvestigationComplete ?? DBNull.Value);
                    #endregion Investigate

                    #region Identify Countermeasure
                    cmd.Parameters.AddWithValue("@Countermeasure", (object)action.Countermeasure ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountermeasurePlanned", (object)action.CountermeasurePlanned ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountermeasurePlannedDate", (object)action.CountermeasurePlannedDate ?? DBNull.Value);
                    #endregion Identify Countermeasure

                    #region Countermeasure Implementation
                    cmd.Parameters.AddWithValue("@Implementation", (object)action.Implementation ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Implemented", (object)action.CountermeasureImplemented ?? DBNull.Value);

                    #endregion Countermeasure Implementation

                    #region Review
                    cmd.Parameters.AddWithValue("@Review", (object)action.ResultDetails ?? DBNull.Value);
                    #endregion Review

                    if (action.UploadedFiles != null && action.UploadedFiles.Count() > 0)
                    {
                        cmd.Parameters.AddWithValue("FileJSON", JsonConvert.SerializeObject(action.UploadedFiles));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FileJSON", DBNull.Value);
                    }

                    SqlParameter NewActionID = new SqlParameter("@NewActionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewActionID);

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

        //To Update the records of a particluar Action  
        public void CancelGembaAction(GembaAction Action, Guid TenantID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ACTI_X_ProcessActionAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Action", "CANCEL");
                    cmd.Parameters.AddWithValue("@CultureID", 49);

                    #region Header

                    cmd.Parameters.AddWithValue("@ActionID", (object)Action.ActionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)TenantID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParentActionID", (object)Action.ParentActionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Title", (object)Action.Title ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TeamID", (object)Action.TeamID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OwnerID", (object)Action.OwnerID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@AssignedID", (object)Action.AssignedID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@RaisedDate", (object)Action.DateRaised ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DueDate", (object)Action.DateDue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", (object)Action.CategoryID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Priority", (object)Action.PriorityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)Action.Modified ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", (object)Action.ModifiedByID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@User", (object)Action.ModifiedBy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClosedDate", (object)Action.ClosedDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Closed", (object)Action.Closed ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StatusProgress", (object)Action.StatusProgress ?? DBNull.Value);

                    #endregion Header

                    #region Misc
                    cmd.Parameters.AddWithValue("@EntityID", (object)Action.EntityID ?? DBNull.Value);
                    #endregion Misc

                    #region Describe

                    cmd.Parameters.AddWithValue("@ShiftID", (object)Action.ShiftID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PartID", (object)Action.PartID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Detail", (object)Action.Detail ?? DBNull.Value);
                    #endregion Describe

                    #region Investigate
                    cmd.Parameters.AddWithValue("@ImmediateAction", (object)Action.ImmediateAction ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RootCause", (object)Action.RootCause ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvestigationComplete", (object)Action.InvestigationComplete ?? DBNull.Value);
                    #endregion Investigate

                    #region Identify Countermeasure
                    cmd.Parameters.AddWithValue("@Countermeasure", (object)Action.Countermeasure ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountermeasurePlanned", (object)Action.CountermeasurePlanned ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountermeasurePlannedDate", (object)Action.CountermeasurePlannedDate ?? DBNull.Value);
                    #endregion Identify Countermeasure

                    #region Countermeasure Implementation
                    cmd.Parameters.AddWithValue("@Implementation", (object)Action.Implementation ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Implemented", (object)Action.CountermeasureImplemented ?? DBNull.Value);

                    #endregion Countermeasure Implementation

                    #region Review
                    cmd.Parameters.AddWithValue("@Review", (object)Action.ResultDetails ?? DBNull.Value);
                    #endregion Review

                    if (Action.UploadedFiles != null && Action.UploadedFiles.Count() > 0)
                    {
                        cmd.Parameters.AddWithValue("FileJSON", JsonConvert.SerializeObject(Action.UploadedFiles));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FileJSON", DBNull.Value);
                    }

                    SqlParameter NewActionID = new SqlParameter("@NewActionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewActionID);

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


        //To Delete the record on a particular Action  
        public void DeleteGembaAction(GembaAction Action, Guid TenantID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ACTI_X_ProcessActionAction", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@CultureID", 49);

                    #region Header

                    cmd.Parameters.AddWithValue("@ActionID", (object)Action.ActionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenantID", (object)TenantID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParentActionID", (object)Action.ParentActionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Title", (object)Action.Title ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TeamID", (object)Action.TeamID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OwnerID", (object)Action.OwnerID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@AssignedID", (object)Action.AssignedID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@RaisedDate", (object)Action.DateRaised ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DueDate", (object)Action.DateDue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", (object)Action.CategoryID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Priority", (object)Action.PriorityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modified", (object)DateTime.Now ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", (object)Action.ModifiedByID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@User", (object)Action.ModifiedBy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClosedDate", (object)DBNull.Value ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StatusProgress", (object)Action.StatusProgress ?? DBNull.Value);

                    #endregion Header

                    #region Misc
                    cmd.Parameters.AddWithValue("@EntityID", (object)Action.EntityID ?? DBNull.Value);
                    #endregion Misc

                    #region Describe

                    cmd.Parameters.AddWithValue("@ShiftID", (object)Action.ShiftID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PartID", (object)Action.PartID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Detail", (object)Action.Detail ?? DBNull.Value);
                    #endregion Describe

                    #region Investigate
                    cmd.Parameters.AddWithValue("@ImmediateAction", (object)Action.ImmediateAction ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RootCause", (object)Action.RootCause ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvestigationComplete", (object)Action.InvestigationComplete ?? DBNull.Value);
                    #endregion Investigate

                    #region Identify Countermeasure
                    cmd.Parameters.AddWithValue("@Countermeasure", (object)Action.Countermeasure ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountermeasurePlanned", (object)Action.CountermeasurePlanned ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountermeasurePlannedDate", (object)Action.CountermeasurePlannedDate ?? DBNull.Value);
                    #endregion Identify Countermeasure

                    #region Countermeasure Implementation
                    cmd.Parameters.AddWithValue("@Implementation", (object)Action.Implementation ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Implemented", (object)Action.CountermeasureImplemented ?? DBNull.Value);

                    #endregion Countermeasure Implementation

                    #region Review
                    cmd.Parameters.AddWithValue("@Review", (object)Action.ResultDetails ?? DBNull.Value);
                    #endregion Review

                    if (Action.UploadedFiles != null && Action.UploadedFiles.Count() > 0)
                    {
                        cmd.Parameters.AddWithValue("FileJSON", JsonConvert.SerializeObject(Action.UploadedFiles));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FileJSON", DBNull.Value);
                    }

                    SqlParameter NewActionID = new SqlParameter("@NewActionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(NewActionID);

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

        public IEnumerable<Priority> GetPriorities()
        {
            try
            {
                List<Priority> Priorities = new List<Priority>();

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PRIO_S_GetPriorities", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.Add("@ModuleID", SqlDbType.Int).Value = (id.HasValue) ? id : (object)DBNull.Value;

                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Priority Priority = new Priority
                            {
                                PriorityID = Convert.ToInt32(rdr["PriorityID"]),
                                Description = rdr["Priority"].ToString()
                            };

                            Priorities.Add(Priority);
                        }
                    }
                }
                return Priorities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GembaAction> GetActionByTitle(string title, Guid tenantId)
        {
            try
            {
                var allActions = GetAllActions(tenantId);
                var action = allActions.ToList().Find(item => item.Title == title);

                return action;
            }

            catch
            {
                throw new Exception("Can't find an Action with that title");
            }

        }
    }
}
