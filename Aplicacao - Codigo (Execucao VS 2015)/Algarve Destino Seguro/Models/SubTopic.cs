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
    
    public partial class SubTopic
    {
        public SubTopic()
        {
            this.Visibility = false;
            this.SubTopicContent = new HashSet<SubTopicContent>();
        }
    
        public string TopicThemeTitle { get; set; }
        public string TopicTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Visibility { get; set; }
        public string Icon { get; set; }
    
        public virtual Topic Topic { get; set; }
        public virtual ICollection<SubTopicContent> SubTopicContent { get; set; }
    }
}
