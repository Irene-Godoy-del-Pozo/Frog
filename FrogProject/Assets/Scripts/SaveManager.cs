using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class SaveManager 
{


    static int maxSaves = 9;       //Limit of files created as saves
    static int currentsave = 0;    //Next file that is going to be created o modified 

    [Serializable]
    public class SaveInfo
    {
        public bool lvl_Finished;

        public bool[] flies_taken;
    }

    [Serializable]
    public class SaveInfoList
    {
        public List<SaveInfo> savedataList;
    }


    public static void SaveData(List<LevelInfo> levelList)
    {
        SaveInfoList datalist = new SaveInfoList();
        datalist.savedataList = new List<SaveInfo>();

        //Save the level state and the flies taken of each level into a SafeInfo variable
        foreach (LevelInfo _levelinfo in levelList)
        {
            //The levels can only be finished in order. If this level isnt finished, the function can stop searching.
            if (!_levelinfo.lvl_Finished) break;

            SaveInfo data = new SaveInfo();


            data.lvl_Finished = _levelinfo.lvl_Finished;
            data.flies_taken = new bool[_levelinfo.flies_taken.Length];
            data.flies_taken = _levelinfo.flies_taken;

            datalist.savedataList.Add(data);


        }

        //If the list is not empty , its converted to json and saved 
        if (datalist.savedataList.Count != 0)
        {
            string path = Path.Combine(Application.persistentDataPath, "save" + currentsave + ".json");

            if (currentsave >= maxSaves)
                currentsave = 0;
            else
                currentsave++;

            Debug.Log(JsonUtility.ToJson(datalist));

            File.WriteAllText(path, JsonUtility.ToJson(datalist, true));
        }
    }



    public static void LoadSave(List<LevelInfo> levelList, out int levelsInicialize)
    {
        SaveInfoList datalist = new SaveInfoList();
        datalist.savedataList = new List<SaveInfo>();

        try
        {

            DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);

            //search the file that have the lastest write time. Also make sure that de char occupied in ? is an digit
            FileInfo lastFile = dir.GetFiles("save?.json").OrderByDescending(f => f.LastWriteTime).First(f => Char.IsDigit(f.Name, 4));
            
            //Get the data from the file          
            string data = File.ReadAllText(lastFile.FullName);
            Debug.Log(lastFile.FullName);
            Debug.Log(data);

            //Transform the data into a SaveInfoList
            datalist = JsonUtility.FromJson<SaveInfoList>(data);
            
            LoadedLevelInitialitation(datalist.savedataList, levelList, out levelsInicialize);

            //Get the number of the file that have the data and get the next one
            currentsave = (int)Char.GetNumericValue(lastFile.Name, 4);
            Debug.Log(currentsave);

            if (currentsave < maxSaves) currentsave++;
            else currentsave = 0;

          
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            levelsInicialize = 0;      
        }
    }

    //Initialize the levels from the level data
    static void LoadedLevelInitialitation(List<SaveInfo> datalist, List<LevelInfo> levelList, out int levelsInicialize)
    {
        int i = 0;
        
      
      
        for (; i < datalist.Count; i++)
        {
      
            levelList[i].set_Name(levelList[i].lvl_Prefab.name + "(Clone)");
            levelList[i].lvl_Finished = datalist[i].lvl_Finished;
            levelList[i].initialize();
            levelList[i].flies_taken = datalist[i].flies_taken;
        }

        levelsInicialize = i;

    }

    public static void DeleteAllSaves()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);

        FileInfo[] files = dir.GetFiles();

        if (files.Length <= 0) return;
        foreach(FileInfo file in files )
        {
            file.Delete();
        }
    }
}
