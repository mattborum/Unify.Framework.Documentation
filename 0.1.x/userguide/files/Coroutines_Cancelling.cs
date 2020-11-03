
using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class Cancelling : MonoBehaviour
{
    private UnifyCoroutine myUnifyCoroutine;

    void Start()
    {
        myUnifyCoroutine = new UnifyCoroutine(WaitAndPrint(), name: "Georgia") { failSilently = false };
     
        print("press S to START, X to STOP, C to CANCEL");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            print("* Starting Unify Coroutine *");
            myUnifyCoroutine.Start();
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            print("* Stopping Unify Coroutine *");
            myUnifyCoroutine.Stop();
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            print("* Cancelling Unify Coroutine *");
            myUnifyCoroutine.Cancel();
        }
    }

    IEnumerator WaitAndPrint()
    {
        for (int i = 0; i < 60; i++)
        {
            print("i = " + i);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
