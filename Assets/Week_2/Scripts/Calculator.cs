using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    private string currentInput = "";

    private double result = 0.0;

    public void OnButtonClick(string buttonValue)
    {
        if (buttonValue == "=")
        {
            Calculateresult();
        }
        else if (buttonValue == "C")
        {
            Clearinput();
        }
        else
        {
            currentInput += buttonValue;
            UpdateDisplay();
        }
    }

    public void Calculateresult()
    {
        try
        {
            result = System.Convert.ToDouble(new System.Data.DataTable().Compute(currentInput, ""));

            currentInput = result.ToString();
            UpdateDisplay();
        }
        catch (System.Exception)
        {
            currentInput = "Error";
            UpdateDisplay();
        }

    }

    private void Clearinput()
    {
        currentInput = "";
        result = 0.0;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayText.text = currentInput;
    }
}
