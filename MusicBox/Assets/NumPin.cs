using TMPro;
using UnityEngine;

public class NumPin : MonoBehaviour
{
    public TextMeshProUGUI textObj;
    public void ChangeNumText(UnityEngine.UI.Slider slider)
    {
        string[] t = textObj.text.Split(" ");
        int sliderValue = (int)slider.value;
        textObj.text = sliderValue.ToString() + " " + t[1];
    }
}
