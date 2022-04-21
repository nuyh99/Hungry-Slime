using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{
    public Slider slider;       //Slider 객체로 fill 셋팅
    public Gradient gradient;   //fill 그라디언트
    public Image fill;          //fill 객체

    public void SetMaxBoost(float boost)        //최대 부스터 용량으로 슬라이더 초기화 및 fill 100%
    {
        slider.maxValue = boost;
        slider.value = boost;

        fill.color = gradient.Evaluate (1f) ;
    }

    public void SetBoost(float boost)       //현재의 부스터 용량 세팅
    {
        slider.value = boost;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
