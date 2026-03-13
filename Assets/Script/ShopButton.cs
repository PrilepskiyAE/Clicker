using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public enum IncomeOption
{
    PerClick,
    perSecond
}

public class ShopButton : MonoBehaviour
{
  [SerializeField] private string _name;
  [SerializeField] private double _price;
  [SerializeField] private double _income;

  [SerializeField] private IncomeOption _incomeOption;
  [SerializeField] private Sprite _iconSprite;

  [Space(20)]
  [SerializeField] private TMP_Text _nameText;
  [SerializeField] private TMP_Text _descriptionText;
  [SerializeField] private TMP_Text _pricrText;
  [SerializeField] private Button _button;
  [SerializeField] private Image _icon;
  [SerializeField] private AnimationCurve _scaleCurve;
  [SerializeField] private float _scalePeriod;


  [SerializeField] private Progress _progress;
    private void Awake() {
        _progress.OnCoisChanged +=UpdateButton;
    }

    private void UpdateButton (double coins) {
        if(_price <= coins)
        {
            _button.interactable=true;
        }
        else
        {
             _button.interactable=false;
        }
    }

    private void OnDestroy()
    {
        _progress.OnCoisChanged -=UpdateButton; 
    }

    void Start()
    {
        _button.onClick.AddListener(Buy);
        _nameText.text = _name;
        _pricrText.text = Formater.Format(_price);
        _icon.sprite=_iconSprite;
        if (_incomeOption == IncomeOption.PerClick)
        _descriptionText.text =  "+"+Formater.Format(_income) + " за клик" ;
        else _descriptionText.text =  "+ "+Formater.Format(_income)+ " в секунду" ;
    }

    void OnValidate()
    {
         _nameText.text = _name;
       _pricrText.text = Formater.Format(_price);
        _icon.sprite=_iconSprite;
        if (_incomeOption == IncomeOption.PerClick)
        _descriptionText.text =  "+"+Formater.Format(_income) + " за клик" ;
        else _descriptionText.text =  "+ "+Formater.Format(_income)+ " в секунду" ;
    }

    public void Buy()
    {    StartCoroutine(ScaleProcess());
         if (_incomeOption == IncomeOption.PerClick)
        {
            _progress.AddCoinsPerClick(_income,_price);
        }
        else
        {
            _progress.AddCoinsPerSecond(_income,_price); 
        }
    
       
    }

    private IEnumerator ScaleProcess()
    {
        for(float t = 0 ; t<1f; t += Time.deltaTime / _scalePeriod )
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

}
