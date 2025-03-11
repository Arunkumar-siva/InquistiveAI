using InquistiveAI_Library.Context;
using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Exceptions;
using InquistiveAI_Library.Interface;
using InquistiveAI_Library.Model;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> AddNewBatchAsync(BatchDetailsDto batchDetailsDto)
        {

            var batch = await this._applicationDbContext.BatchDetails.FirstOrDefaultAsync(batch => batch.BatchName == batchDetailsDto.BatchName);
            if (batch == null)
            {
                var batchDetails = new BatchDetails
                {
                    BatchName = batchDetailsDto.BatchName,
                    BatchMonth = batchDetailsDto.BatchMonth
                };
                await this._applicationDbContext.BatchDetails.AddAsync(batchDetails);
                return true;
            }

            return false;
        }

        public async Task<List<BatchDetails>> GetAllBatchesAsync()
        {
            var batchDetails = await this._applicationDbContext.BatchDetails.Select(batch => new BatchDetails
            {
                BatchId = batch.BatchId,
                BatchName = batch.BatchName,
                BatchMonth = batch.BatchMonth
            }).ToListAsync();


            return batchDetails;


        }

        public async Task<bool> UpdateBatchDetailsAsync(int batchId, BatchDetailsDto batchDetailsDto)
        {
            var batchDetails = await this._applicationDbContext.BatchDetails.FindAsync(batchId);

            if (batchDetails != null)
            {
                batchDetails.BatchName = batchDetailsDto.BatchName;
                batchDetails.BatchMonth = batchDetailsDto.BatchMonth;

                return true;

            }
            throw new BatchNotFoundException($"Unable to Update {batchDetailsDto.BatchName}");

        }

        public async Task<bool> UploadAssessmentAsync(AssessmentDetailDto assessmentDetailDto)
        {
            using var memoryStream = new MemoryStream();
            await assessmentDetailDto.AssessmentFile.CopyToAsync(memoryStream);

            var assessmentDetails = new AssesmentDetails
            {
                QuestionName = assessmentDetailDto.QuestionName,
                AssessmentUploadedDate = DateTime.UtcNow,
                BatchId = assessmentDetailDto.BatchId,
                ContentType = assessmentDetailDto.AssessmentFile.ContentType,
                Content = memoryStream.ToArray()

            };

            await this._applicationDbContext.AssesmentDetails.AddAsync(assessmentDetails);
            return true;


        }
    }
}
