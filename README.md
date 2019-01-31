# How-to-delete-an-item-when-tapping-delete-button-inside-listview-ItemTemplate-in-MVVM
You can delete an item from ListView by binding the command of button inside ItemTemplate to the command property in the ViewModel by passing the BindingContext in command parameter in MVVM.

```
<Syncfusion :SfListView x:Name="listView" ItemsSource="{Binding contactsInfo}" >
    <Syncfusion :SfListView.ItemTemplate>
       <DataTemplate>
         <ViewCell>
            <Grid>
              <Button Text="Delete" Command="{Binding Path=BindingContext.DeleteCommand, Source={x:Reference listView}}" CommandParameter="{Binding .}"/>
             </Grid>
           </ViewCell>
         </DataTemplate>
     </ Syncfusion: SfListView.ItemTemplate>
</ Syncfusion: SfListView>

```
```
namespace ListViewSample 
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
       public Command<object> DeleteCommand { get; set; }
       public ContactsViewModel()
       {
         DeleteCommand = new Command<object>(OnTapped);
       }
       private void OnTapped(object obj)
       {
         var contact = obj as Contacts;
         contactsinfo.Remove(contact);
         App.Current.MainPage.DisplayAlert("Message","Item Deleted :" +contact.ContactName,"Ok");
       }
    }
}

```
