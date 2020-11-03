using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class Coroutines_ReturnValueOnce : MonoBehaviour
{
    private UnifyCoroutine<string> myUnifyCoroutine;

    void Start()
    {
        myUnifyCoroutine = new UnifyCoroutine<string>(WaitAndReturnString()) { failSilently = false, keepAlive = true };

        myUnifyCoroutine.ValueReturned += (sender, e) =>
        {
            print(e.returnValue);
        };

        print("press S to START");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            print("* Starting Unify Coroutine - waiting for 2 seconds....");
            myUnifyCoroutine.Start();
        }
    }

    IEnumerator WaitAndReturnString()
    {
        yield return new WaitForSecondsRealtime(2f);
        yield return "Hello, Unify!";
    }
}
