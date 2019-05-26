using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public static UiManager Ui { get; private set; }
    public Text armyStrength;
    public Text enemyStrength;
    public GameObject instructionPanel;
    public Button gotItBtn;
    public Image meteorCoolDown;
    void Start()
    {
        Ui = this;
        StartCoroutine(GotIt());
    }

    void Update()
    {
        armyStrength.text = "Army Strength \n" + GameManager.Instance.playerAmount.ToString();
        enemyStrength.text = "Enemy army\n" + GameManager.Instance.enemyAmount.ToString();
    }

    public void InstructionClick()
    {
        instructionPanel.SetActive(false);
    }

    public void SetCooldown(float value)
    {
        meteorCoolDown.fillAmount = value;
    }

    private IEnumerator GotIt()
    {
        yield return new WaitForSeconds(3);
        gotItBtn.interactable = true;
    }
}
