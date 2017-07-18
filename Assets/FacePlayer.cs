using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour
{
    [SerializeField] Camera m_playerCam;
    [SerializeField]
    float m_speed = 0; 
 
    private void FixedUpdate()
    {
        Quaternion q = Quaternion.Lerp(transform.localRotation, m_playerCam.transform.localRotation, Time.deltaTime * m_speed);
        transform.localRotation = new Quaternion(0,q.y,0,q.w);
    }
}
