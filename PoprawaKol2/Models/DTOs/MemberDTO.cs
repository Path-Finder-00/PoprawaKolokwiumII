using System;

namespace PoprawaKol2.Models.DTOs
{
    public class MemberDTO
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberNickName { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
