using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MobileControl : MonoBehaviour
{
    private piece GetCurrentPiece()
    {
        piece[] pieces = FindObjectsOfType<piece>();
        foreach (piece p in pieces)
        {
            if (p.enabled)
                return p;



           
        }

        return null;
    }




    public void Rotate()
    {
        piece p = GetCurrentPiece();
        if (p != null)
        {
            p.RotatePiece();
        }
    }
    

}






