using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Repositorise.Interfaces
{
    public interface UserInterface
    {
        Task<int> Add(t_Employee taskData);
        Task<List<t_task>> GetAllTask();
        
    }
}