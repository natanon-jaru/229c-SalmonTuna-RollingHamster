using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
   [SerializeField] Rigidbody2D rb;
   [SerializeField] Transform PlayerPoint;
   [SerializeField] GameObject target;
   [SerializeField] GameObject cursor;

    public static bool hasJumped = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        restartroom();
        menu();
        
        if (!hasJumped &&Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction*10f, Color.magenta, 10f );

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                
                Vector2 newdir = new Vector2(hit.point.x, hit.point.y);
                Instantiate(cursor, newdir,Quaternion.identity);
                
                //Debug.Log($"hit point : {hit.point.x}, {hit.point.y}");
                
                Vector2 move = CalculateProjectileVelocity(PlayerPoint.position, target.transform.position, 1f);
                rb.velocity = move;
                
                // prevent double jumping
                hasJumped = true;
            }

        }

    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t) 
    {
        Vector2 distance = target - origin; 
        float velocityX = distance.x / t;
        float velocityY = distance.y / t + 0.5f * Mathf.Abs (Physics2D.gravity.y); 

        Vector2 result = new Vector2(velocityX, velocityY); 
        return result; 
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
            
        }
        if (collision.gameObject.CompareTag("DeathGround"))
        {
            SceneManager.LoadScene("Gameplay");
        }
        
        if (collision.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("Win");
        }
    }

    void restartroom()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    void menu()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    
}
