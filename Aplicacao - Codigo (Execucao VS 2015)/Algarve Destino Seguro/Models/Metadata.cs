using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Algarve_Destino_Seguro.Models
{
    public class IdentifiedZoneScheduleMetadata
    {
        [Display(Name = "Tipo de Zona")]
        public string IdentifiedZoneTypeName;

        [Display(Name = "Zona Identificada")]
        public string IdentifiedZoneName;

        [Display(Name = "Ínicio")]
        public System.TimeSpan Start;

        [Display(Name = "Fim")]
        public System.TimeSpan End;
    }

    public class IdentifiedZoneTypeMetadata
    {
        [Display(Name = "Tipo de Zona")]
        public string Name;

        [Display(Name = "Notificação")]
        public string Notification;
    }

    public class IdentifiedZoneMetadata
    {
        [Display(Name = "Zona Identificada")]
        public string Name;

        [Display(Name = "Raio")]
        public double Radius;

        [Display(Name = "Latitude")]
        public double VertexLatitude;

        [Display(Name = "Longitude")]
        public double VertexLongitude;
    }

    public class LanguageMetadata
    {
        [Display(Name = "Código Idioma")]
        public string Code;

        [Display(Name = "Nome")]
        public string Name;
    }

    public class SubTopicMetadata
    {
        [Display(Name = "Tema")]
        public string TopicThemeTitle;

        [Display(Name = "Tópico")]
        public string TopicTitle;

        [Display(Name = "Título")]
        public string Title;

        [Display(Name = "Descrição")]
        public string Description;

        [Display(Name = "Visibilidade")]
        public bool Visibility;

        [Display(Name = "Ícone")]
        public string Icon;
    }

    public class SubTopicContentMetadata
    {
        [Display(Name = "Tema")]
        public string SubTopicTopicThemeTitle;

        [Display(Name = "Tópico")]
        public string SubTopicTopicTitle;

        [Display(Name = "Sub-Tópico")]
        public string SubTopicTitle;

        [Display(Name = "Idioma")]
        public string LanguageCode;

        [Display(Name = "Visibilidade")]
        public bool Visibility;

        [Display(Name = "Documento")]
        public string Document;

        [Display(Name = "Tradução")]
        public string TranslatedTitle;
    }

    public class ThemeMetadata
    {
        [Display(Name = "Título")]
        public string Title;

        [Display(Name = "Descrição")]
        public string Description;

        [Display(Name = "Visibilidade")]
        public bool Visibility;

        [Display(Name = "Ícone")]
        public string Icon;
    }

    public class ThemeContentMetadata
    {
        [Display(Name = "Tema")]
        public string ThemeTitle;

        [Display(Name = "Idioma")]
        public string LanguageCode;

        [Display(Name = "Visibilidade")]
        public bool Visibility;

        [Display(Name = "Documento")]
        public string Document;

        [Display(Name = "Tradução")]
        public string TranslatedTitle;
    }

    public class TopicMetadata
    {
        [Display(Name = "Tema")]
        public string ThemeTitle;

        [Display(Name = "Título")]
        public string Title;

        [Display(Name = "Descrição")]
        public string Description;

        [Display(Name = "Visibilidade")]
        public bool Visibility;

        [Display(Name = "Ícone")]
        public string Icon;
    }

    public class TopicContentMetadata
    {
        [Display(Name = "Tema")]
        public string TopicThemeTitle;

        [Display(Name = "Tópico")]
        public string TopicTitle;

        [Display(Name = "Idioma")]
        public string LanguageCode;

        [Display(Name = "Visibilidade")]
        public bool Visibility;

        [Display(Name = "Documento")]
        public string Document;

        [Display(Name = "Tradução")]
        public string TranslatedTitle;
    }
}