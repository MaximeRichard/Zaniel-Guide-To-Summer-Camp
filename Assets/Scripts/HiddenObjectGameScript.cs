using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HiddenObjectGameScript : MonoBehaviour
{
    public List<GameObject> listItems;
    private uint itemFoundsCount;
    private HiddenObject[] hiddenObjects;
	void Start () {
        hiddenObjects = FindObjectsOfType<HiddenObject>();
        foreach (HiddenObject ho in hiddenObjects)
        {
            ho.OnObjectFound += ObjectFound;
        }
	}

    public void ObjectFound(string name)
    {
        GameObject item = null;
        for(int i = 0; i < listItems.Count; i++)
        {
            if (listItems[i].name == name)
                item = listItems[i];
        }
        item.GetComponent<SpriteRenderer>().color = Color.white;

        if (++itemFoundsCount >= listItems.Count)
        {
            GameOver();
        }
	}

    public void GameOver()
    {
		GameManager.LoadScene("Train QTE", "Mom : Holy Moly ! The train is leaving the station ! RUN ZANIEL, RUN ! " +
                        "\n\nTap quickly the left and right arrow to run ! Beware of obstacles : press “Space” to dodge !");
    }
}
