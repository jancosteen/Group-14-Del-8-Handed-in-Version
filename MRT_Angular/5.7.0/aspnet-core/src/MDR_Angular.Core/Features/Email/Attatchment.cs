using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MDR_Angular.Features.Email
{
    public class Attatchment
    {
        public Attatchment(string fileName, object content)
        {
            Content = content;
            FileName = fileName;
            Type = AttatchmentType.Text;
        }

        public enum AttatchmentType
        {
            Json,Text
        } 

        public object Content { get; set; }
        public string FileName { get; set; }
        public AttatchmentType Type { get; set; }


        public async Task<MemoryStream> ContentToStreamAsync()
        {
            string text;
            switch (Type)
            {
                case AttatchmentType.Json:
                    text = Newtonsoft.Json.JsonConvert.SerializeObject(Content);
                    break;
                case AttatchmentType.Text:
                    text = Content.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8);
            await writer.WriteAsync(text);
            await writer.FlushAsync();
            stream.Position = 0;
            return stream;
                
        }
    }
}
