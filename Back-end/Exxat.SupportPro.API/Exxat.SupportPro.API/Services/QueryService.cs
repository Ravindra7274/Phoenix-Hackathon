﻿using Exxat.SupportPro.API.Models;
using Exxat.SupportPro.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exxat.SupportPro.API.Services
{
    public interface IQueryService
    {
        Task<List<Module>> GetAllModules();
        Task<List<CommonQuery>> GetCommonQueries(int moduleId);
        Task<CommonQuery> GetCommonQuery(int queryId);
    }
    public class QueryService: IQueryService
    {
        protected readonly IQueryRepository _queryRepository;
        public QueryService(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public Task<List<Module>> GetAllModules()
        {
            return _queryRepository.GetAll();
        }

        public async Task<List<CommonQuery>> GetCommonQueries(int moduleId)
        {
            return await _queryRepository.GetAllQueries(moduleId);
        }

        public async Task<CommonQuery> GetCommonQuery(int queryId)
        {
            return await _queryRepository.GetQuery(queryId);
        }
    }
}
