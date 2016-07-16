using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Drawing;

using System.Management;
using System.ComponentModel;
namespace Utility
{
    /// <summary>
    /// this class handles configurations of the application
    /// </summary>
    /// 

    public static class Config
    {

        public enum Country
        {
            UnitedKingdom,
            UnitedStates,
            India
        }
        public enum BillTypes
        {
            PORevision,
            PurchaseReturn,
            ClaimIssue,
            ClaimReceipt
        }

        public static string defaultFileFolder()
        {

            try
            {
                return ConfigurationManager.AppSettings["DefaultImagePath"];
            }
            catch
            {
                throw;
            }
        }

        public static string defaultUrl()
        {
            try
            {
                return ConfigurationManager.AppSettings["DefaultURL"];
            }
            catch
            {
                throw;
            }
        }



    }
}
