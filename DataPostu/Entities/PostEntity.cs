using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPostu.Entities
{
    [Table("Posts")]

    public class PostEntity
    {
       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [MaxLength(5000)] // Możesz dostosować maksymalną długość zgodnie z wymaganiami
            public string Content { get; set; }

            [Required]
            [MaxLength(200)] // Dostosuj maksymalną długość
            public string Author { get; set; }

            [DataType(DataType.Date)]
            public DateTime PublicationDate { get; set; }

            [MaxLength(500)] // Dostosuj maksymalną długość
            public string Tags { get; set; }

            [MaxLength(500)] // Dostosuj maksymalną długość
            public string Comment { get; set; }

            [DataType(DataType.Date)]
            public DateTime Created { get; set; }
        
    }
}
