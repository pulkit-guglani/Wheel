using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteWork : MonoBehaviour
{
    public GameObject ballMesh;
    private SpriteShapeController _spriteShapeController;
    private List<GameObject> pointsGameObjects;
    public GameObject childs;

    private GameObject centre;
  //  public GameObject point;
    

    private Vector3[] points;
    // Start is called before the first frame update
    void Start()
    {
        points = new Vector3[ballMesh.transform.childCount];
        pointsGameObjects = new List<GameObject>();
        _spriteShapeController = GetComponent<SpriteShapeController>();
        centre = transform.GetChild(0).gameObject;
        
        
        for (int j = 0; j < ballMesh.transform.childCount; j++)
        {
            points[j] = ballMesh.transform.GetChild(j).position;
        }
        for (int i = 0; i < points.Length; i++)
        {
            // Debug.Log("points : ["+i+"] " + points[i]);
            _spriteShapeController.spline.SetPosition(i,points[i]);
        }

        for (int i = 0; i < points.Length; i++)
        {
            GameObject child = Instantiate(childs,transform.position + points[i],quaternion.identity);
            child.transform.parent = transform;
            pointsGameObjects.Add(child);
        }
        
        
       
        
        int k;
        for (k = 0; k < points.Length -1; k++)
        {
            pointsGameObjects[k].GetComponent<HingeJoint2D>().connectedBody = pointsGameObjects[k+1].GetComponent<Rigidbody2D>();
            pointsGameObjects[k].GetComponent<DistanceJoint2D>().connectedBody = pointsGameObjects[k+1].GetComponent<Rigidbody2D>();
            pointsGameObjects[k].GetComponent<SpringJoint2D>().connectedBody = centre.GetComponent<Rigidbody2D>();
        }
        
        pointsGameObjects[k].GetComponent<DistanceJoint2D>().connectedBody = pointsGameObjects[0].GetComponent<Rigidbody2D>();
        pointsGameObjects[k].GetComponent<SpringJoint2D>().connectedBody = centre.GetComponent<Rigidbody2D>();
        pointsGameObjects[k].GetComponent<HingeJoint2D>().connectedBody = pointsGameObjects[0].GetComponent<Rigidbody2D>();
        



    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
          //  Debug.Log("points : ["+i+"] " + pointsGameObjects[i]);
            _spriteShapeController.spline.SetPosition(i,pointsGameObjects[i].transform.position);
        }
        
        
    }
}
