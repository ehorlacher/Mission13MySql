using System.Linq;
using Mission13MySql.Models;

namespace Mission13MySql
{
    public interface ITeamsRepository
    {
        IQueryable<Team> Teams { get; }

        public void SaveTeam(Team t);
        public void CreateTeam(Team t);
        public void DeleteTeam(Team t);
    }
}
