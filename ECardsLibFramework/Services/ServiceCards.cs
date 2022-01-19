using ECardsLibFramework.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace ECardsLibFramework.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceCards : IServiceCards
    {
        private readonly string _path;
        public ServiceCards(string path)
        {
            _path = path;
        }

        public int Connect()
        {
            return 0;
        }

        public void Disconnect()
        {
            
        }

        public IEnumerable<Event> GetEvents()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Event>>(File.ReadAllText(_path));
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
