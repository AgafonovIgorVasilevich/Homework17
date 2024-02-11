using System.Collections;
using UnityEngine;

public class EnemyCannon : Cannon
{
    [SerializeField] private float _delayTime = 0.5f;

    private void OnEnable() => StartCoroutine(AutoShoot());

    private IEnumerator AutoShoot()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayTime);
        WaitForSeconds initialDelay = new WaitForSeconds(1);

        yield return initialDelay;

        while(enabled)
        {
            Shoot();
            yield return delay;
        }
    }
}