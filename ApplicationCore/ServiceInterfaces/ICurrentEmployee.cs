using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICurrentEmployee
    {
        int EmployeeId { get; }
        bool IsAuthenticated { get; }
        string Name { get; }
        bool IsAdmin { get; }
        bool IsSuperAdmin { get; }
    }
}
