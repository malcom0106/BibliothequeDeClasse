using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryMR
{
    public static class ExtractToCSV
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Object a mettre dans le CSV</typeparam>
        /// <param name="list"></param>
        /// <returns>
        /// Exemple d'utilisation : 
        /// public FileContentResult ExtractToCSV()
        ///{
        ///     ComptaLogEntities comptaLogEntities = new ComptaLogEntities();
        ///
        ///     var listeFEC = comptaLogEntities.T_FEC_LINES
        ///         .Where(w => w.Siren == "123456789")
        ///         .Where(w => w.Poste == "418");
        ///
        ///     string csv = ListToCSV(listeFEC);
        ///
        ///     return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "export.csv");
        ///}
        /// </returns>
        public static string ListToCSV<T>(IEnumerable<T> list)
        {
            StringBuilder sList = new StringBuilder();

            Type type = typeof(T);
            var props = type.GetProperties();
            sList.Append(string.Join(",", props.Select(p => p.Name)));
            sList.Append(Environment.NewLine);

            foreach (var element in list)
            {
                sList.Append(string.Join(",", props.Select(p => p.GetValue(element, null))));
                sList.Append(Environment.NewLine);
            }

            return sList.ToString();
        }
    }
}
