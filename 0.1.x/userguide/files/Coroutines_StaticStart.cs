using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class Coroutines_StaticStart : MonoBehaviour
{
    void Start()
    {
        print("press S to START");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            print("* Starting Unify Coroutine *");

            UnifyCoroutine.Start(SquaresOfOneToTen(), startDelay: 1f, loopCount: 3, passDelay: 2.5f, name: "William",
                                 passCompleteEventHandler: (s, e) =>
                                 {
                                     print("* PASS COMPLETE *");
                                 },
                                 finishedEventHandler: (s, e) =>
                                 {
                                     print("* Static Unify Coroutine FINISHED *");
                                 });
        }
    }

    IEnumerator SquaresOfOneToTen()
    {
        for (int i = 1; i <= 10; i++)
        {
            print($"sqr({i}) = " + i * i);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
