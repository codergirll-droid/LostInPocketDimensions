using System.Collections.Generic;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    LineRenderer lineRenderer;
    public List<Vector3> points;

    [System.Obsolete]
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        points = new List<Vector3>();


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

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Mirror"))
            {
                Vector3 reflectedDirection = ReflectVector(ray.direction, hit.normal);
                
                points.Add(hit.transform.position);

                Debug.Log("hit to " + hit.transform.gameObject.name);

                LightRay(hit.transform.position, reflectedDirection.normalized);

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

        Debug.Log("drawingRay");
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