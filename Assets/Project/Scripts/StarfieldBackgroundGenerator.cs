using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfieldBackgroundGenerator : MonoBehaviour
{
    [System.Serializable]
    public class GeneratorModel
    {
        [SerializeField]
        private int maxNumStars;
        [SerializeField]
        private Transform min3dRange;
        [SerializeField]
        private Transform max3dRange;
        private readonly HashSet<StarfieldObject> starfieldObjects = new HashSet<StarfieldObject>();

        public int MaxNumStars
        {
            get
            {
                return maxNumStars;
            }
        }

        public Vector3 RandomPosition
        {
            get
            {
                return new Vector3(
                    Random.Range(Min3dRange.x, Max3dRange.x)
                    , Random.Range(Min3dRange.y, Max3dRange.y)
                    , Random.Range(Min3dRange.z, Max3dRange.z)
                    );
            }
        }

        public HashSet<StarfieldObject> StarfieldObjects
        {
            get
            {
                return starfieldObjects;
            }
        }

        public Vector3 Min3dRange
        {
            get
            {
                return min3dRange.position;
            }
        }

        public Vector3 Max3dRange
        {
            get
            {
                return max3dRange.position;
            }
        }
    }

    [SerializeField]
    private float maxDelay;
    [SerializeField]
    private StarfieldObject[] allStars;

    [Header("Range")]
    [SerializeField]
    private GeneratorModel background;
    [SerializeField]
    private GeneratorModel foreground;

    public float NextDelay
    {
        get
        {
            return Random.value * maxDelay;
        }
    }

    public Vector3 GetRandomStarPosition(StarfieldObject star)
    {
        if(foreground.StarfieldObjects.Contains(star) == true)
        {
            return foreground.RandomPosition;
        }
        else
        {
            return background.RandomPosition;
        }
    }

    // Use this for initialization
    void Start()
    {
        GenerateStars(background);
    }

    private void GenerateStars(GeneratorModel model)
    {
        int randomIndex;
        GameObject clone;
        StarfieldObject clonedScript;
        for (int index = 0; index < model.MaxNumStars; ++index)
        {
            // Generate a random star
            randomIndex = Random.Range(0, allStars.Length);
            clone = Instantiate<GameObject>(allStars[randomIndex].gameObject);

            // Setup the script
            clonedScript = clone.GetComponent<StarfieldObject>();
            model.StarfieldObjects.Add(clonedScript);
            clonedScript.Setup(this);
        }
    }
}
