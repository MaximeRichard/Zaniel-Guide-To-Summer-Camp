using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	private bool paused = false;
	public GameObject pausePrefab;
	private GameObject pauseScreen;
	public bool inGame = false;
	//variable static  qui ne peut exister qu'une fois dans le programme
	private static GameManager gameManager = null;
	// Use this for initialization
    void Start()
    {
		//SAFE CODE : Check si il existe un autre gamemanager si c'est le cas, je m'autodetruit
		if (gameManager != null && gameManager != this) {
			Destroy (this.gameObject);
			return;
		}

		// pour qu'on puisse y accéder dans les methodes statiques
		gameManager = this;
		pauseScreen = Instantiate (pausePrefab);
		gameManager.pauseScreen.gameObject.GetComponentInChildren<Button> ().onClick.AddListener (() => {
			TogglePause ();
		});
		pauseScreen.SetActive (false);
		DontDestroyOnLoad (this.gameObject);
		DontDestroyOnLoad (pauseScreen);
		LoadScene("Menu");

    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
            TogglePause();
    }

	// fonction a appeller qui retourne le script gameManager
	public static GameManager getInstance()
	{
		return gameManager;
	}

	public static void TogglePause()
	{
		if (!gameManager.inGame)
			return;
		if (gameManager.paused)
		{
			gameManager.pauseScreen.gameObject.SetActive (false);
			GameManager.LoadTextCanvas ("Pause");
			GameManager.LoadButtonCanvas ("Reprendre");
			Time.timeScale = 1f;
			gameManager.paused = false;
		}
		else
		{
			Time.timeScale = 0f;
			gameManager.paused = true;
			gameManager.pauseScreen.gameObject.SetActive (true);
		}
	}
    
    public static void Quit()
    {
        Application.Quit();
    }

	public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
		GameManager.LoadTextCanvas ("Default");
		TogglePause ();
    }

	public static void LoadScene(string name, string instructions)
	{
		SceneManager.LoadScene(name);
		GameManager.LoadTextCanvas (instructions);
		TogglePause ();
	}

	public static void LoadTextCanvas(string text)
	{
		Text GO = gameManager.pauseScreen.gameObject.GetComponentInChildren<Text> ();
		print (GO);
		Text TextFromCanvas= GO.GetComponent<Text> ();
		TextFromCanvas.text = text;
	}
	public static void LoadButtonCanvas(string text)
	{
		Button GO = gameManager.pauseScreen.gameObject.GetComponentInChildren<Button> ();
		Text TextFromButton= GO.GetComponentInChildren<Text> ();
		print (TextFromButton.text);
		TextFromButton.text = text;
	}
}
