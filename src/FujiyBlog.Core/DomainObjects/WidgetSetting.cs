﻿using System.ComponentModel.DataAnnotations;

namespace FujiyBlog.Core.DomainObjects
{
    public class WidgetSetting
    {
        [Required]
        public virtual int Id { get; set; }

        [Required,StringLength(50)]
        public virtual string Name { get; set; }

        [Required,StringLength(50)]
        public virtual string WidgetZone { get; set; }

        [Required]
        public virtual byte[] Settings { get; set; }
    }
}
