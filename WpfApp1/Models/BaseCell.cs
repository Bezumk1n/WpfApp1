using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Enums;

namespace WpfApp1.Models
{
    public class BaseCell : NotifyPropertyChanged
    {
        public int Index { get; set; }
        private string _sampleName;
        public string SampleName
        {
            get => _sampleName;
            set
            {
                _sampleName = value;
                OnPropertyChanged();
            }
        }
        private Biomaterials _biomaterial;
        public Biomaterials Biomaterial
        {
            get => _biomaterial;
            set
            {
                _biomaterial = value;
                OnPropertyChanged();
            }
        }
    }
}
