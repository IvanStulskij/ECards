using System;
using ECards.GlobalConstants;
using ECardsLibFramework.Entities;
using ECardsLibFramework.Services;
using GalaSoft.MvvmLight.Command;

namespace ECards.ViewModels
{
    public class AddingViewModel : DataViewModel
    {
        private readonly ServiceCards _serviceCards = new ServiceCards(Pathes.Directory + "Events.json");

        private RelayCommand<Tuple<string, DateTime, DateTime, string, string>> _add;
        public RelayCommand<Tuple<string, DateTime, DateTime, string, string>> Add
        {
            get
            {
                if (_add == null)
                {
                    return new RelayCommand<Tuple<string, DateTime, DateTime, string, string>>(dataToAdd =>
                    {
                        _serviceCards.Add(new Event
                            (dataToAdd.Item1, dataToAdd.Item2, dataToAdd.Item3, dataToAdd.Item4, dataToAdd.Item5));

                        Name = string.Empty;
                        ShortDescription = string.Empty;
                        ImagePath = string.Empty;
                        BeginDate = DateTime.MinValue;
                        EndDate = DateTime.MinValue;
                    });
                }

                return _add;
            }

            set
            {
                _add = value;
                OnPropertyChanged(nameof(Add));
            }
        }
    }
}
