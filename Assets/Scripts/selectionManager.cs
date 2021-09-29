using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class selectionManager : MonoBehaviour
{

    [SerializeField] private string selectableTag = "selectable";
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material happyMaterial;
    [SerializeField] private Material scaredMaterial; 


    private Transform _selection;
    void Update()
    {

       

        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                if (Input.GetMouseButtonDown(0))
                    HandleClick(selection, 0);

                if (Input.GetMouseButtonDown(1))
                    HandleClick(selection, 1);

                if (Input.GetMouseButtonDown(2))
                    CleanColor();


            }

            


        }

    }

    void HandleClick(Transform selection, int type)  
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            
            if (type == 0)
            {
                selectionRenderer.material = happyMaterial;
            }
            if (type == 1)
            {
                selectionRenderer.material = scaredMaterial;
            }
        }

        _selection = selection;

    }

    void CleanColor()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
    }
   
}

