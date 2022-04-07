using System.Linq;
using Mission13MySql.Models;

namespace Mission13MySql
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        public void SaveBowler(Bowler b);
        public void CreateBowler(Bowler b);
        public void DeleteBowler(Bowler b);
    }
}