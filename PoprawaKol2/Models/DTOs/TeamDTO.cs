using System.Collections.Generic;

namespace PoprawaKol2.Models.DTOs
{
    public class TeamDTO
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string OrganizationName { get; set; }
        public ICollection<MemberDTO> Members { get; set; }
    }
}
