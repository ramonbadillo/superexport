using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FeatherExport
{
    public class DecimalConverterWithEmptyValue : CsvHelper.TypeConversion.DecimalConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0m; // Devuelve el valor predeterminado cuando el valor está vacío.
            }
            return base.ConvertFromString(text, row, memberMapData); // Utiliza el comportamiento predeterminado para valores no vacíos.
        }
    }
    public class Int32ConverterWithEmptyValue : CsvHelper.TypeConversion.Int32Converter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0; // Devuelve el valor predeterminado cuando el valor está vacío.
            }
            return base.ConvertFromString(text, row, memberMapData); // Utiliza el comportamiento predeterminado para valores no vacíos.
        }
    }

    public static class Utils
    {
        public static DateTime ConvertirStringAFechaHora(string dateString, int hora, int minuto, int segundo)
        {
            
            string dateTimeString = dateString + hora.ToString("D2") + minuto.ToString("D2") + segundo.ToString("D2");
            DateTime date;
            if (DateTime.TryParseExact(dateTimeString, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

    }


}
