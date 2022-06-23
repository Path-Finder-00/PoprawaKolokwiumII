
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoprawaKol2.Models
{
    public class Membership
    {
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public DateTime MembershipDate { get; set; }
        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }
        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }
    }
}
