using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models.Gallery;
using LeagueOfPlots.ViewModels;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LeagueOfPlots.TagHelpers
{
    [HtmlTargetElement("img", Attributes = "photo, type")]
    public class PhotoTagHelper : TagHelper
    {
        public ViewModelPhoto Photo { get; set; }
        public ImageType Type { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //string thumbnail = Photo.Thumbnail;

            //if (string.IsNullOrEmpty(thumbnail))
            //{
            //    output.SuppressOutput();
            //    return;
            //}

            //output.Attributes.SetAttribute("width", (int)Type);
            //output.Attributes.SetAttribute("height", height);
            //output.Attributes.SetAttribute("alt", Photo.Name);
            //output.Attributes.SetAttribute("src", thumbnail);

            //if (Type != ImageType.Full)
            //{
            //    string thumb = Photo.GetThumbnailLink((int)ImageType.Thumbnail, out int thumbHeight);
            //    string cover = Photo.GetThumbnailLink((int)ImageType.Cover, out int coverHeight);
            //    output.Attributes.SetAttribute("srcset", $"{thumb} 1x, {cover} 2x");
            //}
        }
    }
}
