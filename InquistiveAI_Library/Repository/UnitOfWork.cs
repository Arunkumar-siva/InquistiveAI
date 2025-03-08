using InquistiveAI_Library.Context;
using InquistiveAI_Library.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public ITrainerRepository Trainer { get; }

        public ITraineeRepository Trainee {  get; }

        public IEmployeeRepository Employee {  get; }

        public UnitOfWork(ApplicationDbContext dbContext, ITrainerRepository trainer, ITraineeRepository trainee, IEmployeeRepository employee)
        {
            _dbContext = dbContext;
            Trainer = trainer;
            Trainee = trainee;
            Employee = employee;
        }

        public async Task CommitAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
