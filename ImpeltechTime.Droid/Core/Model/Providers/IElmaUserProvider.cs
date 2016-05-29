using System.Threading.Tasks;

namespace ImpeltechTime.Droid.Core.Model.Providers
{
    public interface IElmaUserProvider
    {
        IElmaUser LoginUser (string accName, string pass);
    }
}