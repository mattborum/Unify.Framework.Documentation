using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class StoppingAndRestarting : MonoBehaviour
{
    private UnifyCoroutine myUnifyCoroutine;

    void Start()
    {
        myUnifyCoroutine = new UnifyCoroutine(WaitAndPrint(), name: "Tracy") { failSilently = false, keepAlive = true };

        print("press S to START, X to STOP");
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
    }

    IEnumerator WaitAndPrint()
    {
        for (int i = 1; i <= 60; i++)
        {
            print("i = " + i);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}