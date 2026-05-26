using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform movingPlatform;
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float waitDuration = 2.0f;

    private Coroutine movingCoroutine;
    private bool moveToTarget = true;

    private void OnEnable()
    {
        ClearCorutine();
        if (moveToTarget)
        {
            MoveToTarget();
        }
        else
        {
            MoveToStart();
        }
    }
    private void OnDisable()
    {
        ClearCorutine();
    }
    private void ClearCorutine()
    {
        if (movingCoroutine != null)
        {
            StopCoroutine(movingCoroutine);
        }
        movingCoroutine = null;
    }
    private void MoveToTarget()
    {
       moveToTarget = true;
        ClearCorutine();
        movingCoroutine = StartCoroutine(MovePlatform());

    }
    private void MoveToStart()
    {
        moveToTarget = false;
        ClearCorutine();
        movingCoroutine = StartCoroutine(MovePlatform());
    }
    IEnumerator MovePlatform()

    {
        while (true)
        {
            Vector3 targetPos = (moveToTarget) ? targetTransform.position : transform.position;
            yield return null;

            float duration = (movingPlatform.transform.position - targetPos).magnitude / moveSpeed;
            Tween moveTween = movingPlatform.DOMove(targetPos, duration);
            yield return moveTween.WaitForCompletion();
            moveTween.Kill();
            yield return new WaitForSeconds(waitDuration);
            moveToTarget = !moveToTarget;
        }
    }
}

