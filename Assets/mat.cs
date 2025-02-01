using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class mat : MonoBehaviour
{
    Texture2D texture = null;//创建一个空的Texture2D

	void createMat () {
        //创建一个材质名字叫做mat
		Material mat =new Material(Shader.Find("Transparent/Diffuse"));
        //把我们的项目中的图片赋值给我们创建的空的Texture2D
        texture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/imgs/img.jpg",typeof(Texture2D));
        //把已经有图片的Texture2D赋给我们的一步创建的材质材质
        mat.mainTexture = texture;
        //mat.color = new Color(0,0,1,1);//这个可以更改他的颜色，要把上面那句注释掉
		AssetDatabase.CreateAsset(mat,"Assets/mat.mat");
		//找到我们创建的cube
		GameObject cube1 = (GameObject)GameObject.Find("Cube");
		//把我们的材质赋给cube工作结束看效果吧！很霸气的代码啊！
		cube1.GetComponent<Renderer>().material = mat;
	}

    void loadMat()
    {
        Material mat = (Material)AssetDatabase.LoadAssetAtPath("Assets/metial/MyMaterial.mat",typeof(Material));
		GameObject cube = GameObject.Find("Cube");
		cube.GetComponent<Renderer>().material=mat;
    }
}
