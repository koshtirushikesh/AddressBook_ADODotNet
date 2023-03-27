using System;

namespace AddressBook_ADODotNet
{
    // What is Ado.Net -> it is a frame Work
    public class Program
    {
        public static void Main(string[] args)
        {

            AddressBookModel addressBookModel = new AddressBookModel()
            {
                FirstName = "rushi",
                LastName = "KOshti",
                Address = "3/5 room no",
                City = "Mumbai",
                State = "MH",
                Zip = 400078,
                PhoneNUmber = 987654321,
                Email = "rushi.koshti2@gmail.com"
            };

            AddressBook addressBook = new AddressBook();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n1. Create Contact");
                Console.WriteLine("2. Exit the program");

                Console.Write("\nEnter option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (option)
                {
                    case 1: addressBook.AddNewContactInDataBase(addressBookModel); break;
                    
                    case 3: flag = false; break;
                }
                Console.ReadLine();
            }
        }
    }
}
