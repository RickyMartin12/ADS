//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Algarve_Destino_Seguro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TopicContent
    {
        public TopicContent()
        {
            this.Visibility = false;
        }
    
        public string TopicTitle { get; set; }
        public string TopicThemeTitle { get; set; }
        public string LanguageCode { get; set; }
        public string TranslatedTitle { get; set; }
        public bool Visibility { get; set; }
        public string Document { get; set; }
    
        public virtual Topic Topic { get; set; }
        public virtual Language Language { get; set; }
    }
}
