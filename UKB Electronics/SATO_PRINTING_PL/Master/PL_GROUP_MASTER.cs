﻿using SATO_PRINTING_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO_PRINTING_PL
{

    #region Group Master
    public class PL_GROUP_MASTER : Common
    {
        public string GroupName { get; set; }
        public bool Add { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool HasRight { get; set; }

    }
    #endregion

}
