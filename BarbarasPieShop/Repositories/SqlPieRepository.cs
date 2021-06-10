using BarbarasPieShop.Models;
using MSDataAccess;
using System.Collections.Generic;

namespace BarbarasPieShop.Repositories
{
    internal class SqlPieRepository : IPieRepository
    {
        private readonly DataAccess _da;
        public SqlPieRepository()
        {
            _da = new DataAccess(@"Server=(localdb)\MSSQLLocalDB;Database=BarbarasPieShop;Integrated Security = True");
        }
        public IEnumerable<Pie> AllPies
        {
            get
            {
                List<Pie> allPies = new();
                _da.CommandText = "SELECT Name,Price,ShortDescription FROM Pie WHERE IsActive=1";
                _da.CommandType = System.Data.CommandType.Text;
                var result = _da.GetList_DataReader();
                return allPies;
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek => throw new System.NotImplementedException();

        public Pie GetPieById(int pieId)
        {
            throw new System.NotImplementedException();
        }
    }
}