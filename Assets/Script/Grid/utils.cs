using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class utils
{
    public static TextMesh CreateWorldText(Transform parent,string text, Vector3 localPosition,int fontSize,Color color,TextAnchor textAnchor)
    {
        GameObject gameObject = new GameObject("World_Text",typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent,false);
        transform.localPosition = localPosition;
        transform.rotation = Quaternion.Euler(90,0,0);
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.text = text;
        return textMesh;
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    
    // 与该平面交于两个点，获取与该平面相交的世界坐标
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 a = worldCamera.ScreenToWorldPoint(screenPosition + new Vector3(0,0,40)); 
        Vector3 b = worldCamera.ScreenToWorldPoint(screenPosition + new Vector3(0,0,50)); 
        Vector3 step = b - a;
        float value = -1 * b.y / step.y;
        b += value * step;
        return b;
    }
    
    // 如果改区块大小这里记得改
    public static void GetBlockXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / 100f);
        y = Mathf.FloorToInt(worldPosition.z / 100f);
    }
}