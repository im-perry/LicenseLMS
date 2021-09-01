using System;

namespace GroupsAPI.Models
{
    public class Subgroup
    {
        public string SubgroupId { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public Group Group { get; set; }

        public static Subgroup Create(string name, string groupName)
        {
            Subgroup subgroup = new Subgroup
            {
                SubgroupId = Guid.NewGuid().ToString(),
                Name = name,
                GroupName = groupName
            };
            return subgroup;
        }
    }
}
