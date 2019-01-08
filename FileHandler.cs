using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace proj2
{
    public class FileHandler
    {
        const int MaxRowsFile = 1300000;
        public void Convert_NDJSON_File_To_JSON()
        {
            if (FileExist(FilePath()))
            {
                int savePath = 0;
                int Count = 0;               
                List<JObject> allObjects = new List<JObject>();
                
                JsonSerializer serializer = new JsonSerializer();
                using (FileStream s = File.Open(FilePath(), FileMode.Open))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    reader.SupportMultipleContent = true;
                    while (reader.Read())
                    {
                        // deserialize only when there's "{" character in the stream
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            Count++;
                            if(Count > MaxRowsFile)
                            {
                                Count = 0;
                                SaveAllToFile(allObjects, savePath);
                                allObjects = new List<JObject>();
                                savePath++;
                            }
                            JObject oneObject = serializer.Deserialize<JObject>(reader);
                            allObjects.Add(oneObject);
                        }
                    }
                }
                SaveAllToFile(allObjects, savePath); // Saves the last rows of the targeted file, less than "const int MaxRowsFile".
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        private void SaveAllToFile(List<JObject> data, int savePath)
        {
            List<Comment> allComments = new List<Comment>();
            
            foreach (dynamic obj in data)
            {
                Comment comment = new Comment();
                comment.id = obj.id;
                comment.parent_id = obj.parent_id;
                comment.link_id = obj.link_id;
                comment.name = obj.name;
                comment.author = obj.author;
                comment.body = obj.body;
                comment.subreddit_id = obj.subreddit_id;
                comment.subreddit = obj.subreddit;
                comment.score = obj.score;
                comment.created_utc = obj.create_utc;
                allComments.Add(comment);
            }

            var json = JsonConvert.SerializeObject(allComments, Formatting.Indented);
            File.WriteAllText(FilePathSave(savePath), json);
        }

        private string FilePath()
        {
            // string systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            // return Path.Combine(systemPath,RC_2011-07 "RC_2007-10");
            return "H:/Webbprogrammerare 120hp/2DV513/RC_2011-07";
        }

        private string FilePathSave(int savePath)
        {
            // string systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            // return Path.Combine(systemPath, "RC_2007-10_modified");
            return "C:/JSON/RC_2011-07_0" + savePath;
        }

        private bool FileExist(string FileName)
        {
            FileInfo fInfo = new FileInfo(FileName);
            return fInfo.Exists;
        }
    }
}
