using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(DialogueParser))]
public class SocialGame : MonoBehaviour {
    private DialogueParser parser;
    private List<Button> buttons = new List<Button>();
    private DialogueParser.DialogueLine line;

    public int lineNumber;
    public bool talking;

    public GameObject dialogueArea;
    public Text character;
    public Text dialogue;
    public GameObject choiceBox;

    public GameObject alice, skyler, evan;

    GameObject someone;
    float current;

    void Start()
    {
        parser = GetComponent<DialogueParser>();
        line = parser.GetLine(lineNumber);
        someone = (GameObject)Instantiate(alice, transform);
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && talking == false)
        {
            lineNumber++;
            ParseLine();
        }

        UpdateUI();
	}

    public void ParseLine()
    {
        line = parser.GetLine(lineNumber);
        if (line.name == "Player")
        {
            talking = true;
            CreateButtons();
            dialogueArea.SetActive(false);
        }
        else if (line.name == "JumpTo")
        {
            talking = true;
            lineNumber = line.jumpNumber;
            ParseLine();

            Destroy(someone);
            current++;
            if(current == 1)
                someone = (GameObject)Instantiate(skyler, transform);
            else
                someone = (GameObject)Instantiate(evan, transform);
        }
        else if (line.name == "Ending")
        {
            GameManager.LoadScene("BeginRPG", "You’ve been in this forest for a while now…Try to find a way out." +
                    "\nAlice : First it was fun...Now I just want to sleep ! " +
                    "\nSkyler : Think about the marshmallow ! " +
                    "\nZaniel : I think we might be lost…" +
                    "\nAlice : Captain Obvious here you are ! " +
                    "\nZaniel : Guys ? Something is shining behind this tree…" +
                    "\nFour seconds later a circle appeared under your feet." +
                    "\nIt was that moment Zaniel knew he fucked up.");
        }
        else
        {
            talking = false;
            dialogueArea.SetActive(true);
        }
    }

    void CreateButtons()
    {
        for (int i = 0; i < line.options.Length; i++)
        {
            GameObject button = (GameObject)Instantiate(choiceBox);
            Button b = button.GetComponent<Button>();
            ChoiceButton cb = button.GetComponent<ChoiceButton>();
            cb.SetText(line.options[i].Split(':')[0]);
            cb.option = line.options[i].Split(':')[1];
            cb.manager = this;
            b.transform.SetParent(this.transform);
            b.transform.localPosition = new Vector3(0, -25 + (i * 100));
            b.transform.localScale = new Vector3(1, 1, 1);
            buttons.Add(b);
        }
    }

    void UpdateUI()
    {
        if (!talking)
        {
            ClearButtons();
        }
        dialogue.text = line.content;
        character.text = line.name;
    }

    void ClearButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            Button b = buttons[i];
            buttons.Remove(b);
            Destroy(b.gameObject);
        }
    }

}
