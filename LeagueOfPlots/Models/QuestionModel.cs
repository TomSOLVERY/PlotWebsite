using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOfPlots.Models
{
    public class QuestionModel
    {
        public Int32 Id { get; set; }
        public String Content { get; set; }
        public Int32 AnswerId { get; set; }
        public AnswerModel Answer { get; set; }
    }
}
