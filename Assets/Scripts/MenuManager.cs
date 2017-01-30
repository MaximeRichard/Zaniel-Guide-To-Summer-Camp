using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	void Start()
	{
		GameManager.LoadButtonCanvas ("Go");
	}

	public void LaunchSceneGame()
	{
		GameManager.getInstance ().inGame = true;
		GameManager.LoadScene ("HiddenObjectGame", "Zaniel : Oh boy, i’m playing video games all day long and no one can stop me. " +
                                "\nMom : ZANIEL ! I know that you’ve waited these holidays for so long but your dad and i have to work and can’t stay with you.… Now don’t be sad, we took care of everything !" +
                                "\nGuess what ? You’re going on SUMMER CAMP ! HURRAY ! " +
                                "\nZaniel : Oh god… Why ?" +
                                "\nMom : Pack your stuff my lovely boy and get ready for a fantastic adventure ! ");
	}

    public void Quit()
    {
        Application.Quit();
    }
}
