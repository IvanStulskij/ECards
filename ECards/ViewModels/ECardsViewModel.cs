using ECardsLibFramework.Entities;
using ECardsLibFramework.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ECards.ViewModels
{
    public class ECardsViewModel : ViewModel
    {
        private ServiceCards _serviceCards = new ServiceCards(@"D:\for learning\Портфолио\Texode\Data\Events.json");

        private ObservableCollection<EventView> _events;

        public AddingViewModel AddingViewModel { get; set; } = new AddingViewModel();

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
                    ImagePath = _serviceCards.GetImage(SelectedItem.Name, @"D:\for learning\Портфолио\Texode\Data");
                }
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
        
        private string _shortDescription;
        public string ShortDescription
        {
            get
            {
                return _shortDescription;
            }
            set
            {
                _shortDescription = value;
                OnPropertyChanged(nameof(ShortDescription));
            }
        }

        private string _imagePath;
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }

            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
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
