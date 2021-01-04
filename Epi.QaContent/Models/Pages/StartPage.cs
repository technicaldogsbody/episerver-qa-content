using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace Epi.QaContent.Models.Pages
{
    [ContentType(DisplayName = "Start Page", GUID = "f29ae829-0db0-4410-96f8-63918cdd8eec", Description = "")]
    [AvailableContentTypes(Include = new[] { typeof(ArticleList) })]
    public class StartPage : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

    }
}