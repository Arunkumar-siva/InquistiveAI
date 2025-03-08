﻿using InquistiveAI_Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Interface
{
    public interface ITrainerRepository
    {
        Task<string> AddNewBatchAsync(BatchDetailsDto batchDetailsDto);
    }
}
