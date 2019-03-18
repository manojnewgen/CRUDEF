﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEF.TagHelpers
{
    public class Email : TagHelper
    {
        private const string EmailDomain = "thinksys";
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var address = MailTo + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:"+address);
            output.Content.SetContent(address);
        }

    }
}
