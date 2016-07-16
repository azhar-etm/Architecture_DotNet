using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

/*
 * Created By   : M.Mohamed Azharudeen 
 * Date On      : 22 Aug 2014  
 * Modified On  : 3 SEP 2014
 */

namespace ENTITY
{

    #region Login
    public class LoginRequest
    {
        [DataMember]
        public string EMAIL { get; set; }
        [DataMember]
        public string PASS { get; set; }
        [DataMember]
        public string IP { get; set; }
    
    }
    public class LoginResponse:CommonEntity
    {
        [DataMember]
        public string USERID { get; set; }
        [DataMember]
        public string EMAIL { get; set; }
        [DataMember]
        public string PASS { get; set; }
        [DataMember]
        public string MOBILE { get; set; }
        [DataMember]
        public DateTime LAST_LOGON { get; set; }
        [DataMember]
        public DateTime PREV_LOGON { get; set; }
        [DataMember]
        public string IP_ADDR_LAST { get; set; }
        [DataMember]
        public string IP_ADDR_PREV { get; set; }
        [DataMember]
        public string LANG { get; set; }
        [DataMember]
        public string USR_TYPE { get; set; }
        [DataMember]
        public string IMG_PATH { get; set; }
        [DataMember]
        public string NAME { get; set; }
        [DataMember]
        public string ADDR1 { get; set; }
        [DataMember]
        public string ADDR2 { get; set; }
        [DataMember]
        public string CITY { get; set; }
        [DataMember]
        public string REGION { get; set; }
        [DataMember]
        public string COUNTRY { get; set; }
        [DataMember]
        public string PINCODE { get; set; }
        [DataMember]
        public string MAIL1 { get; set; }
        [DataMember]
        public string MAIL2 { get; set; }
        [DataMember]
        public string PHONE1 { get; set; }
        [DataMember]
        public string PHONE2 { get; set; }
        [DataMember]
        public string PANCARD { get; set; }
        [DataMember]
        public string SRV_TAX { get; set; }
        [DataMember]
        public string ECC_NO { get; set; }
        [DataMember]
        public string CST_NO { get; set; }
        [DataMember]
        public string LST_NO { get; set; }
        [DataMember]
        public DateTime CRTD_TS { get; set; }
        [DataMember]
        public DateTime MOD_TS { get; set; }
        
    }

    public class LogoutRequest
    {
        [DataMember]
        public string USERID { get; set; }

    }
    public class LogoutResponse : CommonEntity
    {
        
    }

    public class UserImgPathRequest : CommonRequestEntity
    {
        [DataMember]
        public string EMAIL { get; set; }
        [DataMember]
        public string PATH { get; set; }

    }
    public class UserImgPathResponse : CommonEntity
    {

    }
    #endregion

    #region ForgetPassword
    public class ForgetPwdRequest
    {
        [DataMember]
        public string EMAIL { get; set; }

    }
    public class ForgetPwdResponse : CommonEntity
    {
        [DataMember]
        public string PASS { get; set; }
        [DataMember]
        public string EMAIL { get; set; }
    }

    #endregion

    #region ResetPassword
    public class ResetPwdRequest
    {
        [DataMember]
        public string EMAIL { get; set; }
        [DataMember]
        public string OLD_PASS { get; set; }
        [DataMember]
        public string NEW_PASS { get; set; }
    }
    public class ResetPwdResponse : CommonEntity
    {
        
    }
    #endregion

    public class PasswordPolicyRequest : CommonRequestEntity
    {
        
    }
    public class PasswordPolicyResponse : CommonEntity
    {
        [DataMember]
        public bool NUMCHAR { get; set; }
        [DataMember]
        public bool SCHAR { get; set; }
        [DataMember]
        public int PLEN { get; set; }
        [DataMember]
        public int PEXP { get; set; }
        [DataMember]
        public int POLD { get; set; }
    }

    public class UpdatePasswordPolicyRequest : CommonRequestEntity
    {
        [DataMember]
        public bool NUMCHAR { get; set; }
        [DataMember]
        public bool SCHAR { get; set; }
        [DataMember]
        public int PLEN { get; set; }
        [DataMember]
        public int PEXP { get; set; }
        [DataMember]
        public int POLD { get; set; }
    }
    public class UpdatePasswordPolicyResponse : CommonEntity
    {
        
    }

}
