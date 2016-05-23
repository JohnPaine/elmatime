using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImpeltechTime.Droid.Core.Model
{
    public interface IElmaWcfService
    {
        IElmaUser LoginUser (string accName, string pass);
        bool LogoutUser (IElmaUser user);

        Task<IEnumerable<IElmaTask>> GetTasksForUser (IElmaUser user);
    }
}