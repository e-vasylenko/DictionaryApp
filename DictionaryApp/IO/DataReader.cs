using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DictionaryApp.Model;

namespace DictionaryApp.IO
{
	public static class DataReader
	{
		public static void ReadDictionary(string filePath) {
			using (var streamReader = new StreamReader(filePath)) {
				string word;
				while((word = streamReader.ReadLine()) != null) {
					Dictionary.Data.Add(word.ToLower());
				}
			}
		}

		public static IEnumerable<string> ReadTestData(string filePath) {
			var result = new List<string>();
			string[] tokens = null;
			var expr = new Regex("\t");
			using(var reader = new StreamReader(filePath)) {
				string nextLine;
				reader.ReadLine();
				while((nextLine = reader.ReadLine()) != null) {
					tokens = expr.Split(nextLine);
					string word = tokens != null && tokens.Length == 2 ? tokens[1] : null;
					if (word != null) {
						result.Add(word);
					}
				}
			}
			return result;
		}
	}
}
