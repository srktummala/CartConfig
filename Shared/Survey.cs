using System;
using System.Collections.Generic;
using System.Text;

namespace CartConfig.Shared
{
    public class Survey
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }        
        public string Question { get; set; }
        public int AnswerId { get; set; }        
        public string Answer { get; set; }
    }
}
