using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class PausingAndResuming : MonoBehaviour
{
    private UnifyCoroutine myUnifyCoroutine;

    void Start()
    {
        myUnifyCoroutine = new UnifyCoroutine(WaitAndPrint(), name: "Karen") { failSilently = false };

        print("press S to START, P to PAUSE, R to RESUME");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            print("* Starting Unify Coroutine *");
            myUnifyCoroutine.Start();
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            print("* Pausing Unify Coroutine *");
            myUnifyCoroutine.Pause();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            print("* Resuming Unify Coroutine *");
            myUnifyCoroutine.Resume();
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