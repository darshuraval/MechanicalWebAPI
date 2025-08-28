	using Microsoft.Data.SqlClient;
	using System.Data;
	using System.Reflection;
	using System.Text.Json;

	namespace MechanicalWebAPI.DAL
	{

	public static class SQLManager
	{
		readonly static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=Mechanical;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
		static SQLManager()
		{

		}
		public static string GetConnectionString()
		{
			return connectionString;
		}

		public static string GetListing(object input, string SPName)
		{
			try
			{
				using (var connection = new SqlConnection(connectionString))
				{
					connection.Open();

					using (var cmd = new SqlCommand(SPName, connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						PropertyInfo[] propertyInfos = input.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

						if (propertyInfos != null)
						{
							foreach (var prop in propertyInfos)
							{
								var value = prop.GetValue(input) ?? DBNull.Value;
								cmd.Parameters.AddWithValue("@" + prop.Name, value);
							}
						}

						using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
						{
							DataTable dt = new DataTable();
							adapter.Fill(dt);

							// Convert DataTable → List of Dictionary
							var rows = new List<Dictionary<string, object>>();
							foreach (DataRow dr in dt.Rows)
							{
								var row = new Dictionary<string, object>();
								foreach (DataColumn col in dt.Columns)
								{
									row[col.ColumnName] = dr[col] == DBNull.Value ? null : dr[col];
								}
								rows.Add(row);
							}

							// Convert to JSON
							return JsonSerializer.Serialize(rows, new JsonSerializerOptions { WriteIndented = true });
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Database operation failed - GetListing : " + ex.Message, ex);
			}
		}


		public static int ExecuteNonQuery(object input, string SPName)
		{
			try
			{
				using (var connection = new SqlConnection(connectionString))
				{
					connection.Open();

					using (var cmd = new SqlCommand(SPName, connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						// add input params
						PropertyInfo[] propertyInfos = input.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
						if (propertyInfos != null)
						{
							foreach (var prop in propertyInfos)
							{
								var value = prop.GetValue(input) ?? DBNull.Value;
								cmd.Parameters.AddWithValue("@" + prop.Name, value);
							}
						}

						// add RETURN param
						var returnParam = new SqlParameter("@MachineID", SqlDbType.Int)
						{
							Direction = ParameterDirection.Output
						};
						cmd.Parameters.Add(returnParam);

						cmd.ExecuteNonQuery();

						// if RETURN value exists → return it
						if (returnParam.Value != DBNull.Value)
							return (int)returnParam.Value;

						// otherwise return affected rows
						return 0;
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Database operation failed - ExecuteNonQuery : " + ex.Message, ex);
			}
		}
		public static int DeleteById(object input, string SPName)
		{
			try
			{
				using (var connection = new SqlConnection(connectionString))
				{
					connection.Open();

					using (var cmd = new SqlCommand(SPName, connection))
					{
						cmd.CommandType = CommandType.StoredProcedure;

						// add input params
						PropertyInfo[] propertyInfos = input.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
						if (propertyInfos != null)
						{
							foreach (var prop in propertyInfos)
							{
								var value = prop.GetValue(input) ?? DBNull.Value;
								cmd.Parameters.AddWithValue("@" + prop.Name, value);
							}
						}

						// otherwise return affected rows
						return cmd.ExecuteNonQuery();;
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Database operation failed - ExecuteNonQuery : " + ex.Message, ex);
			}
		}
	}

}
