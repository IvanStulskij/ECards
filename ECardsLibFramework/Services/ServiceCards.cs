using ECardsLibFramework.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Linq;
using ECardsLibFramework.Files;
using ECardsLibFramework.Source;

namespace ECardsLibFramework.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceCards : IServiceCards
    {
        private readonly string _path;
        private readonly ISource _source;
        private readonly HashSet<Event> _events = new HashSet<Event>();
        
        public ServiceCards(IPath path, ISource source)
        {
            _path = path.Path;
            _source = source;
            _events = GetEvents();
        }

        //public HashSet<Event> Events => _events;

        public HashSet<Event> GetEvents()
        {
            return JsonConvert.DeserializeObject<HashSet<Event>>(File.ReadAllText(_path));
        }

        public void Remove(string removingEventName)
        {
            Event eventToRemove = _events
                .FirstOrDefault(hisoryEvent => hisoryEvent.Name == removingEventName);

            if (_events.Remove(eventToRemove))
            {
                WriteInJson();
            }
        }

        public void Remove(IEnumerable<string> eventsToRemove)
        {
            IEnumerable<Event> events = _events;
            bool removedItemsCount = false;

            foreach (var eventToRemove in eventsToRemove)
            {
                removedItemsCount = _events.Remove(_events.FirstOrDefault(jsonEvent => jsonEvent.Name == eventToRemove));
            }

            if (removedItemsCount)
            {
                WriteInJson();
            }
        }

        public void Add(Event historicalEvent)
        {
            _events.Add(historicalEvent);
            WriteInJson();
        }

        public void Update(string eventNameToUpdate, Event newData)
        {
            Event eventToUpdate = _events.FirstOrDefault(historyEvent => historyEvent.Name == eventNameToUpdate);
            eventToUpdate = newData;
            WriteInJson();
        }
        
        public string GetDescription(string name)
        {
            return _events.FirstOrDefault(historyEvent => historyEvent.Name == name).ShortDescription;
        }

        public string GetImage(string name, string directoryName)
        {
            return directoryName + @"\" + _events.FirstOrDefault(historyEvent => historyEvent.Name == name).PicturePath;
        }

        public Event ConvertToEvent(EventView view)
        {
            if (view == null)
            {
                return null;
            }

            return _events.Where(historyEvent => historyEvent.Name == view.Name)
                .FirstOrDefault();
        }

        private void WriteInJson()
        {
            File.WriteAllText(_path, JsonConvert.SerializeObject(_events));
        }
    }
}
