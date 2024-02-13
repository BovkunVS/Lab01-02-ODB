using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Вызов диалогового окна с инфой о подключении к БД
            string connectionString = GetConnectionString();
            MessageBox.Show($"Строка подключения:\n{connectionString}", "Подключение к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Information);

            InitializeComponent();

            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
        }

        private static string GetConnectionString()
        {
            var connect = new SqlConnectionStringBuilder();
            connect.InitialCatalog = "Exibition";
            connect.DataSource = @"VDBS";
            connect.PersistSecurityInfo = true;
            connect.UserID = "dbuser";
            connect.Password = "dbuser";
            connect.Encrypt = false;
            connect.ConnectTimeout = 30;
            return connect.ConnectionString;
        }

        private void loadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbResult.Clear();
            // Получение строки подключения и поставщика из *.config
            string dp = ConfigurationManager.AppSettings["provider"];
            //string cnStr = ConfigurationManager.AppSettings["connectionString"];
            string cnStr = GetConnectionString();

            // Получение генератора поставщика
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            DbConnection cn = df.CreateConnection();

            try
            {
                // Вывод объекта подключения
                rtbResult.AppendText("Объект подключения --> " + cn.GetType().Name + "\n");

                cn.ConnectionString = cnStr;
                //Открыть подключение
                cn.Open();

                // Создание объекта команды
                DbCommand cmd = df.CreateCommand();
                rtbResult.AppendText("Объект команды --> " + cmd.GetType().Name + "\n");

                cmd.Connection = cn;
                cmd.CommandText = "Select * From Company";

                // Вывод данных с помощью объекта считывания данных
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    rtbResult.AppendText("Объект считывания данных --> " + dr.GetType().Name + "\n");
                    rtbResult.AppendText("\n--- Текущее составляющее таблицы Company ---\n");
                    rtbResult.AppendText("--------------------------------------------------------------------------\n");
                    while (dr.Read())
                    {
                        rtbResult.AppendText("-> Фирма #" + dr["id_company"] + " -- " + dr["name"] + " -- " + dr["id_physical_address"] + " -- " + dr["id_owner"] + "\n");
                    }
                }
            }
            catch (DbException ex)
            {
                // Протоколировать исключение
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Гарантировать высвобождение подключения
                cn.Close();
            }

        }

    }
}
