﻿using Exxat.SupportPro.API.Models;
using Exxat.SupportPro.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exxat.SupportPro.API.Services
{
    public interface IModuleService
    {
        Task<List<Module>> GetAllModules();
    }
    public class ModuleService: IModuleService
    {
        protected readonly IQueryRepository _queryRepository;
        public ModuleService(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public Task<List<Module>> GetAllModules()
        {
            return _queryRepository.GetAll();
        }
    }
}
