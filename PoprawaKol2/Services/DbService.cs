using Microsoft.EntityFrameworkCore;
using PoprawaKol2.Models;
using PoprawaKol2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKol2.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMember(int memberID, int teamID)
        {
            if (await _dbContext.Members.Where(m => m.MemberID == memberID).FirstOrDefaultAsync() == null)
                throw new Exception($"No such member with id = {memberID} exists in the database.");

            if (await _dbContext.Teams.Where(t => t.TeamID == teamID).FirstOrDefaultAsync() == null)
                throw new Exception($"No such member with id = {teamID} exists in the database.");

            var teamOrganizationID = _dbContext.Teams.Where(t => t.TeamID == teamID).Select(t => new { t.OrganizationID }).FirstOrDefault();

            if (_dbContext.Members.Where(m => m.MemberID == memberID).Select(m => new { m.OrganizationID }).FirstOrDefault().OrganizationID != teamOrganizationID.OrganizationID)
                throw new Exception($"Member and team aren't in the same organization.");

        }

        public async Task<TeamDTO> GetTeam(int id)
        {
            if (await _dbContext.Teams.Where(t => t.TeamID == id).FirstOrDefaultAsync() == null)
                throw new Exception($"No such team with id = {id} exists in the database.");

            return await _dbContext.Teams
                .Select(t => new TeamDTO
                {
                    TeamName = t.TeamName,
                    TeamDescription = t.TeamDescription,
                    OrganizationName = t.Organization.OrganizationName,
                    Members = t.Memberships
                        .Select(m => new MemberDTO
                        {
                            MemberID = m.MemberID,
                            MemberName = m.Member.MemberName,
                            MemberSurname = m.Member.MemberSurname,
                            MemberNickName = m.Member.MemberNickName,
                            MembershipDate = m.MembershipDate
                        }).OrderBy(m => m.MembershipDate)
                        .ToList()
                }).FirstOrDefaultAsync();
        }
    }
}
