using SQLite;
using System;
using System.Collections.Generic;
using MarcTron.Plugin.MTSql;
using Xamarin.Forms;
using shashin.Models;

namespace shashin.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SQLiteAsyncConnection CF_Database { get; set; }
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            if (NewPasscodeTxt.Text == null || NewPasscodeTxt.Text == "" || NewPasscodeTxt.Text == "Enter Passcode Here")
            {
                return;
            }
            else
            {
                CF_Database = MTSql.Current.GetConnectionAsync("passcode.db");
                CF_Database.DropTableAsync<DatabaseString>().Wait();
                CF_Database.CreateTableAsync<DatabaseString>().Wait();
                await CF_Database.InsertAsync(new DatabaseString { MyString = NewPasscodeTxt.Text });
                NewPasscodeTxt.Text = "";
            }
        }
    }
}
