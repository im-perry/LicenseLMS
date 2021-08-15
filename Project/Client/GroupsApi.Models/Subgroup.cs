using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupsAPI.Models
{
    public class Subgroup
    {
        public Guid SubgroupId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Group")]
        public Guid GroupId { get; set; }
        public Group Group { get; set; }

        public static Subgroup Create(string name, Guid groupId)
        {
            Subgroup subgroup = new Subgroup
            {
                SubgroupId = Guid.NewGuid(),
                Name = name,
                GroupId = groupId
            };
            return subgroup;
        }
    }
}
