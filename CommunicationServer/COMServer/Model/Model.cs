using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMServer
{

    #region User Master
    public class User : Common
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string Group { get; set; }
        public string  Active { get; set; }
        public string RegId { get; set; }
        public string Plant { get; set; }
    }
    #endregion

    #region InOut Process
    public class InAndOut : Common
    {
        public string FromPlant { get; set; }
        public string ToPlant { get; set; }
        public string DocNo { get; set; }
        public string RFIDTag { get; set; }
        
    }
    #endregion
}
