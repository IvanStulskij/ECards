using ECardsLibFramework.Entities;
using System.Collections.Generic;

namespace ECardsLibFramework.Source
{
    public interface ISource
    {
        IEnumerable<Event> GetEvents();
        void WriteInfo(IEnumerable<Event> events);
    }
}
