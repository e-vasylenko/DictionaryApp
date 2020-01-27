using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.Logic
{
	public static class Formatter
	{
		public static string FormatItem(IEnumerable<string> data) {
			var sb = new StringBuilder();
			foreach(string item in data) {
				sb.Append(item).Append(",").Append(" ");
			}
			sb.Remove(sb.Length - 2, 1);
			string splitInfo = data.Count() > 1 ? $"разбили на {data.Count()} части" : "невозможно разбить";
			sb.AppendFormat($"// {splitInfo}");
			return $"\t{sb.ToString()}";
		}

		public static IEnumerable<string> FormatCollection(IEnumerable<IEnumerable<string>> collection) {
			return collection.Select(items => FormatItem(items));
		}
	}
}
