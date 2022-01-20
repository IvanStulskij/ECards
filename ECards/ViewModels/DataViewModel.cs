using System;
using ECards.GlobalConstants;
using ECardsLibFramework.Entities;
using GalaSoft.MvvmLight.Command;

namespace ECards.ViewModels
{
    public class DataViewModel : ViewModel
    {
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
                        ImagePath = imageDialog.SearchImage(Pathes.Directory);
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
    }
}
