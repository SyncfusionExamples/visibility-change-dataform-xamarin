# How to change the editor visibility based on another editor in Xamarin.Forms DataForm (SfDataForm)

You can change the editor visibility based on another editor in Xamarin.Forms SfDataForm using the IsVisible property of DataFormItem.

The following article explains you how to change the editor visibility based on another editor.
https://www.syncfusion.com/kb/11189/how-to-change-the-editor-visibility-based-on-another-editor-in-xamarin-forms-dataform 

To achieve these, you need to implement the INotifyPropertyChanged in data object model class and raise property changed notifier for all the properties.

**C#:** Raise property changed notifier for the DataForm’s DataObject property.
``` c#
 (dataForm.DataObject as DataFormModel).PropertyChanged += OnDataObjectPropertyChanged;
```
**C#:** Here, we are changing the visibility of ConfirmPassword field based on the value of Password field.
```c#
private void OnDataObjectPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
{
       var dataObject = sender as DataFormModel;
            
       if (e.PropertyName =="Password" && dataObject.Password != null)
       {
              var confirmPassword = dataForm.ItemManager.DataFormItems["ConfirmPassword"];
              confirmPassword.IsVisible = true;
       }
}
```
**Output**

![ChangingVisibility](https://github.com/SyncfusionExamples/visibility-change-dataform-xamarin/blob/master/ScreenShots/Output2.gif)
