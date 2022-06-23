
using PoprawaKol2.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoprawaKol2.Services
{
    public interface IDbService
    {
        public Task<TeamDTO> GetTeam(int id);

        public Task AddMember(int memberID, int teamID);
        /*
        public Task<IEnumerable<ZamowienieDTO>> GetZamowienia(string nazwisko);

        public Task AddZamowienie(int IdKlient, AddZamowienieDTO zamowienie);
        */
    }
}
