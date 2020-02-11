using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BIThesisApi.Domain;
using BIThesisApi.Persistence;
using MediatR;

namespace BIThesisApi.Application.Testing
{
    public class TestQuery : IRequest<IEnumerable<TestEntity>>
    {
        public class TestQueryHandler : IRequestHandler<TestQuery, IEnumerable<TestEntity>>
        {
            public async Task<IEnumerable<TestEntity>> Handle(TestQuery request, CancellationToken cancellationToken)
            {
                return await GetTestData();
            }
            
            private async Task<IEnumerable<TestEntity>> GetTestData()
            {
                var cumeDists = new List<TestEntity>();
                var dr = BaseRepository.GetDataFromDb("USE AdventureWorks2016;  SELECT Department, LastName, Rate, CUME_DIST () OVER (PARTITION BY Department ORDER BY Rate) AS CumeDist,   PERCENT_RANK() OVER (PARTITION BY Department ORDER BY Rate ) AS PctRank  FROM HumanResources.vEmployeeDepartmentHistory AS edh  INNER JOIN HumanResources.EmployeePayHistory AS e    ON e.BusinessEntityID = edh.BusinessEntityID  WHERE Department IN (N'Document Control')   ORDER BY Department, Rate DESC;  ");
                while (await dr.ReadAsync())
                {
                    cumeDists.Add(new TestEntity
                    {
                        Name = dr["LastName"].ToString(),
                        CumeDist = dr["CumeDist"].ToString(),
                    });
                }

                return cumeDists;
            }
        }
    }
}