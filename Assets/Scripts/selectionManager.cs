using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionManager : MonoBehaviour
{

    [SerializeField] private string selectableTag = "selectable";
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material newMaterial;


    private Transform _selection;
    void Update()
    {

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
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

       

    }
    


}

