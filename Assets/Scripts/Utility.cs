using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Utility class, used for custom code that is used in multiple places
public static class Utility
{
    public static IEnumerator wait(float waitTime) // simple code that can be used in multiple classes to wait for a moment.
    {
        float cnt = 0;
        while (cnt< waitTime) {
            cnt += Time.deltaTime;
            yield return null;
        }
    }

    // https://www.delftstack.com/howto/csharp/generate-a-random-float-in-csharp/
    // https://www.codegrepper.com/code-examples/csharp/c%23+random+float+between+two+numbers
    public static float GenerateRandomFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}