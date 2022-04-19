using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfFloors { get; set; }
        public int Basements { get; set; }
        public bool HasRoof { get; set; }

        public virtual List<Residence> Residences { get; set; }
    }
}
