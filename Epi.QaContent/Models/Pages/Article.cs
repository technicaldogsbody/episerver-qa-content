using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace Epi.QaContent.Models.Pages
{
    [ContentType(DisplayName = "Article", GUID = "6e3996a8-7b04-4efa-a711-dadd393db64f", Description = "")]
    public class Article : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Page Title",
            Description = "Title of the page.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Snippet",
            Description = "Text that is shown on the Article List Page",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [UIHint(UIHint.Textarea)]
        public virtual string Snippet { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Tags",
            Description = "Tags for the article",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual IEnumerable<string> Tags { get; set; }

    }
}