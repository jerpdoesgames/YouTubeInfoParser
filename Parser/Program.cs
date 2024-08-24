using System;
using System.Text.Json;

namespace Parser
{
    internal class Program
    {
        public static bool isVideoJson(string aFileContents)
        {
            return aFileContents.Contains("\"_type\": \"video\"");
        }
        static void Main(string[] args)
        {
            if (System.IO.Path.Exists(parserConfig.storagePath))
            {
                string templatePath = System.IO.Path.Combine(parserConfig.storagePath, "template.html");
                if (File.Exists(templatePath))
                {
                    string templateContents = File.ReadAllText(templatePath);

                    string configFilePath = (System.IO.Path.Combine(parserConfig.storagePath, "config.json"));
                    if (File.Exists(configFilePath))
                    {
                        string configContents = File.ReadAllText(configFilePath);
                        parserConfig config = JsonSerializer.Deserialize<parserConfig>(configContents);

                        if (System.IO.Directory.Exists(config.inputPath))
                        {
                            string[] fileList = System.IO.Directory.GetFiles(config.inputPath);
                            foreach (string curFilePath in fileList)
                            {
                                string curFileContents = File.ReadAllText(curFilePath);
                                if (isVideoJson(curFileContents))
                                {
                                    string curFileName = Path.GetFileNameWithoutExtension(curFilePath);
                                    videoInfoJson curVideoInfo = JsonSerializer.Deserialize<videoInfoJson>(curFileContents);
                                    string videoOutput = templateContents;
                                    videoOutput = videoOutput.Replace("{$title}", curVideoInfo.title);
                                    videoOutput = videoOutput.Replace("{$description}", curVideoInfo.description);
                                    videoOutput = videoOutput.Replace("{$videoID}", curVideoInfo.id);
                                    videoOutput = videoOutput.Replace("{$tags}", string.Join(",", curVideoInfo.tags.ToArray()));
                                    videoOutput = videoOutput.Replace("{$categories}", string.Join(",", curVideoInfo.categories.ToArray()));
                                    string outputFilePath = System.IO.Path.Combine(parserConfig.storagePath, "output", curFileName + ".html");
                                    File.WriteAllText(outputFilePath, videoOutput);
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Storage Path doesn't exist: " + parserConfig.storagePath);
            }
        }
    }
}
