using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class SubgroupData
    {
        public int SubgroupId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public GroupData Group { get; set; }
    }
}
