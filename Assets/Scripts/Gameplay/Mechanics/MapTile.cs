using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;
    private Vector2 position;

    private bool occupied;

    private void OnMouseEnter() {
        highlight.SetActive(true);
    }

    private void OnMouseExit() {
        highlight.SetActive(false);
    }

    public bool isOccupied() {
        return occupied;
    }

    public void setOccupied(bool occupied) {
        this.occupied = occupied;
    }

    public void setPosition(Vector2 pos) {
        this.position = pos;
    }

    public Vector2 getPosition() {
        return this.position;
    }
}
