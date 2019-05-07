using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public Text armyStrength;
    public GameObject instructionPanel;
    void Start()
    {
        
    }

    void Update()
    {
        armyStrength.text = "Army Strengh \n" + GameManager.Instance.playerAmount.ToString();
    }

    public void InstructionClick()
    {
        instructionPanel.SetActive(false);
    }
}
