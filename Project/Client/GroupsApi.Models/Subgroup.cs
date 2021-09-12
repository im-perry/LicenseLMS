using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GroupsAPI.Models
{
    public class Subgroup
    {
        public Guid SubgroupId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        public IEnumerable<Group> Groups { get; set; }

        public static Subgroup Create(string name, string groupName)
        {
            Subgroup subgroup = new Subgroup
            {
                SubgroupId = Guid.NewGuid(),
                Name = name,
                GroupName = groupName
            };
            return subgroup;
        }
    }
}
