using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina2018.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Boolean? bEnabled { get; set; }
        public Boolean? bDisabled { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
