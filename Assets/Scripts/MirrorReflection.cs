using System.Collections.Generic;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    LineRenderer lineRenderer;
    public List<Vector3> points;
    public LayerMask mirrorLayermask;


    public enum LightColor { red, yellow, blue }

    public LightColor lightColor;

    public GameObject winPanel;

    [System.Obsolete]
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        points = new List<Vector3>();

        if(lightColor == LightColor.red)
        {
            lineRenderer.SetColors(Color.red, Color.red);
        }else if(lightColor == LightColor.yellow)
        {
            lineRenderer.SetColors(Color.yellow, Color.yellow);
        }
        else if (lightColor == LightColor.blue)
        {
            lineRenderer.SetColors(Color.blue, Color.blue);
        }

    }



    private void Update()
    {
        ResetLightRay();

        LightRay(transform.position, transform.forward);

    }

    
    void LightRay(Vector3 position, Vector3 direction)
    {
        Ray ray = new Ray(position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, mirrorLayermask))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Mirror"))
            {
                Vector3 reflectedDirection = ReflectVector(ray.direction, hit.normal);
                
                points.Add(hit.point);

                //Debug.Log("hit to " + hit.transform.gameObject.name);

                LightRay(hit.point, reflectedDirection.normalized);

            }
            else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Key"))
            {
                Key key = hit.transform.gameObject.GetComponent<Key>();

                if (key.keyType == Key.KeyType.red && lightColor == LightColor.red)
                {
                    Debug.Log("unlocked the door");
                    winPanel.SetActive(true);
                    Time.timeScale = 0;
                }
                else if (key.keyType == Key.KeyType.yellow && lightColor == LightColor.yellow)
                {
                    Debug.Log("unlocked the door");
                    winPanel.SetActive(true);
                    Time.timeScale = 0;
                }
                else if (key.keyType == Key.KeyType.blue && lightColor == LightColor.blue)
                {
                    Debug.Log("unlocked the door");
                    winPanel.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    Debug.Log("The light is not compatible with the key");
                }

                points.Add(hit.point);
            }
            else
            {
                points.Add(hit.point);

            }

        }
        else
        {
            points.Add(position + direction * 100);

        }

        if(!points.Contains(this.transform.position))
        {
            points.Insert(0, this.transform.position);

        }

        DrawReflectedRay();
    }

    // Reflect a direction vector off a mirror surface
    public Vector3 ReflectVector(Vector3 incident, Vector3 normal)
    {
        return incident - 2 * Vector3.Dot(incident, normal) * normal;
    }

    // Draw the reflected ray using the line drawer component
    void DrawReflectedRay()
    {
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = points.Count;

            for (int i = 0; i < points.Count; i++)
            {
                lineRenderer.SetPosition(i, points[i]);
            }
        }
    }

    void ResetLightRay()
    {
        points.Clear();
        lineRenderer.positionCount = 0;
    }

}