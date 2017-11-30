
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Models
{
    public class Brand
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<Shoe> Shoes { get; set; }

        public Brand()
        {
            Shoes = new Collection<Shoe>();
        }
    }
}

            // migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Black')");
            // migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Brown')");
            // migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Walnut')");
            // migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Navy')");
            // migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Oxblood')");

            //             migrationBuilder.Sql(@"DELETE FROM Colors WHERE Name IN (
            //     'Black',
            //     'Brown',
            //     'Walnut',
            //     'Navy',
            //     'Oxblood'
            // )");