using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ENTITY;
using System.Data.SqlClient;

/// <summary>
/// Created By:   MOHAMED AZHARUDEEN M
/// Created Date: 22 AUG 2014
/// </summary>



namespace DAL
{
    public class EmployeeDAL:DataBaseOperations,IEmployeeDAL
    {
        public DataTable Login(LoginRequest objReq)
        {
            sqlCommand = new SqlCommand("Login_Proc");
            sqlCommand.Parameters.Add("@EMAIL",SqlDbType.NVarChar).Value = objReq.EMAIL;
            sqlCommand.Parameters.Add("@PASS",SqlDbType.NVarChar).Value = objReq.PASS;
            sqlCommand.Parameters.Add("@IP", SqlDbType.NVarChar).Value = objReq.IP;
            return ExtractData(sqlCommand);
        }
        public DataTable Logout(LogoutRequest objReq)
        {
            sqlCommand = new SqlCommand("Logout_Proc");
            sqlCommand.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = objReq.USERID;
            return ExtractData(sqlCommand);
        }
        
        public DataTable UserImgPath(UserImgPathRequest objReq)
        {
            sqlCommand = new SqlCommand("UpdateUserImgPath_Proc");
            sqlCommand.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = objReq.USERID;
            sqlCommand.Parameters.Add("@PATH", SqlDbType.NVarChar).Value = objReq.PATH;
            return ExtractData(sqlCommand);
        }
        public DataTable ForgetPwd(ForgetPwdRequest objReq)
        {
            sqlCommand = new SqlCommand("ForgetPassword_Proc");
            sqlCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = objReq.EMAIL;
            return ExtractData(sqlCommand);
        }
        public DataTable ResetPwd(ResetPwdRequest objReq)
        {
            sqlCommand = new SqlCommand("ResetPassword_Proc");
            sqlCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = objReq.EMAIL;
            sqlCommand.Parameters.Add("@OLD_PASS", SqlDbType.NVarChar).Value = objReq.OLD_PASS;
            sqlCommand.Parameters.Add("@NEW_PASS", SqlDbType.NVarChar).Value = objReq.NEW_PASS;
            return ExtractData(sqlCommand);
        }
        public DataTable UnlockPwd(ForgetPwdRequest objReq)
        {
            sqlCommand = new SqlCommand("UnlockPassword_Proc");
            sqlCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = objReq.EMAIL;
            return ExtractData(sqlCommand);
        }
        public DataTable PasswordPolicy(PasswordPolicyRequest objReq)
        {
            sqlCommand = new SqlCommand("SelectPasswordPolicy_Proc");
            sqlCommand.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = objReq.USERID;
            return ExtractData(sqlCommand);
        }
        public DataTable UpdatePasswordPolicy(UpdatePasswordPolicyRequest objReq)
        {
            sqlCommand = new SqlCommand("UpdatePasswordPolicy_Proc");
            sqlCommand.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = objReq.USERID;
            sqlCommand.Parameters.Add("@NUMCHAR", SqlDbType.Bit).Value = objReq.NUMCHAR;
            sqlCommand.Parameters.Add("@PLEN", SqlDbType.Int).Value = objReq.PLEN;
            sqlCommand.Parameters.Add("@PEXP", SqlDbType.Int).Value = objReq.PEXP;
            sqlCommand.Parameters.Add("@POLD", SqlDbType.Int).Value = objReq.POLD;
            sqlCommand.Parameters.Add("@SCHAR", SqlDbType.Bit).Value = objReq.SCHAR;
            return ExtractData(sqlCommand);
        }
    }
    public interface IEmployeeDAL
    {
        #region Login
        DataTable Login(LoginRequest objReq);
        DataTable Logout(LogoutRequest objReq);
        DataTable UserImgPath(UserImgPathRequest objReq);
        #endregion
        DataTable ForgetPwd(ForgetPwdRequest objReq);
        DataTable ResetPwd(ResetPwdRequest objReq);
        DataTable UnlockPwd(ForgetPwdRequest objReq);
        DataTable PasswordPolicy(PasswordPolicyRequest objReq);
        DataTable UpdatePasswordPolicy(UpdatePasswordPolicyRequest objReq);
    }
}
