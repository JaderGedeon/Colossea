using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0) {

            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * 10,
                                              0.0f,
                                              Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 10);

        }

        /*
        Camera mycam = GetComponent<Camera>();

        float sensitivity = 0.05f;
        Vector3 vp = mycam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, transform.position.y, mycam.nearClipPlane));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity;
        vp.y *= sensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;
        Vector3 sp = mycam.ViewportToScreenPoint(vp);

        Vector3 v = mycam.ScreenToWorldPoint(sp);
        transform. = (v, Vector3.up);
        */
    }
}
