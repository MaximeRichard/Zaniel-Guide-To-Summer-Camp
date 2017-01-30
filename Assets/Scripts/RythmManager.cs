using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RythmManager : MonoBehaviour {
	public AudioSource Song;
	public float delay;
	private int ArrowCounter = 0;
	string[] Arrows = { "red", "yellow", "green", "blue" };
	List<float> ArrowList = new List<float>();
	public Transform RedSpawn, BlueSpawn, YellowSpawn, GreenSpawn;
	public GameObject RedArrow, GreenArrow, YellowArrow, BlueArrow, ScoreZone;
	public static int Score = 0;
	public static int GetScore(){
		return Score;
	}
	public static void SetScore(int score){
		Score = score;
	}
	// Use this for initialization
	void Start () {
		//ArrowList.Add(1.762f);
		ArrowList.Add(3.08f);
		ArrowList.Add(4.425f);
		ArrowList.Add(5.759f);
		ArrowList.Add(6.6f);
		ArrowList.Add(6.929f);
		ArrowList.Add(7.092f);
		ArrowList.Add(7.763f);
		ArrowList.Add(8.09f);
		ArrowList.Add(9.094f);
		ArrowList.Add(9.760f);
		ArrowList.Add(10.428f);
		ArrowList.Add(10.771f);
		ArrowList.Add(11.091f);
		ArrowList.Add(11.420f);
		ArrowList.Add(11.930f);
		ArrowList.Add(12.259f);
		ArrowList.Add(12.678f);
		ArrowList.Add(13.213f);
		ArrowList.Add(13.507f);
		ArrowList.Add(13.718f);
		ArrowList.Add(13.884f);
		ArrowList.Add(14.526f);
		ArrowList.Add(14.850f);
		ArrowList.Add(15.059f);
		ArrowList.Add(15.208f);
		ArrowList.Add(15.883f);
		ArrowList.Add(16.430f);
		ArrowList.Add(17.087f);
		ArrowList.Add(17.591f);
		ArrowList.Add(17.757f);
		ArrowList.Add(18.096f);
		ArrowList.Add(18.264f);
		ArrowList.Add(18.546f);
		ArrowList.Add(19.098f);
		ArrowList.Add(19.432f);
		ArrowList.Add(19.602f);
		Song.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (ArrowCounter);
		Debug.Log (ArrowList.Count);
		if (ArrowCounter <= ArrowList.Count - 1) {
			if (Song.time >= (ArrowList [ArrowCounter] - delay)) {
				CreateArrow (Arrows.RandomItem ());
				ArrowCounter++;
			}
		}
		if (Song.time >= 28.5f) {
			StartCoroutine(FadeOut(Song, 0.5f));
		}
			
	}

	void CreateArrow(string arrow)
	{
		if(arrow == "red")
			Instantiate (RedArrow, RedSpawn.position, Quaternion.identity);
		if(arrow == "green")
			Instantiate (GreenArrow, GreenSpawn.position, Quaternion.identity);
		if(arrow == "blue")
			Instantiate (BlueArrow, BlueSpawn.position, Quaternion.identity);
		if(arrow == "yellow")
			Instantiate (YellowArrow, YellowSpawn.position, Quaternion.identity);

	}

	public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
		float startVolume = audioSource.volume;

		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

			yield return null;
		}

		audioSource.Stop ();
		audioSource.volume = startVolume;
	}
		
}

public static class ArrayExtensions
{
	// This is an extension method. RandomItem() will now exist on all arrays.
	public static T RandomItem<T>(this T[] array)
	{
		return array[Random.Range(0, array.Length)];
	}
}
