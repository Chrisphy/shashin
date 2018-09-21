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
            GrabUserInformation();
        }
        private async void GrabUserInformation()
        {
            CF_Database = MTSql.Current.GetConnectionAsync("userinfo.db");
            List<DatabaseString> listResult;
            try
            {
                var list = await CF_Database.Table<DatabaseString>().ToListAsync();
                listResult = list;
            }
            catch (SQLiteException)
            {
                listResult = null;
            }
            if (listResult == null)
            {
                CF_Database.CreateTableAsync<DatabaseString>().Wait();
                await CF_Database.InsertAsync(new DatabaseString { MyString = "Name" });
                await CF_Database.InsertAsync(new DatabaseString { MyString = "LastName" });
                await CF_Database.InsertAsync(new DatabaseString { MyString = "Not Specified" });
            }
            var Newlist = await CF_Database.Table<DatabaseString>().ToListAsync();
            NewFirstNameTxt.Text = Newlist[0].MyString;
            NewLastNameTxt.Text = Newlist[1].MyString;
            NewGenderTxt.Text = Newlist[2].MyString;
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
        private async void Button_Clicked(object sender, EventArgs e)
        {
            CF_Database = MTSql.Current.GetConnectionAsync("userinfo.db");
            CF_Database.DropTableAsync<DatabaseString>().Wait();
            CF_Database.CreateTableAsync<DatabaseString>().Wait();
            await CF_Database.InsertAsync(new DatabaseString { MyString = NewFirstNameTxt.Text });
            await CF_Database.InsertAsync(new DatabaseString { MyString = NewLastNameTxt.Text });
            await CF_Database.InsertAsync(new DatabaseString { MyString = NewGenderTxt.Text });
        }
    }
}
