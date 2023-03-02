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
            string MainPath = @"C:\\superExport\\";
            
            List<string> fileList = new List<string>();

            string[] txtFiles = Directory.GetFiles(MainPath, "*.txt"); // Obtiene los archivos .txt en la carpeta

            foreach (string txtFile in txtFiles)
            {
                 
                if (txtFile.Contains("pagos")) {

                    string nombreArchivo = Path.GetFileName(txtFile);
                    string dateFiltered = nombreArchivo.Replace("ventas_pagos_", "");
                    Console.WriteLine(dateFiltered);
                    fileList.Add(dateFiltered);

                }
            }

            string FIleName = "20230206.txt";
            List<Detalle> Detalles;

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using (var reader = new StreamReader(MainPath+"ventas_detalle_"+FIleName))
            using (var csv = new CsvReader(reader, configuration))
            {
               

                Detalles = csv.GetRecords<Detalle>().ToList();
                detalleBindingSource.DataSource = Detalles;
            }

           
            using (var reader = new StreamReader(MainPath + "ventas_pagos_" + FIleName))
            using (var csv = new CsvReader(reader, configuration))
            {
                csv.Context.TypeConverterCache.AddConverter<decimal>(new DecimalConverterWithEmptyValue());
                csv.Context.TypeConverterCache.AddConverter<int>(new Int32ConverterWithEmptyValue());

                List<Transaccion> pagos = csv.GetRecords<Transaccion>().ToList();


               
                var nombresRepetidos = pagos
                .GroupBy(p => p.check)
                .SelectMany(g => g) 
                .Distinct();

                foreach (Transaccion transaccion in nombresRepetidos)
                {
                    Console.WriteLine("El nombre '{0}' se repite en la lista", transaccion.check);
                    IttMove ittMove = new IttMove();
                    //ittMove.ticket_id = persona.check;
                    DateTime dateTime = Utils.ConvertirStringAFechaHora(transaccion.date.ToString(),transaccion.hour,transaccion.minute,transaccion.seconds);



                    List<Detalle> result = Detalles.Where(p => p.check.Trim() == transaccion.check.Trim()).ToList();

                    foreach (var detalle in result)
                    {
                        if (Camaleon.CheckClass(detalle.itemclass) == 0) {
                            Camaleon.CreateNewClass(detalle.itemclass);
                        
                        }
                    }

                }


                transaccionBindingSource.DataSource = pagos;
            }
        }
    }
}
