using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using Epi.QaContent.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.Web;

namespace Epi.QaContent.Business.Init
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CreateQaContentInitModule : IInitializableModule
    {
        private IContentRepository _contentRepository;

        public void Initialize(InitializationEngine context)
        {
            _contentRepository = context.Locate.ContentRepository();

            string enabledString = ConfigurationManager.AppSettings["Epi.QaContent.CreateQaContent"];
            if (bool.TryParse(enabledString, out var enabled) && enabled)
            {
                ContentReference rootReference = ContentReference.RootPage;

                if (ContentReference.IsNullOrEmpty(rootReference))
                {
                    var siteRepo = context.Locate.Advanced.GetInstance<ISiteDefinitionRepository>();
                    var firstSite = siteRepo.List().FirstOrDefault();
                    if (firstSite == null) return; 
                    rootReference = firstSite.RootPage;
                }

                var startReference = CreateStart(rootReference);

                var listReference = CreateList(startReference);

                for (int i = 0; i < 10; i++)
                {
                    CreateArticle(listReference, i);
                }
            }
        }

        private ContentReference CreateStart(ContentReference rootReference)
        {
            IContent startContent = _contentRepository.GetBySegment(rootReference, "test-content",
                CultureInfo.GetCultureInfo("en"));

            if (startContent == null)
            {
                var startPage = _contentRepository.GetDefault<StartPage>(rootReference);

                var faker = new StartPageFaker("QA Start Page", "test-content");
                faker.Populate(startPage);

                return _contentRepository.Save(startPage, SaveAction.Publish, AccessLevel.NoAccess);
            }

            return startContent.ContentLink;
        }

        private ContentReference CreateList(ContentReference startReference)
        {
            IContent listContent = _contentRepository.GetBySegment(startReference, "articles",
                CultureInfo.GetCultureInfo("en"));

            if (listContent == null)
            {
                var listPage = _contentRepository.GetDefault<ArticleList>(startReference);

                var faker = new ArticleListFaker("Articles", "articles");
                faker.Populate(listPage);

                return _contentRepository.Save(listPage, SaveAction.Publish, AccessLevel.NoAccess);
            }

            return listContent.ContentLink;
        }

        private void CreateArticle(ContentReference listReference, int index)
        {
            IContent articleContent = _contentRepository.GetBySegment(listReference, $"article-{index}",
                CultureInfo.GetCultureInfo("en"));

            if (articleContent == null)
            {
                var articlePage = _contentRepository.GetDefault<Article>(listReference);

                var faker = new ArticleFaker($"article-{index}");
                faker.Populate(articlePage);

                _contentRepository.Save(articlePage, SaveAction.Publish, AccessLevel.NoAccess);
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}