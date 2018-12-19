using UnityEngine;
using System.IO;
using System.Collections.Generic;


public class JSONInfoManager : MonoBehaviour
{
	[SerializeField]
	string fileName = "test_data.json";

	public List<ScoreValueObject> LoadUSPs()
	{
		string path = "";
		List<ScoreValueObject> result = new List<ScoreValueObject> ();

		#if UNITY_ANDROID
		path = Application.streamingAssetsPath + "/" + fileName;
		#endif

		#if UNITY_IOS
		path = "file://" + Application.dataPath + "/Raw/" + fileName;
		#endif

		#if UNITY_EDITOR
		path = "file://" + Application.streamingAssetsPath + "/" + fileName;
		#endif

		Debug.Log (path);

		WWW wwwfile = new WWW(path);
		while (!wwwfile.isDone) {}  

		Debug.Log(wwwfile.text.Length);

	    ScoreValueObject[] usps = JSONHelper.FromJson <ScoreValueObject> (wwwfile.text);

		for (int i = 0; i < usps.Length; i++) {
			result.Add (usps [i]);
		}

		return result;
	}
}