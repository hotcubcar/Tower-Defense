using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public bool panEnabled;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float rotMinX = 0f;
    public float rotMaxX = 69f;

	
	// Update is called once per frame
	void Update () {

        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        //X 0- 75
        //Z 0- -80

        if (transform.position.z < -5 && (Input.GetKey("w") || (Input.mousePosition.y >= Screen.height - panBorderThickness) && panEnabled))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (transform.position.z > -85 && (Input.GetKey("s") || (Input.mousePosition.y <=  panBorderThickness) && panEnabled))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (transform.position.x < 75 && (Input.GetKey("d") || (Input.mousePosition.x >= Screen.width - panBorderThickness) && panEnabled))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (transform.position.x > 0 && (Input.GetKey("a") || (Input.mousePosition.x <=  panBorderThickness) && panEnabled))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        //Vector3 turnRotation = Quaternion.Euler((scroll * 625 * Time.deltaTime), 0f, 0f).eulerAngles;
        transform.Rotate(Vector3.left, scroll * 625 * Time.deltaTime);
        //Debug.Log(transform.rotation);
        transform.rotation = new Quaternion(Mathf.Clamp(transform.rotation.x, 0.2419219f, 0.5664063f), 0f, 0f,transform.rotation.w);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - turnRotation);
        pos.y -= scroll * 200 * scrollSpeed * Time.deltaTime;
        //transform.
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;


        //Debug.Log(pos);

    }
}
