using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Interface
{
    public interface IUnitOfWork
    {

        ITrainerRepository Trainer {  get; }

        ITraineeRepository Trainee { get; }

        IEmployeeRepository Employee { get; }

        Task CommitAsync();

    }
}
