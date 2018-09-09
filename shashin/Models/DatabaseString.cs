using System;
using System.Collections.Generic;
using System.Text;

namespace shashin.Models
{
    public class DatabaseString
    {
        public string MyString { get; set; }
        public DatabaseString()
        {
        }
        public DatabaseString(string myString)
        {
            this.MyString = myString;
        }
    }
}
