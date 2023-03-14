using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudTooltip : MonoBehaviour
{
    public GameObject player;
    private Text tooltipText;
    void Start()
    {
        tooltipText = GetComponentInChildren<Text>();

    }

    void Update()
    {
      int totalpower = player.GetComponent<shooting>().powerTot + 1;
      int totalrange = player.GetComponent<shooting>().rangeTot;
      int projectiles = player.GetComponent<shooting>().projectilesnmbrTot;
        tooltipText.text = "Power: " + totalpower + "\nRange: " + totalrange + "\nProjectiles: " + projectiles;
    }
}
