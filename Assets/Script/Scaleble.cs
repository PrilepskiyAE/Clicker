using System.Collections;
using UnityEngine;

public class Scaleble : MonoBehaviour
{
    [SerializeField] private AnimationCurve _caleCurve;
    [SerializeField] private float _scalePeriod = 0.3f;

    private Coroutine _coroutine;
   
    public void Scale()
    {
        if(_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(ScaleProcess());
    }
    private IEnumerator ScaleProcess()
    {
        for(float t = 0 ; t<1f; t += Time.deltaTime / _scalePeriod )
        {
            float scale = _caleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }
}
