using TMPro;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
   [SerializeField] private TMP_Text _text;

   public void Setup(float value)
    {
        _text.text=value.ToString();
    }
}
