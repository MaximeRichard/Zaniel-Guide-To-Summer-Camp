using UnityEngine;
using System.Collections;

public class BeginRPG : MonoBehaviour {
    public float speed = 4.0f;

	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameManager.LoadScene("BattleGame", "A deep white smog circle you. Where the hell are you ? "+
                            "\nZaniel : What..What happened  ? Where are we ?"+
                            "\nAlice :  Look ! I’ve got a hat ! And this dress is so pretty !" +
                            "\nSkyler : Darkness engulf me… There is so much pain here… " +
                            "\n[Zaniel is now a Knight]" +
                            "\n[Alice is now a Magician]" +
                            "\n[Skyler is now a Thief]" +
                            "\nMéri  : The goddesses have heard my prayers !  We must hurry !" +
                            "\nZaniel : Who are you ?  We were in the forest and now..." +
                            "\nMéli : Please Zaniel, we don’t have much time , I need your help. My village is under attack by one of the seven sworn evil king : RATAKING and I used my last power to summons you. You’re the only one who can save my wonderful village." +
                            "\nFight your way out ! Use the commands to defeat the enemies ! ");
    }
}
