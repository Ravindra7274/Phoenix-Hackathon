﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Exxat.SupportPro.API.Models;
using Exxat.SupportPro.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exxat.SupportPro.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        protected readonly IQueryService _queryService;
        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }
        [HttpGet]
        public async Task<List<Module>> GetAsync()
        {
            return await _queryService.GetAllModules();
        }

        [HttpGet("{id}")]
        public async Task<List<CommonQuery>> GetAsync(int id)
        {
            var queries = await _queryService.GetCommonQueries(id);
            foreach (var query in queries)
            {
                var obj = Utility.Serializer.GetObject<QueryContextModel>(query.Context);
                if (obj != null)
                    query.InputParams = obj.InputParams;
                query.Context = null;
            }

            return queries;
        }
        // PUT api/values/5
        [HttpGet("[action]")]
        public async Task GenerateQuery(int id, string[] args)
        {
            var query = await _queryService.GetCommonQuery(id);
            var dynamic_query = query.InitialQuery;
        }

        [HttpGet("[action]")]
        public async Task<object> ExecuteQuery(string query, string queryType)
        {
            return await _queryService.ExecuteQueryAsync(query, queryType);
        }
        
    }
}
