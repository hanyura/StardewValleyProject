using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data
{
    public string playerNewName;
    public string FarmNewName;
}

public class CreatCharactorData : MonoBehaviour
{
    public static CreatCharactorData instance;

    Data newPlayer = new Data();

    private string path;

    private void Awake()
    {
        #region ΩÃ±€≈Ê
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath;
    }

    private void Start()
    {

    }

    void SaveManager()
    {
        string data = JsonUtility.ToJson(newPlayer);
        File.WriteAllText(path, data);
    }

    //void FileName()
    //{
    //    for(int i = 1; i <=3; i++)
    //    {
    //        if()
    //    }
    //}
}
