using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer.Interfaces;
using System.Globalization;

public class SubjectPlayer : MonoBehaviour, ISubject<GameObject>
{
    private GameObject enemy;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.gameObject;
            NotifyObservers();
        }
    }

    // IMPLEMENTACION DEL PATRON OBSERVER
    private List<IObserver<GameObject>> _observers = new List<IObserver<GameObject>>();

    public void AddObserver(IObserver<GameObject> observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver<GameObject> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver<GameObject> observer in _observers)
        {
            observer?.UpdateObserver(enemy);
        }
    }
}
