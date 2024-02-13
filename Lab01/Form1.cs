using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // ����� ����������� ���� � ����� � ����������� � ��
            string connectionString = GetConnectionString();
            MessageBox.Show($"������ �����������:\n{connectionString}", "����������� � ���� ������", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            // ��������� ������ ����������� � ���������� �� *.config
            string dp = ConfigurationManager.AppSettings["provider"];
            //string cnStr = ConfigurationManager.AppSettings["connectionString"];
            string cnStr = GetConnectionString();

            // ��������� ���������� ����������
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            DbConnection cn = df.CreateConnection();

            try
            {
                // ����� ������� �����������
                rtbResult.AppendText("������ ����������� --> " + cn.GetType().Name + "\n");

                cn.ConnectionString = cnStr;
                //������� �����������
                cn.Open();

                // �������� ������� �������
                DbCommand cmd = df.CreateCommand();
                rtbResult.AppendText("������ ������� --> " + cmd.GetType().Name + "\n");

                cmd.Connection = cn;
                cmd.CommandText = "Select * From Company";

                // ����� ������ � ������� ������� ���������� ������
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    rtbResult.AppendText("������ ���������� ������ --> " + dr.GetType().Name + "\n");
                    rtbResult.AppendText("\n--- ������� ������������ ������� Company ---\n");
                    rtbResult.AppendText("--------------------------------------------------------------------------\n");
                    while (dr.Read())
                    {
                        rtbResult.AppendText("-> ����� #" + dr["id_company"] + " -- " + dr["name"] + " -- " + dr["id_physical_address"] + " -- " + dr["id_owner"] + "\n");
                    }
                }
            }
            catch (DbException ex)
            {
                // ��������������� ����������
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // ������������� ������������� �����������
                cn.Close();
            }

        }

    }
}
