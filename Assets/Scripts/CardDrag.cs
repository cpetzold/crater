using UnityEngine;

public class CardDrag : MonoBehaviour {
    public float speed;
    public float rotateForce;

    bool dragging = false;
    Vector3 startPos;

    void OnMouseDrag() {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Plane plane = new Plane(Camera.main.transform.forward, this.startPos);

        float distance = 0.0f;
        plane.Raycast(ray, out distance);

        Vector3 dest = ray.GetPoint(distance);

        this.transform.position = Vector3.Lerp(this.transform.position, dest, Time.deltaTime * this.speed);

        Vector3 d = this.transform.position - dest;
        this.transform.localEulerAngles = new Vector3(-d.z * this.rotateForce, d.x * this.rotateForce, 0);
    }

    void OnMouseDown() {
        this.startPos = this.transform.position;
        this.dragging = true;
    }

    void OnMouseUp() {
        this.dragging = false;
    }

    public bool IsDragging() {
        return this.dragging;
    }
}