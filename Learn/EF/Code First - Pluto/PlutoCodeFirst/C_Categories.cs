namespace PlutoCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("_Categories")]
    public partial class C_Categories
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
