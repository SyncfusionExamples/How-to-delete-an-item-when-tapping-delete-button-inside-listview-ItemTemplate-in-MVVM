using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewSample 
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Properties

        public ObservableCollection<Contacts> contactsinfo { get; set; }
        public Command<object> DeleteCommand { get; set; }
        public ImageSource AddIcon { get; }

        #endregion

        #region Constructor

        public ContactsViewModel()
        {
            contactsinfo = new ObservableCollection<Contacts>();
            DeleteCommand = new Command<object>(OnTapped);
            Random r = new Random();
            AddIcon = ImageSource.FromResource("ListViewSample.Images.Image" + 0 + ".png");
            for (int i=0;i<CustomerNames.Count();i++)
            {
                var contact = new Contacts();
                contact.ContactName = CustomerNames[i];
                contact.ContactNumber = r.Next(720, 799).ToString() + " - " + r.Next(3010, 3999).ToString();
                contactsinfo.Add(contact);
            }
        }

        private void OnTapped(object obj)
        {
            var contact = obj as Contacts;
            contactsinfo.Remove(contact);
            App.Current.MainPage.DisplayAlert("Message","Item Deleted :" +contact.ContactName,"Ok");
        }

        #endregion

        #region Fields

        string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
          };

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
