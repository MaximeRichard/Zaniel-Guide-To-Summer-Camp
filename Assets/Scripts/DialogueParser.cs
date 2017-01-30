using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

public class DialogueParser : MonoBehaviour {
    private List<DialogueLine> lines;

    public struct DialogueLine {
        public string name, content;
        public string[] options;
        public int jumpNumber;

	    public DialogueLine(string name, string content)
        {
            this.name = name;
            this.content = content;
            options = new string[0];
            jumpNumber = 0;
        }
    }

    void Awake()
    {
        string file = "Assets/Data/Dialogue1.txt";
        lines = new List<DialogueLine>();
        LoadDialogue(file);
    }

    void Update()
    {
    }

    void LoadDialogue(string filename)
    {
        string line;
        StreamReader r = new StreamReader(filename);

        using (r)
        {
            do
            {
                line = r.ReadLine();
                if (line != null)
                {
                    string[] lineData = line.Split(';');
                    if (lineData[0] == "Player")
                    {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], "");
                        lineEntry.options = new string[lineData.Length - 1];
                        for (int i = 1; i < lineData.Length; i++)
                        {
                            lineEntry.options[i - 1] = lineData[i];
                        }
                        lines.Add(lineEntry);
                    }
                    else if(lineData[0] == "JumpTo") 
                    {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], "");
                        lineEntry.jumpNumber = int.Parse(lineData[1]);
                        lines.Add(lineEntry);
                    }
                    else if (lineData[0] == "Ending")
                    {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], "");
                        lines.Add(lineEntry);
                    }
                    else
                    {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1]);
                        lines.Add(lineEntry);
                    }
                }
            }
            while (line != null);
            r.Close();
        }
    }

    public DialogueLine GetLine(int lineNumber)
    {
        if(lineNumber < 0 || lineNumber > lines.Count)
            throw new Exception();
        return lines[lineNumber];
    }
}
