using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImpeltechTime.Droid.Core.Model
{
    public interface IElmaWcfService
    {
        IElmaUser LoginUser (string accName, string pass);

        IEnumerable<IElmaTask> GetTasksForUser (IElmaUser user);

        bool SendWorkLogAsync(IElmaUser user, IElmaTask task);
    }
}