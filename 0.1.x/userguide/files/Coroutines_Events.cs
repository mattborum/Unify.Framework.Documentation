using System;
using System.Collections;
using Unify.Coroutines;
using UnityEngine;

public class Coroutines_Events : MonoBehaviour
{
    private UnifyCoroutine myUnifyCoroutine;
    private bool pausedSubscribeToggle = false;

    private EventHandler<UnifyCoroutineEventArgs> pausedEventDelegate;
    private EventHandler<UnifyCoroutineEventArgs> passCompleteEventDelegate;

    void Start()
    {
        myUnifyCoroutine = new UnifyCoroutine(WaitAndPrint(), name: "Grace", loopCount:4) { failSilently = false, keepAlive = true };

        // Subscribe to the Started event programmatically.
        myUnifyCoroutine.Started += StartedEventHandler;

        // Subscribe to the Paused event programmatically.
        myUnifyCoroutine.Paused += PausedEventHandler;
        myUnifyCoroutine.Paused += pausedEventDelegate;

        // Subscribe to the Resumed event using an anonymous method.
        myUnifyCoroutine.Resumed += delegate(object sender, UnifyCoroutineEventArgs e)
        {
            print("* RESUMED EVENT HANDLER *");
        };

        // Subscribe to the Stopped event using an anonymous method.
        myUnifyCoroutine.Stopped += delegate(object sender, UnifyCoroutineEventArgs e)
        {
            print("* STOPPED EVENT HANDLER *");
        };

        // Subscribe to the Cancelled event using a lambda expression.
        myUnifyCoroutine.Cancelled += (sender, e) =>
        {
            print("* CANCELLED EVENT HANDLER *");
        };

        // Subscribe to the PassComplete event using a lambda expression through a referenced delegate
        passCompleteEventDelegate = (sender, args) => { print("* PASS COMPLETE EVENT HANDLER*");};
        myUnifyCoroutine.PassComplete += passCompleteEventDelegate;

        // Subscribe to the Finished event using a lambda expression.
        myUnifyCoroutine.Finished += (sender, e) =>
        {
            print("* FINISHED EVENT HANDLER *");
        };

        print("press S to START, P to PAUSE, R to RESUME, X to STOP, C to CANCEL, E to subscribe to/unsubscribe from PAUSED event");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            myUnifyCoroutine.Start();
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            myUnifyCoroutine.Pause();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            myUnifyCoroutine.Resume();
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            myUnifyCoroutine.Stop();
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            myUnifyCoroutine.Cancel();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (pausedSubscribeToggle)
            {
                myUnifyCoroutine.Paused += PausedEventHandler;
                myUnifyCoroutine.Paused += pausedEventDelegate;

                print("* SUBSCRIBED TO PAUSED EVENT *");
            }
            else
            {
                myUnifyCoroutine.Paused -= PausedEventHandler;
                myUnifyCoroutine.Paused -= pausedEventDelegate;

                print("* UNSUBSCRIBED FROM PAUSED EVENT *");
            }

            pausedSubscribeToggle = !pausedSubscribeToggle;
        }
    }

    IEnumerator WaitAndPrint()
    {
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 == 0)
            {
                print(i);
                yield return new WaitForSecondsRealtime(1f);
            }
        }
    }

    private void StartedEventHandler(object sender, UnifyCoroutineEventArgs e)
    {
        print("* STARTED EVENT HANDLER *");
    }

    private void PausedEventHandler(object sender, UnifyCoroutineEventArgs e)
    {
        print("* PAUSED EVENT HANDLER *");
    }
}