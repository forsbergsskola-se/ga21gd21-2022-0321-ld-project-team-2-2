using UnityEngine;
using System.Collections;
 
public class PressEToRead : MonoBehaviour {
 
    public GameObject Player;
    public float minDist = 5f;
    public string text = "Twin Temple Step inside and leave behind all that is not true. Let the waters of Ain cleansel. Release thy memory and pain. Behemoth and his sharp blade. Savior and her grace Stand and await the judgment of uprising or decay. Step inside and accept thy fate.";
    float dist;
    bool reading = false;
 
    void Update () {
        dist = Vector3.Distance(Player.gameObject.transform.position, gameObject.transform.position);
        if (dist <= minDist) {
            if(Input.GetKeyDown(KeyCode.E)) {
                if(reading) {
                    reading = false;
                }
                else {
                    reading = true;
                }
            }
        }
        else {
            reading = false;
        }
    }
 
    void OnGUI() {
        if(reading) {
            GUI.TextArea(new Rect(Screen.height/2, Screen.width/2, 500, 500), text);
        }
        else if(dist <= minDist) {
            GUI.TextArea(new Rect(Screen.height/2, Screen.width/2, 500, 500), "Press 'E' to read.");
        }
    }
}