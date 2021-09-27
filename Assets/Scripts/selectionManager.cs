using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionManager : MonoBehaviour
{

    [SerializeField] private Material newMaterial;

    private States _currentState;
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                OnObject();
            }
        }


    }
    public void OnObject()
    {
        StartCoroutine(_currentState.Scared());
    }


}

