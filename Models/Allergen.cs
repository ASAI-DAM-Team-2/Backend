namespace AllergyApp
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Allergen")]
    public partial class Allergen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int allergen_id { get; set; }

        public string name { get; set; }

        public string picture { get; set; }
    }
}
