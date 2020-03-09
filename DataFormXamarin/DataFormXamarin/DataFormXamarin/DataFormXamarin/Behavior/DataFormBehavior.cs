using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Syncfusion.XForms.DataForm;
using System.Collections;

namespace DataFormXamarin
{
    public class DataFormBehavior : Behavior<ContentPage>
    {
        SfDataForm dataForm;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dataForm");
            dataForm.DataObject = new DataFormModel();
            (dataForm.DataObject as DataFormModel).PropertyChanged += OnDataObjectPropertyChanged;
            dataForm.AutoGeneratingDataFormItem += OnAutoGeneratingDataFormItem;
            dataForm.RegisterEditor("Country", "DropDown");
            dataForm.RegisterEditor("City", "DropDown");
        }

        private void OnAutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if(e.DataFormItem != null)
            {
                if(e.DataFormItem.Name =="ConfirmPassword")
                {
                    e.DataFormItem.IsVisible = false;
                }
            }
        }

        private void OnDataObjectPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dataObject = sender as DataFormModel;
            if(e.PropertyName =="Password" && dataObject.Password != null)
            {
                var confirmPassword = dataForm.ItemManager.DataFormItems["ConfirmPassword"];
                confirmPassword.IsVisible = true;
            }
        }
    }
}
