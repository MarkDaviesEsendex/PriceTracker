﻿using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace PriceChat.Web.Data
{
    public class ItemPrice : TableEntity
    {
        public string Price { get; set; }
        public DateTime PriceDate { get; set; }
    }
}