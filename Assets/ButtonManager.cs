using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject Test_UI;
    public GameObject targetGameObj;

    public Vector3 TargetPos;
    public Vector3 targetPos, originalPos;
    public Vector3 targetSize;
    public Vector3 targetRotation;

    public float travelTime;
    public float speed;
    public float FadeDuration;
    public float rotationDuration;

    public Image targetImage;
    public void MoveTween()
    {
        targetGameObj.transform.DOLocalMove(targetPos, speed).SetEase(Ease.Linear).OnComplete(() => ReturnPos());
    }

    public void ReturnPos()
    {
        targetGameObj.transform.DOLocalMove(originalPos, speed).SetEase(Ease.Linear);
    }

    public void ScaleTween()
    {
        transform.DOScale(Vector3.zero, travelTime).SetEase(Ease.Linear);
    }

    public void FadeTween()
    {
        targetImage.DOFade(0,FadeDuration);
    }

    public void SequenceTween()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(targetGameObj.transform.DOLocalMove(targetPos, speed).SetEase(Ease.InOutBounce));
        sequence.AppendInterval(1);
        sequence.Append(Test_UI.transform.DOScale(Vector3.one, travelTime).SetEase(Ease.InOutBounce));
        sequence.AppendInterval(1);
        sequence.Append(targetGameObj.transform.DOLocalMove(originalPos, speed).SetEase(Ease.InOutBounce));
    }

    public void Rotation()
    {
        //targetImage.transform.DOLocalRotate(targetRotation, rotationDuration).SetEase(Ease.InOutBounce);
        targetImage.transform.DOLocalRotate(targetRotation,rotationDuration).SetEase(Ease.Linear).SetLoops(10, LoopType.Incremental);
    }
}