using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour
{
    public Canvas canvas;

    private void Awake() {
        canvas.enabled = !canvas.enabled;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            canvas.enabled = !canvas.enabled;
        }
    }
}
