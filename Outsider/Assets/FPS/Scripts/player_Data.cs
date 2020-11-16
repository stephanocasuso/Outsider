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
  public bool Shotgun;
  public bool Launcher;
  public bool JetPack; 
  public float Health; 
  public float[] position;
  //public string pathway = Application.dataPath;
  public int saved = 1;

 public void SaveByJSON()
    {
	cpm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckPointMaster>();
	saved = 1;
        Save save = new Save(cpm.Shotgun_TakenC,cpm.Launcher_TakenC, cpm.JetPack_TakenC, cpm.last_health, cpm.lastCheckPointPos.x, cpm.lastCheckPointPos.y, cpm.lastCheckPointPos.z){};

        string JsonString = JsonUtility.ToJson(save);//Convert SAVE Object into JSON(String)
	Debug.Log(save.Shotgun1);

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
      Shotgun = save.Shotgun1;
      Launcher = save.Launcher1;
      JetPack = save.JetPack1;
      Health = save.Health1;
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
	public bool Shotgun1;
	public bool Launcher1;
	public bool JetPack1;
	public float Health1;
	public float position0;
	public float position1;
	public float position2;
	public Save(bool shot, bool lau, bool jet, float hea, float x, float y, float z) { 
          Shotgun1 = shot;
	  Launcher1 = lau;
	  JetPack1 = jet;
	  Health1 = hea;
          position0 = x;
          position1 = y;
          position2 = z;
	  

	}

 	[SerializeField]
    	    public Save save;

    }

}