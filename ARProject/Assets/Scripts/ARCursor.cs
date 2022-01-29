using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;

public class ARCursor : MonoBehaviour
{
    public GameObject cursorChildObject; //spawnedObject
    public GameObject objectToPlace; //PlaceablePrefab
    public ARRaycastManager raycastManager;
    private List<GameObject> placedPrefabList = new List<GameObject>();

    public bool useCursor = true; 

    // [SerializeField]
    // private int maxPrefabSpawnCount = 0;
    // private int placedPrefabCount;

    // Start is called before the first frame update
    // void Awake()
    // {
    //     //raycastManager = GetComponent<ARRaycastManager>();
    // }
 
    void Start()
    {
        cursorChildObject.SetActive(useCursor);
    }

    // Update is called once per frame
    void Update()
    {
        if (useCursor){
            UpdateCursor();
        }

        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began){
            if(useCursor){
                GameObject.Instantiate(objectToPlace, transform.position, transform.rotation);
                // placedPrefabList.Add(cursorChildObject);
                // placedPrefabCount++;
            }
            else{
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                if (hits.Count >0){
                    GameObject.Instantiate(objectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                    //  if(placedPrefabCount < maxPrefabSpawnCount){
                        //  GameObject.Instantiate(objectToPlace, transform.position, transform.rotation);
                        //  placedPrefabList.Add(cursorChildObject);
                        //  placedPrefabCount++;
                    //  }
                }
            }
        }
    }

    void UpdateCursor(){
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if(hits.Count>0){
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }

    // public void SetPrefabType(GameObject prefabType){
    //     objectToPlace = prefabType;
    // }
}
