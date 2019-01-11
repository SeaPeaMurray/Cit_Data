﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;


namespace USAspendingWindow
{

    public class CsvBulkCopyDataTruncateIntoSqlServer
    {
        //protected const string _truncateLiveTableCommandText = @"TRUNCATE TABLE Current_usaspend";
        protected const string _truncateLiveTableCommandText = @"TRUNCATE TABLE Stage_usaspend";
        protected const int _batchSize = 1000;

        public int LoadTruncateCsvDataIntoSqlServer(String path)
        {
            // This should be the full path
            var fileName = path;

            var createdCount = 0;
            var totalRecords = 0;
            using (var textFieldParser = new TextFieldParser(fileName))
            {
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.Delimiters = new[] { "," };
                textFieldParser.HasFieldsEnclosedInQuotes = true;
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                var connectionString = Properties.Settings.Default.connectionstring ;

                var dataTable = new DataTable("usaspend");

                // Add the columns in the temp table

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 0 * FROM Stage_usaspend", conn))//("SELECT TOP 0 * FROM Current_usaspend", conn))
                    {
                        adapter.Fill(dataTable);
                    };
                    conn.Close();
                };
                
                var colnames = textFieldParser.ReadFields();
                //foreach (var cols in colnames)
                //{
                //    dataTable.Columns.Add(cols);
                //    //dataTable.Columns.Add("LastName");
                //}
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    //// Truncate the live table

                    using (var sqlCommand = new SqlCommand(_truncateLiveTableCommandText, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }


                    // Create the bulk copy object
                    var sqlBulkCopy = new SqlBulkCopy(sqlConnection)
                    {
                        //DestinationTableName = "Current_usaspend"
                        DestinationTableName = "Stage_usaspend"
                    };

                    // Setup the column mappings, anything ommitted is skipped
                    var dtcols = dataTable.Columns;
                    foreach (DataColumn sqlcol in dtcols)
                    {
                        sqlBulkCopy.ColumnMappings.Add(sqlcol.ColumnName, sqlcol.ColumnName);
                        //sqlBulkCopy.ColumnMappings.Add("LastName", "LastName");
                    }
                    // Loop through the CSV and load each set of 100,000 records into a DataTable
                    // Then send it to the LiveTable
                    sqlBulkCopy.BulkCopyTimeout = 240;
                    while (!textFieldParser.EndOfData)
                    {
                       
                        //dataTable.Rows.Add(textFieldParser.ReadFields());

                        

                        String[] fields = textFieldParser.ReadFields();
                        
                       object[] scrupfields = new object[fields.Count()+6];

                        for (int i = 0; i < fields.Count(); i++)
                        {
                            if (String.IsNullOrEmpty(fields[i]))
                            {
                                if (dataTable.Columns[i].DataType == typeof(String) ||
                                    dataTable.Columns[i].DataType == typeof(string))
                                    scrupfields[i] = String.Empty;
                                else
                                    scrupfields[i] = DBNull.Value;

                            }
                            else
                            {
                                if(fields[i].Length > 255)
                                    scrupfields[i] = fields[i].Remove(255);
                                else
                                scrupfields[i] = fields[i];
                            }


                        }
                        scrupfields[225] = DBNull.Value;
                        scrupfields[226] = DBNull.Value;
                        scrupfields[227] = DBNull.Value;
                        scrupfields[228] = DBNull.Value;
                        scrupfields[229] = DateTime.Now;
                        scrupfields[230] = userName;
                        dataTable.Rows.Add(scrupfields);
                        createdCount++;

                        if (createdCount % _batchSize == 0)
                        {
                            InsertDataTable(sqlBulkCopy, sqlConnection, dataTable);

                            //break;
                            totalRecords += createdCount;
                            createdCount = 0;
                            dataTable.Clear();
                        }
                    }

                    // Don't forget to send the last batch under 100,000
                    if (createdCount > 0)
                    {
                        InsertDataTable(sqlBulkCopy, sqlConnection, dataTable);
                        totalRecords += createdCount;
                        createdCount = 0;
                        dataTable.Clear();
                    }
                    sqlConnection.Close();
                    return totalRecords;
                }
            }
        }

        protected void InsertDataTable(SqlBulkCopy sqlBulkCopy, SqlConnection sqlConnection, DataTable dataTable)
        {
            sqlBulkCopy.WriteToServer(dataTable);

            dataTable.Rows.Clear();
        }
    }

}