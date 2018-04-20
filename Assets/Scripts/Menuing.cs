using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menuing : MonoBehaviour {
	public void LoadByIndex(){
		var next = Random.Range (1,3);
		SceneManager.LoadScene (next);
	}

}
