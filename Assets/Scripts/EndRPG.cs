using UnityEngine;
using System.Collections;

public class EndRPG : MonoBehaviour {
    public float speed = 5.0f;
	
	void Update () {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameManager.LoadScene("Rythm Game", "This summer camp was not so bad afterall. " +
                                "\nMonitor : Kids, are you ready to party ?! "+
                                "\nZaniel come ! It’s time to dance ! " +
                                "\nUse the arrows and the spacebarre ");
    }
}
