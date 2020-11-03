
using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class Coroutines_Looping : MonoBehaviour
{
    private UnifyCoroutine myUnifyCoroutine;

    void Start()
    {
        myUnifyCoroutine = new UnifyCoroutine(Fibonacci(), loopCount: 3, passDelay: 2.5f, name: "Ginny");
        myUnifyCoroutine.failSilently = true;
        myUnifyCoroutine.keepAlive = false;

        myUnifyCoroutine.PassComplete += MyUnifyCoroutine_PassComplete;

        print("press S to START");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            print("* Starting Unify Coroutine *");
            myUnifyCoroutine.Start();
        }
    }

    private IEnumerator Fibonacci()
    {
        int a = 0;
        int b = 1;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }

            print(a); 

            yield return new WaitForSecondsRealtime(0.3f);
        }
    }

    private void MyUnifyCoroutine_PassComplete(object sender, UnifyCoroutineEventArgs e)
    {
        print("* PASS COMPLETE *");
    }
}
