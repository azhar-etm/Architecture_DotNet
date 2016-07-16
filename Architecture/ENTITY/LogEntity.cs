using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

/*
 * Created By   : M.Mohamed Azharudeen 
 * Date On      : 22 Jan 2014          
 */

namespace ENTITY
{

    #region CreateUserLog
    [DataContract]
    public class CreateUserLogRequest : CommonRequestEntity
    {
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string LOGIN_SYSTEM_NAME { get; set; }
        [DataMember]
        public string LOGIN_MAC { get; set; }
        [DataMember]
        public string LOGIN_STS { get; set; }
        [DataMember]
        public DateTime LOGIN_TS { get; set; }
        [DataMember]
        public DateTime LOGOUT_TS { get; set; }

    }

    [DataContract]
    public class CreateUserLogResponse : CommonEntity
    {
        [DataMember]
        public int USR_LOG_ID { get; set; }
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string LOGIN_SYSTEM_NAME { get; set; }
        [DataMember]
        public string LOGIN_MAC { get; set; }
        [DataMember]
        public string LOGIN_STS { get; set; }
        [DataMember]
        public DateTime LOGIN_TS { get; set; }
        [DataMember]
        public DateTime LOGOUT_TS { get; set; }

    }
    #endregion

    #region SelectUserLog
    [DataContract]
    public class SelectUserLogRequest : CommonRequestEntity
    {
        [DataMember]
        public int USR_LOG_ID { get; set; }

    }

    [DataContract]
    public class SelectUserLogResponse : CommonEntity
    {
        [DataMember]
        public int USR_LOG_ID { get; set; }
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string LOGIN_SYSTEM_NAME { get; set; }
        [DataMember]
        public string LOGIN_MAC { get; set; }
        [DataMember]
        public string LOGIN_STS { get; set; }
        [DataMember]
        public DateTime LOGIN_TS { get; set; }
        [DataMember]
        public DateTime LOGOUT_TS { get; set; }

    }
    #endregion

    #region UpdateUserLog
    [DataContract]
    public class UpdateUserLogRequest : CommonRequestEntity
    {
        [DataMember]
        public int USR_LOG_ID { get; set; }
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string LOGIN_SYSTEM_NAME { get; set; }
        [DataMember]
        public string LOGIN_MAC { get; set; }
        [DataMember]
        public string LOGIN_STS { get; set; }
        [DataMember]
        public DateTime LOGIN_TS { get; set; }
        [DataMember]
        public DateTime LOGOUT_TS { get; set; }

    }

    [DataContract]
    public class UpdateUserLogResponse : CommonEntity
    {
        [DataMember]
        public int USR_LOG_ID { get; set; }
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string LOGIN_SYSTEM_NAME { get; set; }
        [DataMember]
        public string LOGIN_MAC { get; set; }
        [DataMember]
        public string LOGIN_STS { get; set; }
        [DataMember]
        public DateTime LOGIN_TS { get; set; }
        [DataMember]
        public DateTime LOGOUT_TS { get; set; }

    }
    #endregion

    #region DeleteUserLog
    [DataContract]
    public class DeleteUserLogRequest : CommonRequestEntity
    {
        [DataMember]
        public int USR_LOG_ID { get; set; }

    }

    [DataContract]
    public class DeleteUserLogResponse : CommonEntity
    {

    }
    #endregion

    #region CreateDataModified
    [DataContract]
    public class CreateDataModifiedRequest : CommonRequestEntity
    {
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string TBL_NAME { get; set; }
        [DataMember]
        public int TBL_ROW_ID { get; set; }
        [DataMember]
        public string MOD_ACTN { get; set; }
        [DataMember]
        public string TBL_CLMN_OLD_VAL { get; set; }
        [DataMember]
        public string TBL_CLMN_NEW_VAL { get; set; }

    }

    [DataContract]
    public class CreateDataModifiedResponse : CommonEntity
    {
        [DataMember]
        public int DATA_MOD_ID { get; set; }
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string TBL_NAME { get; set; }
        [DataMember]
        public int TBL_ROW_ID { get; set; }
        [DataMember]
        public string MOD_ACTN { get; set; }
        [DataMember]
        public string TBL_CLMN_OLD_VAL { get; set; }
        [DataMember]
        public string TBL_CLMN_NEW_VAL { get; set; }

    }
    #endregion

    #region SelectDataModified
    [DataContract]
    public class SelectDataModifiedRequest : CommonRequestEntity
    {
        [DataMember]
        public int DATA_MOD_ID { get; set; }

    }

