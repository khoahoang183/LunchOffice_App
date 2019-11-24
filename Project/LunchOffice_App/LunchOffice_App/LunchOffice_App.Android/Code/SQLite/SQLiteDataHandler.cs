﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LunchOffice_App.Droid.Code.Bean;
using SQLite;

namespace LunchOffice_App.Droid.Code.SQLite
{
    class SQLiteDataHandler
    {
        public static string DbFilePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db");
        private static SQLiteConnection db = null;
        public static void CreateDBSQLite()
        {
            try
            {
                if (File.Exists(DbFilePath))
                {
                    return;
                }
                else
                {
                    db = new SQLiteConnection(DbFilePath);
                    db.CreateTable<BeanMonAn>();
                    db.CreateTable<BeanNguoiDung>();
                    db.CreateTable<BeanSession>();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


        #region BeanMonAn
        public static List<BeanMonAn> BeanMonAn_LoadList()
        {
            List<BeanMonAn> data = new List<BeanMonAn>();
            try
            {
                if (File.Exists(DbFilePath))
                {
                    db = new SQLiteConnection(DbFilePath);
                    data = db.Table<BeanMonAn>().ToList();
                }
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static BeanMonAn BeanMonAn_SearchItem(int MaMon)
        {
            BeanMonAn data = new BeanMonAn();
            try
            {
                if (File.Exists(DbFilePath))
                {
                    db = new SQLiteConnection(DbFilePath);
                    data = db.Table<BeanMonAn>().Where(x => x.MaMon == MaMon).FirstOrDefault();
                }
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static bool BeanMonAn_ClearList()
        {
            List<BeanMonAn> data = new List<BeanMonAn>();
            try
            {
                if (File.Exists(DbFilePath))
                {
                    db = new SQLiteConnection(DbFilePath);
                    db.DeleteAll<BeanMonAn>();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static bool BeanMonAn_Insert(BeanMonAn item)
        {
            try
            {
                if (File.Exists(DbFilePath))
                {
                    db = new SQLiteConnection(DbFilePath);
                    db.Insert(item);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static bool BeanMonAn_Update(BeanMonAn item)
        {
            try
            {
                if (File.Exists(DbFilePath))
                {
                    List<BeanMonAn> data = BeanMonAn_LoadList();
                    db = new SQLiteConnection(DbFilePath);
                    db.Update(item);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion

        #region BeanSession
        /// <summary>
        /// list tra ve khac null la ko co session
        /// </summary>
        /// <returns></returns>
        public static List<BeanSession> BeanSession_LoadList()
        {
            List<BeanSession> data = new List<BeanSession>();
            try
            {
                if (File.Exists(DbFilePath))
                {
                    db = new SQLiteConnection(DbFilePath);
                    data = db.Table<BeanSession>().ToList();
                }
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static bool BeanSession_ClearSession()
        {
            List<BeanSession> data = new List<BeanSession>();
            try
            {
                if (File.Exists(DbFilePath))
                {
                    db = new SQLiteConnection(DbFilePath);
                    db.DeleteAll<BeanSession>();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static bool BeanSession_AddSession(BeanSession item)
        {
            try
            {
                if (File.Exists(DbFilePath))
                {
                    List<BeanSession> data = BeanSession_LoadList();
                    db = new SQLiteConnection(DbFilePath);
                    db.Insert(item);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion

    }
}