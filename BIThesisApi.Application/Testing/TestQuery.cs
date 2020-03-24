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
                var dr = BaseRepository.GetDataFromDb("dbo.TestProcedure");
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