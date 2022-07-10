using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
 
public class Bird : MonoBehaviour
{
    private Vector3 _initialposition;
    private bool _isBirdLaunced;
    private float _timeSittingAround;
    [SerializeField] private float _launchPower = 250;

    private void Awake(){
        _initialposition = transform.position;
    }

    private void Update(){
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialposition);
        
        if (_isBirdLaunced && GetComponent<Rigidbody2D>().velocity.magnitude <= 0){
            _timeSittingAround += Time.deltaTime;
        }
        if(transform.position.y > 20 || transform.position.y < -20 || transform.position.x > 20 || transform.position.x < -20 ||
            _timeSittingAround > 3){
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }   
    }

    private void OnMouseDown(){
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
    private void OnMouseDrag(){
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = (new Vector3(ray.origin.x, ray.origin.y, 0));
        
    }
    private void OnMouseUp(){
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialposition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _isBirdLaunced = true;
        GetComponent<LineRenderer>().enabled = false;
    }
    
}
