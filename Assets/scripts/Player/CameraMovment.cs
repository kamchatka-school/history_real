using UnityEngine;


public class CameraMovment : MonoBehaviour
{
    public Transform target;
    public float speed;
   
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z - 5), speed/* * Time.deltaTime*/);
    }
}