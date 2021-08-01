using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models.Gallery;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LeagueOfPlots.TagHelpers
{
    public class PagingTagHelper : TagHelper
    {
        public IPaginator Model { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "nav";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("aria-label", "Pagination");
            output.Attributes.SetAttribute("class", "paging");

            if (Model.Previous != null)
            {
                output.Content.AppendHtml($"<a href=\"{Model.Previous}\" rel=\"prev\">&lt; Précédent</a>");
            }
            else
            {
                output.Content.AppendHtml("<span>&lt; Précédent</span>");
            }

            output.Content.AppendHtml(" | ");

            if (Model.Next != null)
            {
                output.Content.AppendHtml($"<a href=\"{Model.Next}\" rel=\"next\">Suivant &gt;</a>");
            }
            else
            {
                output.Content.AppendHtml("<span>Suivant &gt;</span>");
            }
        }
    }
}
