using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook_ADODotNet
{
    public class AddressBook
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook_Service";

        public void AddNewContactInDataBase(AddressBookModel addressBookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpAddingNewData", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName", addressBookModel.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", addressBookModel.Address);
                    sqlCommand.Parameters.AddWithValue("@City", addressBookModel.City);
                    sqlCommand.Parameters.AddWithValue("@State", addressBookModel.State);
                    sqlCommand.Parameters.AddWithValue("@Zip", addressBookModel.Zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNUmber", addressBookModel.PhoneNUmber);
                    sqlCommand.Parameters.AddWithValue("@Email", addressBookModel.Email);

                    int result = sqlCommand.ExecuteNonQuery(); // For Executing Query
                    sqlConnection.Close();
                    if (result >= 1)
                        Console.WriteLine("New Contact added sussesfully");
                    else
                        Console.WriteLine("Error while adding new contact");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllDataFromDataBase()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<AddressBookModel> addressBookList = new List<AddressBookModel>();
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpGetAllDataFromDB", sqlConnection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            AddressBookModel addressBookModel = new AddressBookModel();

                            addressBookModel.FirstName = sqlReader.GetString(0);
                            addressBookModel.LastName = sqlReader.GetString(1);
                            addressBookModel.Address = sqlReader.GetString(2);
                            addressBookModel.City = sqlReader.GetString(3);
                            addressBookModel.State = sqlReader.GetString(4);
                            addressBookModel.Zip = sqlReader.GetInt32(5);
                            addressBookModel.PhoneNUmber = sqlReader.GetInt64(6);
                            addressBookModel.Email = sqlReader.GetString(7);

                            addressBookList.Add(addressBookModel);
                        }

                        foreach (AddressBookModel contact in addressBookList)
                        {
                            Console.WriteLine(contact.FirstName + " " +
                                contact.LastName + " " +
                                contact.Address + " " +
                                contact.City + " " +
                                contact.Zip);
                        }
                    }
                    else
                        Console.WriteLine("no data found in table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
