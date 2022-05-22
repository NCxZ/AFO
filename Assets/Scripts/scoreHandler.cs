using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreHandler : MonoBehaviour
{
    public TextMesh textmesh;
    public void setScore(int num)
    {
        textmesh.text = num.ToString();
    }
    public void incrementScore()
    {
        textmesh.text = (int.Parse(textmesh.text) + 1).ToString() ;
    }
}
