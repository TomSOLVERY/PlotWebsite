using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LeagueOfPlots.TagHelpers
{
    [HtmlTargetElement("plot-modal")]
    public class ModalTagHelper : TagHelper
    {
        [HtmlAttributeName("id")]
        public String Id { get; set; } = "main-modal";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "modal fade align-middle");
            output.Attributes.Add("id", this.Id);
            output.Attributes.Add("style", "display:none;");
        }
    }
}
