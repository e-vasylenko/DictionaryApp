using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.IO
{
	public static class DataWriter
	{
		public static void WriteToFile(string filePath, IEnumerable<string> data) {
			using(var sw = new StreamWriter(filePath, false, Encoding.Unicode)) {
				sw.WriteLine("country ss");
				foreach(string line in data) {
					sw.WriteLine(line);
				}
			}
		}
	}
}
