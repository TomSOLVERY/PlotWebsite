using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOfPlots.Models
{
    public class AnswerModel
    {
        public Int32 Id { get; set; }
        public String Content { get; set; }
        public QuestionModel Question { get; set; }
    }
}
