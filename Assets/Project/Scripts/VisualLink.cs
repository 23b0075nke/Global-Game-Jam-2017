using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Node
{
    [RequireComponent(typeof(LineRenderer))]
    public class VisualLink : MonoBehaviour
    {
        [SerializeField]
        private SubNode leftNode;
        [SerializeField]
        private SubNode rightNode;
        [SerializeField]
        private ParticleSystem leftParticleSystem;
        [SerializeField]
        private ParticleSystem rightParticleSystem;

        private LineRenderer line;
        private Vector3 center;
        private static readonly Dictionary<SubNode, HashSet<SubNode>> connectedNodes = new Dictionary<SubNode, HashSet<SubNode>>();

        public SubNode LeftNode
        {
            get
            {
                return leftNode;
            }
        }

        public SubNode RightNode
        {
            get
            {
                return rightNode;
            }
        }

        public static VisualLink CreateLink(VisualLink prefab, SubNode left, SubNode right, bool emitParticles = true)
        {
            // Check if the left has any connections
            VisualLink newLink = null;
            if (AddOneWayConnection(left, right) == true)
            {
                // Add another connection in reverse direction, to create 2 way direction
                AddOneWayConnection(right, left);

                // Initialize the link
                GameObject clone = Instantiate(prefab.gameObject, left.transform.parent);
                clone.transform.localPosition = Vector3.zero;
                clone.transform.localRotation = Quaternion.identity;
                clone.transform.localScale = Vector3.one;

                // Set the link member variables
                newLink = clone.GetComponent<VisualLink>();
                newLink.leftNode = left;
                newLink.rightNode = right;

                if(emitParticles == true)
                {
                    newLink.leftParticleSystem.Play();
                    newLink.rightParticleSystem.Play();
                }
            }
            return newLink;
        }

        private static bool AddOneWayConnection(SubNode left, SubNode right)
        {
            bool returnFlag = false;
            HashSet<SubNode> leftConnections;
            if (connectedNodes.TryGetValue(left, out leftConnections) == false)
            {
                // If left key is not created, create a hash set containing right
                leftConnections = new HashSet<SubNode>();
                leftConnections.Add(right);

                // Add this hash set into the dictionary, with left as key
                connectedNodes.Add(left, leftConnections);
                returnFlag = true;
            }
            else if (leftConnections.Contains(right) == false)
            {
                // If a connection hash set is already there, but doesn't contain right, add right
                leftConnections.Add(right);
                returnFlag = true;
            }
            return returnFlag;
        }

        private void Start()
        {
            line = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if((LeftNode != null) && (RightNode != null))
            {
                line.enabled = true;
                line.SetPosition(0, LeftNode.transform.position);
                leftParticleSystem.transform.position = LeftNode.transform.position;
                line.SetPosition(2, RightNode.transform.position);
                rightParticleSystem.transform.position = RightNode.transform.position;

                center = (LeftNode.transform.position + RightNode.transform.position) / 2f;
                line.SetPosition(1, center);
            }
            else
            {
                line.enabled = false;
            }
        }
    }
}