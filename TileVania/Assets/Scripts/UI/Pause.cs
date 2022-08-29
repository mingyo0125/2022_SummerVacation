using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pause : MonoBehaviour
{     
bool IsPause;
public GameObject Pop;
public GameObject Back;
public GameObject Sound;
// Use this for initialization    
void Start ()
{
       IsPause = false;    
}        
// Update is called once per frame    

void Update ()
{        
if (Input.GetKeyDown(KeyCode.Escape))        
{
    Instantiate(Sound);
            /*일시정지 활성화*/           
if (IsPause == false)            
{ 
    Pop.gameObject.SetActive(true);
    Back.gameObject.SetActive(true);
               Time.timeScale = 0;    
            IsPause = true;             
   return;           
 }          
   /*일시정지 비활성화*/   
if (IsPause == true)        
{    
    Pop.gameObject.SetActive(false);
    Back.gameObject.SetActive(false);
           Time.timeScale = 1;        
        IsPause = false;   
             return;          
  }    
    }  
 }}
