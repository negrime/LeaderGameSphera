using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public static UiManager Ui { get; private set; }
    public Text armyStrength;
    public GameObject instructionPanel;
    public Image meteorCoolDown;
    void Start()
    {
        Ui = this;
    }

    void Update()
    {
        armyStrength.text = "Army Strengh \n" + GameManager.Instance.playerAmount.ToString();
    }

    public void InstructionClick()
    {
        instructionPanel.SetActive(false);
    }

    public void SetCooldown(float value)
    {
        meteorCoolDown.fillAmount = value;
    }
}
