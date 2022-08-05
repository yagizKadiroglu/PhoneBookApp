using System;
using System.Collections.Generic;

namespace PhoneBook
{
    class Program
    {
        
        static void Main(string[] args)
        {
            PhoneDal phoneDal = new PhoneDal();
            PhoneManager phoneManager = new PhoneManager();
            phoneManager.HomePage(phoneDal);      
        }

    }
}
