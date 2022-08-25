using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Utill
{
    public static class Dotween
    {
        /// <summary>
        /// �߾ӿ��� �� ������� ������ �ִϸ��̼�
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static Sequence PopUpAnimation(GameObject gameObject)
        {
            return DOTween.Sequence()
           .SetAutoKill(false)
           .AppendCallback(() =>
           {
               gameObject.SetActive(true);
           })
           .OnStart(() =>
           {
               gameObject.transform.localScale = Vector3.zero;
           })
           .Append(gameObject.transform.DOScale(1, 0.3f).SetEase(Ease.InCirc))
           .SetDelay(0.1f)
           .SetUpdate(true);

        }
    }

}