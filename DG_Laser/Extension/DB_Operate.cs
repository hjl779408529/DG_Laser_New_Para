using ADOX;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DG_Laser 
{
    class DB_Operate
    {
        OleDbConnection DBConnection;
        OleDbDataAdapter DBAdapter;
        OleDbCommandBuilder DBBuilder;
        private string txtConn; 
        private string TBName;
        private string DBName;
        private string FilePath;
        public DataTable DB_Table;
        /// <summary>
        /// 构造函数
        /// </summary>
        public DB_Operate(string dbName, string tbName,string path)
        {
            string currentPath = new DirectoryInfo("./").FullName;//获取当前应用程序路径的目录 
            DBName = dbName;
            TBName = tbName;

            FilePath = currentPath + path + "//";
            txtConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + DBName + ";Jet OLEDB:Database Password=dg123";
            DBConnection = new OleDbConnection(txtConn);
            UpdateDatable();
            UpdateAdapterCommand();
        }
        public void UpdateByDt(DataTable dt)
        {            
            DBAdapter.Update(dt);
        }
        /// <summary>
        /// 更新DataTable
        /// </summary>
        public void UpdateDatable()
        {
            string txtCommand = "SELECT * FROM " + "[" + TBName + "]";
            DBAdapter = new OleDbDataAdapter(txtCommand, DBConnection);
            DB_Table = new DataTable();
            DBAdapter.Fill(DB_Table);
        }
        /// <summary>
        /// 更新Adapter命令
        /// </summary>
        public void UpdateAdapterCommand()
        {
            string txtCommand = "SELECT * FROM " + "[" + TBName + "]";
            DBAdapter = new OleDbDataAdapter(txtCommand, DBConnection);
            DBBuilder = new OleDbCommandBuilder(DBAdapter);
            DBBuilder.QuotePrefix = "`";
            DBBuilder.QuoteSuffix = "`";
            DBAdapter.UpdateCommand = DBBuilder.GetUpdateCommand();
            DBAdapter.DeleteCommand = DBBuilder.GetDeleteCommand();
            DBAdapter.InsertCommand = DBBuilder.GetInsertCommand();
        }

        /// <summary>
        /// 获取指定字段列数据
        /// </summary>
        public List<string> getUserList(string fields)
        {
            List<string> Result = new List<string>();
            UpdateDatable();
            /**方法一**/
            //foreach (DataRow row in DB_Table.Rows)
            //{
            //    Result.Add(row[fields].ToString());
            //}
            /**方法二**/
            Result = (from d in DB_Table.AsEnumerable() select d.Field<string>(fields)).ToList();
            return Result;
        }
        /// <summary>
        /// 查询用户和密码
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool questDB(string command)
        {
            openDBConnect();
            OleDbCommand cmd = new OleDbCommand(command, DBConnection);
            OleDbDataReader hyw = cmd.ExecuteReader();
            if (hyw.Read())
            {
                closeDBConnect();
                return true;
            }
            else
            {
                closeDBConnect();
                return false;
            }            
        }
        /// <summary>
        /// 向数据库追加数据
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        public bool addToDB(string fields,string values)
        {
            openDBConnect();
            string sql = string.Format("insert into [User]({0}) values({1})", fields, values);
            OleDbCommand cmd = new OleDbCommand(sql, DBConnection);
            cmd.ExecuteNonQuery();
            closeDBConnect();
            return true;
        }
        /// <summary>
        /// 向数据库表中追加数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool addToDB(Dictionary<string, object> data) 
        {
            DataRow dataRow = DB_Table.NewRow();
            openDBConnect();
            if (data.Count > 0)
            {
                string fields = null;
                string values = null;
                string sql = null;
                foreach (var item in data)
                {
                    fields += item.Key.ToString() + ',';
                    values += string.Format("'{0}'", item.Value.ToString()) + ',';
                    dataRow[item.Key.ToString()] = item.Value.ToString();
                }
                DB_Table.Rows.Add(dataRow);
                fields = fields.Remove(fields.Length - 1, 1);
                values = values.Remove(values.Length - 1, 1);
                sql = string.Format("insert into [{0}]({1}) values({2})", TBName, fields, values);
                OleDbCommand cmd = new OleDbCommand(sql, DBConnection);
                cmd.ExecuteNonQuery();
            }
            closeDBConnect();
            return true;
        }
        /// <summary>
        /// 从数据库删除数据
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool deleteDB(string fields, string values)
        {
            openDBConnect();
            string sql = string.Format("delete from [User] where {0} = {1}", fields, values);
            OleDbCommand cmd = new OleDbCommand(sql, DBConnection);
            cmd.ExecuteNonQuery();
            closeDBConnect();
            return true;
        }
        /// <summary>
        /// 更新表数据
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool updateDB(string fields, string values, string pos)
        {
            openDBConnect();
            string sql = string.Format("update [User] set {0} = '{1}' where User_Name = '{2}'", fields, values, pos);
            OleDbCommand cmd = new OleDbCommand(sql, DBConnection);
            cmd.ExecuteNonQuery();
            closeDBConnect();
            return true;
        }
        /// <summary>
        /// 在指定目录下创建DB
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool createAcessDB(string filename)
        {
            Catalog catalog = new Catalog();
            string path = FilePath + filename;
            if (!File.Exists(path))
            {
                try
                {
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Jet OLEDB:Engine Type=5");
                }
                catch (System.Exception e)
                {
                    Trace.TraceWarning("创建Access数据库出错");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 向指定Access中添加指定的表格
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tbName"></param>
        /// <param name="colums"></param>
        /// <returns></returns>
        public bool createAccessTable(string dbName, string tbName, List<string> colums)
        {
            /*****检查数据库文件是否存在******/
            Catalog catalog = new Catalog();
            string path = FilePath + "WorkData\\" + dbName;
            if (!File.Exists(path))
            {
                try
                {
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Jet OLEDB:Engine Type=5");
                }
                catch (System.Exception e)
                {
                    Trace.TraceWarning("创建Access数据库出错");
                    return false;
                }
            }
            /********连接数据库*********/
            ADODB.Connection connection = new ADODB.Connection();
            try
            {
                connection.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path, null, null, -1);
            }
            catch (System.Exception ex)
            {
                Trace.TraceWarning("Access连接打开失败", ex);
                return false;
            }
            /********向数据库文件追加表格*********/
            catalog.ActiveConnection = connection;
            Table table = new Table
            {
                ParentCatalog = catalog,
                Name = tbName
            };
            /*******Table的列名*********/
            //{
            //    colums.Insert(0, "test_time");
            //    colums.Insert(1, "circuit_batches");
            //    colums.Insert(2, "function");
            //    colums.Insert(3, "ins_no");
            //    colums.Insert(4, "fixture_no");
            //    colums.Insert(5, "testos_no");
            //}
            foreach (var column in colums)
            {
                ColumnClass col = new ColumnClass
                {
                    ParentCatalog = catalog,
                    Name = column,
                    Attributes = ColumnAttributesEnum.adColNullable//允许空值
                };
                table.Columns.Append(col, DataTypeEnum.adVarWChar, 50);//默认数据类型和字段大小
            }
            /***测试连接***/
            OleDbConnection accessConnection = new OleDbConnection(connection.ConnectionString);
            if (!accessConnection.TableExists(tbName)) catalog.Tables.Append(table);//追加表数据
            try
            {
                accessConnection.Open();
            }
            catch (System.Exception ex)
            {
                Trace.TraceWarning("Access连接打开失败", ex);
                return false;
            }
            accessConnection.Close();
            connection.Close();
            return true;
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void closeDBConnect()
        {
            if (!(DBConnection.State == ConnectionState.Closed)) DBConnection.Close();
        }
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void openDBConnect()
        {
            if (DBConnection.State == ConnectionState.Closed) DBConnection.Open();
        }
    }

    /// <summary>
    /// 数据库连接扩展
    /// </summary>
    public static class DbConnectionExtensions
    {
        /// <summary>
        /// 判断数据库中是否存在某个表
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static bool TableExists(this DbConnection conn, string table)
        {
            conn.Open();
            var exists = conn.GetSchema("Tables", new string[4] { null, null, table, "TABLE" }).Rows.Count > 0;
            conn.Close();
            return exists;
        }
    }

}
