using System.Collections.Generic;

namespace ClubManager.Observer
{
    public class EntrainementSubject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify(string message)
        {
            foreach (var obs in observers)
            {
                obs.Update(message);
            }
        }
    }
}