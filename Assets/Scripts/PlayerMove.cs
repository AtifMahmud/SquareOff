using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject visualMarker;
    public float maxSidewaysMovement;
    public float maxForwardMovement;
    public Material validMaterial;
    public Material invalidMaterial;
    public Material defaultMaterial;

    private bool dragging = true;
    private Vector3 currentPositionVector;
    private Vector3 targetPositionVector;
    private bool isValidMove = false;

    private void Start()
    {
        currentPositionVector = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (!GameManager.Instance.isPlayerSelected && Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    visualMarker.SetActive(true);
                    dragging = true;
                    GameManager.Instance.isPlayerSelected = true;
                    GameManager.Instance.currentSelected = this.gameObject;
                }
            }
        }
        else
        {
            dragging = false;
            visualMarker.SetActive(false);
            GameManager.Instance.isPlayerSelected = false;
            GameManager.Instance.currentSelected = null;
            visualMarker.GetComponent<MeshRenderer>().material = defaultMaterial;

            if (isValidMove)
            {
                this.gameObject.transform.position = targetPositionVector;
                currentPositionVector = this.gameObject.transform.position;
            }
        }

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Square"))
                {
                    targetPositionVector = hit.collider.transform.position;
                    if ((Mathf.Abs(targetPositionVector.z - currentPositionVector.z) <= (maxForwardMovement + 0.5 * maxForwardMovement))
                        && (Mathf.Abs(targetPositionVector.x - currentPositionVector.x) <= (maxSidewaysMovement + 0.5 * maxSidewaysMovement)))
                    {
                        visualMarker.GetComponent<MeshRenderer>().material = validMaterial;
                        isValidMove = true;
                    }
                    else
                    {
                        visualMarker.GetComponent<MeshRenderer>().material = invalidMaterial;
                        isValidMove = false;
                    }
                }
            }

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            visualMarker.transform.position = new Vector3(worldPosition.x, 1.01f, worldPosition.z);
        }
    }
}
