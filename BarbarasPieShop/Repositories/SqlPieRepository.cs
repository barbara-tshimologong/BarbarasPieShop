using BarbarasPieShop.Models;
using MSDataAccess;
using System;
using System.Collections;
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
                List<object> result = _da.GetList_DataReader();


                for (int i = 0; i < result.Count; i++)
                {
                    IEnumerable enumerable = result[i] as IEnumerable;

                    int count = 0;

                    foreach (var item in enumerable)
                    {
                        Pie pie = new();
                        switch (count)
                        {
                            case 0:
                                pie.Name = item.ToString();
                                count++;
                                break;
                            case 1:
                                pie.Price = Convert.ToDecimal(item);
                                count++;
                                break;
                            case 2:
                                pie.ShortDescription = item.ToString();
                                count++;
                                break;

                            default:
                                break;
                        }

                        allPies.Add(pie);

                    }
                }

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