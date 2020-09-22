# How-to-delete-an-item-when-tapping-delete-button-inside-listview-ItemTemplate-in-MVVM

You can delete an item from [ListView](https://help.syncfusion.com/xamarin/listview/getting-started) by the button loaded inside [ItemTemplate](https://help.syncfusion.com/cr/xamarin/Syncfusion.ListView.XForms.SfListView.html#Syncfusion_ListView_XForms_SfListView_ItemTemplate) in Xamarin.Forms.

You can also refer the following article.

https://www.syncfusion.com/kb/10173/how-to-remove-listview-item-using-itemtemplate-button-in-xamarin-forms-sflistview

**XAML**

**ViewModel** command bound to the Button Command by the reference of **ListView**

``` xml
<ContentPage xmlns:listView="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms">
    <ContentPage.Content>
        <Grid>
           <Syncfusion :SfListView x:Name="listView" 
                           ItemsSource="{Binding contactsInfo}" >
                        < Syncfusion :SfListView.ItemTemplate>
                            <DataTemplate>
                                <ViewCell>
                                        <Grid>
                                             <Button Text="Delete" Command="{Binding Path=BindingContext.DeleteCommand, Source={x:Reference listView}}" CommandParameter="{Binding .}"/>
                                        </Grid>
                                </ViewCell>
                            </DataTemplate>
                        </ Syncfusion: SfListView.ItemTemplate>
           </ Syncfusion: SfListView>
        </Grid>
    </ContentPage.Content>
</ContentPage>
```

**C#**

In **VeiwModel** command handler, removed the selected item from the collection.

``` c#
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
