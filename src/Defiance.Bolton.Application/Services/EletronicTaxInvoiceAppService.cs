using Defiance.Bolton.Domain.Aggregates;
using Defiance.Bolton.Domain.Entities;
using Defiance.Bolton.Domain.Interfaces.Repositories;
using Defiance.Bolton.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Defiance.Bolton.Application.Services
{
    public class EletronicTaxInvoiceAppService : IEletronicTaxInvoiceAppService
    {
        private readonly IEletronicTaxInvoiceRepository _eletronicTaxInvoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EletronicTaxInvoiceAppService
            (IEletronicTaxInvoiceRepository eletronicTaxInvoiceRepository,
            IUnitOfWork unitOfWork)
        {
            _eletronicTaxInvoiceRepository = eletronicTaxInvoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAllAsync(List<EletronicTaxInvoice> eletronicTaxInvoices)
        {
            try
            {
                if (!eletronicTaxInvoices.Any())
                    return;

                var keys = eletronicTaxInvoices.Select(x => x.AccessKey).ToList();
                var exists = await _eletronicTaxInvoiceRepository.GetAllByKeysAsync(keys);

                var addAll = eletronicTaxInvoices;

                if (exists.Any())
                {
                    var existingKeys = exists.Select(x => x.AccessKey).ToList();
                    addAll = eletronicTaxInvoices.Where(x => !existingKeys.Contains(x.AccessKey)).ToList();
                }

                await _eletronicTaxInvoiceRepository.AddAllAsync(addAll);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<NFe> GetByAccessKeyAsync(string accessKey)
        {
            var nfe = await _eletronicTaxInvoiceRepository.GetByKeyAsync(accessKey);

            return nfe is null ? null : NFe.Build(accessKey, nfe.TotalAmount);
        }
    }
}
