using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public string option;
    public SocialGame manager;

    public void SetText(string newText)
    {
        this.GetComponentInChildren<Text>().text = newText;
    }

    public void SetOption(string newOption)
    {
        this.option = newOption;
    }

    public void ParseOption()
    {
        manager.talking = false;
        manager.lineNumber = int.Parse(option);
        manager.ParseLine();
    }
}
