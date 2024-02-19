using System.Configuration;
using System.Data.Common;

namespace ExibitionConnectedLayer
{
    public partial class Form1 : Form
    {
        private ExibitionDAL.ExibitionDAL exibitionDAL;

        public Form1()
        {
            InitializeComponent();
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            exibitionDAL = new ExibitionDAL.ExibitionDAL();
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
                cn.Close();
            }
        }

        private void insertOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuChecks();
            insertOwnerToolStripMenuItem.Checked = true;

            rtbResult.Clear();

            toolStripStatusLabel.Text = "";
            toolStripStatusLabel.Text = "Через пробел: <last_name> <first_name> <middle_name> <id_home_address> <telephone>";
        }

        private void deleteContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuChecks();
            deleteContractToolStripMenuItem.Checked = true;

            rtbResult.Clear();

            toolStripStatusLabel.Text = "";
            toolStripStatusLabel.Text = "Введите такие параметры через пробел: <id>";
        }

        private void updateCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuChecks();
            updateCompanyToolStripMenuItem.Checked = true;

            rtbResult.Clear();

            toolStripStatusLabel.Text = "";
            toolStripStatusLabel.Text = "Введите такие параметры через пробел: <id> <new_name_company>";
        }

        private void dataTableProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuChecks();
            dataTableProductsToolStripMenuItem.Checked = true;

            rtbResult.Clear();

            toolStripStatusLabel.Text = "";
            toolStripStatusLabel.Text = "Введите такие параметры через пробел: <count_value>";
        }

        private void createContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuChecks();
            createContractToolStripMenuItem.Checked = true;

            rtbResult.Clear();

            toolStripStatusLabel.Text = "";
            toolStripStatusLabel.Text = "Через пробел: <companyID1> <companyID2> <productID> <dateOfConclusion> <deadline>";
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string input = rtbResult.Text.Trim();
            string[] lines = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            try
            {
                exibitionDAL.OpenConnection(connectionString); // Подключение

                foreach (string line in lines)
                {
                    string[] parameters = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (insertOwnerToolStripMenuItem.Checked && parameters.Length == 5)
                    {
                        exibitionDAL.InsertOwner(parameters[0], parameters[1], parameters[2], int.Parse(parameters[3]), parameters[4]);
                    }
                    else if (deleteContractToolStripMenuItem.Checked && parameters.Length == 1)
                    {
                        exibitionDAL.DeleteContract(int.Parse(parameters[0]));
                    }
                    else if (updateCompanyToolStripMenuItem.Checked && parameters.Length == 2)
                    {
                        exibitionDAL.UpdateCompanyName(parameters[0], parameters[1]);
                    }
                    else if (dataTableProductsToolStripMenuItem.Checked && parameters.Length == 1)
                    {
                        exibitionDAL.GetAllProductsAsDataTable(int.Parse(parameters[0]));
                    }
                    else if (createContractToolStripMenuItem.Checked && parameters.Length == 5)
                    {
                        int newContractID = exibitionDAL.CreateContract(parameters[0], parameters[1], parameters[2], DateTime.Parse(parameters[3]), int.Parse(parameters[4]));
                        MessageBox.Show($"Операция выполнена успешно. Новый индекс контракта: {newContractID}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Неправильное количество параметров или неизвестный метод.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show("Операция выполнена успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                exibitionDAL.CloseConnection(); // Закрываем подключение
            }
        }

        private void ClearMenuChecks()
        {
            insertOwnerToolStripMenuItem.Checked = false;
            deleteContractToolStripMenuItem.Checked = false;
            updateCompanyToolStripMenuItem.Checked = false;
            dataTableProductsToolStripMenuItem.Checked = false;
            createContractToolStripMenuItem.Checked = false;
        }
    }
}
