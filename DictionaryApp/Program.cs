using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryApp.IO;
using DictionaryApp.Logic;

namespace DictionaryApp
{
	class Program
	{
		static void Main(string[] args) {
			string folderPath = AppDomain.CurrentDomain.BaseDirectory;
			string dictFileName = "dict";
			string errorMessage = "В работе программы возникли ошибки";
			try {
				DataReader.ReadDictionary(Path.Combine(folderPath, dictFileName));
			} catch (Exception ex) {
				Console.WriteLine($"{errorMessage}: {Environment.NewLine} {ex}");
				Console.ReadKey();
				return;
			}
			
			string testFileName = "de-test-words.tsv";
			IEnumerable<string> testWords = null;
			try {
				testWords = DataReader.ReadTestData(Path.Combine(folderPath, testFileName));
			} catch (Exception ex) {
				Console.WriteLine($"{errorMessage}: {Environment.NewLine} {ex}");
				Console.ReadKey();
				return;
			}

			var parser = new Parser();
			var resultCollection = new List<string[]>();
			foreach(string item in testWords) {
				try {
					string[] tokens = parser.ParseString(item).ToArray();
					resultCollection.Add(tokens);
				} catch(Exception ex) {
					Console.WriteLine($"{errorMessage}: {Environment.NewLine} {ex}");
				}
			}
			IEnumerable<string> formattedCollection = Formatter.FormatCollection(resultCollection).ToArray();

			string resultFileName = "de-test-words-result.tsv";
			DataWriter.WriteToFile(Path.Combine(folderPath, resultFileName), formattedCollection);

			Console.WriteLine("Выполнение программы завершено успешно.\n" +
				 $"Файл доступен по пути: \n<Путь с исполняемому файлу>/de-test-words-result.tsv{Environment.NewLine}");
			Console.WriteLine("Для выхода нажмите любую клавишу");
			Console.ReadKey();
		}
	}
}
