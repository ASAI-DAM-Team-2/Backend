namespace AllergyApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Restaurant")]
    public partial class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int restaurant_id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string adress { get; set; }

        public int plan_id { get; set; }

        public int company_id { get; set; }
    }
}
