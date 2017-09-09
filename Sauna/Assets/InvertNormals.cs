using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertNormals : MonoBehaviour {

	public Transform parent;
	List<Mesh> meshes = new List<Mesh>();

	void Start () {
		var c = parent.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter mf in c) {
			meshes.Add(mf.mesh);
			var g = new GameObject(mf.name + " Inverted");
			g.AddComponent<MeshFilter>();
			g.AddComponent<MeshRenderer>();
			InvertedNormals(mf.mesh.vertices, mf.mesh.normals, mf.transform);
		}
	}

	// DEBUG ATM
	Mesh InvertedNormals (Vector3[] verts, Vector3[] normals, Transform t) {
		for (int i = 0; i < verts.Length; i++) {
			var v = verts[i];
			v += t.position;
			v *= t.localScale.x;
			
			// Scaling
			//v.x *= t.localScale.x; v.y *= t.localScale.y; v.z *= t.localScale.z;
			Debug.DrawRay(v, normals[i], Color.red, Mathf.Infinity);
		}
		return null;
	}
}
