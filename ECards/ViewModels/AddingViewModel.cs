﻿using System;
using ECardsLibFramework.Entities;
using ECardsLibFramework.Services;
using GalaSoft.MvvmLight.Command;

namespace ECards.ViewModels
{
    public class AddingViewModel : ViewModel
    {
        private const string Directory = @"D:\for learning\Портфолио\Texode\Data\";
        private ServiceCards _serviceCards = new ServiceCards(Directory + "Events.json");

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private DateTime _beginDate;
        public DateTime BeginDate
        {
            get
            {
                return _beginDate;
            }
            set
            {
                _beginDate = value;
                OnPropertyChanged(nameof(BeginDate));
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
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

        private RelayCommand _findImage;
        public RelayCommand FindImage
        {
            get
            {
                if (_findImage == null)
                {
                    return new RelayCommand(delegate ()
                    {
                        var imageDialog = new ImageDialog();
                        ImagePath = imageDialog.SearchImage().Replace(Directory, "").Replace(@"\", "/");
                    });
                }

                return _findImage;
            }
            set
            {
                _findImage = value;
                OnPropertyChanged(nameof(FindImage));
            }
        }

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
