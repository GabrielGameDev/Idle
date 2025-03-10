using UnityEngine;

public class MouseView : MonoBehaviour
{
    public float speed = 2.0f;
    float yLimit;
    Transform cam;
    void Start()
    {
        cam = Camera.main.transform;
        yLimit = cam.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.mouseScrollDelta.y;

        cam.Translate(Vector3.up * mouseY * speed * Time.deltaTime);

        if (cam.position.y < yLimit)
        {
            cam.position = new Vector3(cam.position.x, yLimit, cam.position.z);
        }
    }
}
