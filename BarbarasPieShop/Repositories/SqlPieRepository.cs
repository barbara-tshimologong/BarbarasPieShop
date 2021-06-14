using BarbarasPieShop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using MSDataAccess;

namespace BarbarasPieShop.Repositories
{
    internal class SqlPieRepository : IPieRepository
    {
        public SqlPieRepository()
        {
        }
      
        public IEnumerable<Pie> AllPies
        {
            get
            {
                DataAccess<object> _da = new DataAccess<object>();
                List<Pie> allPies = new();
                _da.ConnectionString = "123";
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

        public string GetPieName(int pieId)
        {
            DataAccess<string> _da = new()
            {
                ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BarbarasPieShop;Integrated Security = True",
                CommandText = $"SELECT Name FROM Pie WHERE PieId = {pieId} AND IsActive=1",
                CommandType = System.Data.CommandType.Text
            };

            return _da.GetScalar;
        }

        public int GetPieId(string pieName)
        {
            DataAccess<int> _da = new()
            {
                ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BarbarasPieShop;Integrated Security = True",
                CommandText = $"SELECT PieId FROM Pie WHERE Name = '{pieName}' AND IsActive=1",
                CommandType = System.Data.CommandType.Text
            };

            return _da.GetScalar;
        }

    }
}