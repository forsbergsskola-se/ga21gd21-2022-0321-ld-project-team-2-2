using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteAppear : MonoBehaviour
{
 [SerializeField] private Image _NoteImage;

 void OnTriggerEnter(Collider other)
 {
     if (other.CompareTag("Player"))
     {
         _NoteImage.enabled = true;
     }
 }

 void OnTriggerExit(Collider other) 
 {
     if (other.CompareTag("Player"))
     {
         _NoteImage.enabled = false;
     }
 }
 
 
}
