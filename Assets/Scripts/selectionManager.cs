using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionManager : MonoBehaviour
{

    [SerializeField] private Material newMaterial;
    [SerializeField] private string selectableTag = "selectable";
    [SerializeField] private Material defaultMaterial;
    RaycastHit hit;

    private Transform _selection;
   // private States _currentState;
    void Update()
    {

        if (_selection != null)
        {
            OnSpace();
        }
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        
        if(Physics.Raycast(ray, out hit))
        {
            OnObject();
        }

       

    }
    public void OnObject()
    {
        var selection = hit.transform;
        if (selection.CompareTag(selectableTag))
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = newMaterial;
            }

            _selection = selection;
        }
        
    }

    public void OnSpace()
    {
        var selectionRenderer = _selection.GetComponent<Renderer>();
        selectionRenderer.material = defaultMaterial;
        _selection = null;
    }


}

