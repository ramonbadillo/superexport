using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
