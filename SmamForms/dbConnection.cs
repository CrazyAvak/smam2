﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SmamForms
{
    class dbConnection
    {

        MySqlConnection conn;         
        private string connectionString;
        private string output;

        public dbConnection()
        {
            connectionString = "Server=localhost;Database=smamdb;Uid=root;Pwd=;";//de connectionstring met de wachtwoorden etc om te verbinden

            try
            {
                conn = new MySqlConnection(connectionString);
            }
            catch (Exception exception)
            {
                ExceptionToText ex = new ExceptionToText(exception.ToString());
            }
        }

        public string GetArticleText(string articlename) //tekst van een artikel ophalen
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connectionString);
            }
            string query = "SELECT * FROM article WHERE Name = '" + articlename + "'";
            Console.WriteLine(query);
            DataTable dataTable = new DataTable();
            MySqlCommand querycmd = new MySqlCommand(query, conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
            mySqlDataAdapter.SelectCommand = querycmd;
            mySqlDataAdapter.Fill(dataTable);
            foreach (DataRow item in dataTable.Rows)
            {
                output = "";
                output = item["Description"].ToString();
            }
            return output;
        }

        public List<string> GetArticleTitles(string type) //alle titels van alle artikelen ophalen van één type
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connectionString);
            }
            string query = "Select * FROM article WHERE types_idtypes = " + type;
            Console.WriteLine(query);
            List<string> articletitles = new List<string>();
            DataTable dataTable = new DataTable();
            MySqlCommand querycmd = new MySqlCommand(query, conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
            mySqlDataAdapter.SelectCommand = querycmd;
            mySqlDataAdapter.Fill(dataTable);
            foreach (DataRow item in dataTable.Rows)
            {
                articletitles.Add(item["Name"].ToString());
            }
            return articletitles;
        }

        public string GetTypeName(string type)//geeft een typenaam terug uit de database
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connectionString);
            }
            string query = "Select * FROM type WHERE idtypes = " + type;
            Console.WriteLine(query);
            DataTable dataTable = new DataTable();
            MySqlCommand querycmd = new MySqlCommand(query, conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
            mySqlDataAdapter.SelectCommand = querycmd;
            mySqlDataAdapter.Fill(dataTable);
            foreach (DataRow item in dataTable.Rows)
            {
                output = item["typeName"].ToString();
            }
            return output;
        }

        public Hint getHint()//geeft een hint object terug
        {
            DataTable table = new DataTable();
            try
            {
                conn.Open();
            }
            catch (Exception exception)
            {
                ExceptionToText ex = new ExceptionToText(exception.ToString());
                return null;
            }
            string query = "SELECT * FROM `hint` ORDER BY RAND() LIMIT 1;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            myAdapter.SelectCommand = cmd;
            myAdapter.Fill(table);
            conn.Close();
            Hint hint = new Hint();
            foreach (DataRow item in table.Rows)
            {
                hint.Id = item["idHints"].ToString();
                hint.Name = item["Name"].ToString();
                hint.Body = item["Description"].ToString();
            }
            return hint;
        }
        public List<string> getGroceryTypes()//geeft een lijst terug met boodschappen types
        {
            DataTable table = new DataTable();
            conn.Open();
            string query = "SELECT * FROM `grocery`";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            myAdapter.SelectCommand = cmd;
            myAdapter.Fill(table);
            conn.Close();
            List<string> types = new List<string>();
            foreach (DataRow item in table.Rows)
            {
                types.Add(item["Name"].ToString());
            }
            return types;
        }
        private string getGroceryId(string type)//geeft de id terug van een grocery 
        {
            DataTable table = new DataTable();
            
            string query = "SELECT * FROM `grocery` WHERE grocery.Name = '" + type + "'" ;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            myAdapter.SelectCommand = cmd;
            myAdapter.Fill(table);
            
            string id = "";
            foreach (DataRow item in table.Rows)
            {
                id = item["idGrocery"].ToString();
            }
            return id;
        }
        public List<string> getGroceryProducts(string type)//geeft een lijst terug met grocery producten
        {
            DataTable table = new DataTable();
            conn.Open();
            string query = " SELECT * FROM `groceryproduct` " +
                "INNER JOIN groceries_has_grocery ON groceries_has_grocery.Groceries_idGroceries=groceryproduct.idGroceries " +
                "WHERE groceries_has_grocery.Grocery_idGrocery=" + getGroceryId(type);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            myAdapter.SelectCommand = cmd;
            myAdapter.Fill(table);
            conn.Close();
            List<string> products = new List<string>();
            foreach (DataRow item in table.Rows)
            {
                products.Add(item["Name"].ToString());
            }
            return products;
        }

        public string GetBackgroundURL(string articleID)//haalt de url op van een background
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connectionString);
            }
            string query = "SELECT URL FROM `image` WHERE Article_idArticles = " + articleID + " AND `Name` = 'background'";
            Console.WriteLine(query);
            DataTable dataTable = new DataTable();
            MySqlCommand querycmd = new MySqlCommand(query, conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
            mySqlDataAdapter.SelectCommand = querycmd;
            mySqlDataAdapter.Fill(dataTable);
            foreach (DataRow item in dataTable.Rows)
            {
                output = item["URL"].ToString();
            }
            return output;
        } 


        public List<string> GetImageURL(string articleID)//geeft een lijst terug met image urls 
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connectionString);
            }
            string query = "SELECT URL FROM `image` WHERE Article_idArticles = '" + articleID + "' AND `Name` <> 'background' OR 'Header'";
            Console.WriteLine(query);
            List<string> articleURL = new List<string>();
            DataTable dataTable = new DataTable();
            MySqlCommand querycmd = new MySqlCommand(query, conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
            mySqlDataAdapter.SelectCommand = querycmd;
            mySqlDataAdapter.Fill(dataTable);
            foreach (DataRow item in dataTable.Rows)
            {
                articleURL.Add(item["URL"].ToString());
            }
            return articleURL;
        }

        public string GetArticleID(string articlename)//geeft de id van een artikel terug
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connectionString);
            }
            string query = "SELECT `idArticles` FROM `article` WHERE `Name` = '" + articlename + "'";
            DataTable dataTable = new DataTable();
            MySqlCommand querycmd = new MySqlCommand(query, conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
            mySqlDataAdapter.SelectCommand = querycmd;
            mySqlDataAdapter.Fill(dataTable);
            foreach (DataRow item in dataTable.Rows)
            {
                output = item["idArticles"].ToString();
            }
            return output;
        }

        public string GetArticleIDFromType(string type)//geeft de artikel id terug van een type 
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connectionString);
            }
            string query = "SELECT Min(idArticles) FROM `article` WHERE `types_idtypes` = (SELECT idtypes FROM `type` WHERE typeName = '" + type + "')";
            Console.WriteLine(query);
            DataTable dataTable = new DataTable();
            MySqlCommand querycmd = new MySqlCommand(query, conn);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
            mySqlDataAdapter.SelectCommand = querycmd;
            mySqlDataAdapter.Fill(dataTable);
            foreach (DataRow item in dataTable.Rows)
            {
                output = item["Min(idArticles)"].ToString();
            }
            return output;
        }

        public override string ToString()
        {
            return connectionString.ToString();

        }
    }
}
