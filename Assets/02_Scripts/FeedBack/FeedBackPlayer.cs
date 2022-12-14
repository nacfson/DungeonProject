using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackPlayer : MonoBehaviour
{
    [SerializeField]
    private List<FeedBack> _feedbackToPlay = null;
    public void PlayFeedBack()
    {
        FinishFeedBack(); //������ ���� �ǵ�� ����
        foreach (FeedBack f in _feedbackToPlay)
        {
            f.CreateFeedBack();
        }
    }
    public void FinishFeedBack()
    {
        foreach(FeedBack f in _feedbackToPlay)
        {
            f.CompletePrevFeedBack();
        }
    }
}
