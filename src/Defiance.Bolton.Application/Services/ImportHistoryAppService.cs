using Defiance.Bolton.Domain.Entities;
using Defiance.Bolton.Domain.Interfaces.Repositories;
using Defiance.Bolton.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Defiance.Bolton.Application.Services
{
    public class ImportHistoryAppService : IImportHistoryAppService
    {
        private readonly IImportHistoryRepository _importHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImportHistoryAppService(
            IImportHistoryRepository importHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            _importHistoryRepository = importHistoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ImportHistory importHistory)
        {
            try
            {
                importHistory.SetCompleted();

                await _importHistoryRepository.AddAsync(importHistory);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
