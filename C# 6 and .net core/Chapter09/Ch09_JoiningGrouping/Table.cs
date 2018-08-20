namespace Ch09_JoiningGrouping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        public Table()
        {
            TestTime = new DateTime(1970, 1, 1);
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [DefaultValue("1970-01-01")]
        public DateTime TestTime { get; set; }
    }
}
