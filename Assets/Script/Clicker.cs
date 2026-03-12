using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Progress _progress;

    [SerializeField] private ClickEffect _clickEffectPrefab;
    [SerializeField] private Scaleble _scaleble;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit)){
                if (hit.collider.GetComponent<ClickZone>())
                {
                    _progress.AddClick();
                    _scaleble.Scale();
                   ClickEffect clickEffect = Instantiate(_clickEffectPrefab,hit.point,Quaternion.identity);
                   clickEffect.Setup(_progress.CoinsPerClick);
                    
                }
            }
                
            
        }
    }
}
