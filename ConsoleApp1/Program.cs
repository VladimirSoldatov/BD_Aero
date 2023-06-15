
using System.Data;
using System.Data.SqlClient;
using System.Text;
// See https://aka.ms/new-console-template for more information

string connectionString = "" +
    "Data Source=(localdb)\\MSSQLLocalDB;" +
    "Initial Catalog=aero;" +
    "Integrated Security=True;" +
    "Connect Timeout=30;";

using (SqlConnection sqlConnection = new SqlConnection())
{
    sqlConnection.ConnectionString = connectionString;
    sqlConnection.Open();
    SqlCommand sqlCommand = sqlConnection.CreateCommand();
    sqlCommand.CommandText = "" +
        "SELECT\r\n" +
        "T.plane as [Название]\r\n" +
        ",Format(PIT.date, 'dd.mm.yyyy') as [Дата]\r\n" +
        ", P.name as [Имя пассажира]\r\n" +
        ", PIT.place as [Номер места]\r\n" +
        "FROM \r\n" +
        "[dbo].[Pass_in_trip] AS PIT\r\n" +
        "LEFT JOIN [dbo].[Trip] T \r\n" +
        "ON T.trip_no = PIT.trip_no\r\n" +
        "LEFT JOIN [dbo].[Passenger] AS P\r\n" +
        "ON P.ID_psg = PIT.ID_psg";
    SqlDataReader reader = sqlCommand.ExecuteReader();
    if(reader.HasRows)
    {
        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t\t{reader.GetName(2)}\t{reader.GetName(3)}");
        while(reader.Read())
        {
            object[] objects = new object[reader.FieldCount];
            reader.GetValues(objects);
            StringBuilder text = new StringBuilder();
            foreach(object item in objects)
            {
                text.Append(item.ToString() + "\t");
            }
            Console.WriteLine(text.ToString());
        }
    }
}
