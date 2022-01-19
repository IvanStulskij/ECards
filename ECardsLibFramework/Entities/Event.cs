using System;
using System.Collections.Generic;
using System.Linq;
using ECardsLib;
using ECardsLib.GlobalConstants;

namespace ECardsLibFramework.Entities
{
    /// <summary>
    /// Represents entity of historical event.
    /// </summary>
    public class Event
    {
        private string _picturePath;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value.CheckForUncorrect(ExceptionsMessages.NoName);
            }
        }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PicturePath
        {
            get
            {
                return _picturePath;
            }

            set
            {
                _picturePath = value.CheckForUncorrect(ExceptionsMessages.NoImage);
            }
        }

        public string ShortDescription { get; set; }

        public static IEnumerable<EventView> ConvertToView(IEnumerable<Event> events)
        {
            return events.Select(historyEvent => new EventView(historyEvent));
        }
    }
}
