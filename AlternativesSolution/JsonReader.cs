using Newtonsoft.Json;
using System;
using System.IO;

namespace AlternativesSolution
{
    public class JsonReader<TModel> : IReader<TModel>
    {
        private readonly string _configuationPath;

        public JsonReader(string configuationPath)
        {
            _configuationPath = configuationPath ?? throw new ArgumentNullException(nameof(configuationPath));
        }

        public TModel Read()
        {
            var dataReadFromFile = File.ReadAllText(_configuationPath);

            var config = JsonConvert.DeserializeObject<TModel>(dataReadFromFile);

            return config;
        }
    }

    public interface IReader<TModel>
    {
        TModel Read();
    }
}
