using ExibitionDisconnectedLayer;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace ExibitionConnectedLayer
{
    public partial class Form1 : Form
    {
        private ExibitionDAL.ExibitionDAL exibitionDAL;
        private ExibitionDL exibitionDL;

        public Form1()
        {
            InitializeComponent();
            DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            exibitionDAL = new ExibitionDAL.ExibitionDAL();
            exibitionDL = new ExibitionDL();
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

        private void dataTableSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuChecks();
            dataTableSelectToolStripMenuItem.Checked = true;

            rtbResult.Clear();

            toolStripStatusLabel.Text = "";
            toolStripStatusLabel.Text = "Введите такие параметры через пробел: <count_value> <nameTable>";
        }

        private void createContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuChecks();
            createContractToolStripMenuItem.Checked = true;

            rtbResult.Clear();

            toolStripStatusLabel.Text = "";
            toolStripStatusLabel.Text = "Через пробел: <companyID1> <companyID2> <productID> <dateOfConclusion> <deadline>";
        }

        private void removeProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuChecks();
            removeProductsToolStripMenuItem.Checked = true;

            rtbResult.Clear();

            toolStripStatusLabel.Text = "";
            toolStripStatusLabel.Text = "Через пробел: <true/false> <productID>";
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string input = rtbResult.Text.Trim();
            string[] lines = input.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            try
            {
                exibitionDAL.OpenConnection(connectionString); // Подключение к DAL

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
                    else if (dataTableSelectToolStripMenuItem.Checked && parameters.Length == 2)
                    {
                        DataTable table = exibitionDAL.GetAllDataAsDataTable(int.Parse(parameters[0]), parameters[1]);

                        rtbResult.AppendText("\n");

                        // Проверка о получении данных 
                        if (table != null && table.Rows.Count > 0)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                int columnCount = table.Columns.Count;
                                for (int i = 0; i < columnCount; i++)
                                {
                                    rtbResult.AppendText(row[i].ToString());
                                    if (i < columnCount - 1)
                                    {
                                        rtbResult.AppendText(" --- ");
                                    }
                                }
                                rtbResult.AppendText("\n");
                            }
                        }
                        else
                        {
                            rtbResult.AppendText("Данные не найдены");
                        }
                    }
                    else if (createContractToolStripMenuItem.Checked && parameters.Length == 5)
                    {
                        int newContractID = exibitionDAL.CreateContract(parameters[0], parameters[1], parameters[2], DateTime.Parse(parameters[3]), int.Parse(parameters[4]));
                        MessageBox.Show($"Операция выполнена успешно. Новый индекс контракта: {newContractID}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (removeProductsToolStripMenuItem.Checked && parameters.Length == 2)
                    {
                        exibitionDAL.NonParticipatingProducts(bool.Parse(parameters[0]), parameters[1]);
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
            dataTableSelectToolStripMenuItem.Checked = false;
            createContractToolStripMenuItem.Checked = false;
            removeProductsToolStripMenuItem.Checked = false;
        }

        private void createDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbResult.Clear();

            DataSet dataSet = exibitionDL.CreateDataSet(); // Вызов метода создания DataSet
            PrintDataSet(dataSet);
        }

        private void PrintDataSet(DataSet dataSet)
        {
            // Вывод имени и расширенных свойств
            rtbResult.AppendText("*** Объекты DataSet ***\n");
            rtbResult.AppendText($"Имя DataSet: {dataSet.DataSetName}\n");
            foreach (System.Collections.DictionaryEntry de in dataSet.ExtendedProperties)
                rtbResult.AppendText($"Ключ = {de.Key}, Значение = {de.Value}\n");
            rtbResult.AppendText("\n");

            // Вывод каждой таблицы
            foreach (DataTable table in dataSet.Tables)
            {
                rtbResult.AppendText($"Table: {table.TableName}\n");
                rtbResult.AppendText("-------------------\n");
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        rtbResult.AppendText($"{column.ColumnName}: {row[column]}");
                        if (column.Ordinal < table.Columns.Count - 1)
                            rtbResult.AppendText(" --> ");
                    }
                    rtbResult.AppendText("\n");
                }
                rtbResult.AppendText("\n");
            }
        }

        private void PrintOwnerTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbResult.Clear();

            DataSet ds = exibitionDL.CreateDataSet();

            DataTable dt = ds.Tables["Owner"];

            // Создание объекта DataTableReader
            DataTableReader dtReader = dt.CreateDataReader();

            while (dtReader.Read())
            {
                for (int i = 0; i < dtReader.FieldCount; i++)
                {
                    rtbResult.AppendText($"{dtReader.GetValue(i).ToString().Trim()}");
                    if (i < dtReader.FieldCount - 1)
                        rtbResult.AppendText(" --> ");
                }
                rtbResult.AppendText("\n");
            }
            dtReader.Close();
        }

        private void FillDataSetAdapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbResult.Clear();

            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DataSet ds = exibitionDL.CreateDataSet(); // Получаем DataSet

            string sql = "SELECT * FROM Company";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                // Проверка,содержится ли таблица "Company" в DataSet
                if (!ds.Tables.Contains("Company"))
                {
                    // Если таблицы нет, создаем ее
                    DataTable companyTable = new DataTable("Company");
                    ds.Tables.Add(companyTable);
                }

                // Заполняем таблицу в DataSet данными из базы данных
                adapter.Fill(ds, "Company");
            }
            PrintDataSet(ds);
        }

        private void ModifyDataSetAdapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbResult.Clear();

            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DataSet ds = exibitionDL.CreateDataSet(); // Получаем DataSet

            // Получаем таблицу из DataSet
            DataTable dt = ds.Tables[0];

            // Добавляем новую строку
            DataRow newRow = dt.NewRow();
            newRow["id_address"] = 6097;
            newRow["city"] = "Fasad";
            newRow["street"] = "Lorte";
            newRow["house"] = 3;
            newRow["apartment"] = 218;
            dt.Rows.Add(newRow);

            // Меняем значение в столбце "quantity" для 3 строки
            dt.Rows[2]["house"] = 5;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Задаем команду для DataAdapter
                adapter.SelectCommand = new SqlCommand("SELECT * FROM Address", connection);

                // Создаем объект SqlCommandBuilder
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                rtbResult.AppendText($"{builder.GetUpdateCommand().CommandText}\n");
                rtbResult.AppendText($"{builder.GetInsertCommand().CommandText}\n");
                rtbResult.AppendText($"{builder.GetDeleteCommand().CommandText}\n");
                // Обновляем изменения в базе данных
                adapter.Update(ds, "Address");

                // Полностью очищаем DataSet
                ds.Clear();

                // Перезагружаем данные из базы данных
                adapter.Fill(ds, "Address");
            }

            // Отображаем данные
            // Перебираем все столбцы таблицы
            foreach (DataColumn column in dt.Columns)
            {
                rtbResult.AppendText($"{column.ColumnName}");
                if (column != dt.Columns[dt.Columns.Count - 1])
                {
                    rtbResult.AppendText(" --> ");
                }
            }
            rtbResult.AppendText("\n--------------------------------------------------------------------------\n");

            // Перебираем все строки таблицы
            foreach (DataRow row in dt.Rows)
            {
                // Получаем все элементы строки
                var cells = row.ItemArray;
                for (int i = 0; i < cells.Length; i++)
                {
                    rtbResult.AppendText($"{cells[i]}");
                    if (i != cells.Length - 1)
                    {
                        rtbResult.AppendText(" --> ");
                    }
                }
                rtbResult.AppendText("\n");
            }
        }

        private void DeleteRowFromTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbResult.Clear();

            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DataSet ds = exibitionDL.CreateDataSet(); // Получаем DataSet

            // Получаем таблицу из DataSet
            DataTable dt = ds.Tables[4];

            // Сохраняем данные удаленной строки для итогового вывода
            object[] deletedRowData = dt.Rows[0].ItemArray;

            // Удаляем первую строку
            dt.Rows[0].Delete();

            // Подтверждаем изменения в таблице
            dt.AcceptChanges();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Открываем подключение
                connection.Open();

                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Задаем команду для DataAdapter
                adapter.SelectCommand = new SqlCommand("SELECT * FROM Contract", connection);

                // Создаем объект SqlCommandBuilder
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                // Обновляем изменения в базе данных
                adapter.Update(ds, "Contract");
            }

            // Выводим удаленную строку в rtbResult
            rtbResult.AppendText("Удалена строка из таблицы Contract:\n");
            for (int i = 0; i < deletedRowData.Length; i++)
            {
                rtbResult.AppendText($"{deletedRowData[i]}");
                if (i != deletedRowData.Length - 1)
                {
                    rtbResult.AppendText(" --> ");
                }
            }
            rtbResult.AppendText("\n");
        }
    }
}
