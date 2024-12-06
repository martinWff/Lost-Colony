using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipDisplayer : MonoBehaviour
{
    public PlayerController playerController;
    public TextMeshProUGUI label;
    private void Update()
    {
        if (string.IsNullOrEmpty(playerController.currentTip)) {
            label.text = string.Empty;
        } else {
            label.text = string.Format("TIP: {0}", playerController.currentTip);
        }
    }


}
