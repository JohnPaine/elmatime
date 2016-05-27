using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImpeltechTime.Droid.Core.Model
{
    public interface IElmaWcfService
    {
        IElmaUser LoginUser (string accName, string pass);

        Task<IEnumerable<IElmaTask>> GetTasksForUser (IElmaUser user);

        Task<bool> SendWorkLogAsync(IElmaUser user, IElmaTask task);
    }
}