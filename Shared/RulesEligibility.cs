using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CartConfig.Shared
{
    public class RulesEligibility
    {
        [Key]
        public int RulesEligibilityID { get; set; }
        public int FarmBillId { get; set; }
        public int ProgramId { get; set; }
        public int ProgramComponentId { get; set; }
        public int ContractId { get; set; }
        public int JurisdictionId { get; set; }
        public int StatusID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "bit")]
        public bool IsEnrollmentType { get; set; }
        [Column(TypeName = "bit")]
        public bool IsDuration { get; set; }
        [Column(TypeName = "bit")]
        public bool IsEasementType { get; set; }
        [Column(TypeName = "bit")]
        public bool IsPaymentRateSource { get; set; }
        [Column(TypeName = "bit")]
        public bool IsPracticeSchedule { get; set; }
        [Column(TypeName = "bit")]
        public bool IsCARTAssessmentRequired { get; set; }

        [Column(TypeName = "bit")]
        public bool IsCARTRankingRequired { get; set; }

        [Column(TypeName = "bit")]
        public bool IsApplicationRequired { get; set; }
        public int ProgramRuleId { get; set; }

    }
}
