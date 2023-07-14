using System;
using System.Collections;
using UnityEngine;

public class SubjectOfObserver : MonoBehaviour
{
    private readonly ArrayList _observerList = new ArrayList();

    public void Attach(Observer observer)
    {
        _observerList.Add(observer);
    }
    public void Detach(Observer observer)
    {
        _observerList.Remove(observer);
    }
    public void NotifyObserver()
    {
        foreach (Observer observer in _observerList)
        {
            observer.ReceiveSignal(this);
        }
    }

}