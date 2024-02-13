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
            // ��������� ������ ����������� � ���������� �� *.config
            string dp = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.AppSettings["connectionString"];

            // ��������� ���������� ����������
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            using (DbConnection cn = df.CreateConnection())
            {
                // ����� ������� �����������
                rtbResult.AppendText("������ ����������� --> " + cn.GetType().Name + "\n");

                cn.ConnectionString = cnStr;
                cn.Open();
                // �������� ������� �������
                DbCommand cmd = df.CreateCommand();
                rtbResult.AppendText("������ ������� --> " + df.CreateCommand().GetType().Name + "\n");

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
        }

    }
}
