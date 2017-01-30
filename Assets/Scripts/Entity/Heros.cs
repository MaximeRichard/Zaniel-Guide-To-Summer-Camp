using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heros : MonoBehaviour {
    public string heroesClass;
    public Text currentLifeText;
    public Text maxLifeText;
    public Text currentSkillText;
    public Text maxSkillText;

    public float maxLife;
    public float attackPower;
    public float maxSkill;
    public bool defend;
    float currentSkill;
    float currentLife;

    public float CurrentLife { get { return currentLife; } set { currentLife = value; } }
    public float CurrentSkill { get { return currentSkill; } set { currentSkill = value; } }


    public void Setup()
    {
        currentLife = maxLife;
        currentSkill = maxSkill;
        RefreshUI();
    }

    public void RefreshUI()
    {
        currentSkillText.text = currentSkill.ToString();
        maxSkillText.text = maxSkill.ToString();
        currentLifeText.text = currentLife.ToString();
        maxLifeText.text = maxLife.ToString();
    }

    public void TakeDamage(float damage)
    {
        if (defend)
            damage /= 4;
        currentLife -= damage;
        if (currentLife < 0) currentLife = 0;
        currentLifeText.text = Mathf.Ceil(currentLife).ToString();
    }

}
