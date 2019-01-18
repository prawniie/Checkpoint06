using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint_06
{
    public class Ravioli
    {
        public int Id { get; set; }
        public DateTime PackageDate { get; set; }
        public DateTime BestBeforeDate
        {
            get
            {
                return BestBeforeDate;
            }
            set
            {
                BestBeforeDate = PackageDate.AddMonths(6);
            } 
        }
    }
}
