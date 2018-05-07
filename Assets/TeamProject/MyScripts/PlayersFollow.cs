using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class PlayersFollow : MonoBehaviour
{

    [SerializeField] private List<GameObject> playerMarkers;

    private float yOffset;
    public Vector3 offset;
    private float smoothSpeed = 0.5f;
    public int playerNumber;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;
    private Camera cam;



    private Vector3 velocity;


    private bool canUpdate = false;

    // Use this for initialization
    void Start()
    {

        cam = GetComponent<Camera>();
    }
    public void RemovePlayer(GameObject player)
    {
        if(playerMarkers.Count>1)
        playerMarkers.Remove(player);
    }
    
    public void AlignCamera(int playerNumber)
    {
        playerMarkers = new List<GameObject>();
        canUpdate = false;
        for (int i = 0; i < playerNumber; i++)
        {
            GameObject bew;
            bew = GameObject.FindGameObjectWithTag("Player" + (i + 1));
            Debug.Log(bew.tag);
            if (bew != null && bew.GetComponent<customCharController>().isDead != true)
            {
                if (!playerMarkers.Contains(bew))
                    playerMarkers.Add(bew);

            }
            Debug.Log(playerNumber + "HEREEEEEEEEEEE");
        }
        this.playerNumber = playerNumber;
        canUpdate = true;
    }
    void Move()
    {
        if (playerMarkers.Count == 0)
            return;
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothSpeed);


    }
    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreateastDistance()/ zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);

    }
    float GetGreateastDistance()
    {
        var bounds = new Bounds(playerMarkers[0].transform.position, Vector3.zero);
        for (int i = 0; i < playerMarkers.Count; i++)
        {
            bounds.Encapsulate(playerMarkers[i].transform.position);
        }
        return bounds.size.x;
    }
    void LateUpdate()
    {
        if (canUpdate)
            {
            Move();
            Zoom();
        }
        


        //if (canUpdate == true)
        //    UpdateCamera(playerNumber);

        //float distance = (playerMarker.position - player2Marker.position).magnitude;
        //Vector3 midpoint = (playerMarker.transform.position + player2Marker.transform.position) / 2;

        //Vector3 desiredPosition = midpoint - transform.forward * distance * 0.5f + offset;
        //Vector3 smothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smothedPosition;

    }

    Vector3 GetCenterPoint()
    {
        if(playerMarkers.Count == 1)
        {
            return playerMarkers[0].transform.position;
        }

        var bounds = new Bounds(playerMarkers[0].transform.position, Vector3.zero);
        for (int i = 0; i < playerMarkers.Count; i++)
        {
            bounds.Encapsulate(playerMarkers[i].transform.position);
        }
        return bounds.center;
    }

    //void UpdateCamera(int playerNumber)
    //{

    //    switch (playerNumber)
    //    {
    //        case 1:

    //            float distance = (playerMarkers[0].transform.position).magnitude;
    //            Vector3 midpoint = (playerMarkers[0].transform.position);

    //            Vector3 desiredPosition = midpoint - transform.forward + offset[0];
    //            Vector3 smothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    //            transform.position = smothedPosition;
    //            break;
    //        case 2:
    //            float distance2 = (playerMarkers[0].transform.position - playerMarkers[1].transform.position).magnitude;
    //            Vector3 midpoint2 = (playerMarkers[0].transform.position + playerMarkers[1].transform.position) / 2;

    //            Vector3 desiredPosition2 = midpoint2 - transform.forward * distance2 * zoom + offset[1];
    //            Vector3 smothedPosition2 = Vector3.Lerp(transform.position, desiredPosition2, smoothSpeed * Time.deltaTime);
    //            transform.position = smothedPosition2;
    //            break;
    //        case 3:
    //            float distance3 = (playerMarkers[0].transform.position - playerMarkers[1].transform.position - playerMarkers[2].transform.position).magnitude;
    //            Vector3 midpoint3 = (playerMarkers[0].transform.position + playerMarkers[1].transform.position + playerMarkers[2].transform.position) / 3;

    //            Vector3 desiredPosition3 = midpoint3 - transform.forward * distance3 * zoom + offset[2];
    //            Vector3 smothedPosition3 = Vector3.Slerp(transform.position, desiredPosition3, smoothSpeed * Time.deltaTime);
    //            transform.position = smothedPosition3;
    //            break;
    //        case 4:
    //            float distance4 = (playerMarkers[0].transform.position - playerMarkers[1].transform.position - playerMarkers[2].transform.position - playerMarkers[3].transform.position).magnitude;
    //            Vector3 midpoint4 = (playerMarkers[0].transform.position + playerMarkers[1].transform.position + playerMarkers[2].transform.position + playerMarkers[3].transform.position) / 4;

    //            Vector3 desiredPosition4 = midpoint4 - (transform.forward * distance4 * zoom + offset[3]);
    //            Vector3 smothedPosition4 = Vector3.Lerp(transform.position, desiredPosition4, smoothSpeed * Time.deltaTime);
    //            transform.position = smothedPosition4;
    //            break;

    //    }

    //}
}
    

