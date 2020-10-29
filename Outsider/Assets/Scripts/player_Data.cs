using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;


public class player_Data : MonoBehaviour{
  private CheckPointMaster cpm; //Was private CheckpointMaster cpm on 10/26/2020 at 3:00PM. Last time it worked.
  public float[] position;
  //public string pathway = Application.dataPath;
  public int saved = 1;

 public void SaveByJSON()
    {
	cpm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckPointMaster>();
	saved = 1;
        Save save = new Save(cpm.lastCheckPointPos.x, cpm.lastCheckPointPos.y, cpm.lastCheckPointPos.z){};

        string JsonString = JsonUtility.ToJson(save);//Convert SAVE Object into JSON(String)

        StreamWriter sw = new StreamWriter(Application.dataPath + "/JSONData.text");//Application.persistentDataPath + "/JSONData.text"
        sw.Write(JsonString);
        sw.Close();

        Debug.Log(" SAVED ");
    }
 
 public void LoadByJSON()
  {
    position = new float [3];
    saved = 0;
    if(File.Exists(Application.dataPath + "/JSONData.text"))
    {
      StreamReader sr = new StreamReader(Application.dataPath + "/JSONData.text");
      string JsonString = sr.ReadToEnd();
      sr.Close();
      Save save = JsonUtility.FromJson<Save>(JsonString);//Into the Save Object
      Debug.Log("-LOADED-");
      position[0] = save.position0;
      position[1] = save.position1;
      position[2] = save.position2;
    }
    else
    {
      Debug.Log("NOT FOUND FILE");
    }
  }





    [Serializable]
    public class Save
    {

	public float position0;
	public float position1;
	public float position2;
	public Save(float x, float y, float z) { 
          position0 = x;
          position1 = y;
          position2 = z;
	  

	}

 	[SerializeField]
    	    public Save save;

    }

}