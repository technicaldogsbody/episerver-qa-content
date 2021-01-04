using Bogus;
using Epi.QaContent.Models.Pages;
using EPiServer.Core;

namespace Epi.QaContent.Business.Init
{
    public sealed class ArticleFaker : Faker<Article>
    {
        public ArticleFaker(string urlSegment)
        {
            RuleFor(page => page.Name, faker => faker.WaffleTitle());
            RuleFor(page => page.Title, faker => faker.WaffleTitle());
            RuleFor(page => page.URLSegment, () => urlSegment);
            RuleFor(page => page.Snippet, faker => faker.WaffleText(1, false));
            RuleFor(page => page.MainBody, faker => new XhtmlString(faker.WaffleHtml(3, false)));
            RuleFor(page => page.Tags, faker => faker.Make(6, () => faker.Lorem.Word()));
        }
    }
}