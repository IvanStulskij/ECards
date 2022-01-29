using ECardsLibFramework.Entities;
using ECardsLibFramework.Files;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ECardsLibFramework.Source
{
    public class JsonSource : ISource
    {
        public IPath _path;

        public JsonSource(IPath path)
        {
            _path = path;
        }

        public IEnumerable<Event> GetEvents()
        {
            return JsonConvert.DeserializeObject<HashSet<Event>>(File.ReadAllText(_path.Path));
        }

        public void WriteInfo(IEnumerable<Event> events)
        {
            File.WriteAllText(_path.Path, JsonConvert.SerializeObject(events));
        }
    }
}
