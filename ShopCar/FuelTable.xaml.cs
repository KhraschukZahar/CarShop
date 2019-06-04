﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShopCar
{
    /// <summary>
    /// Interaction logic for FuelTable.xaml
    /// </summary>
    public partial class FuelTable : Window
    {
        private string tblFuels = "tblSFuels";
        public FuelTable()
        {
            InitializeComponent();
        }
        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string dbName = "bublegum";
            SQLiteConnection con = new SQLiteConnection($"Data Source={dbName}");
            con.Open();
            GenerateTabel(con);
            Seed(con);
            con.Close();
        }
        private void GenerateTabel(SQLiteConnection con)
        {
            string query = $"CREATE TABLE IF NOT EXISTS {tblFuels} " +
                                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "FuelType TEXT NOT NULL " +
                                ");";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.ExecuteNonQuery();
        }
        private void Seed(SQLiteConnection con)
        {
            #region SeedFuels
            string query = $"Insert into {tblFuels}(FuelType) " +
                $"values('ELectro');";

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.ExecuteNonQuery();

            query = $"Insert into {tblFuels}(FuelType) " +
                $"values('Disel');";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            query = $"Insert into {tblFuels}(FuelType) " +
                $"values('AirFuel');";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            #endregion
        }
    }
}