using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class AdvancedMultiStreamProceduralMesh : MonoBehaviour
{
    private static int vertexAttributeCount = 4;
    private int vertexCount = 4;
    
    private static Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(1);
    private Mesh.MeshData meshData = meshDataArray[0];

    private NativeArray<VertexAttributeDescriptor> vertexAttributes = new NativeArray<VertexAttributeDescriptor>(
        vertexAttributeCount, Allocator.Temp
    );
    
    
    void OnEnable () {
        
        meshData.SetVertexBufferParams(vertexCount, vertexAttributes); 
        vertexAttributes.Dispose();
        
        var mesh = new Mesh {
            name = "Procedural Mesh"
        };
        
        Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);
        
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
