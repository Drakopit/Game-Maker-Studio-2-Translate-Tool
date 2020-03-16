using GM_Studio_2_Translate_Tool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GM_Studio_2_Translate_Tool.Util
{
    public abstract class FileTranslateReader
    {
        public static List<FileStructure> Read(string fileNamePath)
        {
            List<FileStructure> fileLines = new List<FileStructure>();

            string[] lines = File.ReadAllLines(fileNamePath);

            for (var i = 1; i < lines.Length; i++)
            {
                string[] lineItens = lines[i].Split(",");

                fileLines.Add(new FileStructure()
                {
                    Environment_Variable = lineItens[0],
                    Variable = lineItens[1],
                    Content = lineItens[2],
                    Space = lineItens[3],
                    Description = lineItens[4]
                });
            }

            return fileLines;
        }

        public static void Write(string fileNamePath, List<FileStructure> fileStructures)
        {
            string[] file = new string[fileStructures.Count + 1];
            for (var i = 0; i < fileStructures.Count; i++)
            {
                if (i == 0)
                {
                    file[i] = "Name,English,Translation,Restrictions,Comment";
                }
                else
                {
                    string line = $"{fileStructures[i].Environment_Variable},{fileStructures[i].Variable}," +
                        $"{fileStructures[i].Content},{fileStructures[i].Space},{fileStructures[i].Description}";
                    file[i] = line;
                }
            }

            File.WriteAllLines(fileNamePath, file);
        }
    }
}
