using UnityEngine;
public class Collector : MonoBehaviour
{
    [SerializeField]
    private float interactRange = 5;

    private void Update()
    {
        CheckInteract();
    }
    private void CheckInteract()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactRange))
            {
                ICollectible collectible = hit.collider.GetComponent<ICollectible>();
                if (collectible != null)
                {
                    collectible.Collect();
                }
            }
        }
    }
}
