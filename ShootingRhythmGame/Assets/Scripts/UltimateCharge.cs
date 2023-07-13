using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UltimateCharge : MonoBehaviour
{
    static public int UltCharge;
    [SerializeField] private float _maxUltCharge;
    private bool isUltready = false;

    [SerializeField] private GameObject _gaugeObj;
    private Image _gaugeFilled;
    private Color _gaugeOriginalColor;


    private void Start()
    {
        _gaugeFilled = _gaugeObj.GetComponent<Image>();
        _gaugeOriginalColor = _gaugeFilled.color;
    }


    void Update()
    {
         _gaugeFilled.fillAmount = UltCharge / _maxUltCharge;

        if (UltCharge >= _maxUltCharge)
        {
            if (!isUltready)
            {
                isUltready = true;
                StartCoroutine(RainbowUltGaugeCor());
            }
        }

        if (isUltready && !PauseOnStage.IsPause)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("±Ã¹ß½Î");
                UltCharge = 0;
                _gaugeFilled.color = _gaugeOriginalColor;
                isUltready = false;
            }
        }
    }


    IEnumerator RainbowUltGaugeCor()
    {
        bool isYellow = true;
        while (isUltready)
        {
            if (isYellow) _gaugeFilled.color = Color.cyan; //Random.ColorHSV();
            else _gaugeFilled.color = _gaugeOriginalColor;

            isYellow = !isYellow;
            yield return new WaitForSeconds(BGMManager.Bpm/240f);
        }
    }
}
