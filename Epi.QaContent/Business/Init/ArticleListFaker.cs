﻿using Bogus;
using Epi.QaContent.Models.Pages;
using EPiServer.Core;

namespace Epi.QaContent.Business.Init
{
    public sealed class ArticleListFaker : Faker<ArticleList>
    {
        public ArticleListFaker(string pageName, string urlSegment)
        {
            RuleFor(page => page.Name, () => pageName);
            RuleFor(page => page.Title, faker => faker.WaffleTitle());
            RuleFor(page => page.URLSegment, () => urlSegment);
            RuleFor(page => page.MainBody, faker => new XhtmlString(faker.WaffleHtml(3, false)));
        }
    }
}