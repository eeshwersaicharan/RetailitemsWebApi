using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ItemWebApi.CommonConnection;
using ItemWebApi.Itemclass;
using System.Text;

namespace ItemWebApi.Operations
{
    public class ItemService : IitemServices
    {
        private SqlConnection _sqlConnection = new SqlConnection(ConnectionClass._ConnectionString);
        private SqlCommand _sqlCommand;

        public IEnumerable<Items> GetAllItems()
        {
            List<Items> _items = new List<Items>();
            try
            {
                _sqlCommand = new SqlCommand("SELECT * FROM RetailItems", _sqlConnection);
                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                    _sqlConnection.Open();


                SqlDataReader read = _sqlCommand.ExecuteReader();

                while (read.Read())
                {

                    _items.Add(new Items() { Id = read.GetInt32(0), Name = read.GetString(1), Price = read.GetInt32(2), Quantity = read.GetInt32(3), Category = read.GetString(4) });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (_sqlConnection.State == System.Data.ConnectionState.Open)
                    _sqlConnection.Close();
            }

            return _items;
        }

        public bool InsertItem(Items _Item)
        {
            bool _isSuccess = false;

            try
            {
                _sqlCommand = new SqlCommand($"Insert into RetailItemsvalues('{_Item.Id}','{_Item.Name}'{_Item.Name},{_Item.Quantity},'{_Item.Category}')", _sqlConnection);


                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                    _sqlConnection.Open();


                _sqlCommand.ExecuteNonQuery();

                _isSuccess = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (_sqlConnection.State == System.Data.ConnectionState.Open)
                    _sqlConnection.Close();
            }
            return _isSuccess;
        }

        public bool UpdateItemPrice(int _Id, int _Increment)
        {
            bool _isSuccess = false;

            try
            {
                _sqlCommand = new SqlCommand($"Update STUDENT SET ItemPrice=ItemnPrice+{_Increment} where Id={_Id}", _sqlConnection);


                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                    _sqlConnection.Open();

                _sqlCommand.ExecuteNonQuery();

                _isSuccess = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (_sqlConnection.State == System.Data.ConnectionState.Open)
                    _sqlConnection.Close();
            }
            return _isSuccess;
        }

        public bool DeleteItem(int _Id)
        {
            bool _isSuccess = false;

            try
            {
                _sqlCommand = new SqlCommand($"DELETE from STUDENT where Id={_Id}", _sqlConnection);


                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                    _sqlConnection.Open();

                _sqlCommand.ExecuteNonQuery();

                _isSuccess = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (_sqlConnection.State == System.Data.ConnectionState.Open)
                    _sqlConnection.Close();
            }
            return _isSuccess;

        }
        public IEnumerable<Items> GetItemById()
        {
            List<Items> _items = new List<Items>();
            return _items;
        }

       public IEnumerable<Items> GetItemByCategory()
        {
            List<Items> _items = new List<Items>();
            return _items;
        }
    }
}