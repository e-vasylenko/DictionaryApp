using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryApp.Model;

namespace DictionaryApp.Logic
{
	public class Parser
	{
		private LinkedList<string> result = new LinkedList<string>();

		private void ParseString(string str, int start, LinkedList<string> currentRes) {
			if(start >= str.Length) {
				if(currentRes.Count > result.Count) {
					result = new LinkedList<string>(currentRes);
				}
				return;
			}
			var sb = new StringBuilder();
			string nextStr = null;
			for(int i = start; i < str.Length; ++i) {
				sb.Append(str[i].ToString().ToLower());
				nextStr = sb.ToString();
				if(Dictionary.Data.Contains(nextStr)) {
					currentRes.AddLast(nextStr);
					ParseString(str, i + 1, currentRes);
					currentRes.RemoveLast();
				}
			}
		}

		public IEnumerable<string> ParseString(string str) {
			result.Clear();
			ParseString(str, 0, new LinkedList<string>());
			if(result.Count == 0) {
				return new List<string>() { str };
			}
			return result;
		}
	}
}
