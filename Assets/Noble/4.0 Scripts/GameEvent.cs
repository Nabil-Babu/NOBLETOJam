using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Game Events/GameEvent", fileName = "GameEvent")]
public class GameEvent : ScriptableObject {

    private List<IGameEventListener> listeners = new List<IGameEventListener>();


    public void AddListener(IGameEventListener listener){
        listeners.Add(listener);
    }

    public void RemoveListener(IGameEventListener listener) {
        listeners.Remove(listener);
    }

    public void Invoke() {
        foreach(IGameEventListener listener  in listeners) {
            listener.OnGameEvent(this);
        }
    }

}
