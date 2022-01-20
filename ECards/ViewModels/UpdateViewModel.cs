using ECards.GlobalConstants;
using ECardsLibFramework.Entities;
using ECardsLibFramework.Services;
using GalaSoft.MvvmLight.Command;
using System;

namespace ECards.ViewModels
{
    public class UpdateViewModel : DataViewModel
    {
        private ServiceCards _serviceCards = new ServiceCards(Pathes.Directory + "Events.json");

        private RelayCommand<Tuple<string, DateTime, DateTime, string, string>> _update;
        public RelayCommand<Tuple<string, DateTime, DateTime, string, string>> Update
        {
            get
            {
                if (_update == null)
                {
                    return new RelayCommand<Tuple<string, DateTime, DateTime, string, string>>(dataToAdd =>
                    {
                        _serviceCards.Update(dataToAdd.Item1,
                            new Event(dataToAdd.Item1, dataToAdd.Item2, dataToAdd.Item3, dataToAdd.Item4, dataToAdd.Item5));
                    });
                }

                return _update;
            }

            set
            {
                _update = value;
                OnPropertyChanged(nameof(Update));
            }
        }
    }
}
