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
    
    public partial class ThemeContent
    {
        public ThemeContent()
        {
            this.Visibility = false;
        }
    
        public string ThemeTitle { get; set; }
        public string LanguageCode { get; set; }
        public string TranslatedTitle { get; set; }
        public bool Visibility { get; set; }
        public string Document { get; set; }
    
        public virtual Theme Theme { get; set; }
        public virtual Language Language { get; set; }
    }
}
