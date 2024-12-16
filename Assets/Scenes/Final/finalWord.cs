using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class finalWord : MonoBehaviour
{
    public TMP_InputField[] inputFields;
    public string solutionWord = "SWEETS";
    public TMP_Text feedbackText;

    private void Start()
    {
        foreach (var inputField in inputFields)
        {
            inputField.characterLimit = 1;
            inputField.onValueChanged.AddListener(delegate { OnInputChanged(); });
        }
    }

    private void OnInputChanged()
    {
        // Prüfe, ob alle Felder gefüllt sind
        if (inputFields.All(field => !string.IsNullOrEmpty(field.text)))
        {
            // Baue das Wort aus den Input-Feldern zusammen
            string userWord = string.Concat(inputFields.Select(field => field.text.ToUpper()));

            // Prüfe, ob es mit dem Lösungswort übereinstimmt
            if (userWord == solutionWord)
            {
                SetFeedback("Correct! You won! Congrats girlypop <3", "#77DD77");
            }
            else
            {
                SetFeedback("Girl that wasn't very slay of you. Try again", "#ff8080");
            }
        }
    }
    private void SetFeedback(string message, string hexColor)
    {
        feedbackText.text = message;

        if (ColorUtility.TryParseHtmlString(hexColor, out Color color))
        {
            feedbackText.color = color;
        }
        else
        {
            Debug.LogError($"Invalid Hex Color Code: {hexColor}");
        }
    }
}
