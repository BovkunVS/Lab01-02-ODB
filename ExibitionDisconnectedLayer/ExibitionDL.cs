using ExibitionDAL;
using System;
using System.Data;

namespace ExibitionDisconnectedLayer
{
    public class ExibitionDL
    {
        public DataSet CreateDataSet()
        {
            // Создание DataSet
            DataSet ExibitionDS = new DataSet("Exibition");
            ExibitionDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            ExibitionDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            ExibitionDS.ExtendedProperties["Company"] = "Exibition of wishes";

            FillAddressTable(ExibitionDS);
            FillOwnerTable(ExibitionDS);
            FillCompanyTable(ExibitionDS);
            FillProductsTable(ExibitionDS);
            FillContractTable(ExibitionDS);

            return ExibitionDS;
        }

        public DataSet FillAddressTable(DataSet ds)
        {
            DataColumn addressIDColumn = new DataColumn("id_address", typeof(int));
            addressIDColumn.Caption = "id_address";
            addressIDColumn.ReadOnly = true;
            addressIDColumn.AllowDBNull = false;
            addressIDColumn.Unique = true;
            addressIDColumn.AutoIncrement = true;
            addressIDColumn.AutoIncrementSeed = 1000;
            addressIDColumn.AutoIncrementStep = 1;

            DataColumn addressCityColumn = new DataColumn("city", typeof(string));
            DataColumn addressStreetColumn = new DataColumn("street", typeof(string));
            DataColumn addressHouseColumn = new DataColumn("house", typeof(int));
            DataColumn addressApartmentColumn = new DataColumn("apartment", typeof(int));

            // Добавление объектов DataColumn в DataTable
            DataTable addressTable = new DataTable("Address");
            addressTable.Columns.AddRange(new DataColumn[] { addressIDColumn, addressCityColumn, 
                addressStreetColumn, addressHouseColumn, addressApartmentColumn });

            // Добавление строк в таблицу
            DataRow addressRow = addressTable.NewRow();
            addressRow["city"] = "Raccoon City";
            addressRow["street"] = "Uptown"; 
            addressRow["house"] = 4;
            addressRow["apartment"] = 312;

            addressTable.Rows.Add(addressRow);

            addressRow = addressTable.NewRow();
            addressRow[1] = "Boston"; 
            addressRow[2] = "Puritans";
            addressRow[3] = 1;
            addressRow[4] = 56;

            addressTable.Rows.Add(addressRow);

            // Первичный ключ для таблицы
            addressTable.PrimaryKey = new DataColumn[] { addressTable.Columns[0] };

            // Добавление таблицы в DataSet
            ds.Tables.Add(addressTable);

            Logger.Log("Filling Address table...");

            return ds;
        }

        public DataSet FillOwnerTable(DataSet ds)
        {
            DataColumn ownerIDColumn = new DataColumn("id_owner", typeof(int));
            ownerIDColumn.Caption = "id_owner";
            ownerIDColumn.ReadOnly = true;
            ownerIDColumn.AllowDBNull = false;
            ownerIDColumn.Unique = true;
            ownerIDColumn.AutoIncrement = true;
            ownerIDColumn.AutoIncrementSeed = 1;
            ownerIDColumn.AutoIncrementStep = 1;

            DataColumn ownerLastNameColumn = new DataColumn("last_name", typeof(string));
            DataColumn ownerFirstNameColumn = new DataColumn("first_name", typeof(string));
            DataColumn ownerMiddleNameColumn = new DataColumn("middle_name", typeof(string));
            DataColumn ownerAddressIDColumn = new DataColumn("id_home_address", typeof(int));
            DataColumn ownerTelephoneColumn = new DataColumn("telephone", typeof(string));

            // Добавление объектов DataColumn в DataTable
            DataTable ownerTable = new DataTable("Owner");
            ownerTable.Columns.AddRange(new DataColumn[] { ownerIDColumn, ownerLastNameColumn, 
                ownerFirstNameColumn, ownerMiddleNameColumn, ownerAddressIDColumn, ownerTelephoneColumn });

            // Добавление строк в таблицу
            DataRow ownerRow = ownerTable.NewRow();
            ownerRow["last_name"] = "Kenway";
            ownerRow["first_name"] = "Haytham";
            ownerRow["middle_name"] = "Edward";
            ownerRow["id_home_address"] = 1001;
            ownerRow["telephone"] = 1234567890;

            ownerTable.Rows.Add(ownerRow);

            ownerRow = ownerTable.NewRow();
            ownerRow[1] = "Kennedy";
            ownerRow[2] = "Leon";
            ownerRow[3] = "Scott";
            ownerRow[4] = 1000;
            ownerRow[5] = 1234567890;

            ownerTable.Rows.Add(ownerRow);

            // Первичный ключ для таблицы
            ownerTable.PrimaryKey = new DataColumn[] { ownerTable.Columns[0] };

            // Добавление таблицы в DataSet
            ds.Tables.Add(ownerTable);

            Logger.Log("Filling Owner table...");

            return ds;
        }

