using UnityEngine;
using System.Collections.Generic;

//[RequireComponent(typeof(Rigidbody2D))]
public class ListenPlayerInput : MonoBehaviour
{
    //Rigidbody2D rb;
    public List<Transform> tagetCharacters = new List<Transform>();
    public CanvasManager canvasManager;
    public Transform PlayerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(Transform charaTransform in tagetCharacters) {
            Vector3 moveVector = new Vector3(0, 0, 0);
            
            if(Input.GetKeyDown(KeyCode.W)) {
                moveVector = charaTransform.up;
            }
            if(Input.GetKeyDown(KeyCode.A)) {
                moveVector = -charaTransform.right;
            }
            if(Input.GetKeyDown(KeyCode.S)) {
                moveVector = -charaTransform.up;
            }
            if(Input.GetKeyDown(KeyCode.D)) {
                moveVector = charaTransform.right;
            }
            if(Passable(
                charaTransform.position + moveVector
            )) {
                charaTransform.position += moveVector;
                if(ThereIsDoppelganger()) {
                    Debug.Log("game over...");
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("KeyCode.R");
            foreach(Transform charaTransform in tagetCharacters) {
                charaTransform.Rotate(new Vector3(0,0,90));
            }
        }
        if(Input.GetKeyDown(KeyCode.L)) {
            Debug.Log("KeyCode.L");
            foreach(Transform charaTransform in tagetCharacters) {
                charaTransform.Rotate(new Vector3(0,0,-90));
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision Enter!!");
        if(collider.gameObject.CompareTag("Doppelganger")) {
            Debug.Log("GameOver!!");
        }
    }
    bool ThereIsDoppelganger() {
        Vector3 boxSize = new Vector3(1f, 1f, 1f)/2;  // ボックスのサイズ(半サイズを指定するため0.5にする！)
        Collider2D collider = Physics2D.OverlapBox(PlayerTransform.position, boxSize, 0f);
        if(collider && collider.gameObject.CompareTag("Doppelganger")) {
            return true;
        }
        return false;
    }
    bool Passable(Vector3 pos) {
        Vector3 boxSize = new Vector3(1f, 1f, 1f)/2;  // ボックスのサイズ(半サイズを指定するため0.5にする！)
        Collider2D collider = Physics2D.OverlapBox(pos, boxSize, 0f);
        if(collider) {
            if(collider.gameObject.CompareTag("Block")) {
                return false;
            }
        }
        return true;
    }
    void OnDrawGizmos() {
        //Gizmos.color = Color.red;
        //Vector3 boxSize = new Vector3(0.5f, 0.5f, 0.5f);
        //Gizmos.DrawWireCube(center, boxSize * 2f);
    }
}
