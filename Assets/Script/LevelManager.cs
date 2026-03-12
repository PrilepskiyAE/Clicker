using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private int[] _clickForLevel;
    private int _currentLevelIndex;
    private int _clicks;
    [SerializeField] private GameObject[] _models;
    [SerializeField] private Image _scaleImage;
    [SerializeField] private TMP_Text _level;
    private float _targetScaleValue;
    private float _scaleValue=0;
    void Start()
    {
        _scaleImage.fillAmount=0F;
        _level.text="Уровень 1";
    }

    void Update()
    {
        _scaleValue = Mathf.Lerp(_scaleValue, _targetScaleValue, Time.deltaTime*5f);
        _scaleImage.fillAmount=_scaleValue;
    }
    public void AddClick()
    {
        _clicks++;
        if(_clicks >= _clickForLevel[_currentLevelIndex])
        {
            IncreaseLevel();
            _clicks=0;
        }
       _targetScaleValue =(float)_clicks / _clickForLevel[_currentLevelIndex];
        
    }

    private void IncreaseLevel()
    {
        if (_models.Length-1 >_currentLevelIndex){
        _models[_currentLevelIndex].SetActive(false);
        _currentLevelIndex++;
        _level.text="Уровень "+(_currentLevelIndex+1).ToString();
        _models[_currentLevelIndex].SetActive(true);
        }
        else
        {
            _level.text="Finish";
        }
        
    }

}