        public DataSet FillCompanyTable(DataSet ds)
        {
            DataColumn companyIDColumn = new DataColumn("id_company", typeof(string));
            companyIDColumn.Caption = "id_company";
            companyIDColumn.ReadOnly = true;
            companyIDColumn.AllowDBNull = false;
            companyIDColumn.Unique = true;

            DataColumn companyNameColumn = new DataColumn("name", typeof(string));
            DataColumn companyAddressIDColumn = new DataColumn("id_home_address", typeof(int));
            DataColumn companyOwnerIDColumn = new DataColumn("id_owner", typeof(string));

            // Добавление объектов DataColumn в DataTable
            DataTable companyTable = new DataTable("Company");
            companyTable.Columns.AddRange(new DataColumn[] { companyIDColumn, companyNameColumn,
                companyAddressIDColumn, companyOwnerIDColumn });

            // Добавление строк в таблицу
            DataRow companyRow = companyTable.NewRow();
            companyRow["id_company"] = "F22";
            companyRow["name"] = "DSO";
            companyRow["id_home_address"] = 1001;
            companyRow["id_owner"] = 1;

            companyTable.Rows.Add(companyRow);

            companyRow = companyTable.NewRow();
            companyRow[0] = "F23";
            companyRow[1] = "Templars";
            companyRow[2] = 1000;
            companyRow[3] = 2;

            companyTable.Rows.Add(companyRow);

            // Первичный ключ для таблицы
            companyTable.PrimaryKey = new DataColumn[] { companyTable.Columns[0] };

            // Добавление таблицы в DataSet
            ds.Tables.Add(companyTable);

            Logger.Log("Filling Company table...");

            return ds;
        }

        public DataSet FillProductsTable(DataSet ds)
        {
            DataColumn productIDColumn = new DataColumn("id_products", typeof(string));
            productIDColumn.Caption = "id_products";
            productIDColumn.ReadOnly = true;
            productIDColumn.AllowDBNull = false;
            productIDColumn.Unique = true;

            DataColumn productCompanyIDColumn = new DataColumn("id_company", typeof(string));
            DataColumn productTypeColumn = new DataColumn("product_type", typeof(string));
            DataColumn productQuantityColumn = new DataColumn("quantity", typeof(int));
            DataColumn productUnitPriceColumn = new DataColumn("unit_price", typeof(decimal));

            // Добавление объектов DataColumn в DataTable
            DataTable productTable = new DataTable("Products");
            productTable.Columns.AddRange(new DataColumn[] { productIDColumn, productCompanyIDColumn,
                productTypeColumn, productQuantityColumn, productUnitPriceColumn });

            // Добавление строк в таблицу
            DataRow productRow = productTable.NewRow();
            productRow["id_products"] = "P22";
            productRow["id_company"] = "F23";
            productRow["product_type"] = "Plaga sample";
            productRow["quantity"] = 100;
            productRow["unit_price"] = 345.67;

            productTable.Rows.Add(productRow);

            productRow = productTable.NewRow();
            productRow[0] = "P23";
            productRow[1] = "F22";
            productRow[2] = "Forerunner amulet";
            productRow[3] = 1;
            productRow[4] = 605.35;

            productTable.Rows.Add(productRow);

            // Первичный ключ для таблицы
            productTable.PrimaryKey = new DataColumn[] { productTable.Columns[0] };

            // Добавление таблицы в DataSet
            ds.Tables.Add(productTable);

            Logger.Log("Filling Products table...");

            return ds;
        }

        public DataSet FillContractTable(DataSet ds)
        {
            DataColumn contractIDColumn = new DataColumn("id_contract", typeof(int));
            contractIDColumn.Caption = "id_contract";
            contractIDColumn.ReadOnly = true;
            contractIDColumn.AllowDBNull = false;
            contractIDColumn.Unique = true;

            DataColumn contractCompanyRecipientIDColumn = new DataColumn("id_company_recipient", typeof(string));
            DataColumn contractCompanySupplierIDColumn = new DataColumn("id_company_supplier", typeof(string));
            DataColumn contractProductIDColumn = new DataColumn("id_product", typeof(string));
            DataColumn contractDateOfConclusionColumn = new DataColumn("date_of_conclusion", typeof(DateTime));
            DataColumn contractDeadlineColumn = new DataColumn("deadline", typeof(int));

            // Добавление объектов DataColumn в DataTable
            DataTable contractTable = new DataTable("Contract");
            contractTable.Columns.AddRange(new DataColumn[] { contractIDColumn, contractCompanyRecipientIDColumn,
                contractCompanySupplierIDColumn, contractProductIDColumn, contractDateOfConclusionColumn, contractDeadlineColumn });

            // Добавление строк в таблицу
            DataRow contractRow = contractTable.NewRow();
            contractRow["id_contract"] = 186011;
            contractRow["id_company_recipient"] = "F22";
            contractRow["id_company_supplier"] = "F23";
            contractRow["id_product"] = "P22";
            contractRow["date_of_conclusion"] = DateTime.Parse("2024-03-06");
            contractRow["deadline"] = 13;

            contractTable.Rows.Add(contractRow);

            contractRow = contractTable.NewRow();
            contractRow[0] = 1256632;
            contractRow[1] = "F23";
            contractRow[2] = "F22";
            contractRow[3] = "P23";
            contractRow[4] = DateTime.Parse("2024-03-06");
            contractRow[5] = 9;

            contractTable.Rows.Add(contractRow);

            // Первичный ключ для таблицы
            contractTable.PrimaryKey = new DataColumn[] { contractTable.Columns[0] };

            // Добавление таблицы в DataSet
            ds.Tables.Add(contractTable);

            Logger.Log("Filling Contract table...");

            return ds;
        }
    }
}
