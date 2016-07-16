using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DAL;
using Utility;
using ENTITY;
namespace BAL
{
    public class EmployeeBAL : CommonBALFunctions, IEmployeeBAL
    {
        IEmployeeDAL objDAL = null;
        public EmployeeBAL()
        {
            objDAL = DALFactory.EmployeeFactory();
        }
        #region Login
        public List<LoginResponse> Login(LoginRequest objReq)
        {
            try
            {
                return (List<LoginResponse>)ConvertCls.ConvertTo<LoginResponse>(objDAL.Login(objReq));

            }
            catch (Exception ex)
            {
                ServerLog.BeginInvoke(MethodBase.GetCurrentMethod().Name, ex.Message, null, null);
                List<LoginResponse> objResp = new List<LoginResponse>();
                LoginResponse obj = new LoginResponse();
                obj.IS_SUCCESS = false;
                obj.RESPONSE_CODE = 12;
                obj.RESPONSE_MESSAGE = "Server Error";
                objResp.Add(obj);
                return objResp;
            }
        }
        public List<LogoutResponse> Logout(LogoutRequest objReq)
        {
            try
            {
                return (List<LogoutResponse>)ConvertCls.ConvertTo<LogoutResponse>(objDAL.Logout(objReq));

            }
            catch (Exception ex)
            {
                ServerLog.BeginInvoke(MethodBase.GetCurrentMethod().Name, ex.Message, null, null);
                List<LogoutResponse> objResp = new List<LogoutResponse>();
                LogoutResponse obj = new LogoutResponse();
                obj.IS_SUCCESS = false;
                obj.RESPONSE_CODE = 12;
                obj.RESPONSE_MESSAGE = "Server Error";
                objResp.Add(obj);
                return objResp;
            }
        }
        public List<UserImgPathResponse> UserImgPath(UserImgPathRequest objReq)
        {
            try
            {
                return (List<UserImgPathResponse>)ConvertCls.ConvertTo<UserImgPathResponse>(objDAL.UserImgPath(objReq));

            }
            catch (Exception ex)
            {
                ServerLog.BeginInvoke(MethodBase.GetCurrentMethod().Name, ex.Message, null, null);
                List<UserImgPathResponse> objResp = new List<UserImgPathResponse>();
                UserImgPathResponse obj = new UserImgPathResponse();
                obj.IS_SUCCESS = false;
                obj.RESPONSE_CODE = 12;
                obj.RESPONSE_MESSAGE = "Server Error";
                objResp.Add(obj);
                return objResp;
            }
        }
        
        #endregion
        public List<ForgetPwdResponse> ForgetPwd(ForgetPwdRequest objReq)
        {
            try
            {
                return (List<ForgetPwdResponse>)ConvertCls.ConvertTo<ForgetPwdResponse>(objDAL.ForgetPwd(objReq));

            }
            catch (Exception ex)
            {
                ServerLog.BeginInvoke(MethodBase.GetCurrentMethod().Name, ex.Message, null, null);
                List<ForgetPwdResponse> objResp = new List<ForgetPwdResponse>();
                ForgetPwdResponse obj = new ForgetPwdResponse();
                obj.IS_SUCCESS = false;
                obj.RESPONSE_CODE = 12;
                obj.RESPONSE_MESSAGE = "Server Error";
                objResp.Add(obj);
                return objResp;
            }
        }
        public List<ResetPwdResponse> ResetPwd(ResetPwdRequest objReq)
        {
            try
            {
                return (List<ResetPwdResponse>)ConvertCls.ConvertTo<ResetPwdResponse>(objDAL.ResetPwd(objReq));

            }
            catch (Exception ex)
            {
                ServerLog.BeginInvoke(MethodBase.GetCurrentMethod().Name, ex.Message, null, null);
                List<ResetPwdResponse> objResp = new List<ResetPwdResponse>();
                ResetPwdResponse obj = new ResetPwdResponse();
                obj.IS_SUCCESS = false;
                obj.RESPONSE_CODE = 12;
                obj.RESPONSE_MESSAGE = "Server Error";
                objResp.Add(obj);
                return objResp;
            }
        }
        public List<ForgetPwdResponse> UnlockPwd(ForgetPwdRequest objReq)
        {
            try
            {
                return (List<ForgetPwdResponse>)ConvertCls.ConvertTo<ForgetPwdResponse>(objDAL.UnlockPwd(objReq));

            }
            catch (Exception ex)
            {
                ServerLog.BeginInvoke(MethodBase.GetCurrentMethod().Name, ex.Message, null, null);
                List<ForgetPwdResponse> objResp = new List<ForgetPwdResponse>();
                ForgetPwdResponse obj = new ForgetPwdResponse();
                obj.IS_SUCCESS = false;
                obj.RESPONSE_CODE = 12;
                obj.RESPONSE_MESSAGE = "Server Error";
                objResp.Add(obj);
                return objResp;
            }
        }
        public List<PasswordPolicyResponse> PasswordPolicy(PasswordPolicyRequest objReq)
        {
            try
            {
                return (List<PasswordPolicyResponse>)ConvertCls.ConvertTo<PasswordPolicyResponse>(objDAL.PasswordPolicy(objReq));

            }
            catch (Exception ex)
            {
                ServerLog.BeginInvoke(MethodBase.GetCurrentMethod().Name, ex.Message, null, null);
                List<PasswordPolicyResponse> objResp = new List<PasswordPolicyResponse>();
                PasswordPolicyResponse obj = new PasswordPolicyResponse();
                obj.IS_SUCCESS = false;
                obj.RESPONSE_CODE = 12;
                obj.RESPONSE_MESSAGE = "Server Error";
                objResp.Add(obj);
                return objResp;
            }
        }
        public List<UpdatePasswordPolicyResponse> UpdatePasswordPolicy(UpdatePasswordPolicyRequest objReq)
        {
            try
            {
                return (List<UpdatePasswordPolicyResponse>)ConvertCls.ConvertTo<UpdatePasswordPolicyResponse>(objDAL.UpdatePasswordPolicy(objReq));

            }
            catch (Exception ex)
            {
                ServerLog.BeginInvoke(MethodBase.GetCurrentMethod().Name, ex.Message, null, null);
                List<UpdatePasswordPolicyResponse> objResp = new List<UpdatePasswordPolicyResponse>();
                UpdatePasswordPolicyResponse obj = new UpdatePasswordPolicyResponse();
                obj.IS_SUCCESS = false;
                obj.RESPONSE_CODE = 12;
                obj.RESPONSE_MESSAGE = "Server Error";
                objResp.Add(obj);
                return objResp;
            }
        }
    }

    public interface IEmployeeBAL
    {
        #region Login
        List<LoginResponse> Login(LoginRequest objReq);
        List<LogoutResponse> Logout(LogoutRequest objReq);
        List<UserImgPathResponse> UserImgPath(UserImgPathRequest objReq);
        #endregion
        List<ForgetPwdResponse> ForgetPwd(ForgetPwdRequest objReq);
        List<ResetPwdResponse> ResetPwd(ResetPwdRequest objReq);
        List<ForgetPwdResponse> UnlockPwd(ForgetPwdRequest objReq);
        List<PasswordPolicyResponse> PasswordPolicy(PasswordPolicyRequest objReq);
        List<UpdatePasswordPolicyResponse> UpdatePasswordPolicy(UpdatePasswordPolicyRequest objReq);
    }
}
