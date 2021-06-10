using BarbarasPieShop.Models;
using System.Collections.Generic;

namespace BarbarasPieShop.Repositories
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }

        IEnumerable<Pie> PiesOfTheWeek { get; }

        Pie GetPieById(int pieId);
    }
}
