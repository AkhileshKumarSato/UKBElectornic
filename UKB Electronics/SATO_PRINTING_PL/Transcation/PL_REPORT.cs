using SATO_PRINTING_COMMON;

namespace SATO_PRINTING_PL
{
    public class PL_REPORT:Common
    {
        public string RPT_Type { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string PartNo { get; set; }
        public string LineNo { get; set; }

    }
}
