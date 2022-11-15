using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.DL
{
    public class RefAcademicCalendar
    {
        public int AcademicCalendarId { get; set; }
        public string Name { get; set; }
        public RefAcademicTerm RefAcademicTerm { get; set; }
        public int AcademicTermId { get; set; }

        public List<AcademicCalendarDetail> AcademicCalendarDetails { get; set; }

    }
}
