using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionoffest;

    private Renderer rend;
    private Color startColor;

    private GameObject turret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown() 
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! TODO: Display on screen.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        if (turretToBuild == null)
        {
            Debug.Log("No turret prefab selected!");
            return;
        }

        turret = Instantiate(turretToBuild, transform.position + positionoffest, Quaternion.identity);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
