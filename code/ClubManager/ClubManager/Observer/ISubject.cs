using System.Collections.Generic;

namespace ClubManager.Observer
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Notify(string message);
    }
}