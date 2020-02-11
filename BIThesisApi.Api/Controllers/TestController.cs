using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BIThesisApi.Application.Testing;
using BIThesisApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BIThesisApi.Api.Controllers
{
    public class TestController : BaseController
    {
        [HttpGet]
        public async Task<IEnumerable<TestEntity>> GetTestData(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new TestQuery(), cancellationToken);
        }
    }
}