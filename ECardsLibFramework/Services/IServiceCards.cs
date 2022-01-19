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
        void Update(string eventToUpdate, Event newData);
        
        [OperationContract]
        void Remove(string removingEventName);

        [OperationContract]
        void Remove(IEnumerable<string> historicalEvents);
    }
}
