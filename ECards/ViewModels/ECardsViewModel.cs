using System;
using ECardsLibFramework.Entities;
using ECardsLibFramework.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;

namespace ECards.ViewModels
{
    public class ECardsViewModel : DataViewModel
    {
        private ServiceCards _serviceCards;
        private readonly string _jsonFile;
        private ObservableCollection<EventView> _events;

        public ECardsViewModel()
        {
            var openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
            openDialog.Title = "Choose JSON";
            _jsonFile = openDialog.FileName;
            _serviceCards = new ServiceCards(_jsonFile);
        }

        public AddingViewModel AddingViewModel { get; set; } = new AddingViewModel();
        public UpdateViewModel UpdateViewModel { get; set; } = new UpdateViewModel();

        public ObservableCollection<EventView> Events
        {
            get
            {
                if (_serviceCards.GetEvents() == null)
                {
                    return new ObservableCollection<EventView>();
                }

                if (_events == null)
                {
                    return new ObservableCollection<EventView>(Event.ConvertToView(_serviceCards.GetEvents()));
                }

                return _events;
            }

            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        private EventView _selectedItem;
        public EventView SelectedItem 
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (SelectedItem != null)
                {
                    ShortDescription = _serviceCards.GetDescription(SelectedItem.Name);
                    ImagePath = _serviceCards.GetImage(SelectedItem.Name, Path.GetDirectoryName(_jsonFile));
                    SelectedItemAsEvent = _serviceCards.ConvertToEvent(SelectedItem);
                }
            }
        }
        private Event _selectedItemAsEvent;
        public Event SelectedItemAsEvent
        {
            get
            {
                return _selectedItemAsEvent;
            }
            set
            {
                _selectedItemAsEvent = value;
                OnPropertyChanged(nameof(SelectedItemAsEvent));
            }
        }

        private IEnumerable<EventView> _selectedItems;
        public IEnumerable<EventView> SelectedItems
        {
            get
            {
                return _selectedItems;
            }

            set
            {
                _selectedItems = value;
                OnPropertyChanged(nameof(SelectedItems));
            }
        }

        private RelayCommand<Tuple<string, DateTime, DateTime, string, string>> _update;
        public RelayCommand<Tuple<string, DateTime, DateTime, string, string>> Update
        {
            get
            {
                if (_update == null)
                {
                    return new RelayCommand<Tuple<string, DateTime, DateTime, string, string>>(dataToAdd =>
                    {
                        _serviceCards.Update(SelectedItem.Name,
                            new Event(dataToAdd.Item1, dataToAdd.Item2, dataToAdd.Item3, dataToAdd.Item4, dataToAdd.Item5));
                        Events = new ObservableCollection<EventView>(Event.ConvertToView(_serviceCards.GetEvents()));
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

        private RelayCommand<string> _remove;
        public RelayCommand<string> Remove
        {
            get
            {
                if (_remove == null)
                {
                    return new RelayCommand<string>(name =>
                    {
                        _serviceCards.Remove(name);
                        Events = new ObservableCollection<EventView>(Event.ConvertToView(_serviceCards.GetEvents()));
                    });
                }
                else
                {
                    return _remove;
                }
            }

            set
            {
                _remove = value;
                OnPropertyChanged(nameof(Remove));
            }
        }
    }
}
