using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Interface
{
    public interface ITrainerRepository
    {
        Task<bool> AddNewBatchAsync(BatchDetailsDto batchDetailsDto);

        Task<List<BatchDetails>> GetAllBatchesAsync();

        Task<bool> UpdateBatchDetailsAsync(int batchId,BatchDetailsDto batchDetailsDto);

        Task<bool> UploadAssessmentAsync(AssessmentDetailDto assessmentDetailDto);

        Task<List<AssesmentDetails>> GetAllAssessmentDetailsAync();


    }
}
