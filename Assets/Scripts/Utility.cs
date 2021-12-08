using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static IEnumerator wait(float waitTime)
    {
        float cnt = 0;
        while (cnt< waitTime) {
            cnt += Time.deltaTime;
            yield return null;
        }
    }
}