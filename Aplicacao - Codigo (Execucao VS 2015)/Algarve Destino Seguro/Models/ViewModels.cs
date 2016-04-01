using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Algarve_Destino_Seguro.Models
{
    public class ThemeContentViewModel
    {
        public string ThemeTitle { get; set; }
        public string LanguageCode { get; set; }
        public string TranslatedTitle { get; set; }
        public bool Visibility { get; set; }
        public HttpPostedFileBase Document { get; set; }
        public string DocumentPath { get; set; }
    }

    public class TopicContentViewModel
    {
        public string TopicThemeTitle { get; set; }
        public string TopicTitle { get; set; }
        public string LanguageCode { get; set; }
        public string TranslatedTitle { get; set; }
        public bool Visibility { get; set; }
        public HttpPostedFileBase Document { get; set; }
        public string DocumentPath { get; set; }
    }

    public class SubTopicContentViewModel
    {
        public string SubTopicTopicThemeTitle { get; set; }
        public string SubTopicTopicTitle { get; set; }
        public string SubTopicTitle { get; set; }
        public string LanguageCode { get; set; }
        public string TranslatedTitle { get; set; }
        public bool Visibility { get; set; }
        public HttpPostedFileBase Document { get; set; }
        public string DocumentPath { get; set; }
    }

    public class ThemeViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Visibility { get; set; }
        public HttpPostedFileBase Icon { get; set; }
        public string IconPath { get; set; }
    }

    public class TopicViewModel
    {
        public string ThemeTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Visibility { get; set; }
        public HttpPostedFileBase Icon { get; set; }
        public string IconPath { get; set; }
    }

    public class SubTopicViewModel
    {
        public string TopicThemeTitle { get; set; }
        public string TopicTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Visibility { get; set; }
        public HttpPostedFileBase Icon { get; set; }
        public string IconPath { get; set; }
    }
}