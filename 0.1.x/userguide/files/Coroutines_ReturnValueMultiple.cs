using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class Coroutines_ReturnValueMultiple : MonoBehaviour
{
    private UnifyCoroutine<int> myUnifyCoroutine;

    void Start()
    {
        myUnifyCoroutine = new UnifyCoroutine<int>(MultiplesOfThree());
        myUnifyCoroutine.failSilently = false;
        myUnifyCoroutine.keepAlive = true;

        myUnifyCoroutine.ValueReturned += ValueReturnedHandler;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            print("* Starting Unify Coroutine *");
            myUnifyCoroutine.Start();
        }
    }

    private void ValueReturnedHandler(object sender, UnifyCoroutineEventArgs<int> e)
    {
        print($"{e.returnValue} is a multiple of 3");
    }

    IEnumerator MultiplesOfThree()
    {
        for (int i = 1; i <= 30; i++)
        {
            if (i % 3 == 0)
            {
                yield return i;
                yield return new WaitForSecondsRealtime(1f);
            }
        }
    }
}
