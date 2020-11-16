using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script pulls the object id's from ButtonB and then iteratres over them. This controls the puzzles ability to
// randomize the button choice, Make soundwhen "Simon" has selected a color, when the player has selected the color,
// ifthe players choice was right or wrong, allow the puzzle to keep score, and verify with Door_Controller if the
// win conditions has been fulfilled ( needed = 2).

public class Game_2_Controller : MonoBehaviour{

	public static Game_2_Controller Instance;
	private Game_2_Controller lead;
	public Button_2_B[] btns;
	public int[] pattern;
	public int true_puzzle; // value goes to one if the false one "Lead" runs it course

	static int simonMax;
	public float simonTime;
	public int win;
	public int needed = 0;
	public GameObject[] array;


	static List<int> userList, showList, prevList;

	public static bool simonIsSaying;

	void Awake(){
	}


	void Start(){ // Creating the timing for simon's beeps and halt game condition.
		if ( gameObject.tag  == "Lead"){ // Assuming the game object running this is "Lead"
			true_puzzle = 0;
		}
		else {
			lead = GameObject.FindGameObjectWithTag("Lead").GetComponent<Game_2_Controller>();
			true_puzzle = 1;

		}
		Instance = this;
		
		simonMax = 3;
		simonTime = 1.0f;
		win = 1;
		StartCoroutine(SimonSays());

	}


	public IEnumerator Change_Values(float delay){
     			yield return new WaitForSeconds(delay);
			showList = new List<int>();
			pattern = lead.pattern;
			for (int i = 0; i < simonMax; i++){
				showList.Add(pattern[i]);
			}
			yield break;
			}

	public void PlayAudio(int index) { // creates a noise for each block, based off of their id number and a frequenct wave
//The choice of sound is based off the number of cubes, 4, and is consistent.
		float length = 0.5f;
		float frequency = 0.001f * ((float)index + 1f);

		AnimationCurve volumeCurve = new AnimationCurve(new Keyframe(0f, 1f, 0f, -1f), new Keyframe(length, 0f, -1f, 0f));
		AnimationCurve frequencyCurve = new AnimationCurve(new Keyframe(0f, frequency, 0f, 0f), new Keyframe(length, frequency, 0f, 0f));

		LeanAudioOptions audioOptions = LeanAudio.options();
		audioOptions.setWaveSine();
		audioOptions.setFrequency(44100);
		AudioClip audioClip = LeanAudio.createAudio(volumeCurve, frequencyCurve, audioOptions);

		LeanAudio.play(audioClip, 0.5f);
	}

	public void PlayerAction(Button_2_B b) // determines if they passed a round, failed a round, or won twice in a row.
	{
		userList.Add(b.id);

		if (userList[userList.Count-1] != showList[userList.Count-1])
		{
			needed = 0;
			Start();
			Debug.Log("Lose");
		}

		else if(userList.Count == showList.Count)
		{
			needed++;
			if (needed <= 1){
				Debug.Log("Next Level");
				StartCoroutine(SimonSays());
			}
			
			else{
				return;
			}

		}


	}
	
	IEnumerator SimonSays() // determines the beep order and allows for the player to have their turn
	{	
		pattern = new int [simonMax];
		if (needed >= win){
			yield break;
		}
		Debug.Log("Prepare");
		yield return new WaitForSeconds(1);
		simonIsSaying = true;
		userList = new List<int>();
		showList = new List<int>();

		for (int i = 0; i < simonMax; i++)
		{
			int rand = Random.Range(0, 3);
			pattern[i] = rand;
			showList.Add(rand);
			PlayAudio(rand);
			btns[rand].Action();
			yield return new WaitForSeconds(simonTime);
		}
		simonTime -= 0.015f;
		simonMax++;
		simonIsSaying = false;

		if (gameObject.tag == "Follow"){ 
			Debug.Log("This is now called Follow");
			StartCoroutine(Change_Values(3));
		}
	}
	

	public IEnumerator Retry_Signal() // determines the beep order and allows for the player to have their turn
	{	

		for (int i = 0; i < simonMax; i++)
		{
			PlayAudio(pattern[i]);
			btns[pattern[i]].Action();
			yield return new WaitForSeconds(1);

		}

	}

}
