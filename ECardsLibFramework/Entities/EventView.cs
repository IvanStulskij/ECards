using System;
using System.Collections.Generic;

namespace ECardsLibFramework.Entities
{
    public class EventView
    {
        public EventView(Event historicalEvent)
        {
            if (historicalEvent != null)
            {
                Name = historicalEvent.Name;
                BeginDate = historicalEvent.BeginDate;
                EndDate = historicalEvent.EndDate;
            }
        }

        public string Name { get; private set; }

        public DateTime BeginDate { get; private set; }

        public DateTime EndDate { get; private set; }
    }
}
