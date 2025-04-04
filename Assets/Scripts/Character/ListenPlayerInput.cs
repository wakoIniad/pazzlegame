using UnityEngine;
using System.Collections.Generic;

//[RequireComponent(typeof(Rigidbody2D))]
public class ListenPlayerInput : MonoBehaviour
{
    //Rigidbody2D rb;
    public List<CharacterModel> tagetCharacters = new List<CharacterModel>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(0, 0, 0);
        if(Input.GetKeyDown(KeyCode.W)) {
            moveVector.y = 1;
        }
        if(Input.GetKeyDown(KeyCode.A)) {
            moveVector.x = -1;
        }
        if(Input.GetKeyDown(KeyCode.S)) {
            moveVector.y = -1;
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            moveVector.x = 1;
        }
        for(int i = 0;i < tagetCharacters.Count; i++) {
            if(Passable(
                tagetCharacters[i].containerTransform.TransformPoint(
                    tagetCharacters[i].modelTransform.localPosition + moveVector
                )
            )) {
                tagetCharacters[i].modelTransform.localPosition += moveVector;
            }
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("KeyCode.R");
            for(int i = 0;i < tagetCharacters.Count; i++) {
                tagetCharacters[i].containerTransform.Rotate(new Vector3(0,0,90));
            }
        }
        if(Input.GetKeyDown(KeyCode.L)) {
            Debug.Log("KeyCode.L");
            for(int i = 0;i < tagetCharacters.Count; i++) {
                tagetCharacters[i].containerTransform.Rotate(new Vector3(0,0,-90));
            }
        }
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
