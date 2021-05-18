using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CartConfig.Shared
{
    public class AssistanceRequest
    {
        [Key]
        public int AssistanceRequestID { get; set; }
        public int RulesEligibilityID { get; set; }
        public DateTime? RequestDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string RequestType { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string State { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ServiceCenter { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string County { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string IsLandInState { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string IsTheProducerInterested { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string TypeOfClient { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Priority { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string YearsFarming { get; set; }


    }
}
