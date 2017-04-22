namespace MyBodyShape.Watcher
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Generations
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid AnonymousId { get; set; }

        public bool HasAccount { get; set; }

        public DateTime GenerationDate { get; set; }

        public bool? Success { get; set; }

        public double? ErrorPercent { get; set; }

        public string FrontPicture { get; set; }

        public string SidePicture { get; set; }

        public double Height { get; set; }

        public double? ExpectedWeight { get; set; }

        public double GeneratedWeight { get; set; }
    }
}
