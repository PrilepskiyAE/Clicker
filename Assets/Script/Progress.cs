using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class Progress : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public double NumberOfCoins;
    public double CoinsPerClick;

    public double CoinsPerSecond;

    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _perSecondText;

    private float _timer;

    public event Action<Double> OnCoisChanged;

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
    private void UpdateCoinsText()
    {
        _coinsText.text = Formater.Format(NumberOfCoins);
        OnCoisChanged.Invoke(NumberOfCoins);
    }
    private void UpdatePerSecondText()
    {
        _perSecondText.text = Formater.Format(CoinsPerSecond);
    }

    public void AddCoinsPerClick(double value, double price)
    {
        if (NumberOfCoins < price) return;
        CoinsPerClick += value;
        NumberOfCoins -= price;
        UpdateCoinsText();
    }

    public void AddCoinsPerSecond(double value, double price)
    {
        if (NumberOfCoins < price) return;
        CoinsPerSecond += value;
        UpdatePerSecondText();
        NumberOfCoins -= price;
        UpdateCoinsText();
    }
}
