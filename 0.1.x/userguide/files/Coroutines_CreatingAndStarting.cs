
using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class CreatingAndStarting : MonoBehaviour
{
    private UnifyCoroutine myUnifyCoroutine;

    void Start()
    {
        myUnifyCoroutine = new UnifyCoroutine(PrintEverySecond()) { name = "Bob" };

        print("press S to START");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            myUnifyCoroutine.Start();
        }
    }

    IEnumerator PrintEverySecond()
    {
        for (int i = 1; i <= 10; i++)
        {
            print("i = " + i);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}