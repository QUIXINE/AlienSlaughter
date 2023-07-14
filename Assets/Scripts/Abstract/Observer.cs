using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    public abstract void ReceiveSignal(SubjectOfObserver subject);

}