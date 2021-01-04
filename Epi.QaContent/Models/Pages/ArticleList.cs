using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace Epi.QaContent.Models.Pages
{
    [ContentType(DisplayName = "Article List", GUID = "df988eb8-4a5d-46c9-bdbe-b2622284f1ab", Description = "")]
    [AvailableContentTypes(Include = new[] { typeof(Article) })]
    public class ArticleList : PageData
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
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

    }
}