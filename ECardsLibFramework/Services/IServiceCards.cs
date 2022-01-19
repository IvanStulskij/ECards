using ECardsLibFramework.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace ECardsLibFramework.Services
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceCards" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceCards
    {

        [OperationContract]
        IEnumerable<Event> GetEvents();

        [OperationContract]
        void Update(Event historicalEvent);
        [OperationContract]
    }
}
