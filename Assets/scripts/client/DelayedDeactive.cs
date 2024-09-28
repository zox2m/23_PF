using UnityEngine;
using System.Collections;

public class DelayedDeactive : MonoBehaviour {

	[SerializeField]
	float delay;


	void OnEnable()
	{
		StopAllCoroutines();
		StartCoroutine(delayed_deactive());
	}


	IEnumerator delayed_deactive()
	{
		yield return new WaitForSeconds(this.delay);
		gameObject.SetActive(false);
	}
}
