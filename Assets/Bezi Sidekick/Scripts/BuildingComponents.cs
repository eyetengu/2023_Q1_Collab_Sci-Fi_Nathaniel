using UnityEngine;

public class BuildingComponents : MonoBehaviour
{
    // This method instantiates a building prefab at a given position and rotation
    public void CreateBuilding(GameObject buildingPrefab, Vector3 position, Quaternion rotation)
    {
        if(buildingPrefab != null)
        {
            GameObject newBuilding = Instantiate(buildingPrefab, position, rotation);
            newBuilding.name = buildingPrefab.name;
            Debug.Log($"{buildingPrefab.name} has been created at {position}");
        }
        else
        {
            Debug.LogError("Building prefab is null. Please assign a valid prefab.");
        }
    }

    // This method sets the parent of the building game object
    public void SetParent(Transform buildingTransform, Transform parentTransform)
    {
        if(buildingTransform != null && parentTransform != null)
        {
            buildingTransform.SetParent(parentTransform);
            Debug.Log($"{buildingTransform.name} has been set as child of {parentTransform.name}");
        }
        else
        {
            Debug.LogError("Building transform or parent transform is null.");
        }
    }
}