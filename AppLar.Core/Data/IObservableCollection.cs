using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLar.Core.Data
{
    public interface IObservableCollection<T>
        : IList<T>
        , INotifyCollectionChanged
    {
    }
}
