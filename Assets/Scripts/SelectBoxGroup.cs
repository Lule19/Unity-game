using UnityEngine;

public class SelectBoxGroup : MonoBehaviour
{
    public Transform boxGroup;          
    public float followDistance = 2f;
    public BallSpawner ballSpawner;      

    private bool isSelected = false;

    void Update()
    {
        
        if (isSelected)
        {
            boxGroup.position = Camera.main.transform.position + Camera.main.transform.forward * followDistance;
            boxGroup.rotation = Camera.main.transform.rotation;
        }

       
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (IsChildOrSelf(hit.transform, boxGroup))
                {
                    isSelected = !isSelected;
                    Debug.Log("BoxGroup toggled: " + isSelected);

                   
                    if (ballSpawner != null)
                        ballSpawner.SetSpawning(isSelected);
                }
            }
        }
    }

    private bool IsChildOrSelf(Transform child, Transform parent)
    {
        Transform current = child;
        while (current != null)
        {
            if (current == parent)
                return true;
            current = current.parent;
        }
        return false;
    }
}
