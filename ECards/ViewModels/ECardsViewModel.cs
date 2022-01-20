using ECardsLibFramework.Entities;
using ECardsLibFramework.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECards.ViewModels
{
    public class ECardsViewModel : INotifyPropertyChanged
    {
        private ServiceCards _serviceCards = new ServiceCards(@"D:\for learning\Портфолио\Texode\Data\Events.json");
        private ObservableCollection<EventView> _events;
        private RelayCommand<string> _remove;
        //private 
        private EventView _selectedItem;
        private string _shortDescription;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
            
        }

        public ObservableCollection<EventView> Events
        {
            get
            {
                if (_serviceCards.GetEvents() == null)
                {
                    _events = new ObservableCollection<EventView>();
                }
                else
                {
                    _events = new ObservableCollection<EventView>(Event.ConvertToView(_serviceCards.GetEvents()));
                }
                return _events;
            }

            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

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
            }
        }

        public string ShortDescription
        {
            get
            {
                if (SelectedItem == null)
                {
                    return string.Empty;
                }
                
                return _serviceCards.GetDescription(SelectedItem.Name);
            }

            set
            {
                OnPropertyChanged(nameof(ShortDescription));
            }
        }

        public RelayCommand<string> Remove
        {
            get
            {
                if (_remove == null)
                {
                    return new RelayCommand<string>(name =>
                    {
                        _serviceCards.Remove(name);
                    });
                }
                else
                {
                    return _remove;
                }
            }

            set
            {
                OnPropertyChanged(nameof(Remove));
            }
        }
    }
}
