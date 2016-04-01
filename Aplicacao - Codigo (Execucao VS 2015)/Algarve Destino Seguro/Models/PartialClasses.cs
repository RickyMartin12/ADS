using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Algarve_Destino_Seguro.Models
{
    [MetadataType(typeof(IdentifiedZoneMetadata))]
    public partial class IdentifiedZone
    {
        public double VertexLatitude { get; set; }
        public double VertexLongitude { get; set; }
    }

    [MetadataType(typeof(IdentifiedZoneScheduleMetadata))]
    public partial class IdentifiedZoneSchedule
    {
    }

    [MetadataType(typeof(IdentifiedZoneTypeMetadata))]
    public partial class IdentifiedZoneType
    {
    }

    [MetadataType(typeof(LanguageMetadata))]
    public partial class Language
    {
    }

    [MetadataType(typeof(SubTopicMetadata))]
    public partial class SubTopic
    {
    }

    [MetadataType(typeof(SubTopicContentMetadata))]
    public partial class SubTopicContent
    {
    }

    [MetadataType(typeof(ThemeMetadata))]
    public partial class Theme
    {
    }

    [MetadataType(typeof(ThemeContentMetadata))]
    public partial class ThemeContent
    {
    }

    [MetadataType(typeof(TopicMetadata))]
    public partial class Topic
    {
    }

    [MetadataType(typeof(TopicContentMetadata))]
    public partial class TopicContent
    {
    }
}