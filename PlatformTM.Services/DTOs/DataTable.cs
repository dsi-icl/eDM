﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;


namespace PlatformTM.Services.DTOs
{
    public class DataTable
    {
        public string TableName {get;set;}
        public DataColumnCollection Columns { get; set; }
        public List<DataRow> Rows { get; set; }
        public DataRow NewRow()
        {
            DataRow row = new DataRow(Columns);
            return row;
        }

        public DataTable()
        {
            Columns = new DataColumnCollection();
            Rows = new List<DataRow>();
        }
    }
    public class DataColumn
    {
        public string ColumnName { get; set; }
        public string Label { get; set; }
        public Type DataType { get; set; }

        public DataColumn(string colName, Type type)
        {
            ColumnName = colName;
            DataType = type;
            Label = colName;
        }
    }
    public class DataRow : OrderedDictionary
    {
        private object[] _itemArray; 
        public object[] ItemArray {
            get { return this._itemArray; }
            set { this._itemArray = value; }
        }

        public object this[DataColumn col]{
            get { return this[col.ColumnName]; }
            set { this[col.ColumnName] = value; }
        }

        public DataRow(List<DataColumn> Columns):base(Columns.Count)
        {
            foreach(var col in Columns)
            {
                this.Add(col.ColumnName, "");
            }
        }
    }
    public class DataColumnCollection : List<DataColumn>
    {
        public DataColumnCollection() : base()
        {
            
        }
        public void Add(string colName, Type type)
        {
            this.Add(new DataColumn(colName, type));
        }
        public void Add(string colName)
        {
            this.Add(new DataColumn(colName, typeof(string)));
        }
    }
    
}
