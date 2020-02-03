using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public enum TestEnum { play, exit };

    //This is what you need to show in the inspector.
    GameObject manager;
    public TestEnum choices;
  


    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        Debug.Log("press down");
        switch (choices)
        {
            case TestEnum.play:

                SceneManager.LoadScene(1);
                break;
            case TestEnum.exit:
                #if UNITY_EDITOR
                
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
                break;
            default:
                Debug.Log("NOTHING");
                break;
        }

    }

}