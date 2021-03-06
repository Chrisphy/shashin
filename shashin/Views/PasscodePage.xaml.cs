﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarcTron.Plugin.MTSql;
using SQLite;
using shashin.Models;

namespace shashin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PasscodePage : ContentPage
	{
        public SQLiteAsyncConnection CF_Database { get; set; }
        public PasscodePage()
        {
            InitializeComponent();
            CheckIfFirstTime();
        }
        private void EntryPasscode_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }
        private async void CheckIfFirstTime()
        {
            CF_Database = MTSql.Current.GetConnectionAsync("passcode.db");
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
                FirstTimePasscode.IsVisible = true;
            }
            else
            {
                FirstTimePasscode.IsVisible = false;
            }
        }
        private async void EntryPasscode_Completed(object sender, EventArgs e)
        {
            if (EntryPasscode.Text.Length == 0 || EntryPasscode.Text == "" || EntryPasscode.Text == "Incorrect Passcode")
            {
                return;
            }
            else
            {
                CF_Database = MTSql.Current.GetConnectionAsync("passcode.db");
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
                    await CF_Database.InsertAsync(new DatabaseString { MyString = EntryPasscode.Text });
                    App.Current.MainPage = new MainPage();
                }
                else
                {
                    var list = await CF_Database.Table<DatabaseString>().ToListAsync();
                    if (EntryPasscode.Text == list[0].MyString)
                    {
                        App.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        EntryPasscode.Text = "Incorrect Passcode";
                    }
                }
            }
        }
        private void EntryPasscode_Focused(object sender, FocusEventArgs e)
        {
            EntryPasscode.Text = "";
        }
    }
}