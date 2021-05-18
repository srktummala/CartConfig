using System;
using System.Collections.Generic;
using System.Text;

namespace CartConfig.Shared
{
    public class ConfigItems
    {
        public int ConfigItemsId { get; set; }
        public int FarmsBillId { get; set; }
        public FarmBill FarmsBill { get; set; }
        public int ProgramId { get; set; }
        public Programs Programs { get; set; }
        public int ProgramComponentId { get; set; }
        public ProgramComponent ProgramComponent { get; set; }
        public bool EnrollmentType { get; set; }
        public bool Duration { get; set; }
        public bool EasementType { get; set; }
        public bool PaymentRateSource { get; set; }
        public bool PracticeSchedule { get; set; }
        public bool CARTAssessmentRequired { get; set; }
        public bool CARTRankingRequired { get; set; }
        public bool ApplicationRequired { get; set; }
    }
}
