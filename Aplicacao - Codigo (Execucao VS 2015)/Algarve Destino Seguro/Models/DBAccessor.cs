using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Algarve_Destino_Seguro.Models
{
    public class DBAccessor
    {
        // Languages

        public static IEnumerable<Language> GetLanguages()
        {
            IEnumerable<Language> languages = new List<Language>();
            using (ADSEntities db = new ADSEntities())
            {
                languages = db.Language.ToList();
            }
            return languages;
        }

        public static string CreateLanguage(Language language)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    db.Language.Add(language);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar o idioma, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditLanguage(Language language)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    Language dbLanguage = db.Language.Find(language.Code);
                    dbLanguage.Name = language.Name;
                    
                    db.Entry(dbLanguage).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar o idioma, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeleteLanguage(Language language)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    Language dbLanguage = db.Language.Find(language.Code);
                    db.Language.Remove(dbLanguage);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar o idioma, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // Themes

        public static IEnumerable<Theme> GetThemes()
        {
            IEnumerable<Theme> themes = new List<Theme>();
            using (ADSEntities db = new ADSEntities())
            {
                themes = db.Theme.ToList();
            }
            return themes;
        }

        public static Theme GetTheme(string id)
        {
            Theme theme = null;
            using (ADSEntities db = new ADSEntities())
            {
                theme = db.Theme.Find(id);
            }
            return theme;
        }

        public static string EditTheme(Theme theme)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    Theme dbTheme = db.Theme.Find(theme.Title);
                    dbTheme.Description = theme.Description;
                    dbTheme.Visibility = theme.Visibility;
                    dbTheme.Icon = theme.Icon;

                    db.Entry(dbTheme).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar o tema, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // Theme Contents

        public static IEnumerable<ThemeContent> GetThemeContents(Theme theme)
        {
            IEnumerable<ThemeContent> themeContents = new List<ThemeContent>();
            using (ADSEntities db = new ADSEntities())
            {
                themeContents = db.ThemeContent.Where(tc => tc.ThemeTitle.Equals(theme.Title)).ToList();
            }
            return themeContents;
        }

        public static ThemeContent GetThemeContent(string id, string themeTitle)
        {
            ThemeContent themeContent = null;
            using (ADSEntities db = new ADSEntities())
            {
                themeContent = db.ThemeContent.Find(themeTitle, id);
            }
            return themeContent;
        }

        public static string CreateThemeContent(ThemeContent themeContent)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    db.ThemeContent.Add(themeContent);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar o conteúdo do tema, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditThemeContent(ThemeContent themeContent)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    ThemeContent dbThemeContent = db.ThemeContent.Find(themeContent.ThemeTitle, themeContent.LanguageCode);
                    dbThemeContent.TranslatedTitle = themeContent.TranslatedTitle;
                    dbThemeContent.Visibility = themeContent.Visibility;
                    dbThemeContent.Document= themeContent.Document;

                    db.Entry(dbThemeContent).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar o conteúdo do tema, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeleteThemeContent(ThemeContent themeContent)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    ThemeContent dbThemeContent = db.ThemeContent.Find(themeContent.ThemeTitle, themeContent.LanguageCode);
                    db.ThemeContent.Remove(dbThemeContent);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar o conteúdo do tema, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // Topics

        public static IEnumerable<Topic> GetTopics(Theme theme)
        {
            IEnumerable<Topic> topics = new List<Topic>();
            using (ADSEntities db = new ADSEntities())
            {
                topics = db.Topic.Where(t => t.ThemeTitle.Equals(theme.Title)).ToList();
            }
            return topics;
        }

        public static Topic GetTopic(string id, string themeTitle)
        {
            Topic topic = null;
            using (ADSEntities db = new ADSEntities())
            {
                topic = db.Topic.Find(id, themeTitle);
            }
            return topic;
        }

        public static string CreateTopic(Topic topic)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    db.Topic.Add(topic);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar o tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditTopic(Topic topic)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    Topic dbTopic = db.Topic.Find(topic.Title, topic.ThemeTitle);
                    dbTopic.Description = topic.Description;
                    dbTopic.Visibility = topic.Visibility;
                    dbTopic.Icon = topic.Icon;

                    db.Entry(dbTopic).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar o tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeleteTopic(Topic topic)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    Topic dbTopic = db.Topic.Find(topic.Title, topic.ThemeTitle);
                    db.Topic.Remove(dbTopic);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar o tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // Topic Contents

        public static IEnumerable<TopicContent> GetTopicContents(Topic topic)
        {
            IEnumerable<TopicContent> topicContents = new List<TopicContent>();
            using (ADSEntities db = new ADSEntities())
            {
                topicContents = db.TopicContent.Where(tc => tc.TopicThemeTitle.Equals(topic.ThemeTitle) && tc.TopicTitle.Equals(topic.Title)).ToList();
            }
            return topicContents;
        }

        public static TopicContent GetTopicContent(string id, string topicTitle, string topicThemeTitle)
        {
            TopicContent topicContent = null;
            using (ADSEntities db = new ADSEntities())
            {
                topicContent = db.TopicContent.Find(topicTitle, topicThemeTitle, id);
            }
            return topicContent;
        }

        public static string CreateTopicContent(TopicContent topicContent)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    db.TopicContent.Add(topicContent);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar o conteúdo do tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditTopicContent(TopicContent topicContent)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    TopicContent dbTopicContent = db.TopicContent.Find(topicContent.TopicTitle, topicContent.TopicThemeTitle, topicContent.LanguageCode);
                    dbTopicContent.TranslatedTitle = topicContent.TranslatedTitle;
                    dbTopicContent.Visibility = topicContent.Visibility;
                    dbTopicContent.Document = topicContent.Document;

                    db.Entry(dbTopicContent).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar o conteúdo do tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeleteTopicContent(TopicContent topicContent)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    TopicContent dbTopicContent = db.TopicContent.Find(topicContent.TopicTitle, topicContent.TopicThemeTitle, topicContent.LanguageCode);
                    db.TopicContent.Remove(dbTopicContent);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar o conteúdo do tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // SubTopics

        public static IEnumerable<SubTopic> GetSubTopics(Topic topic)
        {
            IEnumerable<SubTopic> subTopics = new List<SubTopic>();
            using (ADSEntities db = new ADSEntities())
            {
                subTopics = db.SubTopic.Where(st => st.TopicThemeTitle.Equals(topic.ThemeTitle) && st.TopicTitle.Equals(topic.Title)).ToList();
            }
            return subTopics;
        }

        public static SubTopic GetSubTopic(string id, string topicTitle, string topicThemeTitle)
        {
            SubTopic subTopic = null;
            using (ADSEntities db = new ADSEntities())
            {
                subTopic = db.SubTopic.Find(id, topicTitle, topicThemeTitle);
            }
            return subTopic;
        }

        public static string CreateSubTopic(SubTopic subTopic)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    db.SubTopic.Add(subTopic);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar o sub-tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditSubTopic(SubTopic subTopic)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    SubTopic dbSubTopic = db.SubTopic.Find(subTopic.Title, subTopic.TopicTitle, subTopic.TopicThemeTitle);
                    dbSubTopic.Description = subTopic.Description;
                    dbSubTopic.Visibility = subTopic.Visibility;
                    dbSubTopic.Icon = subTopic.Icon;

                    db.Entry(dbSubTopic).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar o sub-tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeleteSubTopic(SubTopic subTopic)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    SubTopic dbSubTopic = db.SubTopic.Find(subTopic.Title, subTopic.TopicTitle, subTopic.TopicThemeTitle);
                    db.SubTopic.Remove(dbSubTopic);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar o sub-tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // SubTopic Contents

        public static IEnumerable<SubTopicContent> GetSubTopicContents(SubTopic subTopic)
        {
            IEnumerable<SubTopicContent> subTopicContents = new List<SubTopicContent>();
            using (ADSEntities db = new ADSEntities())
            {
                subTopicContents = db.SubTopicContent.Where(stc => stc.SubTopicTopicThemeTitle.Equals(subTopic.TopicThemeTitle) && stc.SubTopicTopicTitle.Equals(subTopic.TopicTitle) && stc.SubTopicTitle.Equals(subTopic.Title)).ToList();
            }
            return subTopicContents;
        }

        public static SubTopicContent GetSubTopicContent(string id, string subTopicTitle, string subTopicTopicTitle, string subTopicTopicThemeTitle)
        {
            SubTopicContent subTopicContent = null;
            using (ADSEntities db = new ADSEntities())
            {
                subTopicContent = db.SubTopicContent.Find(subTopicTitle, subTopicTopicTitle, subTopicTopicThemeTitle, id);
            }
            return subTopicContent;
        }

        public static string CreateSubTopicContent(SubTopicContent subTopicContent)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    db.SubTopicContent.Add(subTopicContent);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar o conteúdo do sub-tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditSubTopicContent(SubTopicContent subTopicContent)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    SubTopicContent dbSubTopicContent = db.SubTopicContent.Find(subTopicContent.SubTopicTitle, subTopicContent.SubTopicTopicTitle, subTopicContent.SubTopicTopicThemeTitle, subTopicContent.LanguageCode);
                    dbSubTopicContent.TranslatedTitle = subTopicContent.TranslatedTitle;
                    dbSubTopicContent.Visibility = subTopicContent.Visibility;
                    dbSubTopicContent.Document = subTopicContent.Document;

                    db.Entry(dbSubTopicContent).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar o conteúdo do sub-tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeleteSubTopicContent(SubTopicContent subTopicContent)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    SubTopicContent dbSubTopicContent = db.SubTopicContent.Find(subTopicContent.SubTopicTitle, subTopicContent.SubTopicTopicTitle, subTopicContent.SubTopicTopicThemeTitle, subTopicContent.LanguageCode);
                    db.SubTopicContent.Remove(dbSubTopicContent);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar o conteúdo do sub-tópico, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // Identified Zones

        public static IEnumerable<IdentifiedZone> GetIdentifiedZones()
        {
            IEnumerable<IdentifiedZone> identifiedZones = new List<IdentifiedZone>();
            using (ADSEntities db = new ADSEntities())
            {
                identifiedZones = db.IdentifiedZone.ToList();
                foreach (IdentifiedZone zone in identifiedZones)
                {
                    zone.VertexLatitude = zone.Vertex.Latitude;
                    zone.VertexLongitude = zone.Vertex.Longitude;
                }
            }
            return identifiedZones;
        }

        public static IdentifiedZone GetIdentifiedZone(string id)
        {
            IdentifiedZone identifiedZone = null;
            using (ADSEntities db = new ADSEntities())
            {
                identifiedZone = db.IdentifiedZone.Find(id);
                identifiedZone.VertexLatitude = identifiedZone.Vertex.Latitude;
                identifiedZone.VertexLongitude = identifiedZone.Vertex.Longitude;
            }
            return identifiedZone;
        }

        public static string CreateIdentifiedZone(IdentifiedZone identifiedZone)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    Vertex vertex = db.Vertex.Find(identifiedZone.VertexLatitude, identifiedZone.VertexLongitude);
                    if (vertex == null)
                    {
                        vertex = new Vertex { Latitude = identifiedZone.VertexLatitude, Longitude = identifiedZone.VertexLongitude };
                        db.Vertex.Add(vertex);
                    }
                    identifiedZone.Vertex = vertex;

                    db.IdentifiedZone.Add(identifiedZone);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar a zona identificada, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditIdentifiedZone(IdentifiedZone identifiedZone)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    Vertex vertex = db.Vertex.Find(identifiedZone.VertexLatitude, identifiedZone.VertexLongitude);
                    if (vertex == null)
                    {
                        vertex = new Vertex { Latitude = identifiedZone.VertexLatitude, Longitude = identifiedZone.VertexLongitude };
                        db.Vertex.Add(vertex);
                    }
                    identifiedZone.Vertex = vertex;


                    IdentifiedZone dbIdentifiedZone = db.IdentifiedZone.Find(identifiedZone.Name);

                    if (db.Entity.Where(e => e.VertexLatitude == dbIdentifiedZone.VertexLatitude && e.VertexLongitude == dbIdentifiedZone.VertexLongitude).Count() == 0)
                    {
                        db.Vertex.Remove(dbIdentifiedZone.Vertex);
                    }

                    dbIdentifiedZone.Radius = identifiedZone.Radius;

                    db.Entry(dbIdentifiedZone).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar a zona identificada, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeleteIdentifiedZone(IdentifiedZone identifiedZone)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    IdentifiedZone dbIdentifiedZone = db.IdentifiedZone.Find(identifiedZone.Name);
                    db.IdentifiedZone.Remove(dbIdentifiedZone);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar a zona identificada, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // Identified Zone Types

        public static IEnumerable<IdentifiedZoneType> GetIdentifiedZoneTypes()
        {
            IEnumerable<IdentifiedZoneType> identifiedZoneTypes = new List<IdentifiedZoneType>();
            using (ADSEntities db = new ADSEntities())
            {
                identifiedZoneTypes = db.IdentifiedZoneType.ToList();
            }
            return identifiedZoneTypes;
        }

        public static string CreateIdentifiedZoneType(IdentifiedZoneType identifiedZoneType)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    db.IdentifiedZoneType.Add(identifiedZoneType);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar o tipo de zona identificada, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditIdentifiedZoneType(IdentifiedZoneType identifiedZoneType)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    IdentifiedZoneType dbIdentifiedZoneType = db.IdentifiedZoneType.Find(identifiedZoneType.Name);
                    dbIdentifiedZoneType.Notification = identifiedZoneType.Notification;

                    db.Entry(dbIdentifiedZoneType).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar o tipo de zona identificada, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeleteIdentifiedZoneType(IdentifiedZoneType identifiedZoneType)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    IdentifiedZoneType dbIdentifiedZoneType = db.IdentifiedZoneType.Find(identifiedZoneType.Name);
                    db.IdentifiedZoneType.Remove(dbIdentifiedZoneType);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar o tipo de zona identificada, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // Identified Zone Schedules

        public static IEnumerable<IdentifiedZoneSchedule> GetIdentifiedZoneSchedules(IdentifiedZone identifiedZone)
        {
            IEnumerable<IdentifiedZoneSchedule> identifiedZoneSchedules = new List<IdentifiedZoneSchedule>();
            using (ADSEntities db = new ADSEntities())
            {
                identifiedZoneSchedules = db.IdentifiedZoneSchedule.Where(izs => izs.IdentifiedZoneName.Equals(identifiedZone.Name)).ToList();
            }
            return identifiedZoneSchedules;
        }

        public static string CreateIdentifiedZoneSchedule(IdentifiedZoneSchedule identifiedZoneSchedule)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    db.IdentifiedZoneSchedule.Add(identifiedZoneSchedule);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar o horário da zona identificada, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditIdentifiedZoneSchedule(IdentifiedZoneSchedule identifiedZoneSchedule)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    IdentifiedZoneSchedule dbIdentifiedZoneSchedule = db.IdentifiedZoneSchedule.Find(identifiedZoneSchedule.IdentifiedZoneTypeName, identifiedZoneSchedule.IdentifiedZoneName);
                    dbIdentifiedZoneSchedule.Start = identifiedZoneSchedule.Start;
                    dbIdentifiedZoneSchedule.End = identifiedZoneSchedule.End;

                    db.Entry(dbIdentifiedZoneSchedule).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar o horário da zona identificada, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeleteIdentifiedZoneSchedule(IdentifiedZoneSchedule identifiedZoneSchedule)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    IdentifiedZoneSchedule dbIdentifiedZoneSchedule = db.IdentifiedZoneSchedule.Find(identifiedZoneSchedule.IdentifiedZoneTypeName, identifiedZoneSchedule.IdentifiedZoneName);
                    db.IdentifiedZoneSchedule.Remove(dbIdentifiedZoneSchedule);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar o horário da zona identificada, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        // Phrase

        public static IEnumerable<Phrase> GetPhrases()
        {
            IEnumerable<Phrase> phrases = new List<Phrase>();
            using (ADSEntities db = new ADSEntities())
            {
                phrases = db.Phrase.ToList();
            }
            return phrases;
        }

        public static string CreatePhrase(Phrase phrase)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    db.Phrase.Add(phrase);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível criar a frase, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string EditPhrase(Phrase phrase)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    Phrase dbPhrase = db.Phrase.Find(phrase.Code);
                    dbPhrase.LanguageCode = phrase.LanguageCode;
                    dbPhrase.PhraseCode = phrase.PhraseCode;
                    dbPhrase.Content = phrase.Content;

                    db.Entry(dbPhrase).State = EntityState.Modified;
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível editar a frase, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }

        public static string DeletePhrase(Phrase phrase)
        {
            using (ADSEntities db = new ADSEntities())
            {
                try
                {
                    Phrase dbPhrase = db.Phrase.Find(phrase.Code);
                    db.Phrase.Remove(dbPhrase);
                    db.SaveChanges();
                    return null;
                }
                catch (DataException /*dex*/)
                {
                    // Check exception to find specific error
                    return "Não foi possível apagar a frase, por favor reveja os dados inseridos e tente mais tarde. Se o error persistir contacte o administrador.";
                }
            }
        }
    }
}