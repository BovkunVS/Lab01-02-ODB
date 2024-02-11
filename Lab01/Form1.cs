using System.Configuration;
using System.Data.Common;

namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
        }

        private void loadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbResult.Clear();
            // Получение строки подключения и поставщика из *.config
            string dp = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.AppSettings["connectionString"];

            // Получение генератора поставщика
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            using (DbConnection cn = df.CreateConnection())
            {
                // Вывод объекта подключения
                rtbResult.AppendText("Объект подключения --> " + cn.GetType().Name + "\n");

                cn.ConnectionString = cnStr;
                cn.Open();
                // Создание объекта команды
                DbCommand cmd = df.CreateCommand();
                rtbResult.AppendText("Объект команды --> " + df.CreateCommand().GetType().Name + "\n");

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
        }

    }
}
