using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conector : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance = 10; // Distancia desde la cámara al objeto
    private bool isDragged = false;
    // private BoxCollider connectorCollider;
    // [SerializeField]Material childMaterial;
    // private Renderer clipRenderer;
    public GameObject[] pegs;

    void Start()
    {
        // connectorCollider = this.gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragged && Input.GetKeyDown(KeyCode.R)){
            Rotate90Degrees();
        }
    }
    private void OnMouseDrag()
    {
        // connectorCollider.enabled = true;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
        isDragged = true;
    }
    private void OnMouseUp()
    {
        if (pegs[0].GetComponent<Peg>().isSnappable && pegs[1].GetComponent<Peg>().isSnappable){
            SnapToNearest();
        }
        isDragged=false;
    }

    private void Rotate90Degrees(){
        transform.Rotate(0, 90, 0);
    }

    private void SnapToNearest()
    {
        Vector3 originalVector = transform.position;
        transform.position = new Vector3(
                                            Mathf.Round(originalVector.x),
                                            Mathf.Round(originalVector.y),
                                            Mathf.Round(originalVector.z)
                                        );
    }
}
