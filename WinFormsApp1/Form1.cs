using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private DataTable currentData;
        private readonly string connectionString;
        private int currentRowIndex;
        bool isCurrentRowNewRow;
        bool wasRowEdited;
        public Form1()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            InitializeComponent();
            ReloadData();
        }


        // Reload
        private IDbCommand GetReloadDataCommand(SqlConnection connection)
        {
            string sCmd = $"SELECT * FROM Movies WHERE Imax3d = {(imaxCheckBox.Checked ? 1 : 0)} " +
                        $"AND '{startTime.Value:yyyy-MM-dd}' <= ReleaseDate " +
                        $"AND ReleaseDate <= '{endTime.Value:yyyy-MM-dd}' " +
                        $"AND Title LIKE @PTitle " + 
                        $"AND @PBudgetMin <= Budget AND Budget <= @PBudgetMax " + 
                        $"AND @PRatingMin <= AvgRating AND AvgRating <= @PRatingMax";
            IDbCommand command = new SqlCommand(sCmd, connection);

            var pTitle = new SqlParameter()
            {
                ParameterName = "@PTitle",
                Value = titleBox.Text.Length > 0 ? $"%{titleBox.Text}%" : "%",
                SqlDbType = SqlDbType.VarChar,
                Size = 50
            };

            var pBudgetMin = new SqlParameter()
            {
                ParameterName = "@PBudgetMin",
                Value = minBudgetBox.Text.Length == 0 ? 0 : decimal.Parse(minBudgetBox.Text)
            };

            var pBudgetMax = new SqlParameter()
            {
                ParameterName = "@PBudgetMax",
                Value = maxBudgetBox.Text.Length == 0 ? decimal.MaxValue : decimal.Parse(maxBudgetBox.Text)
            };

            var pRatingMin = new SqlParameter()
            {
                ParameterName = "@PRatingMin",
                Value = minRatingBox.Text.Length == 0 ? 0 : decimal.Parse(minRatingBox.Text)
            };

            var pRatingMax = new SqlParameter()
            {
                ParameterName = "@PRatingMax",
                Value = maxRatingBox.Text.Length == 0 ? decimal.MaxValue : decimal.Parse(maxRatingBox.Text)
            };

            command.Parameters.Add(pTitle);
            command.Parameters.Add(pBudgetMin);
            command.Parameters.Add(pBudgetMax);
            command.Parameters.Add(pRatingMin);
            command.Parameters.Add(pRatingMax);
            return command;
        }
        private void ReloadData()
        {
            try
            {
                currentData = new DataTable();
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        IDbCommand command = GetReloadDataCommand(connection);

                        IDataReader reader = command.ExecuteReader();
                        currentData.Load(reader);

                    }
                    connection.Close();
                }
                currentRowIndex = -1;
                isCurrentRowNewRow = false;
                wasRowEdited = false;
                dataGridView1.DataSource = currentData;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
                dataGridView1.Columns[3].DefaultCellStyle.Format = "#";
                dataGridView1.Columns[4].DefaultCellStyle.Format = "#.##";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }


        // Remove
        private void RemoveRowFromDatabase(int rowId)
        {
            try
            {
                currentData = new DataTable();
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        string cmd = $"DELETE FROM Movies WHERE Id = {rowId}";
                        using (SqlCommand command = new SqlCommand(cmd, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }


        // Update
        private IDbCommand GetUpdateDataCommand(SqlConnection connection, int rowId)
        {
            string sCmd = $"UPDATE Movies SET " +
                $"Title = @PTitle, " +
                $"ReleaseDate = @PReleaseDate, " +
                $"Budget = @PBudget, " +
                $"AvgRating = @PRating, " +
                $"Imax3d = @PImax, " +
                $"TicketsSold = @PTicketsSold " +
                $"WHERE Id = {currentData.Rows[rowId].Field<int>("Id")};";
            IDbCommand command = new SqlCommand(sCmd, connection);

            var pTitle = new SqlParameter()
            {
                ParameterName = "@PTitle",
                Value = currentData.Rows[rowId].Field<String>("Title"),
                SqlDbType = SqlDbType.VarChar,
                Size = 50
            };

            var pReleaseDate = new SqlParameter()
            {
                ParameterName = "@PReleaseDate",
                Value = currentData.Rows[rowId].Field<DateTime>("ReleaseDate"),
                SqlDbType = SqlDbType.Date
            };

            var pBudget = new SqlParameter()
            {
                ParameterName = "@PBudget",
                Value = currentData.Rows[rowId].Field<decimal>("Budget")
            };

            var pRating = new SqlParameter()
            {
                ParameterName = "@PRating",
                Value = currentData.Rows[rowId].Field<decimal>("AvgRating")
            };

            var pImax = new SqlParameter()
            {
                ParameterName = "@PImax",
                Value = currentData.Rows[rowId].Field<bool>("Imax3d")
            };

            var pTicketsSold = new SqlParameter()
            {
                ParameterName = "@PTicketsSold",
                Value = currentData.Rows[rowId].Field<int>("TicketsSold")
            };

            command.Parameters.Add(pTitle);
            command.Parameters.Add(pReleaseDate);
            command.Parameters.Add(pBudget);
            command.Parameters.Add(pRating);
            command.Parameters.Add(pImax);
            command.Parameters.Add(pTicketsSold);
            return command;
        }
        private void UpdateRowInDatabase(int rowId)
        {
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        IDbCommand command = GetUpdateDataCommand(connection, rowId);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                dataGridView1.DataSource = currentData;
                dataGridView1.Columns[0].Visible = false;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }


        // Insert
        private IDbCommand GetInsertDataCommand(SqlConnection connection, int rowId, SqlTransaction transaction)
        {
            string sCmd = $"INSERT INTO Movies Values " +
                $"(@PTitle, " +
                $"@PReleaseDate, " +
                $"@PBudget, " +
                $"@PRating, " +
                $"@PImax, " +
                $"@PTicketsSold);";
            IDbCommand command = new SqlCommand(sCmd, connection, transaction);

            var pTitle = new SqlParameter()
            {
                ParameterName = "@PTitle",
                Value = currentData.Rows[rowId].Field<string>("Title"),
                SqlDbType = SqlDbType.VarChar,
                Size = 50
            };

            var pReleaseDate = new SqlParameter()
            {
                ParameterName = "@PReleaseDate",
                Value = currentData.Rows[rowId].Field<DateTime>("ReleaseDate"),
                SqlDbType = SqlDbType.Date
            };

            var pBudget = new SqlParameter()
            {
                ParameterName = "@PBudget",
                Value = currentData.Rows[rowId].Field<decimal>("Budget")
            };

            var pRating = new SqlParameter()
            {
                ParameterName = "@PRating",
                Value = currentData.Rows[rowId].Field<decimal>("AvgRating")
            };

            var pImax = new SqlParameter()
            {
                ParameterName = "@PImax",
                Value = currentData.Rows[rowId].Field<bool>("Imax3d")
            };

            var pTicketsSold = new SqlParameter()
            {
                ParameterName = "@PTicketsSold",
                Value = currentData.Rows[rowId].Field<int>("TicketsSold")
            };

            command.Parameters.Add(pTitle);
            command.Parameters.Add(pReleaseDate);
            command.Parameters.Add(pBudget);
            command.Parameters.Add(pRating);
            command.Parameters.Add(pImax);
            command.Parameters.Add(pTicketsSold);
            return command;
        }
        private IDbCommand GetNewRowDatabaseIdCommand(SqlConnection connection, int rowId, SqlTransaction transaction)
        {
            string sCmd = $"SELECT Id FROM Movies WHERE " +
                $"Title = @PTitle AND " +
                $"ReleaseDate = @PReleaseDate AND " +
                $"Budget = @PBudget AND " +
                $"AvgRating = @PRating AND " +
                $"Imax3d = @PImax AND " +
                $"TicketsSold = @PTicketsSold;";
            IDbCommand command = new SqlCommand(sCmd, connection, transaction);

            var pTitle = new SqlParameter()
            {
                ParameterName = "@PTitle",
                Value = currentData.Rows[rowId].Field<String>("Title"),
                SqlDbType = SqlDbType.VarChar,
                Size = 50
            };

            var pReleaseDate = new SqlParameter()
            {
                ParameterName = "@PReleaseDate",
                Value = currentData.Rows[rowId].Field<DateTime>("ReleaseDate"),
                SqlDbType = SqlDbType.Date
            };

            var pBudget = new SqlParameter()
            {
                ParameterName = "@PBudget",
                Value = currentData.Rows[rowId].Field<decimal>("Budget")
            };

            var pRating = new SqlParameter()
            {
                ParameterName = "@PRating",
                Value = currentData.Rows[rowId].Field<decimal>("AvgRating")
            };

            var pImax = new SqlParameter()
            {
                ParameterName = "@PImax",
                Value = currentData.Rows[rowId].Field<bool>("Imax3d")
            };

            var pTicketsSold = new SqlParameter()
            {
                ParameterName = "@PTicketsSold",
                Value = currentData.Rows[rowId].Field<int>("TicketsSold")
            };

            command.Parameters.Add(pTitle);
            command.Parameters.Add(pReleaseDate);
            command.Parameters.Add(pBudget);
            command.Parameters.Add(pRating);
            command.Parameters.Add(pImax);
            command.Parameters.Add(pTicketsSold);
            return command;
        }
        private void InsertRowToDatabase(int rowId)
        {
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        SqlTransaction transaction = connection.BeginTransaction();
                        try
                        {
                            IDbCommand command = GetInsertDataCommand(connection, rowId, transaction);
                            command.ExecuteNonQuery();
                            command = GetNewRowDatabaseIdCommand(connection, rowId, transaction);
                            using (IDataReader reader = command.ExecuteReader())
                            {
                                reader.Read();
                                currentData.Rows[rowId][0] = reader["Id"];
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception exRollback)
                            {
                                MessageBox.Show(exRollback.Message);
                            }
                        }
                    }
                    connection.Close();
                }
                dataGridView1.DataSource = currentData;
                dataGridView1.Columns[0].Visible = false;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            RemoveRowFromDatabase((int)e.Row.Cells[0].Value);
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (wasRowEdited && currentRowIndex != -1 && currentRowIndex + 1 == currentData.Rows.Count && isCurrentRowNewRow)
                InsertRowToDatabase(currentRowIndex);
            else if (wasRowEdited && currentRowIndex != -1 && currentRowIndex < currentData.Rows.Count)
                UpdateRowInDatabase(currentRowIndex);

            currentRowIndex = e.RowIndex;
            if (e.RowIndex == currentData.Rows.Count) isCurrentRowNewRow = true;
            else isCurrentRowNewRow = false;
            wasRowEdited = false;
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (MessageBox.Show("Incorrect data! \nDo You wish to abandon changes?", "Validation error",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                e.Cancel = true;
            else e.Cancel = false;
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            wasRowEdited = true;
        }
    }
}