    [DataContract]
    public class SelectDataModifiedResponse : CommonEntity
    {
        [DataMember]
        public int DATA_MOD_ID { get; set; }
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string TBL_NAME { get; set; }
        [DataMember]
        public int TBL_ROW_ID { get; set; }
        [DataMember]
        public string MOD_ACTN { get; set; }
        [DataMember]
        public string TBL_CLMN_OLD_VAL { get; set; }
        [DataMember]
        public string TBL_CLMN_NEW_VAL { get; set; }

    }
    #endregion

    #region UpdateDataModified
    [DataContract]
    public class UpdateDataModifiedRequest : CommonRequestEntity
    {
        [DataMember]
        public int DATA_MOD_ID { get; set; }
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string TBL_NAME { get; set; }
        [DataMember]
        public int TBL_ROW_ID { get; set; }
        [DataMember]
        public string MOD_ACTN { get; set; }
        [DataMember]
        public string TBL_CLMN_OLD_VAL { get; set; }
        [DataMember]
        public string TBL_CLMN_NEW_VAL { get; set; }

    }

    [DataContract]
    public class UpdateDataModifiedResponse : CommonEntity
    {
        [DataMember]
        public int DATA_MOD_ID { get; set; }
        [DataMember]
        public int USR_ID { get; set; }
        [DataMember]
        public string TBL_NAME { get; set; }
        [DataMember]
        public int TBL_ROW_ID { get; set; }
        [DataMember]
        public string MOD_ACTN { get; set; }
        [DataMember]
        public string TBL_CLMN_OLD_VAL { get; set; }
        [DataMember]
        public string TBL_CLMN_NEW_VAL { get; set; }

    }
    #endregion

    #region DeleteDataModified
    [DataContract]
    public class DeleteDataModifiedRequest : CommonRequestEntity
    {
        [DataMember]
        public int DATA_MOD_ID { get; set; }

    }

    [DataContract]
    public class DeleteDataModifiedResponse : CommonEntity
    {

    }
    #endregion

    #region CreateDataBaseBackup
    [DataContract]
    public class CreateDataBaseBackupRequest : CommonRequestEntity
    {
        [DataMember]
        public int ORG_ID { get; set; }
        [DataMember]
        public int CRTD_BY { get; set; }
        [DataMember]
        public string BCKUP_LOC { get; set; }
        [DataMember]
        public string BCKUP_NOTS { get; set; }

    }

    [DataContract]
    public class CreateDataBaseBackupResponse : CommonEntity
    {
        [DataMember]
        public int DB_BCKUP_ID { get; set; }
        [DataMember]
        public int ORG_ID { get; set; }
        [DataMember]
        public int CRTD_BY { get; set; }
        [DataMember]
        public string BCKUP_LOC { get; set; }
        [DataMember]
        public string BCKUP_NOTS { get; set; }

    }
    #endregion

    #region SelectDataBaseBackup
    [DataContract]
    public class SelectDataBaseBackupRequest : CommonRequestEntity
    {
        [DataMember]
        public int DB_BCKUP_ID { get; set; }

    }

    [DataContract]
    public class SelectDataBaseBackupResponse : CommonEntity
    {
        [DataMember]
        public int DB_BCKUP_ID { get; set; }
        [DataMember]
        public int ORG_ID { get; set; }
        [DataMember]
        public int CRTD_BY { get; set; }
        [DataMember]
        public string BCKUP_LOC { get; set; }
        [DataMember]
        public string BCKUP_NOTS { get; set; }

    }
    #endregion

    #region UpdateDataBaseBackup
    [DataContract]
    public class UpdateDataBaseBackupRequest : CommonRequestEntity
    {
        [DataMember]
        public int DB_BCKUP_ID { get; set; }
        [DataMember]
        public int ORG_ID { get; set; }
        [DataMember]
        public int CRTD_BY { get; set; }
        [DataMember]
        public string BCKUP_LOC { get; set; }
        [DataMember]
        public string BCKUP_NOTS { get; set; }

    }

    [DataContract]
    public class UpdateDataBaseBackupResponse : CommonEntity
    {
        [DataMember]
        public int DB_BCKUP_ID { get; set; }
        [DataMember]
        public int ORG_ID { get; set; }
        [DataMember]
        public int CRTD_BY { get; set; }
        [DataMember]
        public string BCKUP_LOC { get; set; }
        [DataMember]
        public string BCKUP_NOTS { get; set; }

    }
    #endregion

    #region DeleteDataBaseBackup
    [DataContract]
    public class DeleteDataBaseBackupRequest : CommonRequestEntity
    {
        [DataMember]
        public int DB_BCKUP_ID { get; set; }

    }

    [DataContract]
    public class DeleteDataBaseBackupResponse : CommonEntity
    {

    }
    #endregion

}
