// ===============================
// *******************************
// The Bodyshape database context.
// ===============================
// *******************************

namespace MyBodyShape.Watcher
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    /// <summary>
    /// The bodyshape database context class.
    /// </summary>
    public partial class BodyShapeContext : DbContext
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public BodyShapeContext()
            : base("name=BodyShapeContext")
        {
        }

        /// <summary>
        /// The generations rows.
        /// </summary>
        public virtual DbSet<Generations> Generations { get; set; }
    }
}
