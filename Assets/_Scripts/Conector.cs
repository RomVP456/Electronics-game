using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conector : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance = 10; // Distancia desde la cámara al objeto
    private BoxCollider connectorCollider;
    // [SerializeField]Material childMaterial;
    [SerializeField] Renderer clipRenderer;
    [SerializeField] List<Material> materials = new List<Material>();
    void Start()
    {
        connectorCollider = this.gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        connectorCollider.enabled = true;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
    private void OnTriggerEnter(Collider other) {
        print("trigger entered");
        clipRenderer = transform.Find("Clip").GetComponent<Renderer>();
        clipRenderer.material = materials[1];
        // childMaterial = rightChild.GetComponent<Material>();
        // childMaterial = materials[1];
    }
}
