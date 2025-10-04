using UnityEngine;

public class Bowl : MonoBehaviour
{
    public GameManager gameManager;  
    public Renderer bowlRenderer;    

    void Start()
    {
        if (bowlRenderer == null)
            bowlRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Renderer ballRenderer = other.gameObject.GetComponent<Renderer>();
            if (ballRenderer != null)
            {
                Color ballColor = ballRenderer.material.color;
                Color bowlColor = bowlRenderer.material.color;

               
                if (Vector3.Distance(new Vector3(ballColor.r, ballColor.g, ballColor.b),
                                     new Vector3(bowlColor.r, bowlColor.g, bowlColor.b)) < 0.05f)
                {
                    gameManager.AddScore(1); 
                }

                Destroy(other.gameObject); 
            }
        }
    }
}
