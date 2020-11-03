using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    private UnifyCoroutine myUnifyCoroutine;

    void Start()
    {
        myUnifyCoroutine = new UnifyCoroutine(SayHello(), startDelay: 2.5f, name: "Dave") { failSilently = false };

        print("press S to START");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            myUnifyCoroutine.Start();
        }
    }

    IEnumerator SayHello()
    {
        string hello = "Hello, Unify!";

        for (int i = 0; i < hello.Length; i++)
        {
            print(hello[i]);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}