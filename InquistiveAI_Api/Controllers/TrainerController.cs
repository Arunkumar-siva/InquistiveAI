﻿using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Exceptions;
using InquistiveAI_Library.Interface;
using InquistiveAI_Library.Model;
using Microsoft.AspNetCore.Mvc;


namespace InquistiveAI_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public TrainerController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("AddNewBatch")]
        public async Task<ActionResult> AddNewBatch([FromBody] BatchDetailsDto batchDetailsDto)
        {
            try
            {
                var response = await this._unitOfWork.Trainer.AddNewBatchAsync(batchDetailsDto);
                if (response)
                {
                    await this._unitOfWork.CommitAsync();
                    return Ok($"{batchDetailsDto.BatchName} added Successfully");
                }
                return Ok($"{batchDetailsDto.BatchName} already Exists");

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }



        [HttpGet("GetAllBatches")]

        public async Task<ActionResult> GetAllBatches()
        {
            var response = await this._unitOfWork.Trainer.GetAllBatchesAsync();

            if (response != null)
            {
                return Ok(response);

            }
            return new NoContentResult();

        }

        [HttpPut("EditBatchDetail/{batchId}")]

        public async Task<IActionResult> UpdateBatchDetails(int batchId, [FromBody] BatchDetailsDto batchDetails)
        {
            try
            {
                var response = await this._unitOfWork.Trainer.UpdateBatchDetailsAsync(batchId, batchDetails);
                if (response)
                {
                    await this._unitOfWork.CommitAsync();
                    return Ok($"{batchDetails.BatchName} Updated Successfully");
                }

                return NotFound($"{batchDetails.BatchName} not Found");
            }
            catch (BatchNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, new { error = "An Unexpexted Error Occured", details = exception.Message });
            }

        }

        [HttpPost("UploadAssessment")]

        public async Task<IActionResult> UploadAssessment([FromForm] AssessmentDetailDto assessmentDetailDto)
        {
            if( assessmentDetailDto.AssessmentFile == null || assessmentDetailDto.AssessmentFile.Length == 0)
            {
                return BadRequest("No File Uploaded");
            }

            var response = await this._unitOfWork.Trainer.UploadAssessmentAsync(assessmentDetailDto);
            if(response)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
