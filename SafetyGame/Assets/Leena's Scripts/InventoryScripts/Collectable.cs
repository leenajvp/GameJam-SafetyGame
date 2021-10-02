using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    public Sprite image = null;
    public Sprite Image
    {
        get
        {
            return image;
        }
    }

    public void Collect()
    {
        gameObject.SetActive(false);
    }

    public void Drop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }
}
