using UnityEngine;
using UnityEngine.UI;

public class FrogGameMain : MonoBehaviour
{
    [SerializeField] private Sprite[] _NumberImages;
    [SerializeField] private Image _CountImage;

    float _lapTime = 1.0f;
    float _spendTime = 0.0f;

    int _StartCount = 5;
    bool _isStart = false;


    // Start is called before the first frame update
    void Start()
    {
        _isStart = true;
        _CountImage.gameObject.SetActive(true);
        _CountImage.sprite = _NumberImages[_StartCount];
    }



    // Update is called once per frame
    void Update()
    {
        if (_isStart)
        {
            _spendTime += Time.deltaTime;

            Debug.Log($"_spendTime = {_spendTime}");

            if (_spendTime >= _lapTime)
            {
                if (_StartCount >= 0)
                {
                    _StartCount--;

                    if (_StartCount >= 0)
                    {
                        _CountImage.sprite = _NumberImages[_StartCount];
                    }
                    else
                    {
                        _CountImage.gameObject.SetActive(false);
                    }
                }
                else
                {
                    _isStart = false;

                }

                _spendTime = 0.0f;
            }
        }

    }
}
