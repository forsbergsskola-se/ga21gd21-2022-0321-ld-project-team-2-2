using UnityEngine;
using UnityEngine.UI;
     
public class NoteReader : MonoBehaviour
{
    public GameObject myNoteCanvas;
         
    void Update()
    {
        if (Input.GetButton("E"))
        {
            myNoteCanvas.SetActive(true);
        }
        else
        {
            myNoteCanvas.SetActive(false);
        }
    }
}