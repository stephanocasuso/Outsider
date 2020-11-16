using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class CheckPointMaster : MonoBehaviour
{
  public static CheckPointMaster instance;
  private player_Data data;
  private Health health_amount;
  public Vector3 lastCheckPointPos;
  public bool Shotgun_TakenC = false;
  public bool Launcher_TakenC = false;
  public bool JetPack_TakenC = false;
  public float last_health = 100;
  public float top_health = 100;
  public float[] position;
  public int saved = 0;

  void Awake(){ //ensures that loading the scene / respawning doesnt delete all the check points
    health_amount = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
   // data = GameObject.FindGameObjectWithTag("Load").GetComponent<player_Data>();
    if(instance == null){
      instance = this;
      DontDestroyOnLoad(instance);
    }
    else{
      Destroy(gameObject);
    }
  }
    // Start is called before the first frame update
    void Start()
    {
      position = new float [3];
     saved = 1;
     if(File.Exists(Application.dataPath + "/JSONData.text"))
     {
       StreamReader sr = new StreamReader(Application.dataPath + "/JSONData.text");
       string JsonString = sr.ReadToEnd();
       sr.Close();
       Save save = JsonUtility.FromJson<Save>(JsonString);//Into the Save Object
       Debug.Log("-LOADED-");
       Shotgun_TakenC = save.Shotgun1;
       Launcher_TakenC = save.Launcher1;
       JetPack_TakenC = save.JetPack1;
       last_health = save.Health1;
       lastCheckPointPos.x = save.position0;
       lastCheckPointPos.y = save.position1;
       lastCheckPointPos.z = save.position2;
    }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void True_Shotgun(){ // Warps the JetPack to your location
      Shotgun_TakenC = true;
      return;
    }

  public void True_Launcher(){ // Warps the JetPack to your location
      Launcher_TakenC = true;
      return;
    }

    public void True_JetPack(){ // Warps the JetPack to your location
      JetPack_TakenC = true;
      return;
    }

    public void Save_Health(float health){
      last_health = health;
      top_health = health;
      return;
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
