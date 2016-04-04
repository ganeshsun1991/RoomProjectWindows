using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using Dapper;
using System.Windows.Forms;
using System.Collections;
using System.Data;
namespace WindowsFormsApplication1
{

    class Medhods
    {
        static string constring = Convert.ToString(ConfigurationSettings.AppSettings["connection"]);
        SqlConnection cn = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public void CallMessageBox(string body, string title, string type)
        {

            if (type == "information")
            {
                MessageBox.Show(body, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (type == "error")
            {
                MessageBox.Show(body, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (type == "ex")
            {
                MessageBox.Show(body, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public IList<User> GetUserList()
        {
            IList<User> user = null;
            try
            {
                string sql = "select UserName,Passwod,[UserRole] from [dbo].[User]";
                cn.Open();

                user = cn.Query<User>(sql).ToList();
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return user;
        }
        public DataTable GetUserListCombo()
        {
            DataTable user = new DataTable();
            try
            {
                //string sql = "select UserID as ID,UserName as Name from [dbo].[User]";
                string sql = "exec [dbo].[FillCombo] 'user',0,''";
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                da.Fill(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return user;
        }
        public User GetUserDetaile(string uname, string pword, string id = "")
        {
            User user = null;
            Global gl = new Global();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("uname", uname);
                param.Add("pword", pword);
                param.Add("id", id);
                string sql = @"select u.UserID,u.UserName,u.Passwod,u.UserRole,u.Allow_Access,ud.NickName,ud.[Address],ud.MobileNo1,ud.MobileNo2,ud.JobName,ud.JoiningDate from dbo.[User] u
                           inner join dbo.UserDetails ud on ud.UserId =u.UserID";
                if (id == "")
                {
                    sql += " where UserName=@uname and Passwod=@pword and ISNULL(IsAcive,'')=1 ";
                }
                else
                {
                    sql += " where u.UserID=@id and ISNULL(IsAcive,'')=1 ";
                }
                cn.Open();
                user = cn.Query<User>(sql, param).SingleOrDefault();
                gl = cn.Query<Global>(sql, param).SingleOrDefault();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return user;

        }
        public IList<User> GetUserName(string uname)
        {
            IList<User> name = null;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("uname", uname);
                string sql = @"select UserName from dbo.[User] where UserName=@uname and ISNULL(IsAcive,0)=1";
                cn.Open();
                name = cn.Query<User>(sql, param).ToList();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return name;
        }
        public int GetLastId()
        {
            int id = 0;
            try
            {
                string sql = "select MAX(UserID)+1 AS UserID from [User]";
                cn.Open();
                id = cn.Query<int>(sql).SingleOrDefault();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return id;
        }
        public int InserUserDetails(User user)
        {
            int UserId = 0;
            try
            {
                var param = new
                {
                    UserID = user.UserID,
                    UserName = user.UserName,
                    Passwod = "pass@123",
                    UserRole = user.UserRole,
                    NickName = user.NickName,
                    Address = user.Address,
                    MobileNo1 = user.MobileNo1,
                    MobileNo2 = user.MobileNo2,
                    JobName = user.JobName,
                    Allow_Access = user.Allow_Access,
                    IsNonFoodUser = user.@IsNonFoodUser,
                    JoiningDate = user.JoiningDate,
                    IsAcive = user.IsAcive,
                };
                string sql = "[dbo].[UserInsert]";
                cn.Open();
                UserId = cn.Execute(sql, param, commandType: CommandType.StoredProcedure);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return UserId;
        }
        public SqlDataAdapter GetAllUsers()
        {
            SqlDataAdapter da = null;
            try
            {

                string sql = @"select u.UserID,u.UserName as [Member Name],ud.NickName [Nick Name],ud.[Address],ud.MobileNo1,ud.MobileNo2,ud.JobName as [Desigination],convert(date,ud.JoiningDate) as [Joining Date],u.UserRole as [Member Role],case when u.AllOw_Access=1 then 'Yes' else 'No' end as Allow_Access
                               from dbo.[User] u inner join dbo.UserDetails ud on u.UserID=ud.UserId 
                               where 1=1
                               and ISNULL(u.IsAcive,'')=1";
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                da = new SqlDataAdapter(cmd);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            //dt = cmd.ExecuteNonQuery();
            return da;
        }
        public int UpdateUserDetails(User user)
        {
            int res = 0;
            try
            {
                var param = new
                {
                    UserID = user.UserID,
                    UserName = user.UserName,
                    UserRole = user.UserRole,
                    NickName = user.NickName,
                    Address = user.Address,
                    MobileNo1 = user.MobileNo1,
                    MobileNo2 = user.MobileNo2,
                    JobName = user.JobName,
                    Allow_Access = user.Allow_Access,
                    IsAcive = user.IsAcive,
                };

                string sql = @"update dbo.[User] set
                               UserName=@UserName
                                ,UserRole=@UserRole
                                ,Allow_Access=@Allow_Access where UserID=@UserID;
                              update dbo.UserDetails set
                              Name=@UserName
                              ,NickName=@NickName
                              ,Address=@Address
                              ,MobileNo1=@MobileNo1
                              ,MobileNo2=@MobileNo2
                              ,JobName=@JobName   where UserID=@UserID;";
                cn.Open();
                res = cn.Execute(sql, param);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }

            return res;
        }
        public int DeleteUserDetails(int id)
        {
            int res = 0;
            try
            {
                var param = new
               {
                   UserID = id,
                   IsAcive = false
               };
                string sql = "update dbo.[User] set IsAcive=@IsAcive where UserID=@UserID";
                cn.Open();
                res = cn.Execute(sql, param);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return res;
        }
        public Transaction GetCurrentCommanTransaction()
        {
            Transaction trs = null;
            try
            {
                string sql = @"select * from dbo.CommonTransaction where 1=1 
                            and MONTH(TransactionDate) = MONTH(getdate())
                            and year(TransactionDate) = year(getdate())";
                cn.Open();
                trs = cn.Query<Transaction>(sql).SingleOrDefault();
                cn.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
            }
            return trs;
        }
        public SqlDataAdapter GetCommanTransaction()
        {
            SqlDataAdapter da = null;
            try
            {
                string sql = @"select top 1000 ct.Id as ID,ct.UserID as [User ID],u.UserName as [Membar Name],ct.TransactionName as [Transaction Name],convert(date,ct.TransactionDate) as [Transaction Date],DATENAME(month,ct.TransactionDate) [For The Month],YEAR(ct.TransactionDate) [For The Year],
                               case when isnull(ct.Descrption,'')='' then 'N/A' else ct.Descrption end as [Descrption],ct.Amount
                               from dbo.CommonTransaction ct inner join  dbo.[User] u on ct.UserID=u.UserID
                               where month(ct.TransactionDate) = month(getdate())
                               and year(ct.TransactionDate) = year(getdate())
                               order by ct.TransactionDate asc";
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                da = new SqlDataAdapter(cmd);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return da;
        }
        public SqlDataAdapter GetIndividualTransaction(int UserId)
        {
            SqlDataAdapter da = null;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("UserId", UserId);
                string sql = @"select ct.Id as ID,ct.UserID as [User ID],u.UserName as [Membar Name],ct.TransactionName as [Transaction Name],convert(date,ct.TransactionDate) as [Transaction Date],DATENAME(month,ct.TransactionDate) as [For The Month],YEAR(ct.TransactionDate) as [For The Year],
                               case when isnull(ct.Descrption,'')='' then 'N/A' else ct.Descrption end as [Descrption],ct.Amount
                               from dbo.IndividualTransaction ct inner join  dbo.[User] u on ct.UserID=u.UserID
                               where ct.UserID=" + UserId +
                               @" and month(getdate())=month(ct.TransactionDate)
                                  and year(getdate()) = year(ct.TransactionDate)
                                  and isnull(ct.TransactionName,'')<>'empty'
                               order by ct.TransactionDate asc";
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                da = new SqlDataAdapter(cmd);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return da;
        }
        public SqlDataAdapter GetIndividualTransactionAll()
        {
            SqlDataAdapter da = null;
            try
            {

                string sql = @"select ct.Id as ID,ct.UserID as [User ID],u.UserName as [Membar Name],ct.TransactionName as [Transaction Name],convert(date,ct.TransactionDate) as [Transaction Date],DATENAME(month,ct.TransactionDate) as [For The Month],YEAR(ct.TransactionDate) as [For The Year],
                               case when isnull(ct.Descrption,'')='' then 'N/A' else ct.Descrption end as [Descrption],ct.Amount
                               from dbo.IndividualTransaction ct inner join  dbo.[User] u on ct.UserID=u.UserID
                               where MONTH(getdate())=MONTH(ct.TransactionDate)
                               and year(getdate()) = year(ct.TransactionDate)
                               and ct.TransactionName<>'empty'
                               order by ct.TransactionDate desc";
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                da = new SqlDataAdapter(cmd);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return da;
        }
        public int InsertCommanTransaction(Transaction t)
        {
            int res = 0;
            try
            {
                var param = new
                    {
                        UserID = t.UserID,
                        TransactionDate = t.TransactionDate,
                        TransactionName = t.TransactionName,
                        Amount = t.Amount,
                        Descrption = t.Descrption,
                    };
                string sql = @"insert into CommonTransaction (UserID,TransactionDate,TransactionName,Amount,Descrption)values(@UserID,@TransactionDate,@TransactionName,@Amount,@Descrption)";
                cn.Open();
                res = cn.Execute(sql, param);
                cn.Close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return res;
        }
        public Boolean CheckRentAmountAvaliablity(int month, int year)
        {
            decimal ramount = 0;
            try
            {
                string sql = @"select Amount from dbo.CommonTransaction                                
                                where 1=1 
                                 and TransactionName='Rent'
                                 and month(TransactionDate)=" + month +
                                 "and year(TransactionDate) = " + year;
                cn.Open();
                ramount = cn.Query<Decimal>(sql).SingleOrDefault();
                cn.Close();
                if (ramount == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }

            return false;
        }
        public Transaction GetCommanTransactionById(int Id, string type)
        {
            Transaction tr = null;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("Id", Id);
                string sql = "";
                if (type == "ct")
                {
                    sql = @"select Id,UserID,TransactionDate,TransactionName,Amount,Descrption from dbo.CommonTransaction where Id=@Id";
                }
                else if (type == "idt")
                {
                    sql = @"select Id,UserID,TransactionDate,TransactionName,Amount,Descrption from dbo.IndividualTransaction where Id=@Id";
                }
                else if (type == "iall")
                {
                    sql = @"select Id,UserID,TransactionDate,TransactionName,Amount,Descrption from dbo.IndividualTransaction where Id=@Id";
                }

                cn.Open();
                tr = cn.Query<Transaction>(sql, param).SingleOrDefault();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return tr;
        }
        public int DeleteCommanTransactionById(int Id)
        {
            int res = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("Id", Id);
                string sql = @"delete from dbo.CommonTransaction where Id=@Id";
                cn.Open();
                res = cn.Execute(sql, param);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return res;
        }
        public int DeleteIndividualTransactionById(int Id)
        {
            int res = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("Id", Id);
                string sql = @"delete from dbo.IndividualTransaction where Id=@Id";
                cn.Open();
                res = cn.Execute(sql, param);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return res;
        }
        public int UpdateCommanTransacation(Transaction tr)
        {
            int res = 0;
            try
            {
                var param = new
                {
                    Id = tr.Id,
                    UserID = tr.UserID,
                    TransactionDate = tr.TransactionDate,
                    TransactionName = tr.TransactionName,
                    Amount = tr.Amount,
                    Descrption = tr.Descrption,
                };
                string sql = @"update dbo.CommonTransaction set 
                                UserID=@UserID,
                                TransactionDate=@TransactionDate,
                                TransactionName=@TransactionName,
                                Amount=@Amount,
                                Descrption=@Descrption
                                where Id=@Id";
                cn.Open();
                res = cn.Execute(sql, param);
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return res;
        }
        public int UpdateIndividualTransacation(Transaction tr)
        {
            int res = 0;
            try
            {
                var param = new
                {
                    Id = tr.Id,
                    UserID = tr.UserID,
                    TransactionDate = tr.TransactionDate,
                    TransactionName = tr.TransactionName,
                    Amount = tr.Amount,
                    Descrption = tr.Descrption,
                };
                string sql = @"update dbo.IndividualTransaction set 
                                UserID=@UserID,
                                TransactionDate=@TransactionDate,
                                TransactionName=@TransactionName,
                                Amount=@Amount,
                                Descrption=@Descrption
                                where Id=@Id";
                cn.Open();
                res = cn.Execute(sql, param);
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return res;
        }
        public int InsertIndividualTransaction(Transaction t)
        {
            int res = 0;
            try
            {
                var param = new
                {
                    UserID = t.UserID,
                    TransactionDate = t.TransactionDate,
                    TransactionName = t.TransactionName,
                    Amount = t.Amount,
                    Descrption = t.Descrption,
                };
                string sql = @"insert into IndividualTransaction (UserID,TransactionDate,TransactionName,Amount,Descrption)values(@UserID,@TransactionDate,@TransactionName,@Amount,@Descrption)";
                cn.Open();
                res = cn.Execute(sql, param);
                cn.Close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return res;
        }
        public DataTable GetCommanTransactionList(string type)
        {
            DataTable ct = new DataTable();
            try
            {

                string sql = "exec [dbo].[FillCombo] '" + type + "'";
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                da.Fill(ct);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return ct;
        }
        public DataTable GetUserNameByID(string type, int UserID)
        {
            DataTable ct = new DataTable();
            try
            {

                string sql = "exec [dbo].[FillCombo] '" + type + "'," + UserID + ",'yes'";
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                da.Fill(ct);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return ct;
        }
        public SqlDataAdapter GetIndividualShareAmount(string mode, int month, int year)
        {
            SqlDataAdapter da = null;
            try
            {
                string sql = @"EXEC [Calculation_Test] '" + mode + "'," + month + "," + year;
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                da = new SqlDataAdapter(cmd);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return da;
        }
        public decimal GetTotalExpensessAmountByUserID(int UserId)
        {
            decimal totamount = 0;
            try
            {
                var sql = "";
                DynamicParameters param = new DynamicParameters();
                param.Add("UserId", UserId);
                sql = @"select isnull(sum(idt.Amount),0) as TotalAmount from [dbo].[IndividualTransaction] idt 
                    inner join [dbo].[User] u on u.UserID=idt.UserID
                    where idt.UserID=@UserID
                    and MONTH(idt.TransactionDate)=MONTH(GETDATE())
                    and year(idt.TransactionDate) = year(GETDATE())
                    and isnull(u.IsAcive,0)=1";
                cn.Open();
                totamount = cn.Query<Decimal>(sql, param).SingleOrDefault();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return totamount;
        }
        public int ChangePasswordByID(string UserID, string pword)
        {
            int res = 0;
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("UserID", UserID);
                param.Add("password", pword);
                var sql = "update [dbo].[User] set [Passwod]=@password where UserID=@UserID";
                cn.Open();
                res = cn.Execute(sql, param);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return res;
        }
        public int GetUserCount()
        {
            int count = 0;
            try
            {
                string sql = "exec [dbo].[FillCombo] 'count',0,''";
                cn.Open();
                count = cn.Query<int>(sql).SingleOrDefault();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return count;
        }
        public CalculationDomain GetCalculationAmount(string month)
        {
            CalculationDomain cd = null;
            try
            {
                var sql = "EXEC [dbo].[Calculation] 'grp','" + month + "'";
                cn.Open();
                cd = cn.Query<CalculationDomain>(sql).SingleOrDefault();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return cd;
        }
        public SqlDataAdapter GetUserList(string mode)
        {
            SqlDataAdapter da = null;
            try
            {
                string sql = @"select UserID as ID,UserName as [Member Name] from [dbo].[User]  where isnull(IsAcive,0)=1 order by ID asc  ";
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                da = new SqlDataAdapter(cmd);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return da;
        }
        public void CallInsertScript(int userid)
        {
            try
            {
                int res;
                string sql = "exec [dbo].[InsertScript] " + userid;
                cn.Open();
                res = cn.Execute(sql);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public SqlDataAdapter GetCalculatedDataByYearMonth(int year, int month)
        {
            SqlDataAdapter da = null;
            DynamicParameters param = new DynamicParameters();
            param.Add("year", year, DbType.Int32);
            param.Add("month", month, DbType.Int32);
            try
            {

                //var sql = "EXEC [dbo].[CalculationByYearMonth] " + year + "," + month;
                var sql = @"select u.UserID,u.UserName As [Member Name],mpd.ExpensesAmount as [Expenses Amount] ,mpd.PayableAmount as [Payable Amount],case when mpd.IsPaided = 1 then 'Paided'else 'Unpaid' end as [Status]
                            from Ganesh.MonthlyPaymentDetails mpd
                            inner join dbo.[User] u with(nolock) on u.UserId=mpd.UserID
                            where year(Date) = " + year + @"
                            and month(Date) = " + month;
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                da = new SqlDataAdapter(cmd);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            //dt = cmd.ExecuteNonQuery();
            return da;
        }
        public List<User> GetUsersList(string type)
        {
            List<User> res = null;
            try
            {

                string sql = "exec [dbo].[FillCombo] '" + type + "'";
                cn.Open();
                res = cn.Query<User>(sql).ToList();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return res;
        }
    }
}
