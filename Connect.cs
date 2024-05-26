using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FakeQQ
{
	class Connect
	{
		public MySqlConnection conn = null;//连接对象
		public MySqlCommand comm = null;//语句执行对象
		public MySqlDataReader dr = null;//语句执行结果数据对象

		public void load()
		{
			// 与数据库连接的信息
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
			// 数据库连接时的用户名，可以用pid
			builder.UserID = "root";
			// 数据库连接时的密码，可以用pwd
			builder.Password = "1234";
			// 数据库连接时的服务器地址
			builder.Server = "localhost";
			// 要连接的数据库
			builder.Database = "fake_qq";
			// 不校验ssl证书
			builder.SslMode = MySqlSslMode.None;
			// 定义与数据连接的链接
			conn = new MySqlConnection(builder.ConnectionString);
			// 打开这个链接
			conn.Open();
		}
	}
}
