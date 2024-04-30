using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    public CapsuleCollider pegCollider;
    public bool isSnappable;
    private Renderer pegRenderer;
    [SerializeField] List<Material> materials = new List<Material>();

    void Start()
    {
        pegCollider = gameObject.GetComponent<CapsuleCollider>();
        pegRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        print($"trigger entered on {this.name}");

        
        pegRenderer.material = materials[1];
        isSnappable = true;
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Peg"){
            pegRenderer.material = materials[0];
            
        }
        isSnappable = false;
    }
}
