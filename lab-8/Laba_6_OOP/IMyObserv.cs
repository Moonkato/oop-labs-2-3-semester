using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6_OOP
{
    public interface IMyObservable
    {
        void AddObserver(IMyObserver o);
        void RemoveObserver(IMyObserver o);
        void NotifyCreate();
        void NotifySelect();
        void NotifyDelete_with_cnt();
        void NotifyDelete_without_cnt();
    }

    public interface IMyObserver
    {
        void UpdateCreate_with_cnt(CShape who);
        void UpdateSelect(CShape who);
        void UpdateDelete_with_cnt(CShape who);
        void UpdateDelete_without_cnt(CShape who);
    }
}
