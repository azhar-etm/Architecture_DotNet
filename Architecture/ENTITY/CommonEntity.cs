using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

/*
 * Created By   : M.Mohamed Azharudeen 
 * Date On      : 21 Jan 2014          
 */

namespace ENTITY
{
    [DataContract]
    public abstract class CommonEntity
    {
        [DataMember]
        public bool IS_SUCCESS { get; set; }
        [DataMember]
        public int RESPONSE_CODE { get; set; }
        [DataMember]
        public string RESPONSE_MESSAGE { get; set; }

    }

    [DataContract]
    public abstract class CommonRequestEntity
    {
        [DataMember]
        public string USERID { get; set; }
        
    }
}
