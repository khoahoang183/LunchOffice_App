﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LunchOffice_App.Droid.Code.Bean
{
    public class BeanShoppingCart
    {
        public int MaMonAn;
        public int SoLuong;

        public BeanShoppingCart()
        {
        }

        public BeanShoppingCart(int maMonAn, int soLuong)
        {
            MaMonAn = maMonAn;
            SoLuong = soLuong;
        }
    }
}