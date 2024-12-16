using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class MoveReloading
{
    public void CanMove(TMP_Text text)
    {
        if (Language.Instance.CurrentLanguage == "en")
            text.text = "You can move";

        else if (Language.Instance.CurrentLanguage == "ru")
            text.text = "Ты можешь двигаться";

        else
            text.text = "You can move";
    }

    public void CantMove(TMP_Text text)
    {
        if (Language.Instance.CurrentLanguage == "en")
            text.text = "You can`t move";

        else if (Language.Instance.CurrentLanguage == "ru")
            text.text = "Ты не можешь двигаться";

        else
            text.text = "You can`t move";
    }
}
