using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   
    public enum ActionType
    {
        Left,
        Right,
        Down
    }



    public ActionType action;

    private bool holding = false;

    public float moveDelay = 0.1f;

    public float timer;
    
    void Update()
    {
        if (!holding) return;

        timer += Time.deltaTime;

        if (timer < moveDelay)
            return;

        timer = 0f;

        piece p = FindCurrentPiece();

        if (p == null) return;

        switch (action)
        {
            case ActionType.Left:
                p.Move(Vector3.left);
                break;

            case ActionType.Right:
                p.Move(Vector3.right);
                break;

            case ActionType.Down:
                p.Fall();
                break;
        }
    }


    piece FindCurrentPiece()
    {
        piece[] pieces = FindObjectsOfType<piece>();

        foreach (piece p in pieces)
        {
            if (p.enabled)
                return p;
        }


        return null;
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        holding = true;
        timer = 0f;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        holding = false;
        
    }
}
