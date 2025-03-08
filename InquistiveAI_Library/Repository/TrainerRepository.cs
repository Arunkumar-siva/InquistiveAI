using InquistiveAI_Library.Context;
using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Interface;
using InquistiveAI_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Repository
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TrainerRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public async Task<string> AddNewBatchAsync(BatchDetailsDto batchDetailsDto)
        {
            var batchDetails = new BatchDetails
            {
                BatchName = batchDetailsDto.BatchName,
                BatchMonth = batchDetailsDto.BatchMonth
            };
            await this._applicationDbContext.BatchDetails.AddAsync(batchDetails);
            return batchDetailsDto.BatchName;
        }
    }
}
