﻿using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using FujiyBlog.Core.DomainObjects;
using FujiyBlog.Core.EntityFramework;

namespace FujiyBlog.Core.Services
{
    public class FeedGenerator
    {
        private readonly SettingRepository settingRepository;
        private readonly FeedRepository feedRepository;

        public FeedGenerator(SettingRepository settingRepository, FeedRepository feedRepository)
        {
            this.settingRepository = settingRepository;
            this.feedRepository = feedRepository;
        }

        public string GetBlog<T>(string feedUrl, Func<User, string> getAuthorUrl, Func<Post, string> getPostUrl) where T : SyndicationFeedFormatter
        {
            SyndicationFeed feed = new SyndicationFeed(settingRepository.BlogName, settingRepository.BlogDescription, new Uri(feedUrl));

            foreach (User user in feedRepository.GetAllUsers())
            {
                feed.Authors.Add(new SyndicationPerson(user.Email, user.DisplayName, getAuthorUrl(user)));
            }

            foreach (Category category in feedRepository.GetAllCategories())
            {
                feed.Categories.Add(new SyndicationCategory(category.Name));
            }

            List<SyndicationItem> items = new List<SyndicationItem>(settingRepository.PostsPerPage);

            foreach (Post post in feedRepository.GetPosts(settingRepository.PostsPerPage))
            {
                string content = post.Content ?? string.Empty;

                int moreIndex = content.IndexOf("[more]", StringComparison.OrdinalIgnoreCase);
                if (moreIndex >= 0)
                {
                    content = content.Remove(moreIndex, 6);
                }

                items.Add(new SyndicationItem(
                              post.Title,
                              new TextSyndicationContent(content, TextSyndicationContentKind.Html), 
                              new Uri(getPostUrl(post)),
                              post.Id.ToString(),
                              post.LastModificationDate));
            }

            feed.Items = items;

            SyndicationFeedFormatter feedFormatter;
            
            if (typeof(T) == typeof(Rss20FeedFormatter))
            {
                feedFormatter= new Rss20FeedFormatter(feed);
            }
            else if (typeof(T) == typeof(Atom10FeedFormatter))
            {
                feedFormatter = new Atom10FeedFormatter(feed);
            }
            else
            {
                return null;
            }

            StringBuilder rssBuilder = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(rssBuilder))
            {
                feedFormatter.WriteTo(writer);
            }
            return rssBuilder.ToString();
        }
    }
}
