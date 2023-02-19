using CsvHelper.Configuration;
using CsvHelper;
using FeatherExport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeatherExport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using (var reader = new StreamReader(@"C:\\ventas_detalle_20230216.txt"))
            using (var csv = new CsvReader(reader, configuration))
            {
                //csv.Context.TypeConverterCache.AddConverter<decimal>(new DecimalConverterWithEmptyValue());
                //csv.Context.TypeConverterCache.AddConverter<int>(new Int32ConverterWithEmptyValue());

                List<Detalle> Detalles = csv.GetRecords<Detalle>().ToList();


                foreach (var item in Detalles)
                {
                    Console.WriteLine(item.check);
                }
                detalleBindingSource.DataSource = Detalles;
            }

           
            using (var reader = new StreamReader(@"C:\\ventas_pagos_20230216.txt"))
            using (var csv = new CsvReader(reader, configuration))
            {
                csv.Context.TypeConverterCache.AddConverter<decimal>(new DecimalConverterWithEmptyValue());
                csv.Context.TypeConverterCache.AddConverter<int>(new Int32ConverterWithEmptyValue());

                List<Transaccion> Detalles = csv.GetRecords<Transaccion>().ToList();


                foreach (var item in Detalles)
                {
                    Console.WriteLine(item.check);
                }
                //detalleBindingSource.DataSource = Detalles;
            }
        }
    }
}
