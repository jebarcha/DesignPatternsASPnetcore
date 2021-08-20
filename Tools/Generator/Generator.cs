using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class Generator
    {
        public List<string> Content { get; set; }
        public string Path { get; set; }
        public TypeFormat Format { get; set; }
        public TypeCharacter Character { get; set; }

        public void Save()
        {
            string result = String.Empty;
            result = Format == TypeFormat.Json ? GetJson() : GetPipe();
            result = GetResultTypeCharacter(result);

            File.WriteAllText(Path, result);
        }
        private string GetResultTypeCharacter(string result)
        {
            if (Character == TypeCharacter.Uppercase)
            {
                result = result.ToUpper();
            }
            else if (Character == TypeCharacter.Lowercase)
            {
                result = result.ToLower();
            }
            return result;
        }
        private string GetJson() => JsonSerializer.Serialize(Content);
        private string GetPipe() => Content.Aggregate((accum, current) => accum + "|" + current);
    }
}
