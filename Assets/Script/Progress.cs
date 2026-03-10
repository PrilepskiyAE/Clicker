using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Progress : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float NumberOfCoins;
    public float CoinsPerClick;

    public float CoinsPerSecond;

    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _perSecondText;   

    private float _timer;

    void Start()
    {
        UpdateCoinsText();
        UpdatePerSecondText();
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1f)
        {
            _timer = 0f;
            NumberOfCoins += CoinsPerSecond;
            UpdateCoinsText();
        }
    }

    public void AddClick()
    {
        NumberOfCoins += CoinsPerClick;
        UpdateCoinsText();
    }
    private void UpdateCoinsText() {
       _coinsText.text = NumberOfCoins.ToString(); 
    }
    private void UpdatePerSecondText()
    {
        _perSecondText.text = CoinsPerSecond.ToString();
    }
}
