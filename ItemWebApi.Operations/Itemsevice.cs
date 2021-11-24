// This class contain Methods of All Item operations
//Each Method Performs Each operations , these operations will be executed through item controller 

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

        //This method will return all items in the table
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

        //This method will return true if item inserted
        public bool InsertItem(Items _Item)
        {
            bool _isSuccess = false;

            try
            {
                _sqlCommand = new SqlCommand($"Insert into RetailItems values('{_Item.Id}','{_Item.Name}',{_Item.Quantity},{_Item.Price},'{_Item.Category}')", _sqlConnection);


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
        //This method will return true after updating Change in Price
        public bool UpdateItemPriceById(int _Id, int _Changeinprice)
        {
            bool _isSuccess = false;

            try
            {
                _sqlCommand = new SqlCommand($"Update Retailitems SET ItemPrice=ItemPrice+{_Changeinprice} where ItemId={_Id}", _sqlConnection);


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
        //This method will return true after updating Change in Price
        public bool UpdateItemPriceByCategory(string _category, int _Changeinprice)
        {
            bool _isSuccess = false;

            try
            {
                _sqlCommand = new SqlCommand($"Update Retailitems SET ItemPrice=ItemPrice+{_Changeinprice} where ItemCategory='{_category}'", _sqlConnection);


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
        //This Method Used to Delete any Item in table By using ItemId
        public bool DeleteItem(int _Id)
        {
            bool _isSuccess = false;

            try
            {
                _sqlCommand = new SqlCommand($"DELETE  from Retailitems where ItemId={_Id}", _sqlConnection);


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

        //This method returns Perticular Item by using its Id
        public IEnumerable<Items> GetItemById(int _id)
        {
            List<Items> _items = new List<Items>();
            try
            {
                _sqlCommand = new SqlCommand($"SELECT * FROM RetailItems where ItemId={_id}", _sqlConnection);
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

        //This method returns Perticular Item by using its Category
        public IEnumerable<Items> GetItemByCategory(string _category)
        {
            List<Items> _items = new List<Items>();
            try
            {
                _sqlCommand = new SqlCommand($"SELECT * FROM RetailItems where ItemCategory='{_category}'", _sqlConnection);
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

        //This Method used to Update the Change in Quantity of Item
        public bool UpdateItemQuantity(int _id, int _Changeinquantity)
        {
            bool _isSuccess = false;

            try
            {
                _sqlCommand = new SqlCommand($"Update Retailitems SET Quantity=Quantity+{_Changeinquantity} where ItemId={_id}", _sqlConnection);


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
    }
}