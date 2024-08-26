using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VacuumTest
    {
        public int ID { get; set; }
        public string Barcode { get; set; }
        public int QualityID { get; set; }
        public string Quality { get; set; }
        public int ResultID { get; set; }
        public string Result { get; set; }
        public DateTime Datetime { get; set; }
        public int QualityPersonalID { get; set; }
        public string QualityPersonal { get; set; }
    }
}
