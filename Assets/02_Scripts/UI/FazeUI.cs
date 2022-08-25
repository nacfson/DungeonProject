using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FazeUI : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI fazeText;
    

    [SerializeField] private float time = 1.0f;
    public int rotationValue;
    public Sequence sequenceFadeInOut;
    private void FazeText()
    {
        rotationValue = 0;
        fazeText.gameObject.SetActive(true);
        sequenceFadeInOut = DOTween.Sequence()
.SetAutoKill(false) // DoTween Sequence는 기본적으로 일회용임. 재사용하려면 써주자.
.OnRewind(() => // 실행 전. OnStart는 unity Start 함수가 불릴 때 호출됨. 낚이지 말자.
{
    fazeText.enabled = true;
})
.Append(fazeText.DOFade(1.0f, time)) // 어두워짐. 알파 값 조정.
.Append(fazeText.DOFade(0.0f, time)) // 밝아짐. 알파 값 조정.
.OnComplete(() => // 실행 후.
{
    fazeText.enabled = false;
});
    }


    private void Start()
    {
        fazeText.text = "Faze1";
        FazeText();
    }
}
