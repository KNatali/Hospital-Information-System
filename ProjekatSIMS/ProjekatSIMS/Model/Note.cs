using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Model
{
    public class Note : ValidationBase
    {
        private string vrijeme;
        private string description;

        public string Vrijeme
        {
            get { return vrijeme; }
            set
            {
                if (vrijeme != value)
                {
                    vrijeme = value;
                    OnPropertyChanged("Vrijeme");
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.vrijeme))
            {
                this.ValidationErrors["Vrijeme"] = "Polje je obavezno.";
            }
            if (string.IsNullOrWhiteSpace(this.description))
            {
                this.ValidationErrors["Description"] = "Description cannot be empty.";
            }
        }
    }
}
