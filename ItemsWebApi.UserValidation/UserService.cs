using System;
using System.Collections.Generic;
using System.Text;
using ItemWebApi.Itemclass;
using ItemWebApi.CommonConnection;
using System.Data.SqlClient;


namespace ItemsWebApi.UserValidation
{
   public class UserService :Iuserservice
    {
        private SqlConnection _sqlConnection = new SqlConnection(ConnectionClass._ConnectionString);
        private SqlCommand _sqlCommand;
        public IEnumerable<User> GetAllUsers()
        {
            List<User> _UserList = new List<User>();
            try
            {
                _sqlCommand = new SqlCommand("Select * from Registration", _sqlConnection);
                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                    _sqlConnection.Open();


                SqlDataReader read = _sqlCommand.ExecuteReader();

                while (read.Read())
                {

                    _UserList.Add(new User() { FirstName = read.GetString(0), LastName = read.GetString(1), emailId = read.GetString(2), Mobileno = read.GetInt64(3), Password = read.GetString(4) });
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
            return _UserList;
        }


        public object GetUserPasswordByUserName(object _emailId)
        {
            
            object password = "";
            try
            {
                _sqlCommand = new SqlCommand($"select password1 from Registration where EmailId='{_emailId}", _sqlConnection);
                if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                    _sqlConnection.Open();


                password= _sqlCommand.ExecuteScalar();

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

            return password;
        }
        public bool LoginToNextPage(string _username,string _password)
        {
            bool isLogin = false;
            //try
            //{
            //    _sqlCommand = new SqlCommand($"select password1 from Registration where EmailId='{_emailId}", _sqlConnection);
            //    if (_sqlConnection.State == System.Data.ConnectionState.Closed)
            //        _sqlConnection.Open();

            //    isLogin = true;

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);

            //}
            //finally
            //{
            //    if (_sqlConnection.State == System.Data.ConnectionState.Open)
            //        _sqlConnection.Close();
            //}
            return isLogin;

        }
       public bool RegisterNewUser(User user)
        {
          bool  _isSuccess = false;
            try
            {
                _sqlCommand = new SqlCommand($"Insert into Registration('{user.FirstName}','{user.LastName}','{user.emailId}',{user.Mobileno},'{user.Password}')", _sqlConnection);


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
