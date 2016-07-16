using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ENTITY;
using BAL;
using Utility;

namespace RMS_WEB.Models
{
    public class EmployeeModel:IEmployeeModel
    {
        IEmployeeBAL objBAL = null;
        public EmployeeModel()
        {
            objBAL = BALFactory.EmployeeFactory();
        
        }
        public bool IS_ERROR { set; get; }
        public bool IS_ERROR1 { set; get; }
        public string ERROR_MSG { set; get; }
        public string BROWSER { get; set; }
        public decimal VERSION { get; set; }
        public string USERNAME { get; set; }
        public string PWD { get; set; }

        #region Login
        public List<LoginResponse> LoginDetail { get; set; }
        public List<LogoutResponse> LogoutDetail { get; set; }
        public List<ForgetPwdResponse> PwdDetail { get; set; }
        public List<ResetPwdResponse> ResetPwdDetail { get; set; }
        public List<PasswordPolicyResponse> pwdpolicy { get; set; }
        public List<UpdatePasswordPolicyResponse> updatepwdpolicy { get; set; }
        public List<LoginResponse> Login(LoginRequest objReq)
        {
            return objBAL.Login(objReq);
        }
        public List<LogoutResponse> Logout(LogoutRequest objReq)
        {
            return objBAL.Logout(objReq);
        }        
        public List<UserImgPathResponse> UserImgPath(UserImgPathRequest objReq)
        {
            return objBAL.UserImgPath(objReq);
        }
        #endregion
        public List<ForgetPwdResponse> ForgetPwd(ForgetPwdRequest objReq)
        {
            return objBAL.ForgetPwd(objReq);
        }
        public List<ResetPwdResponse> ResetPwd(ResetPwdRequest objReq)
        {
            return objBAL.ResetPwd(objReq);
        }
        public List<ForgetPwdResponse> UnlockPwd(ForgetPwdRequest objReq)
        {
            return objBAL.UnlockPwd(objReq);
        }
        public List<PasswordPolicyResponse> PasswordPolicy(PasswordPolicyRequest objReq)
        {
            return objBAL.PasswordPolicy(objReq);
        }
        public List<UpdatePasswordPolicyResponse> UpdatePasswordPolicy(UpdatePasswordPolicyRequest objReq)
        {
            return objBAL.UpdatePasswordPolicy(objReq);
        }
    }
    public interface IEmployeeModel
    {
        bool IS_ERROR { set; get; }
        string ERROR_MSG { set; get; }
        bool IS_ERROR1 { set; get; }
        string BROWSER { get; set; }
        decimal VERSION { get; set; }
        string USERNAME { get; set; }
        string PWD { get; set; }

        List<LoginResponse> LoginDetail { get; set; }
        List<LogoutResponse> LogoutDetail { get; set; }
        List<ForgetPwdResponse> PwdDetail { get; set; }
        List<ResetPwdResponse> ResetPwdDetail { get; set; }
        List<PasswordPolicyResponse> pwdpolicy { get; set; }
        List<UpdatePasswordPolicyResponse> updatepwdpolicy { get; set; }

        List<LoginResponse> Login(LoginRequest objReq);
        List<LogoutResponse> Logout(LogoutRequest objReq);
        List<UserImgPathResponse> UserImgPath(UserImgPathRequest objReq);
        List<ForgetPwdResponse> ForgetPwd(ForgetPwdRequest objReq);
        List<ResetPwdResponse> ResetPwd(ResetPwdRequest objReq);
        List<ForgetPwdResponse> UnlockPwd(ForgetPwdRequest objReq);
        List<PasswordPolicyResponse> PasswordPolicy(PasswordPolicyRequest objReq);
        List<UpdatePasswordPolicyResponse> UpdatePasswordPolicy(UpdatePasswordPolicyRequest objReq);
    }
}