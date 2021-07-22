using FileProcessor.Application.Contracts;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FileProcessor.API.Services
{
    public class UploadService : IUploadService
    {
        private string[] _wordsToLookFor;
        private StringBuilder _processedWordResultToReturn = new StringBuilder();

        public Tuple<string, long> Upload(byte[] fileContent)
        {
            var fileContentAsString = Encoding.UTF8.GetString(fileContent);

            _wordsToLookFor = fileContentAsString.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '-', '\\', '/' },
                                                           StringSplitOptions.RemoveEmptyEntries);

            return getProcessedTextAndElapsedTime();
        }

        private Tuple<string, long> getProcessedTextAndElapsedTime()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < _wordsToLookFor.Count(); i++)
            {
                var processedWord = processWordByIndex(i);

                _processedWordResultToReturn.AppendLine(processedWord);
            }
            stopwatch.Stop();

            return Tuple.Create<string, long>(_processedWordResultToReturn.ToString(), stopwatch.ElapsedMilliseconds);
        }

        private string processWordByIndex(int index)
        {
            string searchTerm = _wordsToLookFor[index];

            var matchQuery = from word in _wordsToLookFor
                             where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
                             select word;

            int wordCount = matchQuery.Count();

            return string.Format("{0} occurrences(s) of the search term \"{1}\" were found.", wordCount, searchTerm);
        }
    }
}
